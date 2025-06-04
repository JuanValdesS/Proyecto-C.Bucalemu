<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Autorizar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Autorizar))
        btnAceptar = New Button()
        btnRechazar = New Button()
        btnMenu = New Button()
        dgAutorizar = New DataGridView()
        Label1 = New Label()
        CType(dgAutorizar, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAceptar
        ' 
        btnAceptar.BackColor = Color.CornflowerBlue
        btnAceptar.Cursor = Cursors.Hand
        btnAceptar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnAceptar.Location = New Point(759, 77)
        btnAceptar.Margin = New Padding(3, 4, 3, 4)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.Size = New Size(97, 31)
        btnAceptar.TabIndex = 1
        btnAceptar.Text = "Aceptar"
        btnAceptar.UseVisualStyleBackColor = False
        ' 
        ' btnRechazar
        ' 
        btnRechazar.BackColor = Color.IndianRed
        btnRechazar.Cursor = Cursors.Hand
        btnRechazar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnRechazar.Location = New Point(759, 116)
        btnRechazar.Margin = New Padding(3, 4, 3, 4)
        btnRechazar.Name = "btnRechazar"
        btnRechazar.Size = New Size(97, 31)
        btnRechazar.TabIndex = 2
        btnRechazar.Text = "Rechazar"
        btnRechazar.UseVisualStyleBackColor = False
        ' 
        ' btnMenu
        ' 
        btnMenu.BackColor = Color.Transparent
        btnMenu.BackgroundImage = CType(resources.GetObject("btnMenu.BackgroundImage"), Image)
        btnMenu.BackgroundImageLayout = ImageLayout.Stretch
        btnMenu.Cursor = Cursors.Hand
        btnMenu.FlatStyle = FlatStyle.Popup
        btnMenu.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnMenu.Location = New Point(776, 165)
        btnMenu.Margin = New Padding(3, 4, 3, 4)
        btnMenu.Name = "btnMenu"
        btnMenu.Size = New Size(68, 51)
        btnMenu.TabIndex = 3
        btnMenu.UseVisualStyleBackColor = False
        ' 
        ' dgAutorizar
        ' 
        dgAutorizar.BackgroundColor = Color.AliceBlue
        dgAutorizar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgAutorizar.Location = New Point(29, 77)
        dgAutorizar.Margin = New Padding(3, 4, 3, 4)
        dgAutorizar.Name = "dgAutorizar"
        dgAutorizar.RowHeadersWidth = 51
        dgAutorizar.Size = New Size(678, 465)
        dgAutorizar.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSlateGray
        Label1.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(29, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(371, 35)
        Label1.TabIndex = 5
        Label1.Text = "Autorización de compras"
        ' 
        ' Autorizar
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.AliceBlue
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(906, 600)
        Controls.Add(Label1)
        Controls.Add(dgAutorizar)
        Controls.Add(btnMenu)
        Controls.Add(btnRechazar)
        Controls.Add(btnAceptar)
        Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Autorizar"
        Text = "Autorizar"
        CType(dgAutorizar, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnRechazar As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents dgAutorizar As DataGridView
    Friend WithEvents Label1 As Label
End Class
