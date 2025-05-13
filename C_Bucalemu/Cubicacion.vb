Imports System.Globalization

Public Class Cubicacion
    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Dim menu As New Menú()
        Me.Close()
        menu.Show()
    End Sub

    Private Sub btncubicar_Click(sender As Object, e As EventArgs) Handles btncubicar.Click
        Try
            Dim material As String = cmbMaterial.Text.Trim()
            Dim tipo = cmbTipoCubica.Text.Trim()
            Dim resultadoCubicacion As Double = 0
            Dim descripcion As String = ""

            If tipo = "Por volumen (Largo x Ancho x Alto)" Then
                If String.IsNullOrWhiteSpace(txtLargo.Text) Or String.IsNullOrWhiteSpace(txtAncho.Text) Or String.IsNullOrWhiteSpace(txtAlto.Text) Then
                    MsgBox("Por favor, completa todos los campos.", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                Dim largo As Double, ancho As Double, alto, cantidadUnidades As Double

                Dim culture = New CultureInfo("es-CL")
                If Not Double.TryParse(txtLargo.Text, NumberStyles.Any, culture, largo) OrElse Not Double.TryParse(txtAncho.Text, NumberStyles.Any, culture, ancho) OrElse Not Double.TryParse(txtAlto.Text, NumberStyles.Any, culture, alto) OrElse Not Double.TryParse(txtCantidadUnidades.Text, cantidadUnidades) Then
                    MsgBox("Ingresa valores numéricos válidos. Usa coma para decimales y números enteros para las unidades.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                resultadoCubicacion = largo * ancho * alto ' m³
                descripcion = $"{material} (Volumen: {largo}x{ancho}x{alto})"

            ElseIf tipo = "Por cantidad de unidades" Then

                If String.IsNullOrWhiteSpace(txtCantidadUnidades.Text) Then
                    MsgBox("Ingrese la cantidad de unidades.", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If

                Dim cantidadUnidades As Double
                Dim culture As New CultureInfo("es-CL")

                If Not Double.TryParse(txtCantidadUnidades.Text, NumberStyles.Any, culture, cantidadUnidades) Then
                    MsgBox("Ingrese una cantidad válida (usa coma para decimales si es necesario).", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If



                resultadoCubicacion = cantidadUnidades
                descripcion = $"{material} (Cantidad de unidades: {cantidadUnidades})"
            Else
                MsgBox("Seleccione un tipo de cubicación válido.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If

            ' Agregar al DataGridView
            dgCubicacion.Rows.Add(material, tipo, resultadoCubicacion, descripcion)

            ' Limpiar campos
            txtLargo.Clear()
            txtAncho.Clear()
            txtAlto.Clear()
            txtCantidadUnidades.Clear()
            cmbTipoCubica.Text = ""

        Catch ex As Exception
            MsgBox("Error en la cubicación: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Cubicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar columnas del DataGridView
        With dgCubicacion

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

            .Columns.Add("Material", "Material")
            .Columns.Add("TipoCubicacion", "Tipo de Cubicación")
            .Columns.Add("Resultado", "Resultado")
            .Columns.Add("Descripcion", "Descripción")

        End With

        cmbTipoCubica.Items.Add("Por volumen (Largo x Ancho x Alto)")
        cmbTipoCubica.Items.Add("Por cantidad de unidades")


    End Sub

    Private Sub dgHistorialCubicas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCubicacion.CellContentClick

    End Sub
End Class