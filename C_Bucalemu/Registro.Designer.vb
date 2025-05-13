<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Registro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Registro))
        btn_registro = New Button()
        txtEmail = New TextBox()
        txtPassword = New TextBox()
        combo_rol = New ComboBox()
        txtUsuario = New TextBox()
        txtConfirmarPass = New TextBox()
        visualizarpass = New CheckBox()
        regresar = New Button()
        SuspendLayout()
        ' 
        ' btn_registro
        ' 
        btn_registro.BackColor = Color.Moccasin
        btn_registro.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_registro.Location = New Point(205, 330)
        btn_registro.Name = "btn_registro"
        btn_registro.Size = New Size(86, 61)
        btn_registro.TabIndex = 0
        btn_registro.Text = "Registrar"
        btn_registro.UseVisualStyleBackColor = False
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Arial Narrow", 9F)
        txtEmail.Location = New Point(205, 106)
        txtEmail.Name = "txtEmail"
        txtEmail.PlaceholderText = "Email o correo electrónico"
        txtEmail.Size = New Size(189, 25)
        txtEmail.TabIndex = 1
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Arial Narrow", 9F)
        txtPassword.Location = New Point(205, 162)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.PlaceholderText = "Contraseña"
        txtPassword.Size = New Size(189, 25)
        txtPassword.TabIndex = 2
        ' 
        ' combo_rol
        ' 
        combo_rol.Font = New Font("Arial Narrow", 9F)
        combo_rol.FormattingEnabled = True
        combo_rol.Items.AddRange(New Object() {"Administrador", "Jefe", "Trabajador"})
        combo_rol.Location = New Point(205, 282)
        combo_rol.Name = "combo_rol"
        combo_rol.Size = New Size(129, 28)
        combo_rol.TabIndex = 3
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Font = New Font("Arial Narrow", 9F)
        txtUsuario.Location = New Point(205, 51)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.PlaceholderText = "Usuario"
        txtUsuario.Size = New Size(157, 25)
        txtUsuario.TabIndex = 4
        ' 
        ' txtConfirmarPass
        ' 
        txtConfirmarPass.Font = New Font("Arial Narrow", 9F)
        txtConfirmarPass.Location = New Point(205, 223)
        txtConfirmarPass.Name = "txtConfirmarPass"
        txtConfirmarPass.PasswordChar = "*"c
        txtConfirmarPass.PlaceholderText = "Repita la contraseña"
        txtConfirmarPass.Size = New Size(189, 25)
        txtConfirmarPass.TabIndex = 5
        ' 
        ' visualizarpass
        ' 
        visualizarpass.AutoSize = True
        visualizarpass.BackColor = Color.Transparent
        visualizarpass.Font = New Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        visualizarpass.ForeColor = SystemColors.HighlightText
        visualizarpass.Location = New Point(400, 162)
        visualizarpass.Name = "visualizarpass"
        visualizarpass.Size = New Size(121, 24)
        visualizarpass.TabIndex = 6
        visualizarpass.Text = "Ver contraseña"
        visualizarpass.UseVisualStyleBackColor = False
        ' 
        ' regresar
        ' 
        regresar.BackColor = Color.Moccasin
        regresar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        regresar.Location = New Point(309, 330)
        regresar.Name = "regresar"
        regresar.Size = New Size(94, 61)
        regresar.TabIndex = 7
        regresar.Text = "Regresar"
        regresar.UseVisualStyleBackColor = False
        ' 
        ' Registro
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(604, 450)
        Controls.Add(regresar)
        Controls.Add(visualizarpass)
        Controls.Add(txtConfirmarPass)
        Controls.Add(txtUsuario)
        Controls.Add(combo_rol)
        Controls.Add(txtPassword)
        Controls.Add(txtEmail)
        Controls.Add(btn_registro)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Registro"
        Text = "Registro"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btn_registro As Button
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents combo_rol As ComboBox
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtConfirmarPass As TextBox
    Friend WithEvents visualizarpass As CheckBox
    Friend WithEvents regresar As Button
End Class
