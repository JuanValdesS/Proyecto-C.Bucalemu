<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Compras))
        btnAgregar = New Button()
        btnEliminar = New Button()
        btnSolicitar = New Button()
        txtMaterial = New TextBox()
        nCantidad = New NumericUpDown()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Label3 = New Label()
        cbUnidad = New ComboBox()
        dgCompras = New DataGridView()
        cbMedidas = New CheckBox()
        cmMedida = New ComboBox()
        lbl_medida = New Label()
        ToolTip1 = New ToolTip(components)
        nMedidas = New TextBox()
        CType(nCantidad, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgCompras, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = SystemColors.ActiveCaption
        btnAgregar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnAgregar.Location = New Point(755, 158)
        btnAgregar.Margin = New Padding(3, 4, 3, 4)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(96, 31)
        btnAgregar.TabIndex = 0
        btnAgregar.Text = "Agregar"
        ToolTip1.SetToolTip(btnAgregar, "Seleccione para agregar sus datos antes de enviar")
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = SystemColors.ActiveCaption
        btnEliminar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnEliminar.Location = New Point(755, 235)
        btnEliminar.Margin = New Padding(3, 4, 3, 4)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(96, 31)
        btnEliminar.TabIndex = 1
        btnEliminar.Text = "Eliminar"
        ToolTip1.SetToolTip(btnEliminar, "Seleccione para eliminar la Solicitud")
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' btnSolicitar
        ' 
        btnSolicitar.BackColor = SystemColors.ActiveCaption
        btnSolicitar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnSolicitar.Location = New Point(755, 196)
        btnSolicitar.Margin = New Padding(3, 4, 3, 4)
        btnSolicitar.Name = "btnSolicitar"
        btnSolicitar.Size = New Size(96, 31)
        btnSolicitar.TabIndex = 2
        btnSolicitar.Text = "Solicitar"
        ToolTip1.SetToolTip(btnSolicitar, "Seleccione para enviar la solicitud de compra al administrador")
        btnSolicitar.UseVisualStyleBackColor = False
        ' 
        ' txtMaterial
        ' 
        txtMaterial.BackColor = Color.AliceBlue
        txtMaterial.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMaterial.Location = New Point(136, 48)
        txtMaterial.Margin = New Padding(3, 4, 3, 4)
        txtMaterial.Name = "txtMaterial"
        txtMaterial.PlaceholderText = "Nombre del material"
        txtMaterial.Size = New Size(133, 25)
        txtMaterial.TabIndex = 4
        ToolTip1.SetToolTip(txtMaterial, "Ingrese nombre del material a solicitar.")
        ' 
        ' nCantidad
        ' 
        nCantidad.BackColor = Color.AliceBlue
        nCantidad.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nCantidad.Location = New Point(136, 115)
        nCantidad.Margin = New Padding(4, 5, 4, 5)
        nCantidad.Name = "nCantidad"
        nCantidad.Size = New Size(133, 25)
        nCantidad.TabIndex = 5
        ToolTip1.SetToolTip(nCantidad, "Ingrese cantidad del material a solicitar")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.LightSteelBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label1.Location = New Point(136, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(132, 20)
        Label1.TabIndex = 6
        Label1.Text = "Ingrese Material"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.LightSteelBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label2.Location = New Point(136, 89)
        Label2.Name = "Label2"
        Label2.Size = New Size(143, 20)
        Label2.TabIndex = 7
        Label2.Text = "Agregar Cantidad"
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ActiveCaption
        Button1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Button1.Location = New Point(755, 391)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(96, 31)
        Button1.TabIndex = 8
        Button1.Text = "Menu"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(315, 22)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 20)
        Label3.TabIndex = 9
        Label3.Text = "Unidad"
        ' 
        ' cbUnidad
        ' 
        cbUnidad.BackColor = Color.AliceBlue
        cbUnidad.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cbUnidad.FormattingEnabled = True
        cbUnidad.Items.AddRange(New Object() {"Unidade(s)", "Kilogramo(s)", "Litro(s)", "Metros", "Metros cuadrado(s)", "Metros Cúbico(s)", "Milímetro(s)"})
        cbUnidad.Location = New Point(315, 48)
        cbUnidad.Margin = New Padding(3, 2, 3, 2)
        cbUnidad.Name = "cbUnidad"
        cbUnidad.Size = New Size(89, 25)
        cbUnidad.TabIndex = 10
        ToolTip1.SetToolTip(cbUnidad, "Seleccione unidad del material a solicitar")
        ' 
        ' dgCompras
        ' 
        dgCompras.AllowUserToAddRows = False
        dgCompras.AllowUserToDeleteRows = False
        dgCompras.BackgroundColor = Color.AliceBlue
        dgCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgCompras.Location = New Point(136, 158)
        dgCompras.Margin = New Padding(3, 2, 3, 2)
        dgCompras.Name = "dgCompras"
        dgCompras.ReadOnly = True
        dgCompras.RowHeadersWidth = 51
        dgCompras.Size = New Size(528, 265)
        dgCompras.TabIndex = 11
        ' 
        ' cbMedidas
        ' 
        cbMedidas.AutoSize = True
        cbMedidas.BackColor = Color.Transparent
        cbMedidas.Location = New Point(275, 114)
        cbMedidas.Margin = New Padding(3, 2, 3, 2)
        cbMedidas.Name = "cbMedidas"
        cbMedidas.Size = New Size(161, 24)
        cbMedidas.TabIndex = 12
        cbMedidas.Text = "Agregar medidas"
        ToolTip1.SetToolTip(cbMedidas, "Tache la opción si desea agregar medidas especificas para el material.")
        cbMedidas.UseVisualStyleBackColor = False
        ' 
        ' cmMedida
        ' 
        cmMedida.BackColor = Color.AliceBlue
        cmMedida.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmMedida.FormattingEnabled = True
        cmMedida.Items.AddRange(New Object() {"cm", "mm", "m"})
        cmMedida.Location = New Point(557, 112)
        cmMedida.Margin = New Padding(3, 2, 3, 2)
        cmMedida.Name = "cmMedida"
        cmMedida.Size = New Size(70, 25)
        cmMedida.TabIndex = 13
        ToolTip1.SetToolTip(cmMedida, "Seleccione medida del material. Ej: cm")
        ' 
        ' lbl_medida
        ' 
        lbl_medida.AutoSize = True
        lbl_medida.BackColor = Color.LightSteelBlue
        lbl_medida.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        lbl_medida.ForeColor = SystemColors.ActiveCaptionText
        lbl_medida.Location = New Point(463, 89)
        lbl_medida.Name = "lbl_medida"
        lbl_medida.Size = New Size(163, 20)
        lbl_medida.TabIndex = 16
        lbl_medida.Text = "Medida del material"
        ' 
        ' ToolTip1
        ' 
        ToolTip1.BackColor = Color.Azure
        ' 
        ' nMedidas
        ' 
        nMedidas.BackColor = Color.AliceBlue
        nMedidas.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nMedidas.Location = New Point(463, 112)
        nMedidas.Margin = New Padding(3, 4, 3, 4)
        nMedidas.Name = "nMedidas"
        nMedidas.Size = New Size(88, 25)
        nMedidas.TabIndex = 18
        ' 
        ' Compras
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(887, 451)
        Controls.Add(nMedidas)
        Controls.Add(lbl_medida)
        Controls.Add(cmMedida)
        Controls.Add(cbMedidas)
        Controls.Add(dgCompras)
        Controls.Add(cbUnidad)
        Controls.Add(Label3)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(nCantidad)
        Controls.Add(txtMaterial)
        Controls.Add(btnSolicitar)
        Controls.Add(btnEliminar)
        Controls.Add(btnAgregar)
        Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Compras"
        Text = "Compras"
        CType(nCantidad, ComponentModel.ISupportInitialize).EndInit()
        CType(dgCompras, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnSolicitar As Button
    Friend WithEvents txtMaterial As TextBox
    Friend WithEvents nCantidad As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbUnidad As ComboBox
    Friend WithEvents dgCompras As DataGridView
    Friend WithEvents cbMedidas As CheckBox
    Friend WithEvents cmMedida As ComboBox
    Friend WithEvents lbl_medida As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents nMedidas As TextBox
End Class
