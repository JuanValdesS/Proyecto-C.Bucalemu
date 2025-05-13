Imports Newtonsoft.Json.Linq

Public Class GestionarReportes
    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
}

    Private client As FireSharp.Interfaces.IFirebaseClient

    Private Sub GestionarReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            client = New FireSharp.FirebaseClient(fcon)

            If client IsNot Nothing Then
                CargarReportes()
            Else
                MsgBox("Error al conectar con la base de datos", MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception
            MsgBox("Error de conexión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub CargarReportes()
        Try
            Dim respuesta = client.Get("Reportes")

            If String.IsNullOrEmpty(respuesta.Body) OrElse respuesta.Body = "null" Then
                data_repo.Rows.Clear()
                data_repo.Columns.Clear()

                If data_repo.Columns.Count = 0 Then
                    data_repo.Columns.Add("ID", "N°") ' ← este es solo el contador
                    data_repo.Columns.Add("FirebaseID", "ID Firebase") ' ← oculto
                    data_repo.Columns.Add("Titulo del reporte", "Titulo")
                    data_repo.Columns.Add("Reporte", "Descripción del reporte")
                    data_repo.Columns.Add("Estado", "Estado")

                    ' Ocultar la columna del ID real
                    data_repo.Columns("FirebaseID").Visible = False
                End If


                MsgBox("No hay reportes disponibles.", MsgBoxStyle.Information, "Aviso")
                Return
            End If

            Dim jsonData As JObject = JObject.Parse(respuesta.Body)

            ConfigurarEstiloDataGridView()
            data_repo.Rows.Clear()
            data_repo.Columns.Clear()

            If data_repo.Columns.Count = 0 Then
                data_repo.Columns.Add("ID", "N°") ' ← este es solo el contador
                data_repo.Columns.Add("FirebaseID", "ID Firebase") ' ← oculto
                data_repo.Columns.Add("Titulo del reporte", "Titulo")
                data_repo.Columns.Add("Reporte", "Descripción del reporte")
                data_repo.Columns.Add("Estado", "Estado")

                ' Ocultar la columna del ID real
                data_repo.Columns("FirebaseID").Visible = False
            End If

            Dim contador As Integer = 1
            For Each item As KeyValuePair(Of String, JToken) In jsonData
                Dim titulo As String = If(item.Value("Titulo del correo") IsNot Nothing, item.Value("Titulo del correo").ToString(), "Sin título")
                Dim descripcion As String = If(item.Value("Descripcion") IsNot Nothing, item.Value("Descripcion").ToString(), "No registrada")

                Dim estado As String = If(item.Value("Estado") IsNot Nothing, item.Value("Estado").ToString(), "No visualizado")
                data_repo.Rows.Add(contador, item.Key, titulo, descripcion, estado)
                contador += 1
            Next

        Catch ex As Exception
            MsgBox("Error al cargar los reportes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With data_repo
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sh As New Menú()
        Me.Close()
        sh.Show()
    End Sub

    Private Sub btn_reporte_Click(sender As Object, e As EventArgs) Handles btn_reporte.Click
        ' Verifica que haya una fila seleccionada
        If data_repo.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione un reporte para aceptar.", MsgBoxStyle.Exclamation, "Atención")
            Return
        End If

        ' Obtener el ID del reporte seleccionado
        Dim selectedRow As DataGridViewRow = data_repo.SelectedRows(0)
        Dim reporteId As String = selectedRow.Cells("FirebaseID").Value.ToString()
        Dim estadoActual As String = selectedRow.Cells("Estado").Value.ToString()

        ' Validar si ya está atendido
        If estadoActual = "Atendido" Then
            MsgBox("Este reporte ya fue marcado como atendido.", MsgBoxStyle.Information, "Información")
            Return
        End If

        Try
            ' Crear conexión a Firebase
            Dim fcon As New FireSharp.Config.FirebaseConfig With {
            .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
            .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
        }

            Dim client As New FireSharp.FirebaseClient(fcon)

            ' Crear el campo a actualizar
            Dim datos As New Dictionary(Of String, Object) From {
            {"Estado", "Atendido"}
        }

            ' Actualizar el nodo en Firebase
            client.Update("Reportes/" & reporteId, datos)

            MsgBox("Reporte marcado como atendido.", MsgBoxStyle.Information, "Éxito")
            CargarReportes()

        Catch ex As Exception
            MsgBox("Error al actualizar el reporte: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        ' Verificar que haya una fila seleccionada
        If data_repo.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione un reporte para eliminar.", MsgBoxStyle.Exclamation, "Atención")
            Return
        End If

        ' Confirmación de eliminación
        Dim confirmacion = MsgBox("¿Estás seguro de que deseas eliminar este reporte?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar Eliminación")
        If confirmacion = MsgBoxResult.No Then
            Return
        End If

        ' Obtener el ID del reporte seleccionado
        Dim reporteId As String = data_repo.SelectedRows(0).Cells("FirebaseID").Value.ToString()

        Try
            ' Eliminar de Firebase
            Dim respuesta = client.Delete("Reportes/" & reporteId)

            ' Eliminar la fila del DataGridView
            data_repo.Rows.RemoveAt(data_repo.SelectedRows(0).Index)

            MsgBox("Reporte eliminado correctamente.", MsgBoxStyle.Information, "Éxito")
            CargarReportes()
        Catch ex As Exception
            MsgBox("Error al eliminar el reporte: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class