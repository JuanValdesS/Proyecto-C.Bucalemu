Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class CreacionProyecto

    Dim client As IFirebaseClient

    Private Sub btn_regresar_Click(sender As Object, e As EventArgs) Handles btn_regresar.Click
        Dim Log As New Proyectos()

        Me.Close()
        Log.Show()
    End Sub

    Private Async Sub CreacionProyecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim config As New FirebaseConfig() With {
            .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
            .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
        }
        client = New FireSharp.FirebaseClient(config)

        If client Is Nothing Then
            MessageBox.Show("Error de conexión con Firebase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'configurar el datagrid'
        ConfigurarEstiloDataGridView()
        ' Cargar usuarios al ComboBox
        Await CargarUsuarios()

    End Sub

    Private Sub btn_crear_Click(sender As Object, e As EventArgs) Handles btn_crear.Click

        Dim nombreProyecto = txt_nombre.Text.Trim
        Dim encargado = cmb_encargado.Text.Trim
        Dim descripcion = txt_descripcion.Text.Trim

        ' Validar campos
        If nombreProyecto = "" OrElse descripcion = "" OrElse encargado = "" Then
            MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validar que haya al menos un usuario agregado al proyecto
        If dg_personal.Rows.Count = 0 Then
            MessageBox.Show("Debe agregar al menos un usuario al proyecto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Verificar si ya existe el proyecto
        Dim proyectosResponse = client.Get("Proyectos")
        Dim proyectosExistentes = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(proyectosResponse.Body)
        Dim maxId = 0
        If proyectosExistentes IsNot Nothing Then
            For Each kvp In proyectosExistentes
                Dim claveProyecto = kvp.Key ' Ejemplo: Proyecto_1

                ' Extraer número de ID
                If claveProyecto.StartsWith("Proyecto_") Then
                    Dim idNumericoStr = claveProyecto.Replace("Proyecto_", "")
                    Dim idNumerico As Integer
                    If Integer.TryParse(idNumericoStr, idNumerico) Then
                        If idNumerico > maxId Then maxId = idNumerico
                    End If
                End If

                ' Validar que el nombre no exista repetido
                Dim datosProyecto = JObject.Parse(kvp.Value.ToString)
                If datosProyecto("Info") IsNot Nothing AndAlso datosProyecto("Info")("Nombre") IsNot Nothing Then
                    If datosProyecto("Info")("Nombre").ToString.ToLower = nombreProyecto.ToLower Then
                        MessageBox.Show("Ya existe un proyecto con este nombre. Usa otro.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End If
            Next
        End If

        ' Generar el nuevo ID secuencial
        Dim nuevoId = maxId + 1
        Dim idProyecto = "Proyecto_" & nuevoId

        ' Crear objeto de proyecto
        Dim infoProyecto As New Dictionary(Of String, Object) From {
        {"Nombre", nombreProyecto},
        {"Encargado", encargado},
        {"Descripción", descripcion}
    }

        ' Guardar la información principal
        client.Set("Proyectos/" & idProyecto & "/Info", infoProyecto)

        ' Crear las subcategorías vacías
        client.Set("Proyectos/" & idProyecto & "/Compras", New Dictionary(Of String, Object))
        client.Set("Proyectos/" & idProyecto & "/Inventario", New Dictionary(Of String, Object))
        client.Set("Proyectos/" & idProyecto & "/Reportes", New Dictionary(Of String, Object))

        For Each fila As DataGridViewRow In dg_personal.Rows
            If Not fila.IsNewRow Then
                Dim usuario = fila.Cells("usuario").Value.ToString.Trim
                Dim Email = fila.Cells("Email").Value.ToString.Trim

                ' Saneamiento para usar en la ruta de Firebase
                Dim claveUsuario = usuario.Replace(".", "_").Replace("@", "_at_")

                Dim datosPersonal As New Dictionary(Of String, Object) From {
                {"usuario", usuario},   ' se guarda el original
                {"Email", Email}
            }

                client.Set("Proyectos/" & idProyecto & "/Personal_autorizado/" & claveUsuario, datosPersonal)
            End If
        Next

        ' Mensaje de éxito
        MessageBox.Show("Proyecto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Volver al formulario principal
        Dim frm As New Proyectos
        Close()
        frm.Show()

    End Sub
    Private Async Function CargarUsuarios() As Task

        Try
            ' Obtener todos los usuarios desde Firebase
            Dim response As FirebaseResponse = Await client.GetAsync("Usuarios")

            ' Verifica si no hay datos
            If response.Body = "null" Then
                MessageBox.Show("No hay usuarios disponibles.")
                Return
            End If

            ' Convertimos la respuesta JSON a un diccionario anidado
            Dim usuariosDict As Dictionary(Of String, Dictionary(Of String, String)) =
            JsonConvert.DeserializeObject(Of Dictionary(Of String, Dictionary(Of String, String)))(response.Body)

            ' Limpiamos ambos ComboBox antes de llenarlos
            cmb_encargado.Items.Clear()
            cmb_personal.Items.Clear()

            ' Recorremos cada usuario
            For Each user In usuariosDict.Values
                ' Agregamos todos al ComboBox de personal (independiente del rol)
                If user.ContainsKey("Usuario") Then
                    cmb_personal.Items.Add(user("Usuario"))
                End If

                ' Agregamos solo los administradores al ComboBox de encargado
                If user.ContainsKey("Rol") AndAlso user("Rol") = "Jefe" AndAlso user.ContainsKey("Usuario") Then
                    cmb_encargado.Items.Add(user("Usuario"))
                End If

            Next

            ' Seleccionamos el primer elemento de cada ComboBox si tienen ítems
            If cmb_encargado.Items.Count > 0 Then
                cmb_encargado.SelectedIndex = 0
            End If

            If cmb_personal.Items.Count > 0 Then
                cmb_personal.SelectedIndex = 0
            End If

        Catch ex As Exception
            ' Si algo falla, mostramos un mensaje de error
            MessageBox.Show("Error al cargar usuarios: " & ex.Message)
        End Try

    End Function

    Private Sub btn_ingresar_Click(sender As Object, e As EventArgs) Handles btn_ingresar.Click

        Dim nombreSeleccionado As String = cmb_personal.SelectedItem?.ToString()

        If String.IsNullOrEmpty(nombreSeleccionado) Then
            MessageBox.Show("Selecciona un usuario.")
            Exit Sub
        End If

        ' Verificar si el usuario ya está en el DataGridView
        For Each fila As DataGridViewRow In dg_personal.Rows
            If Not fila.IsNewRow AndAlso fila.Cells("Usuario").Value.ToString() = nombreSeleccionado Then
                MessageBox.Show("El usuario ya fue ingresado al proyecto.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmb_personal.Focus()
                Exit Sub
            End If
        Next

        Try
            ' Obtener todos los usuarios
            Dim response As FirebaseResponse = client.Get("Usuarios")

            If response.Body = "null" Then
                MessageBox.Show("No se encontraron usuarios.")
                Exit Sub
            End If

            ' Deserializar la respuesta
            Dim usuariosDict As Dictionary(Of String, Dictionary(Of String, String)) =
            JsonConvert.DeserializeObject(Of Dictionary(Of String, Dictionary(Of String, String)))(response.Body)

            ' Buscar al usuario por nombre
            For Each usuario In usuariosDict.Values
                If usuario.ContainsKey("Usuario") AndAlso usuario("Usuario") = nombreSeleccionado Then
                    Dim correo As String = If(usuario.ContainsKey("Email"), usuario("Email"), "No disponible")
                    Dim rol As String = If(usuario.ContainsKey("Rol"), usuario("Rol"), "No disponible")

                    ' Agregar fila al DataGridView
                    Dim numeroFila As Integer = dg_personal.Rows.Count + 1
                    dg_personal.Rows.Add("", nombreSeleccionado, correo, rol)
                    RenumerarFilas()

                    Exit For
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error al agregar usuario: " & ex.Message)
        End Try

    End Sub

    Private Sub ConfigurarEstiloDataGridView()

        With dg_personal
            .Columns.Clear()
            .Columns.Add("N", "N°")
            .Columns.Add("Usuario", "Usuario")
            .Columns.Add("Email", "Email")
            .Columns.Add("Rol", "Rol")
        End With

        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With dg_personal
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
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True

            ' Cambiar estilo del grid
            .BorderStyle = BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Private Sub RenumerarFilas()
        For i As Integer = 0 To dg_personal.Rows.Count - 1
            dg_personal.Rows(i).Cells("N").Value = (i + 1).ToString()
        Next
    End Sub
    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        If dg_personal.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmacion As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmacion = DialogResult.Yes Then
            dg_personal.Rows.Remove(dg_personal.SelectedRows(0))
        End If
    End Sub

End Class