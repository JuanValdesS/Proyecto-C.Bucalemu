<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reportes))
        btn_reporte = New Button()
        txtObservacion = New TextBox()
        Button1 = New Button()
        Label1 = New Label()
        btn_greportes = New Button()
        txtTitulo = New TextBox()
        SuspendLayout()
        ' 
        ' btn_reporte
        ' 
        btn_reporte.BackColor = Color.LightSteelBlue
        btn_reporte.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_reporte.Location = New Point(127, 267)
        btn_reporte.Name = "btn_reporte"
        btn_reporte.Size = New Size(159, 47)
        btn_reporte.TabIndex = 0
        btn_reporte.Text = "Enviar Reporte"
        btn_reporte.UseVisualStyleBackColor = False
        ' 
        ' txtObservacion
        ' 
        txtObservacion.BackColor = Color.AliceBlue
        txtObservacion.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtObservacion.Location = New Point(46, 113)
        txtObservacion.Multiline = True
        txtObservacion.Name = "txtObservacion"
        txtObservacion.PlaceholderText = "Descripción"
        txtObservacion.ScrollBars = ScrollBars.Vertical
        txtObservacion.Size = New Size(330, 130)
        txtObservacion.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), Image)
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Location = New Point(166, 383)
        Button1.Name = "Button1"
        Button1.Size = New Size(74, 51)
        Button1.TabIndex = 3
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.LightSteelBlue
        Label1.Font = New Font("Segoe UI Symbol", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(46, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(330, 23)
        Label1.TabIndex = 4
        Label1.Text = "Ingrese breve descripción del reporte" & vbCrLf
        ' 
        ' btn_greportes
        ' 
        btn_greportes.BackColor = Color.LightSteelBlue
        btn_greportes.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_greportes.Location = New Point(127, 320)
        btn_greportes.Name = "btn_greportes"
        btn_greportes.Size = New Size(159, 57)
        btn_greportes.TabIndex = 5
        btn_greportes.Text = "Gestionar Reportes"
        btn_greportes.UseVisualStyleBackColor = False
        ' 
        ' txtTitulo
        ' 
        txtTitulo.BackColor = Color.AliceBlue
        txtTitulo.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtTitulo.Location = New Point(46, 67)
        txtTitulo.Name = "txtTitulo"
        txtTitulo.PlaceholderText = "Ingrese un título para su reporte"
        txtTitulo.Size = New Size(330, 25)
        txtTitulo.TabIndex = 6
        ' 
        ' Reportes
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(423, 459)
        Controls.Add(txtTitulo)
        Controls.Add(btn_greportes)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(txtObservacion)
        Controls.Add(btn_reporte)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Reportes"
        Text = "Reportes"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btn_reporte As Button
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_greportes As Button
    Friend WithEvents txtTitulo As TextBox
End Class
