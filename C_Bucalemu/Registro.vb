Imports System.DirectoryServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Registro

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
}

    Private client As FireSharp.Interfaces.IFirebaseClient
    Private Sub Registro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            client = New FireSharp.FirebaseClient(fcon)
            If client Is Nothing Then
                MsgBox("No se pudo conectar a la base de datos.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error al conectar con Firebase: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btn_registro_Click(sender As Object, e As EventArgs) Handles btn_registro.Click
        Try
            ' Capturar los datos del usuario
            Dim usu As String = txtUsuario.Text
            Dim email As String = txtEmail.Text
            Dim password As String = txtPassword.Text
            Dim cpassword As String = txtConfirmarPass.Text
            Dim rol As String = combo_rol.Text

            ' Validar que los campos no estén vacíos
            If String.IsNullOrWhiteSpace(usu) OrElse String.IsNullOrWhiteSpace(email) OrElse
               String.IsNullOrWhiteSpace(password) OrElse String.IsNullOrWhiteSpace(cpassword) OrElse
               String.IsNullOrWhiteSpace(rol) Then
                MsgBox("Por favor, ingrese todos los campos solicitados", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' Verificar si las contraseñas coinciden
            If password <> cpassword Then
                MsgBox("Las contraseñas no coinciden.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' Generar hash seguro de la contraseña
            Dim hashedPassword As String = BCrypt.Net.BCrypt.HashPassword(password)

            ' Obtener todos los usuarios en Firebase
            Dim response = client.Get("Usuarios")

            ' Si no hay usuarios, crea el primero directamente
            If response.Body = "null" OrElse response Is Nothing Then
                MsgBox("No hay usuarios registrados. Creando el primero...", MsgBoxStyle.Information)
                GoTo RegistrarUsuario
            End If

            ' Convertir la respuesta a un diccionario
            Dim users As Dictionary(Of String, Object) = response.ResultAs(Of Dictionary(Of String, Object))

            Try
                Dim jsonObject As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(response.Body)
                users = jsonObject.ToObject(Of Dictionary(Of String, Object))()
            Catch ex As Exception
                MsgBox("Error al procesar los datos de usuarios: " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            ' Verificar si la conversión fue exitosa
            If users Is Nothing Then
                MsgBox("Error al obtener los datos de los usuarios.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            ' Buscar si el email ya está registrado
            For Each user In users
                ' Convertir el objeto almacenado en Firebase a un diccionario correctamente
                Dim userData As Dictionary(Of String, Object) = CType(Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(user.Value.ToString()), Dictionary(Of String, Object))

                If userData("Email") = email Then
                    MsgBox("El usuario ya está registrado.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Next

RegistrarUsuario:
            ' Obtener el último ID numérico y generar uno nuevo (0001, 0002, ...)
            Dim lastID As Integer = If(users?.Count > 0, users.Count, 0)
            Dim nuevoID As String = (lastID + 1).ToString("D4")

            ' Crear el objeto con los datos del usuario
            Dim Usuario As New Dictionary(Of String, Object) From {
                {"Usuario", usu},
                {"Email", email},
                {"Password", hashedPassword},
                {"Rol", rol}
            }

            ' Guardar en Firebase
            Dim saveResponse = client.Set("Usuarios/" & nuevoID, Usuario)

            ' Mensaje de éxito
            MsgBox("Usuario agregado correctamente", MsgBoxStyle.Information)

            ' Limpiar los campos
            txtUsuario.Text = ""
            txtEmail.Text = ""
            txtPassword.Text = ""
            txtConfirmarPass.Text = ""
            combo_rol.Text = ""

        Catch ex As Exception
            MsgBox("Error al agregar el usuario: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles visualizarpass.CheckedChanged
        If visualizarpass.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar ' Muestra la contraseña
        Else
            txtPassword.PasswordChar = "*" ' Oculta la contraseña
        End If
    End Sub

    Private Sub regresar_Click(sender As Object, e As EventArgs) Handles regresar.Click
        Dim menu As New Menú()
        menu.Show()
        Me.Close()
    End Sub
End Class