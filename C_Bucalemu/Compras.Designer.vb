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
        ToolTip1 = New ToolTip(components)
        Label4 = New Label()
        CType(nCantidad, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgCompras, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = Color.CornflowerBlue
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnAgregar.Location = New Point(69, 149)
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
        btnEliminar.BackColor = Color.IndianRed
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnEliminar.Location = New Point(380, 149)
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
        btnSolicitar.BackColor = Color.CornflowerBlue
        btnSolicitar.Cursor = Cursors.Hand
        btnSolicitar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnSolicitar.Location = New Point(231, 149)
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
        txtMaterial.Cursor = Cursors.IBeam
        txtMaterial.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMaterial.Location = New Point(52, 96)
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
        nCantidad.Location = New Point(380, 96)
        nCantidad.Margin = New Padding(4, 5, 4, 5)
        nCantidad.Name = "nCantidad"
        nCantidad.Size = New Size(133, 25)
        nCantidad.TabIndex = 5
        ToolTip1.SetToolTip(nCantidad, "Ingrese cantidad del material a solicitar")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.CornflowerBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label1.Location = New Point(52, 70)
        Label1.Name = "Label1"
        Label1.Size = New Size(132, 20)
        Label1.TabIndex = 6
        Label1.Text = "Ingrese Material"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.CornflowerBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label2.Location = New Point(380, 70)
        Label2.Name = "Label2"
        Label2.Size = New Size(143, 20)
        Label2.TabIndex = 7
        Label2.Text = "Agregar Cantidad"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), Image)
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.Cursor = Cursors.Hand
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Button1.Location = New Point(633, 126)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(74, 54)
        Button1.TabIndex = 8
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.CornflowerBlue
        Label3.Location = New Point(231, 70)
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
        cbUnidad.Items.AddRange(New Object() {"un", "mt", "kg", "pieza", "plancha"})
        cbUnidad.Location = New Point(231, 96)
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
        dgCompras.Location = New Point(52, 206)
        dgCompras.Margin = New Padding(3, 2, 3, 2)
        dgCompras.Name = "dgCompras"
        dgCompras.ReadOnly = True
        dgCompras.RowHeadersWidth = 51
        dgCompras.Size = New Size(655, 265)
        dgCompras.TabIndex = 11
        ' 
        ' ToolTip1
        ' 
        ToolTip1.BackColor = Color.Azure
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.DarkSlateGray
        Label4.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.HighlightText
        Label4.Location = New Point(52, 20)
        Label4.Name = "Label4"
        Label4.Size = New Size(299, 35)
        Label4.TabIndex = 19
        Label4.Text = "Ingreso de compras"
        ' 
        ' Compras
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(794, 488)
        Controls.Add(Label4)
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
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label4 As Label
End Class
