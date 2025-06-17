Imports FireSharp.Response
Imports FireSharp.Interfaces
Imports FireSharp.Config
Imports Newtonsoft.Json

Public Class Menú
    Dim compra As New Compras()
    Dim mod_mat As New mod_material()
    Dim repo As New Reportes()
    Dim VerInventario As New Inventario
    Dim Autorizar As New Autorizar()
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
        btn_inventario.Enabled = False
        btnAutorizar.Enabled = False
        btn_finalizar.Visible = False
        btnVerInventario.Enabled = False
        btn_Compras.Enabled = False
        btn_cubicacion.Enabled = False
        btn_confirmar.Enabled = False
        btn_reportes.Enabled = False
        btn_finalizar.Enabled = False

        ' Obtener el rol del usuario autenticado
        Dim rolUsuario As String = My.Settings.RolUsuario

        ' Mostrar el botón solo si el usuario es Administrador
        If rolUsuario = "Jefe" Then
            btn_inventario.Enabled = True
            btnAutorizar.Enabled = True
            btn_finalizar.Visible = True
            btnVerInventario.Enabled = True
            btn_Compras.Enabled = True
            btn_cubicacion.Enabled = True
            btn_confirmar.Enabled = True
            btn_reportes.Enabled = True
            btn_finalizar.Enabled = True
        End If

        If rolUsuario = "Administrador" Then
            btn_Compras.Enabled = True
            btn_reportes.Enabled = True
            btnVerInventario.Enabled = True
            btn_cubicacion.Enabled = True
        End If

        If rolUsuario = "Encargado de compras" Then
            btnAutorizar.Enabled = True
            btn_reportes.Enabled = True
            btnVerInventario.Enabled = True
        End If

        If rolUsuario = "Encargado del inventario" Then
            btn_inventario.Enabled = True
            btn_reportes.Enabled = True
            btnVerInventario.Enabled = True
            btn_confirmar.Enabled = True
        End If

        If rolUsuario = "Trabajador" Then
            btn_reportes.Enabled = True
            btnVerInventario.Enabled = True
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

    Private Sub btnVerInventario_Click(sender As Object, e As EventArgs) Handles btnVerInventario.Click
        VerInventario.Show()
        Me.Close()

    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Autorizar.Show()
        Me.Close()
    End Sub

    Private Sub btn_finalizar_Click(sender As Object, e As EventArgs) Handles btn_finalizar.Click

        Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de finalizar el proyecto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Try
                Dim rutaProyecto As String = $"Proyectos/{IdentifyProject}/Inventario"
                Dim rutaInventarioGlobal As String = "Inventario"

                ' Obtener inventario del proyecto
                Dim inventarioResponse As FirebaseResponse = client.Get(rutaProyecto)

                If inventarioResponse.Body <> "null" Then
                    Dim inventarioProyecto As Dictionary(Of String, Dictionary(Of String, Object)) =
                        JsonConvert.DeserializeObject(Of Dictionary(Of String, Dictionary(Of String, Object)))(inventarioResponse.Body)

                    For Each kvp In inventarioProyecto
                        Dim idMaterial As String = kvp.Key
                        Dim datosMaterial As Dictionary(Of String, Object) = kvp.Value

                        ' Obtener campos del material
                        Dim nombreMaterial As String = datosMaterial("material").ToString()
                        Dim cantidadProyecto As Double = Convert.ToDouble(datosMaterial("cantidad"))
                        Dim unidad As String = datosMaterial("unidad").ToString()
                        Dim fecha As String = datosMaterial("fecha").ToString()

                        ' Ruta al material en el inventario global
                        Dim rutaMaterialGlobal As String = $"{rutaInventarioGlobal}/{idMaterial}"

                        ' Obtener si ya existe en inventario global
                        Dim globalResponse As FirebaseResponse = client.Get($"{rutaMaterialGlobal}/cantidad")
                        Dim cantidadGlobal As Double = 0

                        If globalResponse.Body <> "null" Then
                            cantidadGlobal = Convert.ToDouble(globalResponse.Body)
                        End If

                        ' Sumar cantidades
                        Dim nuevaCantidad As Double = cantidadGlobal + cantidadProyecto

                        ' Crear o actualizar el material en InventarioGlobal
                        Dim nuevoMaterial As New Dictionary(Of String, Object) From {
                            {"material", nombreMaterial},
                            {"cantidad", nuevaCantidad},
                            {"unidad", unidad},
                            {"fecha", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}
                        }

                        client.Set(rutaMaterialGlobal, nuevoMaterial)
                    Next
                End If

                ' Eliminar el proyecto completo
                client.Delete($"Proyectos/{IdentifyProject}")

                MessageBox.Show("Proyecto finalizado correctamente. El inventario fue transferido al Inventario Global.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim pro As New Proyectos()
                Me.Close()
                pro.Show()


            Catch ex As Exception
                MessageBox.Show("Error al finalizar el proyecto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btn_confirmar_Click(sender As Object, e As EventArgs) Handles btn_confirmar.Click
        Dim Confirmar As New Confirmar()
        Confirmar.Show()
        Me.Close()
    End Sub
End Class