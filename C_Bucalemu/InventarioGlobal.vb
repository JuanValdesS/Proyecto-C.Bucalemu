Imports Newtonsoft.Json.Linq

Public Class InventarioGlobal
    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
    }

    Private client As FireSharp.Interfaces.IFirebaseClient
    Private Sub InventarioGlobal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                dgvInventario.Rows.Clear()
                dgvInventario.Columns.Clear()

                ' Definir columnas si no existen
                If dgvInventario.Columns.Count = 0 Then
                    dgvInventario.Columns.Add("ID", "N°")
                    dgvInventario.Columns.Add("Nombre", "Nombre del Material")
                    dgvInventario.Columns.Add("Cantidad", "Cantidad")
                    dgvInventario.Columns.Add("Unidad", "Unidad")
                    dgvInventario.Columns.Add("Fecha", "Fecha de Ingreso")
                End If

                ' Crear lista para almacenar temporalmente los materiales
                Dim listaMateriales As New List(Of Dictionary(Of String, String))

                For Each item As KeyValuePair(Of String, JToken) In jsonData
                    Dim nombre As String = If(item.Value("Material") IsNot Nothing, item.Value("Material").ToString(), "Desconocido")
                    Dim cantidad As String = If(item.Value("cantidad") IsNot Nothing, item.Value("cantidad").ToString(), "0")
                    Dim unidades As String = If(item.Value("unidad") IsNot Nothing, item.Value("unidad").ToString(), "No registrada")
                    Dim fechaIngreso As String = If(item.Value("fecha") IsNot Nothing, item.Value("fecha").ToString(), "No registrada")

                    ' Solo agregar si la fecha es válida
                    If DateTime.TryParse(fechaIngreso, Nothing) Then
                        Dim material As New Dictionary(Of String, String) From {
                            {"nombre", nombre},
                            {"cantidad", cantidad},
                            {"unidad", unidades},
                            {"fecha", fechaIngreso}
                        }
                        listaMateriales.Add(material)
                    End If
                Next

                ' Ordenar por fecha descendente (más reciente primero)
                listaMateriales = listaMateriales.OrderByDescending(Function(m) DateTime.Parse(m("fecha"))).ToList()

                ' Agregar filas al DataGridView
                Dim contador As Integer = 1
                For Each material In listaMateriales
                    dgvInventario.Rows.Add(contador, material("nombre"), material("cantidad"), material("unidad"), material("fecha"))
                    contador += 1
                Next
            ElseIf respuesta.Body = "null" Then
                MsgBox("No hay datos disponibles en el inventario.", MsgBoxStyle.Information)
            Else
                MsgBox("Error al obtener los datos del inventario.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Error al cargar inventario: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With dgvInventario
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

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim proyecto As New Proyectos()

        Me.Close()
        proyecto.Show()
    End Sub
End Class