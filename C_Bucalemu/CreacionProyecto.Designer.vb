<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreacionProyecto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreacionProyecto))
        Label1 = New Label()
        txt_nombre = New TextBox()
        Label2 = New Label()
        cmb_encargado = New ComboBox()
        txt_descripcion = New TextBox()
        Label3 = New Label()
        btn_crear = New Button()
        btn_regresar = New Button()
        btn_ingresar = New Button()
        cmb_personal = New ComboBox()
        Label4 = New Label()
        dg_personal = New DataGridView()
        btn_eliminar = New Button()
        Label5 = New Label()
        CType(dg_personal, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.CornflowerBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(93, 86)
        Label1.Name = "Label1"
        Label1.Size = New Size(171, 20)
        Label1.TabIndex = 0
        Label1.Text = "Nombre del proyecto"
        ' 
        ' txt_nombre
        ' 
        txt_nombre.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt_nombre.Location = New Point(93, 109)
        txt_nombre.Name = "txt_nombre"
        txt_nombre.PlaceholderText = "Ingrese nombre del proyecto"
        txt_nombre.Size = New Size(222, 25)
        txt_nombre.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.CornflowerBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(93, 320)
        Label2.Name = "Label2"
        Label2.Size = New Size(190, 20)
        Label2.TabIndex = 2
        Label2.Text = "Encargado del proyecto"
        ' 
        ' cmb_encargado
        ' 
        cmb_encargado.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmb_encargado.FormattingEnabled = True
        cmb_encargado.Location = New Point(93, 343)
        cmb_encargado.Name = "cmb_encargado"
        cmb_encargado.Size = New Size(222, 25)
        cmb_encargado.TabIndex = 3
        ' 
        ' txt_descripcion
        ' 
        txt_descripcion.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt_descripcion.Location = New Point(93, 174)
        txt_descripcion.Multiline = True
        txt_descripcion.Name = "txt_descripcion"
        txt_descripcion.PlaceholderText = "Ingrese breve descripción"
        txt_descripcion.Size = New Size(222, 127)
        txt_descripcion.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.CornflowerBlue
        Label3.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(93, 151)
        Label3.Name = "Label3"
        Label3.Size = New Size(199, 20)
        Label3.TabIndex = 5
        Label3.Text = "Descripción del proyecto"
        ' 
        ' btn_crear
        ' 
        btn_crear.BackColor = Color.CornflowerBlue
        btn_crear.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_crear.Location = New Point(232, 419)
        btn_crear.Name = "btn_crear"
        btn_crear.Size = New Size(225, 39)
        btn_crear.TabIndex = 7
        btn_crear.Text = "Crear"
        btn_crear.UseVisualStyleBackColor = False
        ' 
        ' btn_regresar
        ' 
        btn_regresar.BackColor = Color.Transparent
        btn_regresar.BackgroundImage = CType(resources.GetObject("btn_regresar.BackgroundImage"), Image)
        btn_regresar.BackgroundImageLayout = ImageLayout.Stretch
        btn_regresar.FlatStyle = FlatStyle.Popup
        btn_regresar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_regresar.Location = New Point(312, 473)
        btn_regresar.Name = "btn_regresar"
        btn_regresar.Size = New Size(57, 49)
        btn_regresar.TabIndex = 8
        btn_regresar.UseVisualStyleBackColor = False
        ' 
        ' btn_ingresar
        ' 
        btn_ingresar.BackColor = Color.CornflowerBlue
        btn_ingresar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_ingresar.Location = New Point(509, 109)
        btn_ingresar.Name = "btn_ingresar"
        btn_ingresar.Size = New Size(80, 28)
        btn_ingresar.TabIndex = 11
        btn_ingresar.Text = "Ingresar"
        btn_ingresar.UseVisualStyleBackColor = False
        ' 
        ' cmb_personal
        ' 
        cmb_personal.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmb_personal.FormattingEnabled = True
        cmb_personal.Location = New Point(364, 109)
        cmb_personal.Name = "cmb_personal"
        cmb_personal.Size = New Size(139, 25)
        cmb_personal.TabIndex = 10
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.CornflowerBlue
        Label4.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(364, 86)
        Label4.Name = "Label4"
        Label4.Size = New Size(174, 20)
        Label4.TabIndex = 9
        Label4.Text = "Personal del proyecto"
        ' 
        ' dg_personal
        ' 
        dg_personal.BackgroundColor = Color.AliceBlue
        dg_personal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dg_personal.Location = New Point(364, 151)
        dg_personal.Name = "dg_personal"
        dg_personal.RowHeadersWidth = 51
        dg_personal.Size = New Size(225, 171)
        dg_personal.TabIndex = 12
        ' 
        ' btn_eliminar
        ' 
        btn_eliminar.BackColor = Color.IndianRed
        btn_eliminar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_eliminar.Location = New Point(364, 332)
        btn_eliminar.Name = "btn_eliminar"
        btn_eliminar.Size = New Size(225, 36)
        btn_eliminar.TabIndex = 13
        btn_eliminar.Text = "Eliminar personal"
        btn_eliminar.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.DarkSlateGray
        Label5.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.HighlightText
        Label5.Location = New Point(174, 25)
        Label5.Name = "Label5"
        Label5.Size = New Size(329, 35)
        Label5.TabIndex = 14
        Label5.Text = "Creación del proyecto"
        ' 
        ' CreacionProyecto
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(669, 540)
        Controls.Add(Label5)
        Controls.Add(btn_eliminar)
        Controls.Add(dg_personal)
        Controls.Add(btn_ingresar)
        Controls.Add(cmb_personal)
        Controls.Add(Label4)
        Controls.Add(btn_regresar)
        Controls.Add(btn_crear)
        Controls.Add(txt_descripcion)
        Controls.Add(Label3)
        Controls.Add(cmb_encargado)
        Controls.Add(Label2)
        Controls.Add(txt_nombre)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "CreacionProyecto"
        Text = "CreacionProyecto"
        CType(dg_personal, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt_nombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmb_encargado As ComboBox
    Friend WithEvents txt_descripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_crear As Button
    Friend WithEvents btn_regresar As Button
    Friend WithEvents btn_ingresar As Button
    Friend WithEvents cmb_personal As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dg_personal As DataGridView
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents Label5 As Label
End Class
