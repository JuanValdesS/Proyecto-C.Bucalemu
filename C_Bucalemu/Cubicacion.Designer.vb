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
        cmbMaterial.BackColor = Color.AliceBlue
        cmbMaterial.Font = New Font("Arial", 7.8F)
        cmbMaterial.FormattingEnabled = True
        cmbMaterial.Items.AddRange(New Object() {"Agua", "Arena", "Cemento", "Clavos", "Grava", "Madera", "Ladrillos", "Ripio"})
        cmbMaterial.Location = New Point(98, 64)
        cmbMaterial.Margin = New Padding(3, 2, 3, 2)
        cmbMaterial.Name = "cmbMaterial"
        cmbMaterial.Size = New Size(109, 24)
        cmbMaterial.TabIndex = 0
        ' 
        ' cmbTipoCubica
        ' 
        cmbTipoCubica.BackColor = Color.AliceBlue
        cmbTipoCubica.Font = New Font("Arial", 7.8F)
        cmbTipoCubica.FormattingEnabled = True
        cmbTipoCubica.Location = New Point(243, 64)
        cmbTipoCubica.Margin = New Padding(3, 2, 3, 2)
        cmbTipoCubica.Name = "cmbTipoCubica"
        cmbTipoCubica.Size = New Size(177, 24)
        cmbTipoCubica.TabIndex = 1
        ' 
        ' txtLargo
        ' 
        txtLargo.BackColor = Color.AliceBlue
        txtLargo.Cursor = Cursors.IBeam
        txtLargo.Font = New Font("Arial", 7.8F)
        txtLargo.Location = New Point(98, 157)
        txtLargo.Margin = New Padding(3, 2, 3, 2)
        txtLargo.Name = "txtLargo"
        txtLargo.PlaceholderText = "Largo del material"
        txtLargo.Size = New Size(113, 22)
        txtLargo.TabIndex = 2
        ' 
        ' txtAncho
        ' 
        txtAncho.BackColor = Color.AliceBlue
        txtAncho.Cursor = Cursors.IBeam
        txtAncho.Font = New Font("Arial", 7.8F)
        txtAncho.Location = New Point(230, 157)
        txtAncho.Margin = New Padding(3, 2, 3, 2)
        txtAncho.Name = "txtAncho"
        txtAncho.PlaceholderText = "Ancho del material"
        txtAncho.Size = New Size(120, 22)
        txtAncho.TabIndex = 3
        ' 
        ' txtAlto
        ' 
        txtAlto.BackColor = Color.AliceBlue
        txtAlto.Cursor = Cursors.IBeam
        txtAlto.Font = New Font("Arial", 7.8F)
        txtAlto.Location = New Point(368, 157)
        txtAlto.Margin = New Padding(3, 2, 3, 2)
        txtAlto.Name = "txtAlto"
        txtAlto.PlaceholderText = "Alto del material"
        txtAlto.Size = New Size(107, 22)
        txtAlto.TabIndex = 4
        ' 
        ' btncubicar
        ' 
        btncubicar.BackColor = Color.CornflowerBlue
        btncubicar.Cursor = Cursors.Hand
        btncubicar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btncubicar.Location = New Point(97, 268)
        btncubicar.Margin = New Padding(3, 2, 3, 2)
        btncubicar.Name = "btncubicar"
        btncubicar.Size = New Size(101, 44)
        btncubicar.TabIndex = 5
        btncubicar.Text = "Cubicar"
        btncubicar.UseVisualStyleBackColor = False
        ' 
        ' lblResultado
        ' 
        lblResultado.AutoSize = True
        lblResultado.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResultado.Location = New Point(97, 333)
        lblResultado.Name = "lblResultado"
        lblResultado.Size = New Size(71, 20)
        lblResultado.TabIndex = 6
        lblResultado.Text = "Mensaje"
        ' 
        ' dgCubicacion
        ' 
        dgCubicacion.BackgroundColor = Color.AliceBlue
        dgCubicacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgCubicacion.Location = New Point(96, 365)
        dgCubicacion.Margin = New Padding(3, 2, 3, 2)
        dgCubicacion.Name = "dgCubicacion"
        dgCubicacion.RowHeadersWidth = 51
        dgCubicacion.Size = New Size(379, 122)
        dgCubicacion.TabIndex = 7
        ' 
        ' btnRegresar
        ' 
        btnRegresar.BackColor = Color.Transparent
        btnRegresar.BackgroundImage = CType(resources.GetObject("btnRegresar.BackgroundImage"), Image)
        btnRegresar.BackgroundImageLayout = ImageLayout.Stretch
        btnRegresar.Cursor = Cursors.Hand
        btnRegresar.FlatStyle = FlatStyle.Popup
        btnRegresar.Location = New Point(230, 274)
        btnRegresar.Margin = New Padding(3, 2, 3, 2)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(54, 34)
        btnRegresar.TabIndex = 8
        btnRegresar.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.CornflowerBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(98, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 20)
        Label1.TabIndex = 9
        Label1.Text = "Material"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.CornflowerBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(243, 42)
        Label2.Name = "Label2"
        Label2.Size = New Size(131, 20)
        Label2.TabIndex = 10
        Label2.Text = "Tipo Cubicación"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.CornflowerBlue
        Label3.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(100, 135)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 20)
        Label3.TabIndex = 11
        Label3.Text = "Largo (m)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.CornflowerBlue
        Label4.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(230, 135)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 20)
        Label4.TabIndex = 12
        Label4.Text = "Ancho (m)"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.CornflowerBlue
        Label5.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(368, 135)
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
        Label6.Location = New Point(98, 104)
        Label6.Name = "Label6"
        Label6.Size = New Size(480, 20)
        Label6.TabIndex = 14
        Label6.Text = "Tenga en cuenta que las medidas se deben ingresar en metros"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.CornflowerBlue
        Label7.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(98, 197)
        Label7.Name = "Label7"
        Label7.Size = New Size(423, 20)
        Label7.TabIndex = 16
        Label7.Text = "Dimensiones o Unidades (si es que no require medida)"
        ' 
        ' txtCantidadUnidades
        ' 
        txtCantidadUnidades.BackColor = Color.AliceBlue
        txtCantidadUnidades.Cursor = Cursors.IBeam
        txtCantidadUnidades.Font = New Font("Arial", 7.8F)
        txtCantidadUnidades.Location = New Point(97, 219)
        txtCantidadUnidades.Margin = New Padding(3, 2, 3, 2)
        txtCantidadUnidades.Name = "txtCantidadUnidades"
        txtCantidadUnidades.PlaceholderText = "Cantidad"
        txtCantidadUnidades.Size = New Size(75, 22)
        txtCantidadUnidades.TabIndex = 15
        ' 
        ' Cubicacion
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.AliceBlue
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(593, 531)
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
        Font = New Font("Arial", 7.8F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
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
