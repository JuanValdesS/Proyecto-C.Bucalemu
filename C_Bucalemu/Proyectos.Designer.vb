<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proyectos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Proyectos))
        DataGridView1 = New DataGridView()
        btn_ingresar = New Button()
        btn_crear = New Button()
        Label1 = New Label()
        btnInventario = New Button()
        btnGestionarInventario = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.AliceBlue
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(41, 48)
        DataGridView1.Margin = New Padding(3, 2, 3, 2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(632, 423)
        DataGridView1.TabIndex = 0
        ' 
        ' btn_ingresar
        ' 
        btn_ingresar.BackColor = Color.CornflowerBlue
        btn_ingresar.Cursor = Cursors.Hand
        btn_ingresar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_ingresar.Location = New Point(707, 48)
        btn_ingresar.Margin = New Padding(3, 2, 3, 2)
        btn_ingresar.Name = "btn_ingresar"
        btn_ingresar.Size = New Size(108, 50)
        btn_ingresar.TabIndex = 1
        btn_ingresar.Text = "Ingresar al proyecto"
        btn_ingresar.UseVisualStyleBackColor = False
        ' 
        ' btn_crear
        ' 
        btn_crear.BackColor = Color.CornflowerBlue
        btn_crear.Cursor = Cursors.Hand
        btn_crear.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_crear.Location = New Point(707, 117)
        btn_crear.Margin = New Padding(3, 2, 3, 2)
        btn_crear.Name = "btn_crear"
        btn_crear.Size = New Size(108, 50)
        btn_crear.TabIndex = 2
        btn_crear.Text = "Crear Proyecto"
        btn_crear.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(41, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(189, 26)
        Label1.TabIndex = 3
        Label1.Text = "Proyectos activos"
        ' 
        ' btnInventario
        ' 
        btnInventario.BackColor = Color.CornflowerBlue
        btnInventario.Cursor = Cursors.Hand
        btnInventario.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnInventario.Location = New Point(707, 198)
        btnInventario.Margin = New Padding(3, 2, 3, 2)
        btnInventario.Name = "btnInventario"
        btnInventario.Size = New Size(108, 50)
        btnInventario.TabIndex = 5
        btnInventario.Text = "Inventario"
        btnInventario.UseVisualStyleBackColor = False
        ' 
        ' btnGestionarInventario
        ' 
        btnGestionarInventario.BackColor = Color.CornflowerBlue
        btnGestionarInventario.Cursor = Cursors.Hand
        btnGestionarInventario.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnGestionarInventario.Location = New Point(707, 278)
        btnGestionarInventario.Margin = New Padding(3, 2, 3, 2)
        btnGestionarInventario.Name = "btnGestionarInventario"
        btnGestionarInventario.Size = New Size(108, 50)
        btnGestionarInventario.TabIndex = 6
        btnGestionarInventario.Text = "Gestionar Inventario"
        btnGestionarInventario.UseVisualStyleBackColor = False
        ' 
        ' Proyectos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(877, 655)
        Controls.Add(btnGestionarInventario)
        Controls.Add(btnInventario)
        Controls.Add(Label1)
        Controls.Add(btn_crear)
        Controls.Add(btn_ingresar)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Proyectos"
        Text = "Proyectos"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_ingresar As Button
    Friend WithEvents btn_crear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btnInventario As Button
    Friend WithEvents btnGestionarInventario As Button
End Class
