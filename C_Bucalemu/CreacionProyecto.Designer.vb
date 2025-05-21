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
        cmb_personal = New ComboBox()
        btn_ingresar = New Button()
        txt_descripcion = New TextBox()
        Label3 = New Label()
        btn_crear = New Button()
        btn_regresar = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.CornflowerBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(93, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(171, 20)
        Label1.TabIndex = 0
        Label1.Text = "Nombre del proyecto"
        ' 
        ' txt_nombre
        ' 
        txt_nombre.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt_nombre.Location = New Point(93, 65)
        txt_nombre.Name = "txt_nombre"
        txt_nombre.PlaceholderText = "Ingrese nombre del proyecto"
        txt_nombre.Size = New Size(171, 25)
        txt_nombre.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.CornflowerBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(93, 118)
        Label2.Name = "Label2"
        Label2.Size = New Size(174, 20)
        Label2.TabIndex = 2
        Label2.Text = "Personal del proyecto"
        ' 
        ' cmb_personal
        ' 
        cmb_personal.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmb_personal.FormattingEnabled = True
        cmb_personal.Location = New Point(93, 141)
        cmb_personal.Name = "cmb_personal"
        cmb_personal.Size = New Size(139, 25)
        cmb_personal.TabIndex = 3
        ' 
        ' btn_ingresar
        ' 
        btn_ingresar.BackColor = Color.CornflowerBlue
        btn_ingresar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_ingresar.Location = New Point(238, 141)
        btn_ingresar.Name = "btn_ingresar"
        btn_ingresar.Size = New Size(80, 28)
        btn_ingresar.TabIndex = 4
        btn_ingresar.Text = "Ingresar"
        btn_ingresar.UseVisualStyleBackColor = False
        ' 
        ' txt_descripcion
        ' 
        txt_descripcion.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt_descripcion.Location = New Point(96, 213)
        txt_descripcion.Multiline = True
        txt_descripcion.Name = "txt_descripcion"
        txt_descripcion.PlaceholderText = "Ingrese breve descripción"
        txt_descripcion.Size = New Size(220, 121)
        txt_descripcion.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.CornflowerBlue
        Label3.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(96, 190)
        Label3.Name = "Label3"
        Label3.Size = New Size(199, 20)
        Label3.TabIndex = 5
        Label3.Text = "Descripción del proyecto"
        ' 
        ' btn_crear
        ' 
        btn_crear.BackColor = Color.CornflowerBlue
        btn_crear.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_crear.Location = New Point(152, 352)
        btn_crear.Name = "btn_crear"
        btn_crear.Size = New Size(94, 59)
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
        btn_regresar.Location = New Point(166, 417)
        btn_regresar.Name = "btn_regresar"
        btn_regresar.Size = New Size(66, 55)
        btn_regresar.TabIndex = 8
        btn_regresar.UseVisualStyleBackColor = False
        ' 
        ' CreacionProyecto
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(404, 501)
        Controls.Add(btn_regresar)
        Controls.Add(btn_crear)
        Controls.Add(txt_descripcion)
        Controls.Add(Label3)
        Controls.Add(btn_ingresar)
        Controls.Add(cmb_personal)
        Controls.Add(Label2)
        Controls.Add(txt_nombre)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "CreacionProyecto"
        Text = "CreacionProyecto"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt_nombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmb_personal As ComboBox
    Friend WithEvents btn_ingresar As Button
    Friend WithEvents txt_descripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_crear As Button
    Friend WithEvents btn_regresar As Button
End Class
