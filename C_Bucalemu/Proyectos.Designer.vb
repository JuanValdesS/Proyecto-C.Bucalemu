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
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.AliceBlue
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(47, 64)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(417, 244)
        DataGridView1.TabIndex = 0
        ' 
        ' btn_ingresar
        ' 
        btn_ingresar.BackColor = Color.CornflowerBlue
        btn_ingresar.Cursor = Cursors.Hand
        btn_ingresar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_ingresar.Location = New Point(526, 64)
        btn_ingresar.Name = "btn_ingresar"
        btn_ingresar.Size = New Size(123, 66)
        btn_ingresar.TabIndex = 1
        btn_ingresar.Text = "Ingresar al proyecto"
        btn_ingresar.UseVisualStyleBackColor = False
        ' 
        ' btn_crear
        ' 
        btn_crear.BackColor = Color.CornflowerBlue
        btn_crear.Cursor = Cursors.Hand
        btn_crear.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_crear.Location = New Point(526, 146)
        btn_crear.Name = "btn_crear"
        btn_crear.Size = New Size(123, 66)
        btn_crear.TabIndex = 2
        btn_crear.Text = "Crear Proyecto"
        btn_crear.UseVisualStyleBackColor = False
        ' 
        ' Proyectos
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(713, 374)
        Controls.Add(btn_crear)
        Controls.Add(btn_ingresar)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Proyectos"
        Text = "Proyectos"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_ingresar As Button
    Friend WithEvents btn_crear As Button
End Class
