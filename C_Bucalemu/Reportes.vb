Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports Newtonsoft.Json.Linq
Imports System.Net.Mail
Imports System.Net

Public Class Reportes

    Private fcon As New FireSharp.Config.FirebaseConfig With {
    .AuthSecret = "N6kTJwGfYKq9AVH7i3yJ6aTk95ZXw8F3nY1aZFUy",
    .BasePath = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/"
}

    Private client As FireSharp.Interfaces.IFirebaseClient
    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            client = New FireSharp.FirebaseClient(fcon)

            If client IsNot Nothing Then

            Else
                MsgBox("Error al conectar con la base de datos", MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception
            MsgBox("Error de conexión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        'Ocultamos el botón
        btn_greportes.Visible = False

        ' Obtener el rol del usuario autenticado
        Dim rolUsuario As String = My.Settings.RolUsuario

        ' Mostrar el botón solo si el usuario es Administrador o Jefe
        If rolUsuario = "Administrador" Then
            btn_greportes.Visible = True
        End If

        If rolUsuario = "Jefe" Then
            btn_greportes.Visible = True
        End If
    End Sub
    Private Sub btn_reporte_Click(sender As Object, e As EventArgs) Handles btn_reporte.Click

        Dim descripcion = txtObservacion.Text.Trim
        Dim titulo = txtTitulo.Text.Trim

        'validaciones
        If client Is Nothing Then
            MsgBox("Error de conexión a la base de datos.", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If String.IsNullOrEmpty(descripcion) Then
            MsgBox("Por favor, ingrese un reporte.", MsgBoxStyle.Exclamation, "Advertencia")
            txtObservacion.Focus()
            Return
        End If

        Dim reporteid = "Reporte_" & Date.Now.ToString("dd-MM-yyyy_HH:mm")

        ' guardar el reporte en firebase
        Try
            Dim reporte As New Dictionary(Of String, Object) From {
                {"Estado", "No visualizado"},
                {"Titulo del correo", titulo},
                {"Descripcion", descripcion},
                {"Fecha", Date.Now.ToString("dd-MM-yyyy HH:mm:ss")}
            }

            client.Set("Reportes/" & reporteid, reporte)
            txtObservacion.Clear()
            txtTitulo.Clear()
            txtObservacion.Focus()
            MsgBox("Reporte subido correctamente", MsgBoxStyle.Information, "Éxito")

        Catch Ex As Exception
            MsgBox("Error al guardar el reporte en Firebase: " & Ex.Message, MsgBoxStyle.Critical, "Error")
            Exit Sub

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sh As New Menú()
        Me.Close()
        sh.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_greportes.Click
        Dim sh As New GestionarReportes()
        Me.Close()
        sh.Show()
    End Sub
End Class