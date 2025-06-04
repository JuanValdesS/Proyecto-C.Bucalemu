Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Drawing.Drawing2D


Public Class Login

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
}

    Private client As FireSharp.Interfaces.IFirebaseClient

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Diseño btnLogin
        AplicarEstiloBasico(btnLogin, "Login")
        RedondearBoton(btnLogin, 20)
        btnLogin.BackColor = Color.MidnightBlue
        btnLogin.ForeColor = Color.White
        AplicarEstiloHover(btnLogin, Color.MidnightBlue, Color.White, Color.White, Color.MidnightBlue)


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
    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            ' Capturar datos ingresados por el usuario
            Dim email = txtUsuario.Text
            Dim password = txtPassword.Text

            UsuarioRegistrado = email

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
                Dim jsonObject = JObject.Parse(response.Body)
                users = jsonObject.ToObject(Of Dictionary(Of String, Object))
            Catch ex As Exception
                MsgBox("Error al procesar los datos de usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try

            ' Buscar si el usuario existe
            For Each user In users
                Dim userData = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(user.Value.ToString)

                ' Comparar email
                If userData("Email") = email Or userData("Usuario") = email Then
                    ' Verificar la contraseña encriptada
                    If BCrypt.Net.BCrypt.Verify(password, userData("Password").ToString) Then
                        MsgBox("Inicio de sesión exitoso. Bienvenido " & userData("Usuario"), MsgBoxStyle.Information, "Éxito")

                        ' Guardar el rol en My.Settings
                        My.Settings.RolUsuario = userData("Rol")
                        My.Settings.Save()

                        ' Ocultar login y abrir menú principal
                        Hide()
                        Dim pro As New Proyectos
                        pro.Show()
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar ' Muestra la contraseña
        Else
            txtPassword.PasswordChar = "*" ' Oculta la contraseña
        End If
    End Sub

    Private Sub RedondearBoton(btn As Button, radio As Integer)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(0, 0, radio, radio, 180, 90)
        path.AddArc(btn.Width - radio, 0, radio, radio, 270, 90)
        path.AddArc(btn.Width - radio, btn.Height - radio, radio, radio, 0, 90)
        path.AddArc(0, btn.Height - radio, radio, radio, 90, 90)
        path.CloseFigure()
        btn.Region = New Region(path)
    End Sub

    Private Sub AplicarEstiloHover(boton As Button, colorBase As Color, colorHover As Color, textoColorBase As Color, textoColorHover As Color)
        AddHandler boton.MouseEnter, Sub(sender As Object, e As EventArgs)
                                         boton.BackColor = colorHover
                                         boton.ForeColor = textoColorHover
                                     End Sub

        AddHandler boton.MouseLeave, Sub(sender As Object, e As EventArgs)
                                         boton.BackColor = colorBase
                                         boton.ForeColor = textoColorBase
                                     End Sub
    End Sub

    Private Sub AplicarEstiloBasico(boton As Button, texto As String)
        With boton
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.MidnightBlue
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
            .Size = New Size(140, 40)
            .Text = texto
        End With
    End Sub

End Class