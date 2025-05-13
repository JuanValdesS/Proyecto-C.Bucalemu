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
        CheckBox1 = New CheckBox()
        cbMedida = New ComboBox()
        lbl_medida = New Label()
        ToolTip1 = New ToolTip(components)
        nCantidad = New NumericUpDown()
        nMedidas = New TextBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(nCantidad, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = Color.LightSteelBlue
        btnAgregar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnAgregar.ForeColor = SystemColors.ActiveCaptionText
        btnAgregar.Location = New Point(125, 189)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(141, 42)
        btnAgregar.TabIndex = 0
        btnAgregar.Text = "Agregar"
        ToolTip1.SetToolTip(btnAgregar, "Para agregar material asegurese de llenar todos los campos")
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' txtMaterial
        ' 
        txtMaterial.BackColor = Color.AliceBlue
        txtMaterial.Font = New Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMaterial.Location = New Point(125, 72)
        txtMaterial.Name = "txtMaterial"
        txtMaterial.PlaceholderText = "Nombre del material"
        txtMaterial.Size = New Size(146, 22)
        txtMaterial.TabIndex = 1
        ToolTip1.SetToolTip(txtMaterial, "Ingrese nombre del material. Ej: Cemento")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.LightSteelBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(125, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 20)
        Label1.TabIndex = 3
        Label1.Text = "Material"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.LightSteelBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(125, 118)
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
        DataGridView1.Location = New Point(73, 251)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(625, 253)
        DataGridView1.TabIndex = 5
        ' 
        ' btn_regresar
        ' 
        btn_regresar.BackColor = Color.Transparent
        btn_regresar.BackgroundImage = CType(resources.GetObject("btn_regresar.BackgroundImage"), Image)
        btn_regresar.BackgroundImageLayout = ImageLayout.Stretch
        btn_regresar.FlatStyle = FlatStyle.Popup
        btn_regresar.ImageAlign = ContentAlignment.BottomCenter
        btn_regresar.Location = New Point(641, 31)
        btn_regresar.Name = "btn_regresar"
        btn_regresar.Size = New Size(57, 48)
        btn_regresar.TabIndex = 6
        btn_regresar.TabStop = False
        btn_regresar.Tag = "Regresar al menú"
        ToolTip1.SetToolTip(btn_regresar, "Volver al menú")
        btn_regresar.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.LightSteelBlue
        Label3.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(225, 118)
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
        ComboBox1.Items.AddRange(New Object() {"Unidade(s)", "Kilogramo(s)", "Litro(s)", "Metros", "Metros cuadrado(s)", "Metros Cúbico(s)", "Milímetro(s)"})
        ComboBox1.Location = New Point(225, 144)
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
        txtbox1.Location = New Point(125, 42)
        txtbox1.Name = "txtbox1"
        txtbox1.Size = New Size(146, 24)
        txtbox1.TabIndex = 9
        ToolTip1.SetToolTip(txtbox1, "Seleccione un material para añadir")
        ' 
        ' btn_retirar
        ' 
        btn_retirar.BackColor = Color.IndianRed
        btn_retirar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_retirar.ForeColor = SystemColors.ActiveCaptionText
        btn_retirar.Location = New Point(429, 189)
        btn_retirar.Name = "btn_retirar"
        btn_retirar.Size = New Size(148, 42)
        btn_retirar.TabIndex = 10
        btn_retirar.Text = "Retirar Material"
        ToolTip1.SetToolTip(btn_retirar, "Para retirar material, asegurese de llenar todos los campos.")
        btn_retirar.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.LightSteelBlue
        Button1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(235, 521)
        Button1.Name = "Button1"
        Button1.Size = New Size(291, 45)
        Button1.TabIndex = 11
        Button1.Text = "Visualizar el inventario completo"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.BackColor = Color.Transparent
        CheckBox1.Font = New Font("Segoe UI Symbol", 7.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CheckBox1.ForeColor = Color.Black
        CheckBox1.Location = New Point(429, 80)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(141, 21)
        CheckBox1.TabIndex = 12
        CheckBox1.Text = "Agregar Medida"
        ToolTip1.SetToolTip(CheckBox1, "Tache esta opción si desea añadir una medida al material. Ej: 2 mm")
        CheckBox1.UseVisualStyleBackColor = False
        ' 
        ' cbMedida
        ' 
        cbMedida.BackColor = Color.AliceBlue
        cbMedida.Font = New Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cbMedida.FormattingEnabled = True
        cbMedida.Items.AddRange(New Object() {"cm", "mm", "m"})
        cbMedida.Location = New Point(524, 144)
        cbMedida.Name = "cbMedida"
        cbMedida.Size = New Size(68, 24)
        cbMedida.TabIndex = 14
        ToolTip1.SetToolTip(cbMedida, "Seleccione medida del material. Ej: cm")
        ' 
        ' lbl_medida
        ' 
        lbl_medida.AutoSize = True
        lbl_medida.BackColor = Color.LightSteelBlue
        lbl_medida.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_medida.ForeColor = SystemColors.ActiveCaptionText
        lbl_medida.Location = New Point(429, 118)
        lbl_medida.Name = "lbl_medida"
        lbl_medida.Size = New Size(163, 20)
        lbl_medida.TabIndex = 15
        lbl_medida.Text = "Medida del material"
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
        nCantidad.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nCantidad.Location = New Point(125, 144)
        nCantidad.Margin = New Padding(3, 4, 3, 4)
        nCantidad.Name = "nCantidad"
        nCantidad.Size = New Size(77, 25)
        nCantidad.TabIndex = 19
        ToolTip1.SetToolTip(nCantidad, "Ingrese Cantidad del material. Ej: 20")
        ' 
        ' nMedidas
        ' 
        nMedidas.BackColor = Color.AliceBlue
        nMedidas.Font = New Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nMedidas.Location = New Point(429, 144)
        nMedidas.Name = "nMedidas"
        nMedidas.Size = New Size(89, 22)
        nMedidas.TabIndex = 20
        ToolTip1.SetToolTip(nMedidas, "Ingrese nombre del material. Ej: Cemento")
        ' 
        ' mod_material
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(774, 578)
        Controls.Add(nMedidas)
        Controls.Add(nCantidad)
        Controls.Add(lbl_medida)
        Controls.Add(cbMedida)
        Controls.Add(CheckBox1)
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
        Cursor = Cursors.Hand
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
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cbMedida As ComboBox
    Friend WithEvents lbl_medida As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents nCantidad As NumericUpDown
    Friend WithEvents nMedidas As TextBox
End Class
