Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
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
        ' Validar si hay filas en el DataGridView
        If dgvConfirmar.Rows.Count = 0 Then
            MsgBox("No hay datos para enviar.", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If

        ' Validar si el usuario seleccionó una fila
        If dgvConfirmar.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione una solicitud.", MsgBoxStyle.Information, "Información")
            Exit Sub
        End If

        ' Obtener la fila seleccionada y el ID de la solicitud
        Dim row As DataGridViewRow = dgvConfirmar.SelectedRows(0)
        Dim solicitudID As String = row.Cells("ID").Value.ToString()

        ' Definir las URLs de Firebase para Inventario y la solicitud de Compra
        Dim firebaseInventarioUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Inventario.json"
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Confirmar/" & solicitudID & ".json"

        Try
            Dim client As New WebClient()

            ' Descargar el inventario actual desde Firebase
            Dim inventarioResponse As String = client.DownloadString(firebaseInventarioUrl)
            Dim inventarioData As New Dictionary(Of String, JObject)

            ' Verificar si el inventario existe y no está vacío
            If Not String.IsNullOrEmpty(inventarioResponse) AndAlso inventarioResponse <> "null" Then
                inventarioData = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(inventarioResponse)
            End If

            ' Obtener la cadena de materiales de la solicitud seleccionada
            Dim materiales As String = row.Cells("Materiales").Value.ToString()
            Dim Texto() As String = materiales.Split(",") 'con esto volvemos a convertir la cadena de string de materiales en una lista, la cual almacena el nombre, medida, cantidad, unidad

            ' Procesar cada material de la solicitud
            For Each palabra In Texto
                Dim Material() As String = palabra.Trim().Split(" ")
                If Material.Length < 4 Then Continue For ' Saltar si no tiene formato correcto

                ' Separar los datos del material
                Dim Nombre As String = Material(0).ToUpper() ' Ej: "Cemento"
                Dim medida As String = Material(1).ToUpper() ' Ej: "Saco"
                Dim CantidadStr As String = Material(2)      ' Ej: "10"
                Dim unidad As String = Material(3)           ' Ej: "Unidades"

                ' Unir nombre y medida para formar el identificador
                Dim nombreMedida As String = (Nombre + " " + medida).Trim()

                ' Validar y convertir la cantidad a entero
                Dim CantidadInt As Integer
                If Not Integer.TryParse(CantidadStr, CantidadInt) Then
                    MsgBox("Cantidad inválida para " & nombreMedida, MsgBoxStyle.Critical, "Error de datos")
                    Continue For
                End If

                ' Verificar si el material ya existe en el inventario
                Dim materialEncontrado As Boolean = False
                For Each item In inventarioData
                    Dim datosMaterial As JObject = item.Value

                    If datosMaterial("material").ToString().ToUpper() = nombreMedida AndAlso
                   datosMaterial("unidad").ToString().ToUpper() = unidad Then

                        ' Si existe, sumar la cantidad
                        Dim cantidadExistente As Integer = Integer.Parse(datosMaterial("cantidad").ToString())
                        datosMaterial("cantidad") = (cantidadExistente + CantidadInt).ToString()
                        datosMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                        materialEncontrado = True
                        Exit For
                    End If
                Next

                ' Si no se encontró el material, se crea uno nuevo
                If Not materialEncontrado Then
                    Dim nuevoMaterial As New JObject()
                    nuevoMaterial("material") = nombreMedida
                    nuevoMaterial("cantidad") = CantidadInt.ToString()
                    nuevoMaterial("unidad") = unidad
                    nuevoMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

                    ' Crear una clave para el nuevo material (ej: CEMENTOSACO_0001)
                    Dim claveMaterial As String = (Nombre + medida).Replace(" ", "").ToUpper() & "_0001"
                    inventarioData(claveMaterial) = nuevoMaterial
                End If
            Next

            ' Convertir el inventario actualizado a JSON y subirlo a Firebase
            Dim updateJson As String = JsonConvert.SerializeObject(inventarioData)
            client.UploadString(firebaseInventarioUrl, "PUT", updateJson)

            ' Eliminar la solicitud aceptada de la base de datos
            client.UploadString(firebaseComprasUrl, "DELETE", String.Empty)

            ' Recargar los datos en la interfaz
            'Autorizar_Load(Me, EventArgs.Empty)

            ' Confirmar al usuario que todo salió bien
            MsgBox("Inventario actualizado correctamente.", MsgBoxStyle.Information, "Mensaje de confirmación")


        Catch ex As Exception
            ' Capturar errores generales
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
End Class