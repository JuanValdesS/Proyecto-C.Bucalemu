<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Confirmar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Confirmar))
        Label1 = New Label()
        dgvConfirmar = New DataGridView()
        btnConfirmar = New Button()
        btnEliminar = New Button()
        btnRegresar = New Button()
        CType(dgvConfirmar, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSlateGray
        Label1.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(27, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(520, 35)
        Label1.TabIndex = 0
        Label1.Text = "Confirmar llegada de los materiales"
        ' 
        ' dgvConfirmar
        ' 
        dgvConfirmar.BackgroundColor = Color.AliceBlue
        dgvConfirmar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvConfirmar.Location = New Point(27, 88)
        dgvConfirmar.Margin = New Padding(3, 4, 3, 4)
        dgvConfirmar.Name = "dgvConfirmar"
        dgvConfirmar.RowHeadersWidth = 51
        dgvConfirmar.Size = New Size(1042, 787)
        dgvConfirmar.TabIndex = 1
        ' 
        ' btnConfirmar
        ' 
        btnConfirmar.BackColor = Color.CornflowerBlue
        btnConfirmar.Cursor = Cursors.Hand
        btnConfirmar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfirmar.ForeColor = Color.Black
        btnConfirmar.Location = New Point(1098, 88)
        btnConfirmar.Margin = New Padding(3, 4, 3, 4)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Size = New Size(111, 41)
        btnConfirmar.TabIndex = 2
        btnConfirmar.Text = "Confirmar"
        btnConfirmar.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Color.IndianRed
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEliminar.Location = New Point(1098, 137)
        btnEliminar.Margin = New Padding(3, 4, 3, 4)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(111, 41)
        btnEliminar.TabIndex = 3
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' btnRegresar
        ' 
        btnRegresar.BackColor = Color.Transparent
        btnRegresar.BackgroundImage = CType(resources.GetObject("btnRegresar.BackgroundImage"), Image)
        btnRegresar.BackgroundImageLayout = ImageLayout.Stretch
        btnRegresar.Cursor = Cursors.Hand
        btnRegresar.FlatStyle = FlatStyle.Popup
        btnRegresar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegresar.ForeColor = Color.Black
        btnRegresar.Location = New Point(1117, 193)
        btnRegresar.Margin = New Padding(3, 4, 3, 4)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(67, 47)
        btnRegresar.TabIndex = 4
        btnRegresar.TextAlign = ContentAlignment.MiddleRight
        btnRegresar.UseVisualStyleBackColor = False
        ' 
        ' Confirmar
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CornflowerBlue
        BackgroundImage = My.Resources.Resources.Blur_background_of_modern_office_interior_design_for_creative_business___Premium_AI_generated_image
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1238, 923)
        Controls.Add(btnRegresar)
        Controls.Add(btnEliminar)
        Controls.Add(btnConfirmar)
        Controls.Add(dgvConfirmar)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Confirmar"
        Text = "Confirmar"
        CType(dgvConfirmar, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvConfirmar As DataGridView
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnRegresar As Button
End Class
