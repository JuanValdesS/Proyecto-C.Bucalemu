<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionarReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionarReportes))
        data_repo = New DataGridView()
        Label1 = New Label()
        btn_reporte = New Button()
        btn_eliminar = New Button()
        Button2 = New Button()
        CType(data_repo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' data_repo
        ' 
        data_repo.BackgroundColor = Color.AliceBlue
        data_repo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        data_repo.Location = New Point(55, 79)
        data_repo.Name = "data_repo"
        data_repo.RowHeadersWidth = 51
        data_repo.Size = New Size(505, 294)
        data_repo.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.LightSteelBlue
        Label1.Font = New Font("Segoe UI Symbol", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(55, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(183, 23)
        Label1.TabIndex = 5
        Label1.Text = "Gestión de Reportes"
        ' 
        ' btn_reporte
        ' 
        btn_reporte.BackColor = Color.LightSteelBlue
        btn_reporte.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_reporte.Location = New Point(601, 79)
        btn_reporte.Name = "btn_reporte"
        btn_reporte.Size = New Size(159, 47)
        btn_reporte.TabIndex = 6
        btn_reporte.Text = "Aceptar Reporte"
        btn_reporte.UseVisualStyleBackColor = False
        ' 
        ' btn_eliminar
        ' 
        btn_eliminar.BackColor = Color.IndianRed
        btn_eliminar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_eliminar.Location = New Point(601, 132)
        btn_eliminar.Name = "btn_eliminar"
        btn_eliminar.Size = New Size(159, 47)
        btn_eliminar.TabIndex = 7
        btn_eliminar.Text = "Eliminar Reporte"
        btn_eliminar.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), Image)
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Location = New Point(638, 185)
        Button2.Name = "Button2"
        Button2.Size = New Size(74, 51)
        Button2.TabIndex = 8
        Button2.UseVisualStyleBackColor = False
        ' 
        ' GestionarReportes
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(btn_eliminar)
        Controls.Add(btn_reporte)
        Controls.Add(Label1)
        Controls.Add(data_repo)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "GestionarReportes"
        Text = "GestionarReportes"
        CType(data_repo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents data_repo As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_reporte As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents Button2 As Button
End Class
