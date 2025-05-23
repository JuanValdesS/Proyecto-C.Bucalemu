Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Diagnostics.Eventing.Reader


Public Class Autorizar

    Private Sub Autorizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Validar que el nombre del proyecto esté definido
        If String.IsNullOrEmpty(IdentifyProject) Then
            MsgBox("El nombre del proyecto actual no está definido.", MsgBoxStyle.Critical, "Error de configuración")
            Exit Sub
        End If

        ' Construcción de la URL
        Dim firebaseUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/{IdentifyProject}/Compras.json"

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
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' Deserializar JSON
            Dim comprasRaw As Dictionary(Of String, JObject) = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(response)

            If comprasRaw Is Nothing OrElse comprasRaw.Count = 0 Then
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' Configurar el DataGridView
            ConfigurarEstiloDataGridView()
            dgAutorizar.Rows.Clear()
            dgAutorizar.Columns.Clear()

            dgAutorizar.Columns.Add("RealID", "ID Real")
            dgAutorizar.Columns("RealID").Visible = False
            dgAutorizar.Columns.Add("ID", "ID de Solicitud")
            dgAutorizar.Columns.Add("Materiales", "Materiales")
            dgAutorizar.Columns.Add("Fecha", "Fecha de Ingreso")
            dgAutorizar.Columns.Add("Estado", "Estado")

            Dim contador As Integer = 1

            For Each solicitud In comprasRaw
                Dim solicitudID As String = solicitud.Key
                Dim solicitudDatos As JObject = solicitud.Value
                Dim materialesTexto As New List(Of String)
                Dim fecha As String = ""
                Dim estado As String = ""

                For Each propiedad In solicitudDatos.Properties()
                    If IsNumeric(propiedad.Name) Then
                        Dim datosMaterial As JObject = JObject.Parse(propiedad.Value.ToString())
                        Dim nombreMaterial As String = datosMaterial("Material").ToString().Trim()
                        Dim cantidad As String = datosMaterial("Cantidad").ToString()
                        Dim unidad As String = datosMaterial("Unidad").ToString()
                        Dim medida As String = datosMaterial("Medida").ToString()
                        Dim unidadMedida As String = datosMaterial("Unidad de medida").ToString()

                        materialesTexto.Add($"{nombreMaterial} {medida}{unidadMedida} {cantidad} {unidad}")
                        fecha = datosMaterial("Fecha").ToString()
                    ElseIf propiedad.Name = "Estado" Then
                        estado = propiedad.Value.ToString()
                    End If
                Next

                If materialesTexto.Count > 0 Then
                    Dim materialesTextoTexto As String = String.Join(", ", materialesTexto)
                    Dim solicitudNombre As String = "Solicitud " & contador.ToString()
                    dgAutorizar.Rows.Add(solicitudID, solicitudNombre, materialesTextoTexto, fecha, estado)
                    contador += 1
                End If
            Next

        Catch ex As Exception
            MsgBox("Error al obtener los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub btnMenu_Cdjlick(sender As Object, e As EventArgs) Handles btnMenu.Click
        Menú.Show()
        Me.Close()

    End Sub
    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With dgAutorizar
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        ' Validar si hay filas en el DataGridView
        If dgAutorizar.Rows.Count = 0 Then
            MsgBox("No hay datos para enviar.", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If

        ' Validar si el usuario seleccionó una fila
        If dgAutorizar.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione una solicitud.", MsgBoxStyle.Information, "Información")
            Exit Sub
        End If

        ' Obtener la fila seleccionada y el ID de la solicitud
        Dim row As DataGridViewRow = dgAutorizar.SelectedRows(0)
        Dim solicitudID As String = row.Cells("RealID").Value.ToString()

        ' Definir las URLs de Firebase para Inventario y la solicitud de Compra
        Dim firebaseInventarioUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Inventario.json"
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Compras/" & solicitudID & ".json"

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
            Dim Texto() As String = materiales.Split(",")

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

                    If datosMaterial("Material").ToString().ToUpper() = nombreMedida AndAlso
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
                    nuevoMaterial("Material") = nombreMedida
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
            Autorizar_Load(Me, EventArgs.Empty)

            ' Confirmar al usuario que todo salió bien
            MsgBox("Inventario actualizado correctamente.", MsgBoxStyle.Information, "Mensaje de confirmación")

        Catch ex As Exception
            ' Capturar errores generales
            MsgBox("Error al actualizar el inventario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub



    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click

        'Validar que el nombre del proyecto este almacenado
        If String.IsNullOrEmpty(IdentifyProject) Then
            MsgBox("No se ha definido el nombre del proyecto actual.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        ' Verificar que haya datos en el DataGridView
        If dgAutorizar.Rows.Count = 0 Then
            MsgBox("No hay datos para eliminar.", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If
        ' Verificar que se haya seleccionado una fila   
        If dgAutorizar.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione una solicitud.", MsgBoxStyle.Information, "Información")
            Exit Sub
        End If

        ' Obtener la solicitud seleccionada
        Dim row As DataGridViewRow = dgAutorizar.SelectedRows(0)
        Dim solicitudID As String = row.Cells("RealID").Value.ToString()
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Compras/" & solicitudID & ".json"

        Try
            Dim client As New WebClient()
            client.UploadString(firebaseComprasUrl, "DELETE", String.Empty)
            ' Eliminar la fila del DataGridView y recargar la lista actualizada
            dgAutorizar.Rows.Remove(row)
            ' Mensaje de confirmación
            MsgBox($"La solicitud con ID {solicitudID} fue rechazada correctamente.", MsgBoxStyle.Information, "información")

        Catch ex As Exception
            MsgBox("Error al eliminar la solicitud: ", MsgBoxStyle.Critical, "Error")
        End Try

        ' Recargar los datos del DataGridView para reflejar los cambios

    End Sub
End Class