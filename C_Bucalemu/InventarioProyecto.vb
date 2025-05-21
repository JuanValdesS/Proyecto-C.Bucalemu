Public Class InventarioProyecto
    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Dim menu As New Menú()
        Me.Close()
        menu.Show()
    End Sub
End Class