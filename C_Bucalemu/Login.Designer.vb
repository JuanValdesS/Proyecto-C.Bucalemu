﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Label1 = New Label()
        Label2 = New Label()
        txtUsuario = New TextBox()
        txtPassword = New TextBox()
        CheckBox1 = New CheckBox()
        Label3 = New Label()
        btnLogin = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.CornflowerBlue
        Label1.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.Desktop
        Label1.Location = New Point(158, 83)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 20)
        Label1.TabIndex = 2
        Label1.Text = "Correo"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.CornflowerBlue
        Label2.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        Label2.Location = New Point(158, 170)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 20)
        Label2.TabIndex = 3
        Label2.Text = "Contraseña"
        ' 
        ' txtUsuario
        ' 
        txtUsuario.BackColor = Color.AliceBlue
        txtUsuario.Cursor = Cursors.IBeam
        txtUsuario.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsuario.Location = New Point(158, 106)
        txtUsuario.Margin = New Padding(3, 2, 3, 2)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.PlaceholderText = "Usuario o Correo Electrónico"
        txtUsuario.Size = New Size(203, 25)
        txtUsuario.TabIndex = 4
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.AliceBlue
        txtPassword.Cursor = Cursors.IBeam
        txtPassword.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(158, 192)
        txtPassword.Margin = New Padding(3, 2, 3, 2)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.PlaceholderText = "Contraseña"
        txtPassword.Size = New Size(203, 25)
        txtPassword.TabIndex = 5
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.BackColor = Color.Transparent
        CheckBox1.BackgroundImageLayout = ImageLayout.Stretch
        CheckBox1.Cursor = Cursors.Hand
        CheckBox1.Font = New Font("Segoe UI Symbol", 7.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CheckBox1.ForeColor = Color.White
        CheckBox1.Location = New Point(367, 194)
        CheckBox1.Margin = New Padding(3, 2, 3, 2)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(134, 21)
        CheckBox1.TabIndex = 6
        CheckBox1.Text = "Ver Contraseña"
        CheckBox1.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.DarkSlateGray
        Label3.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.HighlightText
        Label3.Location = New Point(64, 25)
        Label3.Name = "Label3"
        Label3.Size = New Size(418, 35)
        Label3.TabIndex = 7
        Label3.Text = "Inicio de sesión C.Bucalemu"
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(210, 248)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(96, 32)
        btnLogin.TabIndex = 8
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(555, 332)
        Controls.Add(btnLogin)
        Controls.Add(Label3)
        Controls.Add(CheckBox1)
        Controls.Add(txtPassword)
        Controls.Add(txtUsuario)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        Name = "Login"
        Text = "Inicio de Sesión"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLogin As Button

End Class
