Imports Newtonsoft.Json.Linq

Public Class mod_material

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
}

    Private client As FireSharp.Interfaces.IFirebaseClient
    Private Sub Modificar_material_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nMedidas.Visible = False
        cbMedida.Visible = False
        txtMaterial.Visible = False
        lbl_medida.Visible = False

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

        'Agrega datos al combobox mediante try
        Try
            Dim response = client.Get("Inventario")
            If response.Body <> "null" Then
                Dim inventario As Dictionary(Of String, Object) = response.ResultAs(Of Dictionary(Of String, Object))

                ' Llenar el ComboBox con los materiales
                txtbox1.Items.Clear()

                ' Lista para almacenar materiales únicos
                Dim materialesUnicos As New HashSet(Of String)

                ' Recorrer cada material en el inventario y agregar su nombre al ComboBox
                For Each item In inventario
                    Dim datosMaterial As Dictionary(Of String, Object) = CType(Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(item.Value.ToString()), Dictionary(Of String, Object))

                    ' Agregar el nombre del material si existe en el registro
                    If datosMaterial.ContainsKey("Material") Then
                        materialesUnicos.Add(datosMaterial("Material").ToString())
                    End If
                Next

                ' Agregar materiales únicos al ComboBox
                For Each material In materialesUnicos
                    txtbox1.Items.Add(material)
                Next

            End If

        Catch ex As Exception
            MsgBox("Error al cargar materiales: " & ex.Message)
        End Try

        ' Agregar "OTRO" al final
        If Not txtbox1.Items.Contains("OTRO") Then
            txtbox1.Items.Add("OTRO")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If My.Settings.RolUsuario = "Administrador" Or My.Settings.RolUsuario = "Jefe" Then

            Try
                Dim nombre = txtbox1.Text
                ' Capturar los datos del material
                Dim cantidad = nCantidad.Value
                ' Obtener la fecha y hora actuales en formato adecuado
                Dim fechaIngreso = Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
                Dim unidades = ComboBox1.Text

                ' Verificar si se seleccionó "Otro" en el ComboBox
                If nombre = "OTRO" Then
                    nombre = txtMaterial.Text.Trim
                    txtbox1.Items.Add(nombre)
                End If

                'Agrega la medida al nombre si es que este no esta vacío
                If CheckBox1.Checked Then
                    nombre = (nombre & " " & nMedidas.Text & cbMedida.Text).ToUpper()
                    If String.IsNullOrWhiteSpace(nMedidas.Text) OrElse String.IsNullOrWhiteSpace(cbMedida.Text) Then
                        MsgBox("Por favor, ingrese la medida del material", MsgBoxStyle.Exclamation, "Advertencia")
                        Exit Sub
                    End If

                    Dim medidaFormateada As String = nMedidas.Text.Trim() & cbMedida.Text.Trim()

                    ' Verifica si ya contiene la medida para evitar duplicados
                    If Not nombre.ToUpper().Contains(medidaFormateada.ToUpper()) Then
                        nombre &= " " & medidaFormateada
                    End If

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
                    If datosMaterial.ContainsKey("Material") AndAlso datosMaterial("Material").ToString() = nombre Then
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
                    {"Material", nombre},
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
                nMedidas.Clear()
                cbMedida.Text = ""
                CheckBox1.Checked = False

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
            nMedidas.Clear()
            cbMedida.Text = ""
            CheckBox1.Checked = False

            MsgBox("No tienes permisos para realizar esta acción.", MsgBoxStyle.Exclamation, "Acceso denegado")
        End If

    End Sub

    Private Sub btn_retirar_Click(sender As Object, e As EventArgs) Handles btn_retirar.Click

        If My.Settings.RolUsuario = "Administrador" Or My.Settings.RolUsuario = "Jefe" Then

            Try
                Dim nombre = txtbox1.Text.Trim()
                ' Capturar los datos del material
                Dim cantidadSolicitada As Integer
                Dim unidades As String = ComboBox1.Text.Trim()

                ' Verificar si la cantidad ingresada es un número válido
                If Not Integer.TryParse(nCantidad.Text.Trim(), cantidadSolicitada) OrElse cantidadSolicitada <= 0 Then
                    MsgBox("Ingrese una cantidad válida para retirar.", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                ' Verificar que se haya ingresado un nombre y una unidad
                If String.IsNullOrWhiteSpace(nombre) OrElse String.IsNullOrWhiteSpace(unidades) Then
                    MsgBox("Por favor, ingrese nombre del material y seleccione una unidad.", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                ' Verificar si se seleccionó "Otro" en el ComboBox
                If nombre = "OTRO" Then
                    MsgBox("La selección 'OTRO' no es valida para esta opción, por favor, ingrese otra", MsgBoxStyle.Information, "Advertencia")
                    txtbox1.Text = ""
                    txtbox1.Focus()
                    Exit Sub
                End If

                ' Verificar si client está inicializado
                If client Is Nothing Then
                    MsgBox("No hay conexión con la base de datos.", MsgBoxStyle.Critical, "error")
                    Exit Sub
                End If

                ' Obtener todos los materiales de Firebase
                Dim response = client.Get("Inventario")
                If response.Body = "null" Then
                    MsgBox("No hay materiales en el inventario.", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                Dim inventarioJson As JObject = JObject.Parse(response.Body)
                Dim inventario As New Dictionary(Of String, Object)

                For Each item As JProperty In inventarioJson.Properties()
                    Dim materialData As Dictionary(Of String, Object) = item.Value.ToObject(Of Dictionary(Of String, Object))()
                    inventario.Add(item.Name, materialData)
                Next

                Dim materialesFiltrados = New List(Of KeyValuePair(Of String, Dictionary(Of String, Object)))()

                ' Filtrar materiales por nombre y unidad
                For Each item In inventario
                    Dim materialData As Dictionary(Of String, Object) = CType(item.Value, Dictionary(Of String, Object))
                    If materialData("Material").ToString() = nombre AndAlso materialData("unidad").ToString() = unidades Then
                        materialesFiltrados.Add(New KeyValuePair(Of String, Dictionary(Of String, Object))(item.Key, materialData))
                    End If
                Next

                ' Si no se encontró el material con la unidad específica
                If materialesFiltrados.Count = 0 Then
                    MsgBox("No hay stock del material en la unidad seleccionada.", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                ' Ordenar los materiales por fecha de ingreso (el más antiguo primero)
                materialesFiltrados.Sort(Function(a, b) DateTime.Parse(a.Value("fecha").ToString()).CompareTo(DateTime.Parse(b.Value("fecha").ToString())))

                ' Calcular el total disponible
                Dim cantidadDisponible As Integer = materialesFiltrados.Sum(Function(m) CInt(m.Value("cantidad")))

                ' Si la cantidad solicitada es mayor a la disponible, preguntar al usuario
                If cantidadSolicitada > cantidadDisponible Then
                    Dim respuesta As MsgBoxResult
                    respuesta = MsgBox("Solo hay " & cantidadDisponible & " disponibles. ¿Desea retirar lo disponible?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Stock insuficiente")

                    If respuesta = MsgBoxResult.Yes Then
                        cantidadSolicitada = cantidadDisponible ' Asignar la cantidad disponible
                    Else
                        Exit Sub ' No realiza la operación si el usuario elige "No"
                    End If
                End If

                ' Retirar la cantidad solicitada
                Dim cantidadRestante = cantidadSolicitada
                For Each material In materialesFiltrados
                    Dim id As String = material.Key
                    Dim materialData As Dictionary(Of String, Object) = material.Value
                    Dim stockDisponible As Integer = Convert.ToInt32(materialData("cantidad"))

                    If cantidadRestante <= 0 Then
                        Exit For
                    End If

                    If stockDisponible <= cantidadRestante Then
                        ' Si el stock disponible es menor o igual a lo que se quiere retirar, eliminarlo completamente
                        client.Delete("Inventario/" & id)
                        cantidadRestante -= stockDisponible
                    Else
                        ' Si hay más stock del necesario, solo reducir la cantidad
                        materialData("cantidad") = stockDisponible - cantidadRestante
                        client.Update("Inventario/" & id, materialData)
                        cantidadRestante = 0
                    End If
                Next

                ' Mensaje de éxito
                MsgBox("Material retirado correctamente.", MsgBoxStyle.Information, "Éxito")

                ' Limpiar campos
                txtbox1.Text = ""
                nCantidad.Value = 0
                ComboBox1.Text = ""

                ' Recargar el inventario después de retirar material
                CargarInventario()

            Catch ex As Exception
                MsgBox("Error al retirar material: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

        Else

            'Limpiamos los campos
            txtbox1.Text = ""
            nCantidad.Value = 0
            txtMaterial.Clear()
            ComboBox1.Text = ""
            nMedidas.Clear()
            cbMedida.Text = ""
            CheckBox1.Checked = False

            MsgBox("No tienes permisos para realizar esta acción.", MsgBoxStyle.Exclamation, "Acceso denegado")
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
                    DataGridView1.Rows.Add(contador, material("nombre"), material("cantidad"), material("unidad"), material("fecha"))
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

    Private Sub txtMaterial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaterial.KeyPress
        ' Convertir el carácter presionado a mayúscula
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Convertir el carácter presionado a mayúscula
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub btn_regresar_Click(sender As Object, e As EventArgs) Handles btn_regresar.Click
        Dim sh As New Menú()
        Me.Close()
        sh.Show()
    End Sub

    Private Sub txtbox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtbox1.SelectedIndexChanged
        If txtbox1.Text = "OTRO" Then
            txtMaterial.Visible = True
        Else
            txtMaterial.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim inven As New Inventario()

        inven.Show()
        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            nMedidas.Visible = True
            cbMedida.Visible = True
            lbl_medida.Visible = True
        Else
            nMedidas.Visible = False
            cbMedida.Visible = False
            lbl_medida.Visible = False
        End If
    End Sub

End Class