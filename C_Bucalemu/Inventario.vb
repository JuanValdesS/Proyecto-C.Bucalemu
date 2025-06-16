Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Globalization

Public Class Inventario

    Private jsonDataGlobal As JObject ' Declarar al principio del formulario

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
    }

    Private client As FireSharp.Interfaces.IFirebaseClient

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Deshabilitar el botón para que no se pueda presionar de nuevo
        btn_reestablecer.Enabled = False

        ' Puede ir lógica adicional si es necesario

        Try
            client = New FireSharp.FirebaseClient(fcon)

            If client IsNot Nothing Then

                CargarInventario()
                PintarFilasSegunStock()

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

        ' Mostrar el botón solo si el usuario es jefe o encargado del inventario
        If rolUsuario = "Jefe" Or rolUsuario = "Encargado del inventario" Then
            Button2.Visible = True
        End If

    End Sub

    Private Sub CargarInventario()
        Try
            ' Obtener los datos desde Firebase
            Dim respuesta = client.Get("Proyectos/" & IdentifyProject & "/Inventario")
            ' Verificar que la respuesta no sea nula y que no tenga espacios adicionales
            If respuesta.Body IsNot Nothing AndAlso respuesta.Body.Trim() <> "null" Then
                ' Convertir la respuesta a un JObject (Newtonsoft.Json.Linq)
                Dim jsonData As JObject = JObject.Parse(respuesta.Body)
                jsonDataGlobal = jsonData

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

                DataGridView1.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DataGridView1.Columns("Cantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DataGridView1.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DataGridView1.Columns("Unidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                ' Crear lista para almacenar temporalmente los materiales
                Dim listaMateriales As New List(Of Dictionary(Of String, String))

                For Each item As KeyValuePair(Of String, JToken) In jsonData
                    Dim nombre As String = If(item.Value("material") IsNot Nothing, item.Value("material").ToString(), "Desconocido")
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
                    DataGridView1.Rows.Add(contador, material("nombre"), material("cantidad"), material("unidad"), material("fecha"))
                    contador += 1
                Next
            ElseIf respuesta.Body.Trim() = "null" Then

            Else

                MsgBox("Error al cargar los datos del inventario.", MsgBoxStyle.Critical)
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
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Deshabilitar la edición de celdas
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True

            ' Cambiar estilo del grid
            .BorderStyle = BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim men As New Menú()
        men.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gestinven As New mod_material

        gestinven.Show()
        Close()
    End Sub

    Private Sub btn_total_Click(sender As Object, e As EventArgs) Handles btn_total.Click

        ' Deshabilitar el botón para que no se pueda presionar de nuevo
        btn_total.Enabled = False

        'Habilitar el boton de reestablecer
        btn_reestablecer.Enabled = True

        ' Crear un diccionario para almacenar los totales de materiales por nombre y unidad
        Dim totales As New Dictionary(Of String, Integer)

        ' Recorrer las filas del DataGridView1
        For Each fila As DataGridViewRow In DataGridView1.Rows
            ' Verificar que la fila no esté vacía
            If Not fila.IsNewRow Then
                Dim nombre = fila.Cells("Nombre").Value.ToString
                Dim unidad = fila.Cells("Unidad").Value.ToString
                Dim cantidad As Decimal = Decimal.Parse(fila.Cells("Cantidad").Value.ToString, New Globalization.CultureInfo("es-ES"))


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

        DataGridView1.Columns("CantidadTotal").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns("Material").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        ' Agregar los totales al DataGridView2
        For Each kvp In totales
            Dim partes = kvp.Key.Split(" - ")
            DataGridView1.Rows.Add(partes(0), partes(1), kvp.Value)
        Next
    End Sub

    Private Sub btn_reestablecer_Click(sender As Object, e As EventArgs) Handles btn_reestablecer.Click

        ' Deshabilitar el botón para que no se pueda presionar de nuevo
        btn_reestablecer.Enabled = False

        'Habilitar botón de total inventario
        btn_total.Enabled = True

        CargarInventario()
        PintarFilasSegunStock()
        txt_buscar.Clear()
    End Sub
    Private Sub FiltrarInventario(filtro As String)
        Try
            Dim respuesta = client.Get("Proyectos/" & IdentifyProject & "/Inventario")


            If respuesta.Body IsNot "null" Then
                Dim jsonData As JObject = JObject.Parse(respuesta.Body)

                ' Limpiar y configurar nuevamente
                ConfigurarEstiloDataGridView()
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()

                ' Redefinir columnas
                If DataGridView1.Columns.Count = 0 Then
                    DataGridView1.Columns.Add("ID", "N°")
                    DataGridView1.Columns.Add("Nombre", "Nombre del Material")
                    DataGridView1.Columns.Add("Cantidad", "Cantidad")
                    DataGridView1.Columns.Add("Unidad", "Unidad")
                    DataGridView1.Columns.Add("Fecha", "Fecha de Ingreso")
                End If

                DataGridView1.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DataGridView1.Columns("Cantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DataGridView1.Columns("Unidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DataGridView1.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                Dim contador As Integer = 1

                For Each item As KeyValuePair(Of String, JToken) In jsonData
                    Dim nombre As String = If(item.Value("material") IsNot Nothing, item.Value("material").ToString(), "Desconocido")
                    Dim cantidad As String = If(item.Value("cantidad") IsNot Nothing, item.Value("cantidad").ToString(), "0")
                    Dim unidades As String = If(item.Value("unidad") IsNot Nothing, item.Value("unidad").ToString(), "No registrada")
                    Dim fechaIngreso As String = If(item.Value("fecha") IsNot Nothing, item.Value("fecha").ToString(), "No registrada")

                    ' Aplicar filtro
                    If nombre.ToLower().Contains(filtro.ToLower()) Then
                        DataGridView1.Rows.Add(contador, nombre, cantidad, unidades, fechaIngreso)
                        contador += 1
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("Error al filtrar inventario: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function CalcularPorcentajeStock(cantidadStr As String, stockMaxStr As String) As Integer
        Try
            Dim cultura As CultureInfo = New CultureInfo("es-CL")
            Dim cantidad As Double = Convert.ToDouble(cantidadStr, cultura)
            Dim stockMax As Double = Convert.ToDouble(stockMaxStr, cultura)

            If stockMax <= 0 Then
                Return 0 ' evitar división por cero
            End If

            Dim porcentaje As Double = (cantidad / stockMax) * 100
            Return CInt(Math.Round(porcentaje))
        Catch ex As Exception
            Return -1 ' error
        End Try
    End Function

    Private Function VerificarMaterialesBajoStockD() As Boolean
        Dim materialesFaltantes As New List(Of String)
        Dim cultura As CultureInfo = New CultureInfo("es-CL")

        Try
            ' Obtener todo el inventario desde Firebase
            Dim respuesta = client.Get("Proyectos/" & IdentifyProject & "/Inventario")

            If respuesta.Body Is Nothing OrElse respuesta.Body.Trim() = "null" Then
                MessageBox.Show("No se pudo obtener el inventario desde Firebase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Dim inventarioData As JObject = JObject.Parse(respuesta.Body)
            ' Recorrer cada fila del DataGridView
            For Each fila As DataGridViewRow In DataGridView1.Rows

                If fila.IsNewRow Then Continue For

                Try
                    Dim nombreMaterial As String = fila.Cells(1).Value.ToString()
                    Dim cantidadStr As String = fila.Cells(2).Value.ToString()
                    Dim stockMaxStr As String = Nothing

                    ' Buscar el nodo que contiene ese material
                    For Each item As KeyValuePair(Of String, JToken) In inventarioData
                        Dim nombreEnFirebase As String = item.Value("material")?.ToString()

                        If nombreEnFirebase = nombreMaterial Then
                            stockMaxStr = item.Value("stock_max")?.ToString()
                            Exit For
                        End If
                    Next

                    If stockMaxStr IsNot Nothing Then
                        Dim porcentaje As Integer = CalcularPorcentajeStock(cantidadStr, stockMaxStr)

                        If porcentaje >= 0 AndAlso porcentaje <= 15 Then
                            materialesFaltantes.Add($"- {nombreMaterial} ({porcentaje}%)")
                        End If
                    End If

                Catch ex As Exception
                    ' Ignorar errores individuales de fila
                End Try
            Next

            ' Mostrar resultados
            If materialesFaltantes.Count > 0 Then
                Dim mensaje As String = "Los siguientes materiales tienen bajo stock (<20%):" & vbCrLf & String.Join(vbCrLf, materialesFaltantes)
                MessageBox.Show(mensaje, "Materiales con bajo stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return True
            Else
                MessageBox.Show("No hay materiales con poco stock.", "Stock suficiente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("No hay materiales en el inventario" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function PintarFilasSegunStock() As Boolean
        Dim cultura As CultureInfo = New CultureInfo("es-CL")

        Try
            ' Obtener todo el inventario desde Firebase
            Dim respuesta = client.Get("Proyectos/" & IdentifyProject & "/Inventario")

            If respuesta.Body Is Nothing OrElse respuesta.Body.Trim() = "null" Then
                MessageBox.Show("el inventario se encuentra vacio")
                Return False
            End If

            Dim inventarioData As JObject = JObject.Parse(respuesta.Body)

            ' Recorrer cada fila del DataGridView
            For Each fila As DataGridViewRow In DataGridView1.Rows
                If fila.IsNewRow Then Continue For

                Try
                    Dim nombreMaterial As String = fila.Cells(1).Value?.ToString()
                    Dim cantidadStr As String = fila.Cells(2).Value?.ToString()
                    Dim stockMaxStr As String = Nothing

                    ' Buscar stock_max del material en Firebase
                    For Each item As KeyValuePair(Of String, JToken) In inventarioData
                        Dim nombreEnFirebase As String = item.Value("material")?.ToString()

                        If nombreEnFirebase = nombreMaterial Then
                            stockMaxStr = item.Value("stock_max")?.ToString()
                            Exit For
                        End If
                    Next

                    ' Si encontró el stock_max, calcular porcentaje y pintar fila
                    If stockMaxStr IsNot Nothing Then
                        Dim porcentaje As Integer = CalcularPorcentajeStock(cantidadStr, stockMaxStr)

                        If porcentaje <= 60 Then
                            fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200) ' amarillo claro
                        End If

                        If porcentaje <= 15 Then
                            fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200) ' rojo claro
                        End If

                    End If

                Catch ex As Exception
                    ' Ignorar errores por fila individual
                End Try
            Next

            Return True

        Catch ex As Exception
            MessageBox.Show("Error al pintar filas por stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        FiltrarInventario(txt_buscar.Text)
    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        VerificarMaterialesBajoStockD()
    End Sub
End Class