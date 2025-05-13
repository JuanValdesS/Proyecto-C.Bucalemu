Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class Login

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
}

    Private client As FireSharp.Interfaces.IFirebaseClient

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try
            ' Capturar datos ingresados por el usuario
            Dim email = txtUsuario.Text
            Dim password = txtPassword.Text

            ' Validar que los campos no estén vacíos
            If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(password) Then
                MsgBox("Por favor, ingrese su email y contraseña.", MsgBoxStyle.Exclamation, "Adverterncia")
                Exit Sub
            End If

            ' Obtener los usuarios registrados en Firebase
            Dim response = client.Get("Usuarios")

            ' Verificar si la base de datos está vacía
            If response.Body = "null" OrElse response Is Nothing Then
                MsgBox("No hay usuarios registrados.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            ' Convertir los datos de Firebase en un diccionario
            Dim users As New Dictionary(Of String, Object)
            Try
                Dim jsonObject As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(response.Body)
                users = jsonObject.ToObject(Of Dictionary(Of String, Object))()
            Catch ex As Exception
                MsgBox("Error al procesar los datos de usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try

            ' Buscar si el usuario existe
            For Each user In users
                Dim userData As Dictionary(Of String, Object) = CType(Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(user.Value.ToString()), Dictionary(Of String, Object))

                ' Comparar email
                If userData("Email") = email Or userData("Usuario") = email Then
                    ' Verificar la contraseña encriptada
                    If BCrypt.Net.BCrypt.Verify(password, userData("Password").ToString()) Then
                        MsgBox("Inicio de sesión exitoso. Bienvenido " & userData("Usuario"), MsgBoxStyle.Information, "Éxito")

                        ' Guardar el rol en My.Settings
                        My.Settings.RolUsuario = userData("Rol")
                        My.Settings.Save()

                        ' Ocultar login y abrir menú principal
                        Me.Hide()
                        Dim menu As New Menú()
                        menu.Show()
                        Exit Sub
                    Else
                        MsgBox("Contraseña incorrecta.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                End If
            Next

            ' Si no encuentra coincidencia, mostrar error
            MsgBox("Usuario o contraseña incorrectos.", MsgBoxStyle.Critical, "Error")

        Catch ex As Exception
            MsgBox("Error al iniciar sesión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.Focus()
        Try
            client = New FireSharp.FirebaseClient(fcon)
            If client Is Nothing Then
                MsgBox("No se pudo conectar a la base de datos.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error al conectar con Firebase: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar ' Muestra la contraseña
        Else
            txtPassword.PasswordChar = "*" ' Oculta la contraseña
        End If
    End Sub
End Class