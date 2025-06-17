<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario))
        Prueba = New Label()
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        Button2 = New Button()
        btn_total = New Button()
        btn_reestablecer = New Button()
        txt_buscar = New TextBox()
        Label1 = New Label()
        btn_consultar = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Prueba
        ' 
        Prueba.AutoSize = True
        Prueba.BackColor = Color.DarkSlateGray
        Prueba.FlatStyle = FlatStyle.Flat
        Prueba.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Prueba.ForeColor = SystemColors.HighlightText
        Prueba.Location = New Point(653, 45)
        Prueba.Name = "Prueba"
        Prueba.Size = New Size(385, 35)
        Prueba.TabIndex = 2
        Prueba.Text = "Información de materiales"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.AliceBlue
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(379, 95)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(910, 650)
        DataGridView1.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), Image)
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderColor = Color.White
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Location = New Point(156, 435)
        Button1.Name = "Button1"
        Button1.Size = New Size(61, 50)
        Button1.TabIndex = 4
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.CornflowerBlue
        Button2.Cursor = Cursors.Hand
        Button2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(54, 219)
        Button2.Name = "Button2"
        Button2.Size = New Size(268, 52)
        Button2.TabIndex = 5
        Button2.Text = "Gestión de Inventario"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' btn_total
        ' 
        btn_total.BackColor = Color.CornflowerBlue
        btn_total.Cursor = Cursors.Hand
        btn_total.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_total.Location = New Point(54, 161)
        btn_total.Name = "btn_total"
        btn_total.Size = New Size(268, 52)
        btn_total.TabIndex = 6
        btn_total.Text = "Total de Material"
        btn_total.UseVisualStyleBackColor = False
        ' 
        ' btn_reestablecer
        ' 
        btn_reestablecer.BackColor = Color.IndianRed
        btn_reestablecer.Cursor = Cursors.Hand
        btn_reestablecer.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_reestablecer.Location = New Point(54, 358)
        btn_reestablecer.Name = "btn_reestablecer"
        btn_reestablecer.Size = New Size(268, 52)
        btn_reestablecer.TabIndex = 7
        btn_reestablecer.Text = "Reestablecer inventario"
        btn_reestablecer.UseVisualStyleBackColor = False
        ' 
        ' txt_buscar
        ' 
        txt_buscar.BackColor = Color.AliceBlue
        txt_buscar.Cursor = Cursors.IBeam
        txt_buscar.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt_buscar.Location = New Point(54, 95)
        txt_buscar.Name = "txt_buscar"
        txt_buscar.PlaceholderText = "Ingrese nombre del material a buscar"
        txt_buscar.Size = New Size(268, 25)
        txt_buscar.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSlateGray
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(54, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 35)
        Label1.TabIndex = 9
        Label1.Text = "Busqueda"
        ' 
        ' btn_consultar
        ' 
        btn_consultar.BackColor = Color.CornflowerBlue
        btn_consultar.Cursor = Cursors.Hand
        btn_consultar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_consultar.Location = New Point(54, 277)
        btn_consultar.Name = "btn_consultar"
        btn_consultar.Size = New Size(268, 52)
        btn_consultar.TabIndex = 10
        btn_consultar.Text = "Consultar stock"
        btn_consultar.UseVisualStyleBackColor = False
        ' 
        ' Inventario
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CornflowerBlue
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1345, 802)
        Controls.Add(btn_consultar)
        Controls.Add(Label1)
        Controls.Add(txt_buscar)
        Controls.Add(btn_reestablecer)
        Controls.Add(btn_total)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Controls.Add(Prueba)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        Name = "Inventario"
        Text = "Inventario"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Prueba As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btn_total As Button
    Friend WithEvents btn_reestablecer As Button
    Friend WithEvents txt_buscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_consultar As Button
End Class
