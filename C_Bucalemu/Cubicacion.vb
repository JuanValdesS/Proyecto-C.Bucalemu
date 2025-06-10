Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports FireSharp.Exceptions
Imports Newtonsoft.Json
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class Cubicacion

    Dim client As IFirebaseClient

    Private Sub Cubicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBarCarga.Visible = False
        lblEstadoCarga.Visible = False
    End Sub
    Private Sub btnCargarArchivo_Click(sender As Object, e As EventArgs) Handles btnCargarArchivo.Click
        OpenFileDialog1.Filter = "CSV Files (*.csv)|*.csv"
        OpenFileDialog1.Title = "Selecciona un archivo CSV"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim rutaArchivo As String = OpenFileDialog1.FileName
            LeerArchivoCSV(rutaArchivo)
        End If
    End Sub

    Private Sub LeerArchivoCSV(ruta As String)
        dgvMateriales.Rows.Clear()
        dgvMateriales.Columns.Clear()

        Using lector As New IO.StreamReader(ruta)
            ' Leer primera línea para detectar separador
            Dim primeraLineaTexto As String = lector.ReadLine()
            If primeraLineaTexto Is Nothing Then Exit Sub

            Dim separador As Char = If(primeraLineaTexto.Contains(";"), ";"c, ","c)

            ' Agregar columnas
            dgvMateriales.Columns.Add("Descripcion", "Descripción")
            dgvMateriales.Columns.Add("Unidad", "Unidad")
            dgvMateriales.Columns.Add("Cantidad", "Cantidad")

            ' Aplicar estilo
            ConfigurarEstiloDataGridView()

            dgvMateriales.Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvMateriales.Columns("Unidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            ' Leer el resto del archivo
            While Not lector.EndOfStream
                Dim linea As String = lector.ReadLine()?.Trim()

                ' Ignorar líneas vacías
                If String.IsNullOrWhiteSpace(linea) Then Continue While

                Dim campos() As String = linea.Split(separador)

                ' Verificar que haya al menos 3 campos
                If campos.Length >= 3 Then
                    Dim descripcion As String = LimpiarCampo(campos(0))
                    Dim unidad As String = LimpiarCampo(campos(1))
                    Dim cantidad As String = LimpiarCampo(campos(2))

                    ' Agregar solo si unidad y cantidad no están vacíos
                    If Not String.IsNullOrWhiteSpace(unidad) AndAlso Not String.IsNullOrWhiteSpace(cantidad) Then
                        dgvMateriales.Rows.Add(descripcion, unidad, cantidad)
                    End If
                End If
            End While
        End Using
    End Sub

    ' Limpia un campo eliminando comillas externas y dobles
    Private Function LimpiarCampo(texto As String) As String
        If texto.StartsWith("""") AndAlso texto.EndsWith("""") Then
            texto = texto.Substring(1, texto.Length - 2) ' Quita comillas externas
        End If
        texto = texto.Replace("""""", """") ' Reemplaza comillas dobles por una
        Return texto.Trim()
    End Function


    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With dgvMateriales
            ' Establecer el color de fondo y alternar filas en gris claro
            .BackgroundColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

            ' Cambiar el color de los encabezados de columna
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

            ' Borde de celda y alineación
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Ajustar tamaño de columnas automáticamente
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Deshabilitar la edición de celdas
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True

            ' Cambiar estilo del grid
            .BorderStyle = BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub btn_ingresarMateriales_Click(sender As Object, e As EventArgs) Handles btn_ingresarMateriales.Click

        If dgvMateriales.Rows.Count = 0 Then
            MsgBox("No hay materiales para enviar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim firebaseUrlBase As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Compras"

        ' Inicializar barra de progreso
        ProgressBarCarga.Value = 0
        ProgressBarCarga.Maximum = dgvMateriales.Rows.Cast(Of DataGridViewRow).Count(Function(r) Not r.IsNewRow)
        ProgressBarCarga.Visible = True
        lblEstadoCarga.Visible = True
        lblEstadoCarga.Text = "Enviando solicitudes..."

        Try
            Dim client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"

            ' Obtener último número de solicitud
            Dim response As String = client.DownloadString(firebaseUrlBase & ".json")
            Dim solicitudIdActual As Integer = 1

            If Not String.IsNullOrWhiteSpace(response) AndAlso response.Trim() <> "null" Then
                Dim solicitudesExistentes As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
                Dim numerosExistentes = solicitudesExistentes.Keys.Where(Function(k) k.StartsWith("Solicitud_")).Select(Function(k) Integer.Parse(k.Replace("Solicitud_", ""))).ToList()
                If numerosExistentes.Count > 0 Then
                    solicitudIdActual = numerosExistentes.Max() + 1
                End If
            End If

            ' Crear una solicitud por cada material
            For Each row As DataGridViewRow In dgvMateriales.Rows
                If Not row.IsNewRow Then
                    Dim solicitudNombre As String = "Solicitud_" & solicitudIdActual

                    Dim compra As New Dictionary(Of String, Object) From {
                    {"ID", Guid.NewGuid().ToString()},
                    {"Material", row.Cells("Descripcion").Value},
                    {"Cantidad", row.Cells("Cantidad").Value},
                    {"Unidad", row.Cells("Unidad").Value},
                    {"Fecha", DateTime.Now.ToString("dd-MM-yyyy")}
                    }

                    Dim jsonProducto As String = JsonConvert.SerializeObject(compra)
                    client.UploadString($"{firebaseUrlBase}/{solicitudNombre}/0.json", "PUT", jsonProducto)

                    ' Agregar estado individual
                    Dim estadoGeneral As String = """En Proceso"""
                    client.UploadString($"{firebaseUrlBase}/{solicitudNombre}/Estado.json", "PUT", estadoGeneral)

                    ' Avanzar contador
                    solicitudIdActual += 1
                    ProgressBarCarga.Value += 1
                    lblEstadoCarga.Text = $"Enviando solicitud {solicitudIdActual - 1}..."
                    Application.DoEvents()
                End If
            Next

            MsgBox("Materiales enviados correctamente como solicitudes individuales.", MsgBoxStyle.Information, "Éxito")
            dgvMateriales.Rows.Clear()

        Catch ex As Exception
            MsgBox("Error al enviar solicitudes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            ProgressBarCarga.Value = 0
            ProgressBarCarga.Visible = False
            lblEstadoCarga.Text = ""
            lblEstadoCarga.Visible = False
        End Try

    End Sub
    ' Ejemplo de cómo inicializas el cliente (debes tener algo similar en tu código)
    Private Sub InicializarFirebase()
        Dim fcon As New FireSharp.Config.FirebaseConfig() With {
            .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
            .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
        }
        client = New FireSharp.FirebaseClient(fcon)
    End Sub
    Private Sub btn_regresar_Click(sender As Object, e As EventArgs) Handles btn_regresar.Click
        Dim menu As New Menú
        Close()
        menu.Show()
    End Sub

End Class