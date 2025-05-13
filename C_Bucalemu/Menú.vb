Public Class Menú
    Dim compra As New Compras()
    Dim mod_mat As New mod_material()
    Dim repo As New Reportes()
    Dim VerInventario As New Inventario()
    Dim Autorizar As New Autorizar()
    Dim registro As New Registro()
    Dim cubi As New Cubicacion()

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
}

    Private client As FireSharp.Interfaces.IFirebaseClient
    Private Sub btn_Compras_Click(sender As Object, e As EventArgs) Handles btn_Compras.Click
        compra.Show()
        Me.Close()
    End Sub

    Private Sub btn_inventario_Click(sender As Object, e As EventArgs) Handles btn_inventario.Click
        mod_mat.Show()
        Hide()
    End Sub

    Private Sub btn_cubicacion_Click(sender As Object, e As EventArgs) Handles btn_cubicacion.Click
        cubi.Show()
        Hide()
    End Sub

    Private Sub btn_reportes_Click(sender As Object, e As EventArgs) Handles btn_reportes.Click
        repo.Show()
        Hide()
    End Sub

    Private Sub Menú_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            client = New FireSharp.FirebaseClient(fcon)
            If client Is Nothing Then
                MsgBox("No se pudo conectar a la base de datos.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error al conectar con Firebase: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        ' Ocultar el botón por defecto
        btn_inventario.Visible = False
        btn_registro.Visible = False
        btnAutorizar.Visible = False

        ' Obtener el rol del usuario autenticado
        Dim rolUsuario As String = My.Settings.RolUsuario

        ' Mostrar el botón solo si el usuario es Administrador
        If rolUsuario = "Administrador" Then
            btn_registro.Visible = True
            btnAutorizar.Visible = True
            btn_inventario.Visible = True
        End If

        If rolUsuario = "Jefe" Then
            btnAutorizar.Visible = True
            btn_inventario.Visible = True
        End If

    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim sh As New Login()
        ' Mostrar cuadro de mensaje con opciones Sí y No
        Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Si el usuario selecciona "Sí", proceder a redirigir al login
        If resultado = DialogResult.Yes Then
            ' Aquí debes redirigir al formulario de login
            ' Por ejemplo, si tu formulario de login se llama "FormLogin"
            Me.Close() ' Oculta el formulario actual
            sh.Show() ' Muestra el formulario de login
        End If
    End Sub

    Private Sub btnVerInventario_Click(sender As Object, e As EventArgs) Handles btnVerInventario.Click
        VerInventario.Show()
        Me.Close()

    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Autorizar.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_registro.Click
        registro.Show()
        Me.Close()
    End Sub
End Class