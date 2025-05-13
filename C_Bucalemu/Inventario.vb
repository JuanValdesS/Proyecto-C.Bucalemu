Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net

Public Class Inventario

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
    }

    Private client As FireSharp.Interfaces.IFirebaseClient

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Puede ir lógica adicional si es necesario
        Try
            client = New FireSharp.FirebaseClient(fcon)

            If client IsNot Nothing Then
                CargarInventario()
            Else
                MsgBox("Error al conectar con la base de datos", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("Error de conexión: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        ' Ocultar el botón por defecto
        Button2.Visible = False

        ' Obtener el rol del usuario autenticado
        Dim rolUsuario As String = My.Settings.RolUsuario

        ' Mostrar el botón solo si el usuario es Administrador
        If rolUsuario = "Administrador" Then
            Button2.Visible = True

        End If

        If rolUsuario = "Jefe" Then
            Button2.Visible = True
        End If

    End Sub

    Private Sub CargarInventario()
        Try
            ' Obtener los datos desde Firebase
            Dim respuesta = client.Get("Inventario")

            ' Verificar que la respuesta no sea nula
            If respuesta.Body IsNot "null" Then
                ' Convertir la respuesta a un JObject (Newtonsoft.Json.Linq)
                Dim jsonData As JObject = JObject.Parse(respuesta.Body)

                ' Limpiar el DataGridView antes de cargar los datos
                ConfigurarEstiloDataGridView()
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()

                ' Definir columnas si no existen
                If DataGridView1.Columns.Count = 0 Then
                    DataGridView1.Columns.Add("ID", "N°")
                    DataGridView1.Columns.Add("Nombre", "Nombre del Material")
                    DataGridView1.Columns.Add("Cantidad", "Cantidad")
                    DataGridView1.Columns.Add("Unidad", "Unidad")
                    DataGridView1.Columns.Add("Fecha", "Fecha de Ingreso")
                End If

                Dim contador As Integer = 1 ' Para numerar las filas

                ' Recorrer cada elemento del inventario en el JObject
                For Each item As KeyValuePair(Of String, JToken) In jsonData
                    ' Obtener los valores, con control de existencia
                    Dim nombre As String = If(item.Value("Material") IsNot Nothing, item.Value("Material").ToString(), "Desconocido")
                    Dim cantidad As String = If(item.Value("cantidad") IsNot Nothing, item.Value("cantidad").ToString(), "0")
                    Dim unidades As String = If(item.Value("unidad") IsNot Nothing, item.Value("unidad").ToString(), "No registrada")
                    Dim fechaIngreso As String = If(item.Value("fecha") IsNot Nothing, item.Value("fecha").ToString(), "No registrada")

                    ' Agregar la fila con los datos al DataGridView
                    DataGridView1.Rows.Add(contador, nombre, cantidad, unidades, fechaIngreso)

                    ' Incrementar contador para la numeración
                    contador += 1
                Next
            End If
        Catch ex As Exception
            MsgBox("Error al cargar inventario: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With DataGridView1
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
        Dim menu As New Menú()
        menu.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gestinven As New mod_material

        gestinven.Show()
        Close()
    End Sub

    Private Sub btn_total_Click(sender As Object, e As EventArgs) Handles btn_total.Click
        ' Crear un diccionario para almacenar los totales de materiales por nombre y unidad
        Dim totales As New Dictionary(Of String, Integer)

        ' Recorrer las filas del DataGridView1
        For Each fila As DataGridViewRow In DataGridView1.Rows
            ' Verificar que la fila no esté vacía
            If Not fila.IsNewRow Then
                Dim nombre = fila.Cells("Nombre").Value.ToString
                Dim unidad = fila.Cells("Unidad").Value.ToString
                Dim cantidad = Convert.ToInt32(fila.Cells("Cantidad").Value)

                ' Clave única basada en nombre + unidad
                Dim clave = nombre & " - " & unidad

                ' Sumar cantidades del mismo material y unidad
                If totales.ContainsKey(clave) Then
                    totales(clave) += cantidad
                Else
                    totales.Add(clave, cantidad)
                End If
            End If
        Next

        ' Limpiar DataGridView2 antes de cargar los datos
        ConfigurarEstiloDataGridView()
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        ' Agregar columnas si no existen
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("Material", "Material")
            DataGridView1.Columns.Add("Unidad", "Unidad")
            DataGridView1.Columns.Add("CantidadTotal", "Cantidad Total")
        End If

        ' Agregar los totales al DataGridView2
        For Each kvp In totales
            Dim partes = kvp.Key.Split(" - ")
            DataGridView1.Rows.Add(partes(0), partes(1), kvp.Value)
        Next
    End Sub

    Private Sub btn_reestablecer_Click(sender As Object, e As EventArgs) Handles btn_reestablecer.Click
        CargarInventario()
    End Sub
End Class