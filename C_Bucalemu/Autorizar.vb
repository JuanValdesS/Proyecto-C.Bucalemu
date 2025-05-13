Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Diagnostics.Eventing.Reader
Imports System.Net

Public Class Autorizar

    Private Sub Autorizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' URL de Firebase (ajústala según la estructura de tu base de datos)
        Dim firebaseUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Compras.json"

        Try
            Dim client As New WebClient()
            Dim response As String = client.DownloadString(firebaseUrl)

            If String.IsNullOrEmpty(response) OrElse response = "null" Then
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' Deserializar a Dictionary de JObject
            Dim comprasRaw As Dictionary(Of String, JObject) = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(response)

            If comprasRaw Is Nothing OrElse comprasRaw.Count = 0 Then
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' Mostrar la cantidad de solicitudes como validación
            MsgBox("Cantidad de solicitudes: " & comprasRaw.Count)

            ' Limpiar y configurar el DataGridView
            ConfigurarEstiloDataGridView()
            dgAutorizar.Rows.Clear()
            dgAutorizar.Columns.Clear()

            dgAutorizar.Columns.Add("RealID", "ID Real")
            dgAutorizar.Columns("RealID").Visible = False
            dgAutorizar.Columns.Add("ID", "ID de Solicitud")
            dgAutorizar.Columns.Add("Materiales", "Materiales")
            dgAutorizar.Columns.Add("Fecha", "Fecha de Ingreso")

            Dim contador As Integer = 1

            For Each solicitud In comprasRaw
                Dim solicitudID As String = solicitud.Key
                Dim solicitudDatos As JObject = solicitud.Value

                Dim materialesTexto As New List(Of String)
                Dim fecha As String = ""

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
                    End If
                Next

                If materialesTexto.Count > 0 Then
                    Dim materialesTextoTexto As String = String.Join(", ", materialesTexto)
                    Dim solicitudNombre As String = "Solicitud " + contador.ToString()
                    dgAutorizar.Rows.Add(solicitudID, solicitudNombre, materialesTextoTexto, fecha)
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ' Verificar que haya datos en el DataGridView
        If dgAutorizar.Rows.Count = 0 Then
            MsgBox("No hay datos para enviar.", MsgBoxStyle.Exclamation, "Advertencia")
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
        ' Dim listaMateriales As JArray = comprasData(solicitudID)

        ' URL de Firebase para Inventario
        Dim firebaseInventarioUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Inventario.json"
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Compras/{solicitudID}.json"



        Try
            Dim client As New WebClient()
            Dim inventarioResponse As String = client.DownloadString(firebaseInventarioUrl)
            Dim inventarioData As Dictionary(Of String, JObject) = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(inventarioResponse)

            Dim materiales As String = row.Cells("Materiales").Value.ToString()
            Dim Texto() As String = materiales.Split(",")

            For Each palabra In Texto

                Dim Material() As String = palabra.Trim().Split(" ")
                Dim Nombre As String = Material(0).ToUpper()

                Dim medida As String = Material(1).ToUpper()

                Dim nombreMedida As String = (Nombre + " " + medida).Trim()

                Dim Cantidad As String = Material(2)
                Dim unidad As String = Material(3)

                ' Verificar si el material ya existe en el inventario
                Dim materialEncontrado As Boolean = False
                For Each item In inventarioData

                    Dim datosMaterial As JObject = item.Value
                    MsgBox(datosMaterial("Material").ToString())

                    If datosMaterial("Material").ToString() = nombreMedida AndAlso datosMaterial("unidad").ToString() = unidad Then
                        ' Actualizar la cantidad
                        datosMaterial("cantidad") = (Integer.Parse(datosMaterial("cantidad").ToString()) + Cantidad).ToString()
                        materialEncontrado = True
                        Exit For
                    End If
                Next
                ' Si no se encontró, agregar nuevo material
                If Not materialEncontrado Then
                    Dim nuevoMaterial As New JObject()
                    nuevoMaterial("Material") = nombreMedida
                    nuevoMaterial("cantidad") = Cantidad.ToString()
                    nuevoMaterial("unidad") = unidad
                    nuevoMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")


                    inventarioData($"{Nombre.ToUpper()}{medida}_0001") = nuevoMaterial
                End If
            Next
            ' Actualizar Firebase con los nuevos datos
            Dim updateJson As String = JsonConvert.SerializeObject(inventarioData)
            client.UploadString(firebaseInventarioUrl, "PUT", updateJson)
            ' Eliminar la solicitud aceptada de Compras
            client.UploadString(firebaseComprasUrl, "DELETE", String.Empty)
            ' Recargar los datos del DataGridView para reflejar los cambios
            ' Limpiar DataGridView
            ConfigurarEstiloDataGridView()
            dgAutorizar.Rows.Clear()
            dgAutorizar.Columns.Clear()

            Autorizar_Load(Me, EventArgs.Empty)

            MsgBox("Inventario actualizado correctamente.", MsgBoxStyle.Information, "Mensaje de confirmación")

        Catch ex As Exception
            MsgBox("Error al actualizar el inventario: ", MsgBoxStyle.Critical, "Error")
        End Try



    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
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
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Compras/{solicitudID}.json"
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