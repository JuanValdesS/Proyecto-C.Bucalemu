<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mod_material
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mod_material))
        btnAgregar = New Button()
        txtMaterial = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        DataGridView1 = New DataGridView()
        btn_regresar = New Button()
        Label3 = New Label()
        ComboBox1 = New ComboBox()
        txtbox1 = New ComboBox()
        btn_retirar = New Button()
        Button1 = New Button()
        ToolTip1 = New ToolTip(components)
        nCantidad = New NumericUpDown()
        Prueba = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(nCantidad, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = Color.CornflowerBlue
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnAgregar.ForeColor = SystemColors.ActiveCaptionText
        btnAgregar.Location = New Point(72, 307)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(179, 42)
        btnAgregar.TabIndex = 0
        btnAgregar.Text = "Agregar Material"
        ToolTip1.SetToolTip(btnAgregar, "Para agregar material asegurese de llenar todos los campos")
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' txtMaterial
        ' 
        txtMaterial.BackColor = Color.AliceBlue
        txtMaterial.Cursor = Cursors.IBeam
        txtMaterial.Font = New Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMaterial.Location = New Point(72, 163)
        txtMaterial.Name = "txtMaterial"
        txtMaterial.PlaceholderText = "Nombre del material"
        txtMaterial.Size = New Size(179, 22)
        txtMaterial.TabIndex = 1
        ToolTip1.SetToolTip(txtMaterial, "Ingrese nombre del material. Ej: Cemento")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.CornflowerBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(72, 94)
        Label1.Name = "Label1"
        Label1.Size = New Size(139, 20)
        Label1.TabIndex = 3
        Label1.Text = "Material a añadir"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.CornflowerBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(72, 236)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 20)
        Label2.TabIndex = 4
        Label2.Text = "Cantidad"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.BackgroundColor = Color.AliceBlue
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(320, 94)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(699, 445)
        DataGridView1.TabIndex = 5
        ' 
        ' btn_regresar
        ' 
        btn_regresar.BackColor = Color.Transparent
        btn_regresar.BackgroundImage = CType(resources.GetObject("btn_regresar.BackgroundImage"), Image)
        btn_regresar.BackgroundImageLayout = ImageLayout.Stretch
        btn_regresar.Cursor = Cursors.Hand
        btn_regresar.FlatStyle = FlatStyle.Popup
        btn_regresar.ImageAlign = ContentAlignment.BottomCenter
        btn_regresar.Location = New Point(141, 458)
        btn_regresar.Name = "btn_regresar"
        btn_regresar.Size = New Size(57, 48)
        btn_regresar.TabIndex = 6
        btn_regresar.TabStop = False
        btn_regresar.Tag = "Regresar al menú"
        btn_regresar.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.CornflowerBlue
        Label3.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(172, 236)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 20)
        Label3.TabIndex = 7
        Label3.Text = "Unidades"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.BackColor = Color.AliceBlue
        ComboBox1.Font = New Font("Arial", 7.8F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"un", "mt", "ml", "m2", "m3", "gl", "kg", "tira", "rollo", "malla", "sacos", "tineta", "pieza", "plancha", "", ""})
        ComboBox1.Location = New Point(172, 262)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(79, 24)
        ComboBox1.TabIndex = 8
        ToolTip1.SetToolTip(ComboBox1, "Seleccione la unidad del material. Ej: Kilogramos")
        ' 
        ' txtbox1
        ' 
        txtbox1.BackColor = Color.AliceBlue
        txtbox1.Font = New Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtbox1.FormattingEnabled = True
        txtbox1.Location = New Point(72, 133)
        txtbox1.Name = "txtbox1"
        txtbox1.Size = New Size(179, 24)
        txtbox1.TabIndex = 9
        ToolTip1.SetToolTip(txtbox1, "Seleccione un material para añadir")
        ' 
        ' btn_retirar
        ' 
        btn_retirar.BackColor = Color.IndianRed
        btn_retirar.Cursor = Cursors.Hand
        btn_retirar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_retirar.ForeColor = SystemColors.ActiveCaptionText
        btn_retirar.Location = New Point(88, 383)
        btn_retirar.Name = "btn_retirar"
        btn_retirar.Size = New Size(146, 42)
        btn_retirar.TabIndex = 10
        btn_retirar.Text = "Retirar Material"
        ToolTip1.SetToolTip(btn_retirar, "Para retirar material, asegurese de llenar todos los campos.")
        btn_retirar.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.CornflowerBlue
        Button1.Cursor = Cursors.Hand
        Button1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(539, 557)
        Button1.Name = "Button1"
        Button1.Size = New Size(291, 45)
        Button1.TabIndex = 11
        Button1.Text = "Visualizar el inventario completo"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' ToolTip1
        ' 
        ToolTip1.AutoPopDelay = 5000
        ToolTip1.BackColor = Color.Azure
        ToolTip1.InitialDelay = 500
        ToolTip1.IsBalloon = True
        ToolTip1.ReshowDelay = 100
        ' 
        ' nCantidad
        ' 
        nCantidad.BackColor = Color.AliceBlue
        nCantidad.DecimalPlaces = 2
        nCantidad.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nCantidad.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        nCantidad.Location = New Point(72, 262)
        nCantidad.Margin = New Padding(3, 4, 3, 4)
        nCantidad.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nCantidad.Name = "nCantidad"
        nCantidad.Size = New Size(77, 25)
        nCantidad.TabIndex = 19
        ToolTip1.SetToolTip(nCantidad, "Ingrese Cantidad del material. Ej: 20")
        ' 
        ' Prueba
        ' 
        Prueba.AutoSize = True
        Prueba.BackColor = Color.DarkSlateGray
        Prueba.FlatStyle = FlatStyle.Flat
        Prueba.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Prueba.ForeColor = SystemColors.HighlightText
        Prueba.Location = New Point(469, 41)
        Prueba.Name = "Prueba"
        Prueba.Size = New Size(385, 35)
        Prueba.TabIndex = 20
        Prueba.Text = "Información de materiales"
        ' 
        ' mod_material
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1076, 641)
        Controls.Add(Prueba)
        Controls.Add(nCantidad)
        Controls.Add(Button1)
        Controls.Add(btn_retirar)
        Controls.Add(txtbox1)
        Controls.Add(ComboBox1)
        Controls.Add(Label3)
        Controls.Add(btn_regresar)
        Controls.Add(DataGridView1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtMaterial)
        Controls.Add(btnAgregar)
        Font = New Font("Segoe UI Symbol", 7.8F)
        ForeColor = SystemColors.ActiveCaptionText
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "mod_material"
        Text = "Gestionar Inventario"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(nCantidad, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAgregar As Button
    Friend WithEvents txtMaterial As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_regresar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents txtbox1 As ComboBox
    Friend WithEvents btn_retirar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents nCantidad As NumericUpDown
    Friend WithEvents Prueba As Label
End Class
