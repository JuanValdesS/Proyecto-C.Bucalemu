Imports System.Globalization
Imports Newtonsoft.Json.Linq

Public Class GestionarInventarioGlobal

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
    }

    Private client As FireSharp.Interfaces.IFirebaseClient
    Private Sub GestionarInventarioGlobal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Puede ir lógica adicional si es necesario
        Try
            client = New FireSharp.FirebaseClient(fcon)

            If client IsNot Nothing Then
                CargarInventario()
            Else
                MsgBox("Error al conectar con la base de datos", MsgBoxStyle.Critical)
            End If

            ' Obtener el rol del usuario autenticado
            Dim rolUsuario As String = My.Settings.RolUsuario

            ' Mostrar el botón solo si el usuario es Administrador
            If My.Settings.RolUsuario = "Jefe" Or My.Settings.RolUsuario = "Encargado del inventario" Then


            End If

        Catch ex As Exception
            MsgBox("Error de conexión: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        ' Agregar "OTRO" al final
        If Not txtbox1.Items.Contains("OTRO") Then
            txtbox1.Items.Add("OTRO")
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

                dgvInventario.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgvInventario.Columns("Cantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgvInventario.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

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

    Private Sub btn_retirar_Click(sender As Object, e As EventArgs) Handles btn_retirar.Click
        If My.Settings.RolUsuario = "Jefe" Or My.Settings.RolUsuario = "Encargado del inventario" Then
            Try
                ' Verifica que haya una fila seleccionada
                If dgvInventario.SelectedRows.Count = 0 Then
                    MsgBox("Seleccione un material desde la tabla para retirar.", MsgBoxStyle.Exclamation, "Informacion")
                    Exit Sub
                End If

                Dim selectedRow As DataGridViewRow = dgvInventario.SelectedRows(0)
                Dim nombre As String = selectedRow.Cells("Nombre").Value.ToString()
                Dim unidades As String = selectedRow.Cells("Unidad").Value.ToString()

                ' Pregunta la cantidad que desea retirar
                Dim input As String = InputBox("Ingrese la cantidad que desea retirar del material """ & nombre & """ (" & unidades & "):", "Retirar material", "0", MsgBoxStyle.Information)
                If String.IsNullOrWhiteSpace(input) Then Exit Sub

                Dim cantidadRetirar As Double
                If Not Double.TryParse(input.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, cantidadRetirar) OrElse cantidadRetirar <= 0 Then
                    MsgBox("Cantidad inválida.", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                End If

                Dim response = client.Get("Inventario/")
                If response.Body = "null" Then
                    MsgBox("No hay inventario disponible.", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                Dim inventarioJson As JObject = JObject.Parse(response.Body)
                Dim materialesFiltrados = New List(Of KeyValuePair(Of String, Dictionary(Of String, Object)))()

                ' Buscar todos los registros del material con mismo nombre y unidad
                For Each item As JProperty In inventarioJson.Properties()
                    Dim datos As Dictionary(Of String, Object) = item.Value.ToObject(Of Dictionary(Of String, Object))()
                    If datos("material").ToString() = nombre AndAlso datos("unidad").ToString() = unidades Then
                        materialesFiltrados.Add(New KeyValuePair(Of String, Dictionary(Of String, Object))(item.Name, datos))
                    End If
                Next

                If materialesFiltrados.Count = 0 Then
                    MsgBox("No se encontraron registros del material en esa unidad.", MsgBoxStyle.Information, "Advertencia")
                    Exit Sub
                End If

                ' Ordenar por fecha de ingreso (más antiguo primero)
                materialesFiltrados = materialesFiltrados.OrderBy(Function(m) DateTime.Parse(m.Value("fecha").ToString())).ToList()

                ' Calcular stock total
                Dim stockTotal As Double = materialesFiltrados.Sum(Function(m) CDbl(m.Value("cantidad").ToString()))

                If cantidadRetirar > stockTotal Then
                    Dim result = MsgBox("La cantidad solicitada excede el stock actual (" & stockTotal & "). ¿Desea retirar la cantidad disponible?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
                    If result = MsgBoxResult.No Then Exit Sub
                End If

                ' Iniciar proceso de retiro
                Dim cantidadPorRetirar = cantidadRetirar

                For Each item In materialesFiltrados
                    Dim key = item.Key
                    Dim datos = item.Value
                    Dim cantidadDisponible As Double = CDbl(datos("cantidad").ToString())

                    If cantidadPorRetirar >= cantidadDisponible Then
                        ' Eliminar el registro completamente
                        client.Delete("Inventario/" & key)
                        cantidadPorRetirar -= cantidadDisponible
                    Else
                        ' Actualizar con nueva cantidad
                        datos("cantidad") = cantidadDisponible - cantidadPorRetirar
                        client.Update("Inventario/" & key, datos)
                        cantidadPorRetirar = 0
                    End If

                    If cantidadPorRetirar = 0 Then Exit For
                Next

                MsgBox("Material retirado correctamente.", MsgBoxStyle.Information, "Éxito")
                CargarInventario()

            Catch ex As Exception
                MsgBox("Error al retirar material: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            MsgBox("No tienes permisos para realizar esta acción.", MsgBoxStyle.Exclamation, "Advertencia")
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If My.Settings.RolUsuario = "Encargado del inventario " Or My.Settings.RolUsuario = "Jefe" Then

            Try
                Dim nombre = txtbox1.Text
                ' Capturar los datos del material
                Dim cantidad As Decimal = nCantidad.Value
                ' Obtener la fecha y hora actuales en formato adecuado
                Dim fechaIngreso = Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
                Dim unidades = ComboBox1.Text

                ' Verificar si se seleccionó "Otro" en el ComboBox
                If nombre = "OTRO" Then
                    nombre = txtMaterial.Text.Trim
                    txtbox1.Items.Add(nombre)
                End If

                ' Validar que los campos no estén vacíos
                If String.IsNullOrWhiteSpace(nombre) OrElse String.IsNullOrWhiteSpace(cantidad) OrElse String.IsNullOrWhiteSpace(unidades) Then
                    MsgBox("Por favor, ingrese nombre, cantidad del material y su unidad", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                ' Verificar si client está inicializado
                If client Is Nothing Then
                    MsgBox("No hay conexión con la base de datos.", MsgBoxStyle.Critical, "error")
                    Exit Sub
                End If

                ' Obtener la cantidad de materiales en Firebase para generar el número consecutivo
                Dim response = client.Get("Inventario")
                Dim inventario As Dictionary(Of String, Object) = If(response.Body <> "null", response.ResultAs(Of Dictionary(Of String, Object)), New Dictionary(Of String, Object)())

                ' Contar cuántos materiales con el mismo nombre ya existen en Firebase
                Dim contador As Integer = 0
                For Each item In inventario
                    Dim datosMaterial As Dictionary(Of String, Object) = CType(Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(item.Value.ToString()), Dictionary(Of String, Object))
                    ' Si el nombre coincide, aumentar el contador
                    If datosMaterial.ContainsKey("material") AndAlso datosMaterial("material").ToString() = nombre Then
                        contador += 1
                    End If
                Next

                ' Normalizar el nombre quitando espacios
                Dim nombreId As String = nombre.Replace(" ", "").ToUpper()
                ' Obtener número consecutivo formateado
                Dim nuevoNumero As String = (contador + 1).ToString("D4")
                ' Crear ID final tipo: TORNILLO3MM_0001
                Dim materialId = nombreId & "_" & nuevoNumero

                ' Crear el objeto con los datos
                Dim material As New Dictionary(Of String, Object) From {
                    {"material", nombre},
                    {"cantidad", cantidad},
                    {"unidad", unidades},
                    {"fecha", fechaIngreso}
                }

                ' Guardar en Firebase con el nuevo ID
                client.Set("Inventario/" & materialId, material)
                ' Mostrar mensaje de éxito
                MsgBox("Material agregado correctamente", MsgBoxStyle.Information, "Éxito")

                'Limpiamos los campos
                txtbox1.Text = ""
                nCantidad.Value = 0
                txtMaterial.Clear()
                ComboBox1.Text = ""

                ' Recargar el inventario después de agregar un dato
                CargarInventario()

            Catch ex As Exception
                MsgBox("Error al agregar material: " & ex.Message, MsgBoxStyle.Critical, "error")
            End Try
        Else
            'Limpiamos los campos
            txtbox1.Text = ""
            nCantidad.Value = 0
            txtMaterial.Clear()
            ComboBox1.Text = ""

            MsgBox("No tienes permisos para realizar esta acción.", MsgBoxStyle.Exclamation, "Acceso denegado")
        End If
    End Sub
    Private Sub txtbox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtbox1.SelectedIndexChanged
        If txtbox1.Text = "OTRO" Then
            txtMaterial.Visible = True
        Else
            txtMaterial.Visible = False
        End If
    End Sub
    Private Sub txtMaterial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaterial.KeyPress
        ' Convertir el carácter presionado a mayúscula
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Convertir el carácter presionado a mayúscula
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        ' Convertir el carácter presionado a mayúscula
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub btn_regresar_Click(sender As Object, e As EventArgs) Handles btn_regresar.Click
        cerrarTodo = False

        Dim invglo As New InventarioGlobal()
        Me.Close()
        invglo.Show()
    End Sub

    Private Sub GestionarInventarioGlobal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cerrarTodo AndAlso e.CloseReason = CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub
End Class