<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionarInventarioGlobal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionarInventarioGlobal))
        Prueba = New Label()
        dgvInventario = New DataGridView()
        nCantidad = New NumericUpDown()
        btn_retirar = New Button()
        txtbox1 = New ComboBox()
        ComboBox1 = New ComboBox()
        Label3 = New Label()
        btn_regresar = New Button()
        Label2 = New Label()
        Label1 = New Label()
        txtMaterial = New TextBox()
        btnAgregar = New Button()
        CType(dgvInventario, ComponentModel.ISupportInitialize).BeginInit()
        CType(nCantidad, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Prueba
        ' 
        Prueba.AutoSize = True
        Prueba.BackColor = Color.DarkSlateGray
        Prueba.FlatStyle = FlatStyle.Flat
        Prueba.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Prueba.ForeColor = SystemColors.HighlightText
        Prueba.Location = New Point(492, 50)
        Prueba.Name = "Prueba"
        Prueba.Size = New Size(562, 35)
        Prueba.TabIndex = 21
        Prueba.Text = "Información de materiales remanentes"
        ' 
        ' dgvInventario
        ' 
        dgvInventario.AllowUserToAddRows = False
        dgvInventario.AllowUserToDeleteRows = False
        dgvInventario.AllowUserToResizeColumns = False
        dgvInventario.BackgroundColor = Color.AliceBlue
        dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInventario.Location = New Point(342, 124)
        dgvInventario.Name = "dgvInventario"
        dgvInventario.ReadOnly = True
        dgvInventario.RowHeadersWidth = 51
        dgvInventario.Size = New Size(952, 635)
        dgvInventario.TabIndex = 22
        ' 
        ' nCantidad
        ' 
        nCantidad.BackColor = Color.AliceBlue
        nCantidad.DecimalPlaces = 2
        nCantidad.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nCantidad.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        nCantidad.Location = New Point(89, 282)
        nCantidad.Margin = New Padding(3, 4, 3, 4)
        nCantidad.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        nCantidad.Name = "nCantidad"
        nCantidad.Size = New Size(77, 25)
        nCantidad.TabIndex = 32
        ' 
        ' btn_retirar
        ' 
        btn_retirar.BackColor = Color.IndianRed
        btn_retirar.Cursor = Cursors.Hand
        btn_retirar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_retirar.ForeColor = SystemColors.ActiveCaptionText
        btn_retirar.Location = New Point(105, 403)
        btn_retirar.Name = "btn_retirar"
        btn_retirar.Size = New Size(146, 42)
        btn_retirar.TabIndex = 31
        btn_retirar.Text = "Retirar Material"
        btn_retirar.UseVisualStyleBackColor = False
        ' 
        ' txtbox1
        ' 
        txtbox1.BackColor = Color.AliceBlue
        txtbox1.Font = New Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtbox1.FormattingEnabled = True
        txtbox1.Location = New Point(27, 163)
        txtbox1.Name = "txtbox1"
        txtbox1.Size = New Size(291, 24)
        txtbox1.TabIndex = 30
        ' 
        ' ComboBox1
        ' 
        ComboBox1.BackColor = Color.AliceBlue
        ComboBox1.Font = New Font("Arial", 7.8F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"un", "mt", "ml", "m2", "m3", "gl", "kg", "tira", "rollo", "malla", "sacos", "tineta", "pieza", "plancha", "", ""})
        ComboBox1.Location = New Point(189, 282)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(79, 24)
        ComboBox1.TabIndex = 29
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.CornflowerBlue
        Label3.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(189, 256)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 20)
        Label3.TabIndex = 28
        Label3.Text = "Unidades"
        ' 
        ' btn_regresar
        ' 
        btn_regresar.BackColor = Color.Transparent
        btn_regresar.BackgroundImage = CType(resources.GetObject("btn_regresar.BackgroundImage"), Image)
        btn_regresar.BackgroundImageLayout = ImageLayout.Stretch
        btn_regresar.Cursor = Cursors.Hand
        btn_regresar.FlatStyle = FlatStyle.Popup
        btn_regresar.ImageAlign = ContentAlignment.BottomCenter
        btn_regresar.Location = New Point(158, 478)
        btn_regresar.Name = "btn_regresar"
        btn_regresar.Size = New Size(57, 48)
        btn_regresar.TabIndex = 27
        btn_regresar.TabStop = False
        btn_regresar.Tag = "Regresar al menú"
        btn_regresar.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.CornflowerBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(89, 256)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 20)
        Label2.TabIndex = 26
        Label2.Text = "Cantidad"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.CornflowerBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(105, 124)
        Label1.Name = "Label1"
        Label1.Size = New Size(139, 20)
        Label1.TabIndex = 25
        Label1.Text = "Material a añadir"
        ' 
        ' txtMaterial
        ' 
        txtMaterial.BackColor = Color.AliceBlue
        txtMaterial.Cursor = Cursors.IBeam
        txtMaterial.Font = New Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMaterial.Location = New Point(27, 193)
        txtMaterial.Name = "txtMaterial"
        txtMaterial.PlaceholderText = "Nombre del material"
        txtMaterial.Size = New Size(291, 22)
        txtMaterial.TabIndex = 24
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = Color.CornflowerBlue
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnAgregar.ForeColor = SystemColors.ActiveCaptionText
        btnAgregar.Location = New Point(89, 327)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(179, 42)
        btnAgregar.TabIndex = 23
        btnAgregar.Text = "Agregar Material"
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' GestionarInventarioGlobal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1345, 802)
        Controls.Add(nCantidad)
        Controls.Add(btn_retirar)
        Controls.Add(txtbox1)
        Controls.Add(ComboBox1)
        Controls.Add(Label3)
        Controls.Add(btn_regresar)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtMaterial)
        Controls.Add(btnAgregar)
        Controls.Add(dgvInventario)
        Controls.Add(Prueba)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "GestionarInventarioGlobal"
        Text = "GestionarInventarioGlobal"
        CType(dgvInventario, ComponentModel.ISupportInitialize).EndInit()
        CType(nCantidad, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Prueba As Label
    Friend WithEvents dgvInventario As DataGridView
    Friend WithEvents nCantidad As NumericUpDown
    Friend WithEvents btn_retirar As Button
    Friend WithEvents txtbox1 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_regresar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMaterial As TextBox
    Friend WithEvents btnAgregar As Button
End Class
