<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cubicacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cubicacion))
        cmbMaterial = New ComboBox()
        cmbTipoCubica = New ComboBox()
        txtLargo = New TextBox()
        txtAncho = New TextBox()
        txtAlto = New TextBox()
        btncubicar = New Button()
        lblResultado = New Label()
        dgCubicacion = New DataGridView()
        btnRegresar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        txtCantidadUnidades = New TextBox()
        CType(dgCubicacion, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cmbMaterial
        ' 
        cmbMaterial.BackColor = Color.Honeydew
        cmbMaterial.Font = New Font("Segoe UI Symbol", 9F)
        cmbMaterial.FormattingEnabled = True
        cmbMaterial.Items.AddRange(New Object() {"Agua", "Arena", "Cemento", "Clavos", "Grava", "Madera", "Ladrillos", "Ripio"})
        cmbMaterial.Location = New Point(112, 75)
        cmbMaterial.Name = "cmbMaterial"
        cmbMaterial.Size = New Size(124, 28)
        cmbMaterial.TabIndex = 0
        ' 
        ' cmbTipoCubica
        ' 
        cmbTipoCubica.BackColor = Color.Honeydew
        cmbTipoCubica.Font = New Font("Segoe UI Symbol", 9F)
        cmbTipoCubica.FormattingEnabled = True
        cmbTipoCubica.Location = New Point(278, 75)
        cmbTipoCubica.Name = "cmbTipoCubica"
        cmbTipoCubica.Size = New Size(202, 28)
        cmbTipoCubica.TabIndex = 1
        ' 
        ' txtLargo
        ' 
        txtLargo.BackColor = Color.Honeydew
        txtLargo.Font = New Font("Segoe UI Symbol", 9F)
        txtLargo.Location = New Point(115, 192)
        txtLargo.Name = "txtLargo"
        txtLargo.PlaceholderText = "Largo del material"
        txtLargo.Size = New Size(129, 27)
        txtLargo.TabIndex = 2
        ' 
        ' txtAncho
        ' 
        txtAncho.BackColor = Color.Honeydew
        txtAncho.Font = New Font("Segoe UI Symbol", 9F)
        txtAncho.Location = New Point(263, 192)
        txtAncho.Name = "txtAncho"
        txtAncho.PlaceholderText = "Ancho del material"
        txtAncho.Size = New Size(137, 27)
        txtAncho.TabIndex = 3
        ' 
        ' txtAlto
        ' 
        txtAlto.BackColor = Color.Honeydew
        txtAlto.Font = New Font("Segoe UI Symbol", 9F)
        txtAlto.Location = New Point(420, 192)
        txtAlto.Name = "txtAlto"
        txtAlto.PlaceholderText = "Alto del material"
        txtAlto.Size = New Size(122, 27)
        txtAlto.TabIndex = 4
        ' 
        ' btncubicar
        ' 
        btncubicar.BackColor = Color.PaleTurquoise
        btncubicar.Cursor = Cursors.Hand
        btncubicar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btncubicar.Location = New Point(115, 337)
        btncubicar.Name = "btncubicar"
        btncubicar.Size = New Size(115, 55)
        btncubicar.TabIndex = 5
        btncubicar.Text = "Cubicar"
        btncubicar.UseVisualStyleBackColor = False
        ' 
        ' lblResultado
        ' 
        lblResultado.AutoSize = True
        lblResultado.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResultado.Location = New Point(115, 415)
        lblResultado.Name = "lblResultado"
        lblResultado.Size = New Size(71, 20)
        lblResultado.TabIndex = 6
        lblResultado.Text = "Mensaje"
        ' 
        ' dgCubicacion
        ' 
        dgCubicacion.BackgroundColor = Color.Honeydew
        dgCubicacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgCubicacion.Location = New Point(115, 456)
        dgCubicacion.Name = "dgCubicacion"
        dgCubicacion.RowHeadersWidth = 51
        dgCubicacion.Size = New Size(433, 153)
        dgCubicacion.TabIndex = 7
        ' 
        ' btnRegresar
        ' 
        btnRegresar.BackColor = Color.Transparent
        btnRegresar.BackgroundImage = CType(resources.GetObject("btnRegresar.BackgroundImage"), Image)
        btnRegresar.BackgroundImageLayout = ImageLayout.Stretch
        btnRegresar.Cursor = Cursors.Hand
        btnRegresar.FlatStyle = FlatStyle.Popup
        btnRegresar.Location = New Point(263, 343)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(62, 42)
        btnRegresar.TabIndex = 8
        btnRegresar.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.PaleTurquoise
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(112, 52)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 20)
        Label1.TabIndex = 9
        Label1.Text = "Material"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.PaleTurquoise
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(278, 52)
        Label2.Name = "Label2"
        Label2.Size = New Size(131, 20)
        Label2.TabIndex = 10
        Label2.Text = "Tipo Cubicación"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.PaleTurquoise
        Label3.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(114, 169)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 20)
        Label3.TabIndex = 11
        Label3.Text = "Largo (m)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.PaleTurquoise
        Label4.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(263, 169)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 20)
        Label4.TabIndex = 12
        Label4.Text = "Ancho (m)"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.PaleTurquoise
        Label5.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(420, 169)
        Label5.Name = "Label5"
        Label5.Size = New Size(72, 20)
        Label5.TabIndex = 13
        Label5.Text = "Alto (m)"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.DarkSlateGray
        Label6.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.MenuBar
        Label6.Location = New Point(112, 130)
        Label6.Name = "Label6"
        Label6.Size = New Size(480, 20)
        Label6.TabIndex = 14
        Label6.Text = "Tenga en cuenta que las medidas se deben ingresar en metros"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.PaleTurquoise
        Label7.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(112, 246)
        Label7.Name = "Label7"
        Label7.Size = New Size(423, 20)
        Label7.TabIndex = 16
        Label7.Text = "Dimensiones o Unidades (si es que no require medida)"
        ' 
        ' txtCantidadUnidades
        ' 
        txtCantidadUnidades.BackColor = Color.Honeydew
        txtCantidadUnidades.Font = New Font("Segoe UI Symbol", 9F)
        txtCantidadUnidades.Location = New Point(112, 269)
        txtCantidadUnidades.Name = "txtCantidadUnidades"
        txtCantidadUnidades.PlaceholderText = "Cantidad"
        txtCantidadUnidades.Size = New Size(85, 27)
        txtCantidadUnidades.TabIndex = 15
        ' 
        ' Cubicacion
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Honeydew
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(678, 664)
        Controls.Add(Label7)
        Controls.Add(txtCantidadUnidades)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnRegresar)
        Controls.Add(dgCubicacion)
        Controls.Add(lblResultado)
        Controls.Add(btncubicar)
        Controls.Add(txtAlto)
        Controls.Add(txtAncho)
        Controls.Add(txtLargo)
        Controls.Add(cmbTipoCubica)
        Controls.Add(cmbMaterial)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Cubicacion"
        Text = "Cubicacion"
        CType(dgCubicacion, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbMaterial As ComboBox
    Friend WithEvents cmbTipoCubica As ComboBox
    Friend WithEvents txtLargo As TextBox
    Friend WithEvents txtAncho As TextBox
    Friend WithEvents txtAlto As TextBox
    Friend WithEvents btncubicar As Button
    Friend WithEvents lblResultado As Label
    Friend WithEvents dgCubicacion As DataGridView
    Friend WithEvents btnRegresar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCantidadUnidades As TextBox
End Class
