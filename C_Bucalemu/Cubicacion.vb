Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports FireSharp.Exceptions
Imports Newtonsoft.Json
Imports System.Globalization


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
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            ' Deshabilitar la edición de celdas
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False

            ' Cambiar estilo del grid
            .BorderStyle = BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub btn_ingresarMateriales_Click(sender As Object, e As EventArgs) Handles btn_ingresarMateriales.Click

        InicializarFirebase()

        If String.IsNullOrWhiteSpace(IdentifyProject) Then
            MsgBox("El proyecto no ha sido identificado.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Try
            If dgvMateriales.Rows.Count = 0 Then
                MsgBox("No hay materiales para ingresar.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ProgressBarCarga.Value = 0
            ProgressBarCarga.Visible = True
            lblEstadoCarga.Text = "Cargando materiales al inventario..."
            lblEstadoCarga.Visible = True

            Dim totalMateriales As Integer = dgvMateriales.Rows.Count - 1 ' Ignorar la última fila nueva
            Dim contador As Integer = 0

            For Each fila As DataGridViewRow In dgvMateriales.Rows
                ' Saltar la fila nueva (vacía al final)
                If fila.IsNewRow OrElse fila.Cells.Count < 3 Then Continue For

                ' Validar que las celdas existen y no son Nothing
                Dim descripcion As String = If(fila.Cells(0)?.Value IsNot Nothing, fila.Cells(0).Value.ToString().Trim(), "")
                Dim unidad As String = If(fila.Cells(1)?.Value IsNot Nothing, fila.Cells(1).Value.ToString().Trim(), "")
                Dim cantidad As String = If(fila.Cells(2)?.Value IsNot Nothing, fila.Cells(2).Value.ToString().Trim(), "")

                ' Verificar que todos los campos tengan valor
                If String.IsNullOrWhiteSpace(descripcion) OrElse
           String.IsNullOrWhiteSpace(unidad) OrElse
           String.IsNullOrWhiteSpace(cantidad) Then
                    Continue For
                End If

                Dim fechaIngreso As String = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

                Dim nuevoMaterial As New Dictionary(Of String, Object) From {
            {"material", descripcion},
            {"cantidad", cantidad},
            {"fecha", fechaIngreso},
            {"unidad", unidad}
            }

                If client IsNot Nothing Then
                    Dim pushResponse = client.Push("Proyectos/" & IdentifyProject & "/Inventario/", nuevoMaterial)
                Else
                    MsgBox("La conexión con Firebase no está disponible.", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                contador += 1
                ProgressBarCarga.Value = Math.Min(100, CInt((contador / totalMateriales) * 100))
                Application.DoEvents()
            Next

            lblEstadoCarga.Text = "Carga completada exitosamente."
            MsgBox("Materiales cargados exitosamente al inventario.", MsgBoxStyle.Information, "Éxito")
        Catch ex As Exception
            MsgBox("Error al cargar materiales al inventario: " & ex.Message, MsgBoxStyle.Critical, "Error")
            lblEstadoCarga.Text = "Error al cargar los materiales."
        Finally
            ProgressBarCarga.Visible = False
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