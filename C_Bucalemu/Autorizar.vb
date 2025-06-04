Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing


Public Class Autorizar

    Private Sub Autorizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecargarSolicitudes()

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
        Dim ConfirmarURL As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Confirmar"
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Compras/" & solicitudID & ".json"

        Try
            Dim client As New WebClient()

            ' Descargar el confirmar actual desde Firebase
            Dim ConfirmarResponse As String = client.DownloadString(ConfirmarURL & ".json") 'esto muestra {"Solicitud_1":{"0":"contenido","1":"contenido","Estado":"En proceso"}} pero todo esto es un string
            Dim ConfirmarData As New Dictionary(Of String, JObject)

            ' Verificar si el inventario existe y no está vacío
            If Not String.IsNullOrEmpty(ConfirmarResponse) AndAlso ConfirmarResponse <> "null" Then
                ConfirmarData = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(ConfirmarResponse) 'convertimos el string a un diccionario de objetos json para recorrerlo mas facil
            End If
            Dim contador = 2
            Dim Copia = solicitudID
            For Each item In ConfirmarData 'con este for recorremos la base de datos del confirmar para que no se repitan los Id de las solicitudes
                Dim llave As String = item.Key 'aqui obtenemos la solicitud de la base de datos del confirmar
                If llave = Copia Then
                    Copia = "Solicitud_" & contador 'aqui le agregamos el contador para que no se repita el ID de la solicitud))
                    contador += 1
                End If
            Next

            ' Obtener la cadena de materiales de la solicitud seleccionada
            Dim materiales As String = row.Cells("Materiales").Value.ToString()
            Dim Fecha As String = row.Cells("Fecha").Value.ToString()
            Dim Estado As String = "En espera"


            ' Convertir el inventario actualizado a JSON y subirlo a Firebase
            Dim Autorizar As New Dictionary(Of String, Object) From {
                    {"Informacion", materiales},
                    {"Fecha", Fecha},
                    {"Estado", Estado}
                }
            Dim jsonAutorizar As String = JsonConvert.SerializeObject(Autorizar) 'convertimos el contenido que va dentro de la solicitud en un json para que sea de un formato aceptable
            client.UploadString(ConfirmarURL & "/" & Copia & ".json", "PUT", jsonAutorizar)
            ' Eliminar la solicitud aceptada de la base de datos
            client.UploadString(firebaseComprasUrl, "DELETE", String.Empty)
            ' Recargar los datos en la interfaz
            RecargarSolicitudes()

            ' Confirmar al usuario que todo salió bien
            MsgBox("Compra actualizada.", MsgBoxStyle.Information, "Mensaje de confirmación")


        Catch ex As Exception
            ' Capturar errores generales
            MsgBox("Error al actualizar: " & ex.Message, MsgBoxStyle.Critical, "Error")
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
    Private Sub RecargarSolicitudes()
        ' Validar que el nombre del proyecto esté definido
        If String.IsNullOrEmpty(IdentifyProject) Then
            MsgBox("El nombre del proyecto actual no está definido.", MsgBoxStyle.Critical, "Error de configuración")
            Exit Sub
        End If

        ' Construcción de la URL del proyecto
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
                dgAutorizar.Rows.Clear()
                dgAutorizar.Columns.Clear()
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' Deserializar JSON
            Dim comprasRaw As Dictionary(Of String, JObject) = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(response)

            If comprasRaw Is Nothing OrElse comprasRaw.Count = 0 Then
                dgAutorizar.Rows.Clear()
                dgAutorizar.Columns.Clear()
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' LIMPIEZA (primero columnas, luego filas)
            dgAutorizar.Columns.Clear()
            dgAutorizar.Rows.Clear()

            ' Estilo (si quieres mantenerlo aquí)
            ConfigurarEstiloDataGridView()

            ' Agregar columnas
            dgAutorizar.Columns.Add("RealID", "ID Real")
            dgAutorizar.Columns("RealID").Visible = False
            dgAutorizar.Columns.Add("ID", "ID de Solicitud")
            dgAutorizar.Columns.Add("Materiales", "Materiales")
            dgAutorizar.Columns.Add("Fecha", "Fecha de Ingreso")
            dgAutorizar.Columns.Add("Estado", "Estado")

            Dim contador As Integer = 1

            ' Rellenar el DataGridView
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
End Class