Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports Newtonsoft.Json
Imports System.Net
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Compras
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim estado As String = "En proceso"
        Dim material As String = txtMaterial.Text
        Dim cantidad As Integer = nCantidad.Value
        Dim unidad As String = cbUnidad.Text
        Dim medida As String = nMedidas.Text
        Dim unidadMedida = cmMedida.Text
        Dim fecha As String = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") ' Fecha actual

        ' Verificar que no haya campos vacíos
        If String.IsNullOrWhiteSpace(material) OrElse String.IsNullOrWhiteSpace(unidad) Then
            MsgBox("Por favor, ingrese todos los campos.", MsgBoxStyle.Exclamation, "Advertencia")
            Return
        End If

        If cbMedidas.Checked AndAlso (String.IsNullOrWhiteSpace(medida) OrElse String.IsNullOrWhiteSpace(unidadMedida)) Then
            MsgBox("Debe ingresar las medidas si está activado el campo.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Verificar si las columnas están definidas (solo la primera vez)
        If dgCompras.Columns.Count = 0 Then
            dgCompras.Columns.Add("ID", "N°")
            dgCompras.Columns.Add("Nombre", "Nombre del Material")
            dgCompras.Columns.Add("Cantidad", "Cantidad")
            dgCompras.Columns.Add("Unidad", "Unidad")
            dgCompras.Columns.Add("Fecha", "Fecha de Ingreso")
            dgCompras.Columns.Add("Medida", "Medida")
            dgCompras.Columns.Add("Unidad de Medida", "Unidad de Medida")
        End If

        ' Agregar una nueva fila al DataGridView
        Dim rowIndex As Integer = dgCompras.Rows.Add() ' Añadir una nueva fila
        Dim row As DataGridViewRow = dgCompras.Rows(rowIndex)

        ' Asignar los valores a las celdas de la nueva fila
        row.Cells("ID").Value = rowIndex + 1 ' Número de fila
        row.Cells("Nombre").Value = material
        row.Cells("Cantidad").Value = cantidad
        row.Cells("Unidad").Value = unidad
        row.Cells("Fecha").Value = fecha
        row.Cells("Medida").Value = medida
        row.Cells("Unidad de Medida").Value = unidadMedida


        ' Limpiar los controles de entrada después de agregar
        txtMaterial.Clear()
        nMedidas.Clear()
        nCantidad.Value = 0
        cbUnidad.SelectedIndex = -1
        cmMedida.SelectedIndex = -1
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ' Verificar que haya una fila seleccionada
        If dgCompras.SelectedRows.Count > 0 Then
            ' Obtener el índice de la fila seleccionada y eliminarla
            dgCompras.Rows.RemoveAt(dgCompras.SelectedRows(0).Index)

            ' Llamar a la función para actualizar los IDs
            ReindexarIDs()
        Else
            MsgBox("Por favor, seleccione una fila para eliminar.", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub ReindexarIDs()
        ' Recorrer todas las filas y actualizar el número de ID
        For i As Integer = 0 To dgCompras.Rows.Count - 1
            dgCompras.Rows(i).Cells("ID").Value = i + 1 ' Asigna un ID consecutivo
        Next
    End Sub

    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With dgCompras
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Menú.Show()
        Me.Close()
    End Sub




    Private Sub Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarEstiloDataGridView()
        dgCompras.Rows.Clear()
        dgCompras.Columns.Clear()
        cmMedida.Visible = False
        nMedidas.Visible = False
        lbl_medida.Visible = False



    End Sub

    Private Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        ' Verificar que haya datos en el DataGridView
        If dgCompras.Rows.Count = 0 Then
            MsgBox("No hay datos para enviar.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        ' URL de la base de datos en Firebase (reemplaza con tu URL real)
        Dim firebaseUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Compras"
        Dim solicitudId As String = "1"

        ' Enviar los datos a Firebase
        Try
            Dim client As New WebClient()
            Dim response As String = client.DownloadString(firebaseUrl & ".json") ' ← correctamente formateado

            If Not String.IsNullOrWhiteSpace(response) AndAlso response.Trim() <> "null" Then
                Dim solicitudesExistentes As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
                Dim numerosExistentes = solicitudesExistentes.Keys.Where(Function(k) k.StartsWith("Solicitud_")).Select(Function(k) Integer.Parse(k.Replace("Solicitud_", ""))).ToList()
                Dim maxNumero As Integer = If(numerosExistentes.Count > 0, numerosExistentes.Max(), 0)
                solicitudId = (maxNumero + 1).ToString()
            End If
        Catch ex As WebException
            Dim resp = New StreamReader(ex.Response.GetResponseStream()).ReadToEnd()
            MsgBox("Error al contar solicitudes existentes: " & resp, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        ' Guardar cada producto como subíndice numérico
        Try
            Dim client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim solicitudNombre As String = "Solicitud_" & solicitudId

            Dim index As Integer = 0
            For Each row As DataGridViewRow In dgCompras.Rows
                If Not row.IsNewRow Then
                    Dim compra As New Dictionary(Of String, Object) From {
                    {"ID", row.Cells("ID").Value},
                    {"Material", row.Cells("Nombre").Value},
                    {"Cantidad", row.Cells("Cantidad").Value},
                    {"Unidad", row.Cells("Unidad").Value},
                    {"Fecha", row.Cells("Fecha").Value},
                    {"Medida", row.Cells("Medida").Value},
                    {"Unidad de medida", row.Cells("Unidad de medida").Value}
                }

                    Dim jsonProducto As String = JsonConvert.SerializeObject(compra)
                    client.UploadString(firebaseUrl & "/" & solicitudNombre & "/" & index & ".json", "PUT", jsonProducto)
                    index += 1
                End If
            Next

            ' Agregar estado general de la solicitud
            Dim estadoGeneral As String = """En Proceso"""
            client.UploadString(firebaseUrl & "/" & solicitudNombre & "/Estado.json", "PUT", estadoGeneral)

            MsgBox("Solicitud enviada correctamente como N° " & solicitudId, MsgBoxStyle.Information, "Éxito")
            dgCompras.Rows.Clear()
            dgCompras.Columns.Clear()

        Catch ex As Exception
            MsgBox("Error al enviar datos: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub txtMaterial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaterial.KeyPress
        ' Convertir el carácter presionado a mayúscula
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbMedidas.CheckedChanged
        If cbMedidas.Checked Then
            nMedidas.Visible = True
            cmMedida.Visible = True
            lbl_medida.Visible = True
        Else
            nMedidas.Visible = False
            cmMedida.Visible = False
            lbl_medida.Visible = False
        End If

    End Sub

End Class