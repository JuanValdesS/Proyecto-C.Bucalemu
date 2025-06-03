Imports System.IO
Imports System.Xml
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class Proyectos

    Public Property nombre As String
    Public Property Descripción As String
    Public Property encargado As String

    ' Cliente Firebase
    Private client As IFirebaseClient

    Public IdProyectoActual As String

    Private Sub btn_ingresar_Click(sender As Object, e As EventArgs) Handles btn_ingresar.Click

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor selecciona un proyecto antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Obtener nombre del proyecto seleccionado
        Dim nombreProyecto = DataGridView1.CurrentRow.Cells("Nombre").Value.ToString()
        Dim IdProyecto = DataGridView1.CurrentRow.Cells("ID Proyecto").Value.ToString()

        ' Guardar el nombre globalmente
        IdentifyProject = IdProyecto

        ' Crear el formulario Menú, pasándole el proyecto
        If VerificarAccesoProyecto() Then
            Dim men As New Menú
            Me.Close()
            men.Show()
        Else
            MsgBox("No tienes permisos para ingresar a este proyecto.", MsgBoxStyle.Critical, "Acceso Denegado")
        End If

    End Sub

    Private Sub btn_crear_Click(sender As Object, e As EventArgs) Handles btn_crear.Click
        Dim crea As New CreacionProyecto()

        Me.Close()
        crea.Show()
    End Sub

    Private Sub Proyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Conexión a Firebase
        Dim config As New FirebaseConfig With {
            .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
            .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
        }

        client = New FireSharp.FirebaseClient(config)

        'Ocultar botones'
        btn_crear.Visible = False
        btnGestionarInventario.Visible = False
        btn_eliminar.Visible = False

        ' Obtener el rol del usuario autenticado
        Dim rolUsuario As String = My.Settings.RolUsuario

        ' Mostrar el botón solo si el usuario es Administrador
        If rolUsuario = "Administrador" Then
            btn_eliminar.Visible = True
            btn_crear.Visible = True
            btnGestionarInventario.Visible = True
        End If

        If client Is Nothing Then
            MessageBox.Show("Error al conectar con Firebase")
            Return
        End If

        ' Verificar y crear clase raíz "Proyectos" si no existe
        Dim response = client.Get("Proyectos")
        If response.Body = "null" Then
            client.Set("Proyectos", New Dictionary(Of String, Object))
        End If

        ' Cargar proyectos en DataGridView
        ConfigurarEstiloDataGridView()
        CargarProyectos()
    End Sub
    Private Sub CargarProyectos()
        Try
            ' Limpia el DataGridView para evitar datos viejos
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            Dim response As FirebaseResponse = client.Get("Proyectos")

            If response.Body <> "null" Then
                Dim proyectosDict As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response.Body)
                Dim dt As New DataTable()

                ' Columnas a mostrar en el DataGridView
                dt.Columns.Add("ID Proyecto")
                dt.Columns.Add("Nombre")
                dt.Columns.Add("Descripción")
                dt.Columns.Add("Encargado")

                For Each proyectoKey In proyectosDict.Keys
                    Dim infoResponse As FirebaseResponse = client.Get("Proyectos/" & proyectoKey & "/Info")
                    If infoResponse.Body <> "null" Then
                        Dim proyecto As Proyectos = JsonConvert.DeserializeObject(Of Proyectos)(infoResponse.Body)
                        dt.Rows.Add(proyectoKey, proyecto.nombre, proyecto.Descripción, proyecto.encargado)
                    End If
                Next

                DataGridView1.DataSource = dt
            Else
                MsgBox("No se encontraron proyectos.", MsgBoxStyle.Information, "No hay proyectos")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar proyectos: " & ex.Message)
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
    Private Function VerificarAccesoProyecto() As Boolean
        Try
            ' Saneamos el nombre de usuario antes de buscarlo en Firebase
            'Dim usuarioSaneado As String = UsuarioRegistrado '.Replace(".", "_").Replace("@", "_at_")
            Dim correoUsuario As String = UsuarioRegistrado.Trim().ToLower() ' Aseguramos formato uniforme

            Dim TipoIngreso As String
            'define si ingresamos con un usuario o con un email
            If correoUsuario.Contains("@") Then
                TipoIngreso = "Email"

            Else
                TipoIngreso = "Usuario"
            End If

            Dim path As String = $"Proyectos/{IdentifyProject}/Personal_autorizado"
            Dim response As FirebaseResponse = client.Get(path)

            If response.Body = "null" Then

                Return False
            End If

            ' compara por el mail
            If TipoIngreso = "Email" Then
                Dim personalAutorizado As Dictionary(Of String, JObject) =
                JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(response.Body)
                For Each entry In personalAutorizado
                    Dim datosUsuario As JObject = entry.Value
                    Dim email As String = datosUsuario("Email")?.ToString().Trim().ToLower() ' Aseguramos formato uniforme
                    If email = correoUsuario Then
                        Return True
                    End If
                Next
                'compara por el usuario
            Else
                Dim usuarioSaneado As String = UsuarioRegistrado.Replace(".", "_").Replace("@", "_at_")

                Dim personalAutorizado As Dictionary(Of String, Object) =
                JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response.Body)
                For Each key In personalAutorizado.Keys

                    key = key.Trim().ToLower()
                    If key = usuarioSaneado Then
                        Return True
                    End If
                Next

            End If

            Return False

        Catch ex As Exception
            MessageBox.Show("Error al verificar acceso: " & ex.Message)
            Return False
        End Try
    End Function


    Private Sub btnInventario_Click(sender As Object, e As EventArgs) Handles btnInventario.Click
        Dim Inventario As New InventarioGlobal()

        Me.Close()
        Inventario.Show()
    End Sub

    Private Sub btnGestionarInventario_Click(sender As Object, e As EventArgs) Handles btnGestionarInventario.Click
        Dim Modificar_material As New GestionarInventarioGlobal()
        Me.Close()
        Modificar_material.Show()
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor selecciona un proyecto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim nombreProyecto = DataGridView1.CurrentRow.Cells("Nombre").Value.ToString
        Dim idProyecto = DataGridView1.CurrentRow.Cells("ID Proyecto").Value.ToString

        Dim result = MessageBox.Show($"¿Estás seguro de que deseas eliminar el proyecto '{nombreProyecto}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim deleteResponse = client.Delete("Proyectos/" & idProyecto)

                If deleteResponse.StatusCode = Net.HttpStatusCode.OK Then
                    MessageBox.Show("Proyecto eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarProyectos() ' Actualiza el DataGridView
                Else
                    MessageBox.Show("Error al eliminar el proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al eliminar el proyecto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim sh As New Login()
        ' Mostrar cuadro de mensaje con opciones Sí y No
        Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Si el usuario selecciona "Sí", proceder a redirigir al login
        If resultado = DialogResult.Yes Then
            Me.Close() ' Oculta el formulario actual
            sh.Show() ' Muestra el formulario de login
        End If
    End Sub
End Class