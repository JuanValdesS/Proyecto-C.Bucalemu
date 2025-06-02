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
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(24, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(228, 15)
        Label1.TabIndex = 0
        Label1.Text = "Confirmar llegada de los materiales"
        ' 
        ' dgvConfirmar
        ' 
        dgvConfirmar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvConfirmar.Location = New Point(24, 76)
        dgvConfirmar.Name = "dgvConfirmar"
        dgvConfirmar.Size = New Size(678, 465)
        dgvConfirmar.TabIndex = 1
        ' 
        ' btnConfirmar
        ' 
        btnConfirmar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfirmar.Location = New Point(781, 121)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Size = New Size(97, 31)
        btnConfirmar.TabIndex = 2
        btnConfirmar.Text = "Confirmar"
        btnConfirmar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Color.IndianRed
        btnEliminar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEliminar.Location = New Point(781, 183)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(97, 31)
        btnEliminar.TabIndex = 3
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' btnRegresar
        ' 
        btnRegresar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegresar.Location = New Point(781, 248)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(97, 31)
        btnRegresar.TabIndex = 4
        btnRegresar.Text = "Regresar"
        btnRegresar.UseVisualStyleBackColor = True
        ' 
        ' Confirmar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CornflowerBlue
        BackgroundImage = My.Resources.Resources.Blur_background_of_modern_office_interior_design_for_creative_business___Premium_AI_generated_image
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(946, 600)
        Controls.Add(btnRegresar)
        Controls.Add(btnEliminar)
        Controls.Add(btnConfirmar)
        Controls.Add(dgvConfirmar)
        Controls.Add(Label1)
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
