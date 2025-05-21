Imports System.IO
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Newtonsoft.Json
Public Class Proyectos

    Public Property nombre As String
    Public Property Descripción As String
    Public Property Personal As String

    ' Cliente Firebase
    Private client As IFirebaseClient

    Public IdProyectoActual As String

    Private Sub btn_ingresar_Click(sender As Object, e As EventArgs) Handles btn_ingresar.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor selecciona un proyecto antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Obtener nombre del proyecto seleccionado
        Dim nombreProyecto As String = DataGridView1.SelectedRows(0).Cells("Nombre").Value.ToString()
        Dim IdProyecto As String = DataGridView1.SelectedRows(0).Cells("ID Proyecto").Value.ToString()
        sesion.IdProyectoActual = IdProyecto
        ' Crear el formulario Menú, pasándole el proyecto
        Dim men As New Menú()
        Me.Close()
        men.Show()
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
            Dim response As FirebaseResponse = client.Get("Proyectos")

            If response.Body <> "null" Then
                Dim proyectosDict As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response.Body)
                Dim dt As New DataTable()

                ' Columnas a mostrar en el DataGridView
                dt.Columns.Add("ID Proyecto")
                'dt.Columns.("ID Proyecto").Visible = False
                dt.Columns.Add("Nombre")
                dt.Columns.Add("Descripción")
                dt.Columns.Add("Personal")

                For Each proyectoKey In proyectosDict.Keys
                    Dim infoResponse As FirebaseResponse = client.Get("Proyectos/" & proyectoKey & "/Info")
                    If infoResponse.Body <> "null" Then
                        Dim proyecto As Proyectos = JsonConvert.DeserializeObject(Of Proyectos)(infoResponse.Body)
                        dt.Rows.Add(proyectoKey, proyecto.nombre, proyecto.Descripción, proyecto.Personal)
                    End If
                Next

                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No se encontraron proyectos.")
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

End Class