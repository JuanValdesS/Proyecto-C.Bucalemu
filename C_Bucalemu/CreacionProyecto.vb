Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Newtonsoft.Json
Public Class CreacionProyecto

    Dim client As IFirebaseClient

    Private Sub btn_regresar_Click(sender As Object, e As EventArgs) Handles btn_regresar.Click
        Dim Log As New Login()

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

        ' Cargar usuarios al ComboBox
        Await CargarUsuarios()

    End Sub

    Private Sub btn_crear_Click(sender As Object, e As EventArgs) Handles btn_crear.Click
        Dim nombreProyecto As String = txt_nombre.Text.Trim()
        Dim personal As String = cmb_personal.Text.Trim()
        Dim descripcion As String = txt_descripcion.Text.Trim()

        ' Validar campos
        If nombreProyecto = "" OrElse descripcion = "" Then
            MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Verificar si ya existe el proyecto
        Dim response As FirebaseResponse = client.Get("Proyectos/" & nombreProyecto)
        If response.Body <> "null" Then
            MessageBox.Show("Ya existe un proyecto con este nombre. Usa otro.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Crear objeto de proyecto
        Dim proyecto As New Dictionary(Of String, Object) From {
            {"Nombre", nombreProyecto},
            {"Personal", personal},
            {"Descripción", descripcion}
        }

        ' Guardar los datos base del proyecto
        client.Set("Proyectos/" & nombreProyecto & "/Info", proyecto)

        ' Crear las subclases vacías
        client.Set("Proyectos/" & nombreProyecto & "/Compras", New Dictionary(Of String, Object)())
        client.Set("Proyectos/" & nombreProyecto & "/Inventario", New Dictionary(Of String, Object)())
        client.Set("Proyectos/" & nombreProyecto & "/Reportes", New Dictionary(Of String, Object)())

        MessageBox.Show("Proyecto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Volver al formulario principal
        Dim frm As New Proyectos()
        Me.Close()
        frm.Show()
    End Sub
    Private Async Function CargarUsuarios() As Task
        Try
            Dim response As FirebaseResponse = Await client.GetAsync("Usuarios")
            If response.Body = "null" Then
                MessageBox.Show("No hay usuarios disponibles.")
                Return
            End If

            Dim usuariosDict As Dictionary(Of String, Dictionary(Of String, String)) =
            JsonConvert.DeserializeObject(Of Dictionary(Of String, Dictionary(Of String, String)))(response.Body)

            cmb_personal.Items.Clear()
            For Each user In usuariosDict.Values
                If user.ContainsKey("Usuario") Then
                    cmb_personal.Items.Add(user("Usuario"))
                End If
            Next

            If cmb_personal.Items.Count > 0 Then
                cmb_personal.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar usuarios: " & ex.Message)
        End Try
    End Function

End Class