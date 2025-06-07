Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Globalization
Imports System.Net

Public Class Confirmar
    Private Sub Confirmar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Validar que el nombre del proyecto esté definido
        If String.IsNullOrEmpty(IdentifyProject) Then
            MsgBox("El nombre del proyecto actual no está definido.", MsgBoxStyle.Critical, "Error de configuración")
            Exit Sub
        End If

        ' Construcción de la URL del proyecto
        Dim firebaseUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/{IdentifyProject}/Confirmar.json"

        Try
            Dim client As New WebClient()
            client.Headers.Add("Content-Type", "application/json")

            Dim response As String = client.DownloadString(firebaseUrl)

            ' Verificar si la respuesta no es JSON
            If response.Trim().StartsWith("<") Then
                MsgBox("La respuesta no es válida (HTML recibido en lugar de JSON). Verifica la URL y los datos en Firebase.", MsgBoxStyle.Critical, "Error de datos")
                Exit Sub
            End If

            If String.IsNullOrEmpty(response) OrElse response = "null" Then
                dgvConfirmar.Rows.Clear()
                dgvConfirmar.Columns.Clear()
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' Deserializar JSON
            Dim ConfirmarRaw As Dictionary(Of String, JObject) = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(response)

            If ConfirmarRaw Is Nothing OrElse ConfirmarRaw.Count = 0 Then
                dgvConfirmar.Rows.Clear()
                dgvConfirmar.Columns.Clear()
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' LIMPIEZA (primero columnas, luego filas)
            dgvConfirmar.Columns.Clear()
            dgvConfirmar.Rows.Clear()

            ' Estilo (si quieres mantenerlo aquí)
            ConfigurarEstiloDataGridView()

            ' Agregar columnas
            dgvConfirmar.Columns.Add("ID", "ID de Solicitud")
            dgvConfirmar.Columns.Add("Materiales", "Materiales")
            dgvConfirmar.Columns.Add("Fecha", "Fecha de Ingreso")
            dgvConfirmar.Columns.Add("Estado", "Estado")

            dgvConfirmar.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvConfirmar.Columns("Materiales").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvConfirmar.Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells



            Dim contador As Integer = 1

            ' Rellenar el DataGridView
            For Each solicitud In ConfirmarRaw
                Dim solicitudID As String = solicitud.Key ' Con esto obtengo el ID de la solicitud
                Dim solicitudDatos As JObject = solicitud.Value ' Con esto obtengo todos los datos de la solicitud

                Dim Columna As New List(Of String) ' en esta lista van los datos de la solicitud
                For Each propiedad In solicitudDatos.Properties()

                    Columna.Add(propiedad.Value)

                Next
                Dim Estado As String = Columna(0).ToString()
                Dim Fecha As String = Columna(1).ToString()
                Dim Materiales As String = Columna(2).ToString()
                dgvConfirmar.Rows.Add(solicitudID, Materiales, Fecha, Estado)


            Next

        Catch ex As Exception
            MsgBox("Error al obtener los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If dgvConfirmar.Rows.Count = 0 Then
            MsgBox("No hay datos para enviar.", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If

        If dgvConfirmar.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione una solicitud.", MsgBoxStyle.Information, "Información")
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvConfirmar.SelectedRows(0)
        Dim solicitudID As String = row.Cells("ID").Value.ToString()

        Dim firebaseInventarioUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Inventario.json"
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Confirmar/" & solicitudID & ".json"

        Try
            Dim client As New WebClient()
            Dim inventarioResponse As String = client.DownloadString(firebaseInventarioUrl)
            Dim inventarioData As New Dictionary(Of String, JObject)

            If Not String.IsNullOrEmpty(inventarioResponse) AndAlso inventarioResponse <> "null" Then
                inventarioData = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(inventarioResponse)
            End If

            Dim materiales As String = row.Cells("Materiales").Value.ToString()
            Dim Texto() As String = materiales.Split(",")

            For Each palabra In Texto
                Dim Material() As String = palabra.Trim().Split(" ")
                If Material.Length < 4 Then Continue For

                Dim Nombre As String = Material(0).ToUpper()
                Dim medida As String = Material(1).ToUpper()
                Dim CantidadStr As String = Material(2).Trim().Replace(",", ".") ' Reemplazar coma por punto
                Dim unidad As String = Material(3).ToUpper()

                Dim nombreMedida As String = (Nombre & " " & medida).Trim()

                ' Intentar convertir la cantidad a Double, usando CultureInfo para manejar coma o punto
                Dim CantidadDouble As Double
                If Not Double.TryParse(CantidadStr, NumberStyles.Any, CultureInfo.InvariantCulture, CantidadDouble) Then
                    MsgBox("Cantidad inválida para " & nombreMedida & ": """ & CantidadStr & """", MsgBoxStyle.Critical, "Error de datos")
                    Continue For
                End If

                Dim materialEncontrado As Boolean = False
                For Each item In inventarioData
                    Dim datosMaterial As JObject = item.Value
                    If datosMaterial("material").ToString().ToUpper() = nombreMedida AndAlso
                   datosMaterial("unidad").ToString().ToUpper() = unidad Then

                        Dim cantidadExistente As Double = Double.Parse(datosMaterial("cantidad").ToString(), CultureInfo.InvariantCulture)
                        datosMaterial("cantidad") = (cantidadExistente + CantidadDouble).ToString()
                        datosMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                        materialEncontrado = True
                        Exit For
                    End If
                Next

                If Not materialEncontrado Then
                    Dim nuevoMaterial As New JObject()
                    nuevoMaterial("material") = nombreMedida
                    nuevoMaterial("cantidad") = CantidadDouble.ToString(CultureInfo.InvariantCulture)
                    nuevoMaterial("unidad") = unidad
                    nuevoMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

                    Dim claveMaterial As String = (Nombre & medida).Replace(" ", "").ToUpper() & "_0001"
                    inventarioData(claveMaterial) = nuevoMaterial
                End If
            Next

            Dim updateJson As String = JsonConvert.SerializeObject(inventarioData)
            For Each item In inventarioData
                Dim materialKey As String = item.Key
                Dim materialUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Inventario/" & materialKey & ".json"
                Dim materialJson As String = JsonConvert.SerializeObject(item.Value)
                client.UploadString(materialUrl, "PUT", materialJson)
            Next
            client.UploadString(firebaseComprasUrl, "DELETE", String.Empty)

            MsgBox("Inventario actualizado correctamente.", MsgBoxStyle.Information, "Mensaje de confirmación")

        Catch ex As Exception
            MsgBox("Error al actualizar el inventario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Dim men As New Menú()
        Me.Close()
        men.Show()
    End Sub

    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With dgvConfirmar
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
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' Ajustar tamaño de columnas automáticamente
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

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
End Class