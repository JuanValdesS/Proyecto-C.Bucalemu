Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Globalization
Imports System.Net
Imports System.Text.RegularExpressions

Public Class Confirmar
    Private Sub Confirmar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Validar que el nombre del proyecto esté definido
        If String.IsNullOrEmpty(IdentifyProject) Then
            MsgBox("El nombre del proyecto actual no está definido.", MsgBoxStyle.Critical, "Error de configuración")
            Exit Sub
        End If

        ' Construcción de la URL del proyecto
        Dim firebaseUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/{IdentifyProject}/Confirmar.json"

        Try
            Dim client As New WebClient()
            client.Headers.Add("Content-Type", "application/json")

            Dim response As String = client.DownloadString(firebaseUrl)

            ' Verificar si la respuesta no es JSON
            If response.Trim().StartsWith("<") Then
                MsgBox("La respuesta no es válida (HTML recibido en lugar de JSON). Verifica la URL y los datos en Firebase.", MsgBoxStyle.Critical, "Error de datos")
                Exit Sub
            End If

            If String.IsNullOrEmpty(response) OrElse response = "null" Then
                dgvConfirmar.Rows.Clear()
                dgvConfirmar.Columns.Clear()
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub

            End If

            ' Deserializar JSON
            Dim ConfirmarRaw As Dictionary(Of String, JObject) = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(response)

            If ConfirmarRaw Is Nothing OrElse ConfirmarRaw.Count = 0 Then
                dgvConfirmar.Rows.Clear()
                dgvConfirmar.Columns.Clear()
                MsgBox("No hay solicitudes pendientes.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' LIMPIEZA (primero columnas, luego filas)
            dgvConfirmar.Columns.Clear()
            dgvConfirmar.Rows.Clear()

            ' Estilo (si quieres mantenerlo aquí)
            ConfigurarEstiloDataGridView()

            ' Agregar columnas
            dgvConfirmar.Columns.Add("ID", "ID de Solicitud")
            dgvConfirmar.Columns.Add("Materiales", "Materiales")
            dgvConfirmar.Columns.Add("Fecha", "Fecha de Ingreso")
            dgvConfirmar.Columns.Add("Estado", "Estado")

            dgvConfirmar.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvConfirmar.Columns("Materiales").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgvConfirmar.Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells



            Dim contador As Integer = 1

            ' Rellenar el DataGridView
            For Each solicitud In ConfirmarRaw
                Dim solicitudID As String = solicitud.Key ' Con esto obtengo el ID de la solicitud
                Dim solicitudDatos As JObject = solicitud.Value ' Con esto obtengo todos los datos de la solicitud

                Dim Columna As New List(Of String) ' en esta lista van los datos de la solicitud
                For Each propiedad In solicitudDatos.Properties()

                    Columna.Add(propiedad.Value)

                Next
                Dim Estado As String = Columna(0).ToString()
                Dim Fecha As String = Columna(1).ToString()
                Dim Materiales As String = Columna(2).ToString()
                dgvConfirmar.Rows.Add(solicitudID, Materiales, Fecha, Estado)


            Next

        Catch ex As Exception
            MsgBox("Error al obtener los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        If dgvConfirmar.Rows.Count = 0 Then
            MsgBox("No hay datos para enviar.", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If

        If dgvConfirmar.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione una solicitud.", MsgBoxStyle.Information, "Información")
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvConfirmar.SelectedRows(0)
        Dim solicitudID As String = row.Cells("ID").Value.ToString()

        Dim firebaseInventarioUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Inventario.json"
        Dim firebaseComprasUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Confirmar/" & solicitudID & ".json"

        Try
            Dim client As New WebClient()
            Dim inventarioResponse As String = client.DownloadString(firebaseInventarioUrl)
            Dim inventarioData As New Dictionary(Of String, JObject)

            If Not String.IsNullOrEmpty(inventarioResponse) AndAlso inventarioResponse <> "null" Then
                inventarioData = JsonConvert.DeserializeObject(Of Dictionary(Of String, JObject))(inventarioResponse) ' aqui esta toda la info del inventario
            End If
            'MsgBox(inventarioData.Count) ' nos dice la cantidad de elementos que hay en la base de datos de inventario
            Dim materialesTexto As String = row.Cells("Materiales").Value.ToString()

            ' Expresión regular: busca patrones con formato "nombre : cantidad unidad"
            Dim patron As String = "(.+?):\s*([\d\.,]+)\s+([a-zA-Z\.]+)"
            Dim coincidencias As MatchCollection = Regex.Matches(materialesTexto, patron)

            For Each match As Match In coincidencias
                Dim Nombre As String = match.Groups(1).Value.Trim().ToUpper() ' nombre del material
                Dim Cantidad As Double = Double.Parse(match.Groups(2).Value.Trim().Replace(",", "."), CultureInfo.InvariantCulture)
                Dim Unidad As String = match.Groups(3).Value.Trim().ToUpper() ' unidad

                Dim materialEncontrado As Boolean = False

                Dim maxId As Integer = 0 ' Variable para almacenar el ID máximo encontrado

                For Each item In inventarioData
                    'MsgBox(item.Key) ' nos entrega la llave o el id del material material:_0001

                    Dim datosMaterial As JObject = item.Value
                    If datosMaterial("material") IsNot Nothing AndAlso datosMaterial("material").ToString().ToUpper() = Nombre Then
                        ' si el nombre del material coincidecon un elemento en la base de datos entonces entra 

                        'Dim cantidadExistente As Double = Double.Parse(datosMaterial("cantidad").ToString(), CultureInfo.InvariantCulture)
                        Dim claveMaterial = item.Key ' Ejemplo: Proyecto_1
                        Dim idNumerico As Integer = claveMaterial.Split("_")(1)
                        Dim id = claveMaterial.Split("_")(0) ' Extraer el ID del material   

                        ' Extraer número de ID
                        If maxId < idNumerico Then

                            maxId = idNumerico ' Actualizar el ID máximo si es mayor que el actual

                        End If


                        datosMaterial("cantidad") = Cantidad
                        datosMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

                        materialEncontrado = True
                        Exit For
                    End If
                Next

                If materialEncontrado Then
                    Dim nuevoMaterial As New JObject()
                    maxId = maxId + 1

                    ' Limpiar el nombre para usarlo como clave segura en Firebase
                    Dim claveNombre As String = Regex.Replace(Nombre.ToUpper(), "[^A-Z0-9]", "") ' Solo letras y números

                    Dim IdFinal As String = claveNombre & "_" & maxId.ToString("D4") ' ID limpio + número
                    nuevoMaterial("material") = Nombre
                    nuevoMaterial("cantidad") = Cantidad
                    nuevoMaterial("stock_max") = Cantidad
                    nuevoMaterial("unidad") = Unidad
                    nuevoMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

                    inventarioData(IdFinal) = nuevoMaterial ' Aquí sí agregamos nuevo ID aunque ya exista el material
                Else
                    Dim nuevoMaterial As New JObject()
                    nuevoMaterial("material") = Nombre
                    nuevoMaterial("cantidad") = Cantidad
                    nuevoMaterial("stock_max") = Cantidad
                    nuevoMaterial("unidad") = Unidad
                    nuevoMaterial("fecha") = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

                    Dim claveNombre As String = Regex.Replace(Nombre.ToUpper(), "[^A-Z0-9]", "")
                    Dim claveMaterial As String = claveNombre & "_0001"

                    inventarioData(claveMaterial) = nuevoMaterial
                End If
            Next
            'este for esta hecho para verificar que todo se esta agregando de manera correcta
            'For Each item In inventarioData
            'MsgBox(item.Key)
            'MsgBox(JsonConvert.SerializeObject(item.Value))
            'Next

            For Each item In inventarioData
                Dim materialKey As String = item.Key
                Dim materialUrl As String = "https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/" & IdentifyProject & "/Inventario/" & materialKey & ".json"
                'MsgBox(item.Value.ToString()) ' nos entrega el valor del material) ' este nos muestra la informacion del id de los materiales que se va cargando
                Dim materialJson As String = JsonConvert.SerializeObject(item.Value)
                client.UploadString(materialUrl, "PUT", materialJson)
            Next
            client.UploadString(firebaseComprasUrl, "DELETE", String.Empty)

            MsgBox("Inventario actualizado correctamente.", MsgBoxStyle.Information, "Mensaje de confirmación")
            Confirmar_Load(sender, e) ' Recargar el DataGridView para mostrar los cambios
        Catch ex As Exception
            MsgBox("Error al actualizar el inventario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvConfirmar.SelectedRows.Count = 0 Then
            MsgBox("Por favor seleccione una solicitud para eliminar.", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If

        ' Confirmar con el usuario antes de eliminar
        Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar esta solicitud?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If resultado = DialogResult.No Then
            Exit Sub
        End If

        Try
            Dim row As DataGridViewRow = dgvConfirmar.SelectedRows(0)
            Dim solicitudID As String = row.Cells("ID").Value.ToString()

            ' URL a Firebase para eliminar la solicitud específica
            Dim firebaseDeleteUrl As String = $"https://db-cbucalemu-b8965-default-rtdb.firebaseio.com/Proyectos/{IdentifyProject}/Confirmar/{solicitudID}.json"

            Dim client As New WebClient()
            client.Headers.Add("Content-Type", "application/json")
            client.UploadString(firebaseDeleteUrl, "DELETE", String.Empty)

            ' Eliminar del DataGridView
            dgvConfirmar.Rows.Remove(row)

            MsgBox("Solicitud eliminada correctamente.", MsgBoxStyle.Information, "Eliminación exitosa")
        Catch ex As Exception
            MsgBox("Error al eliminar la solicitud: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        cerrarTodo = False
        Dim men As New Menú()
        Me.Close()
        men.Show()
    End Sub

    Private Sub ConfigurarEstiloDataGridView()
        ''Elementos que hacen que el datagrid se vea mas formal y con mas diseño
        With dgvConfirmar
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
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' Ajustar tamaño de columnas automáticamente
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Deshabilitar la edición de celdas
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True

            ' Cambiar estilo del grid
            .BorderStyle = BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub Confirmar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cerrarTodo AndAlso e.CloseReason = CloseReason.UserClosing Then
        Application.Exit()
    End If
    End Sub
End Class