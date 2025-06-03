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
        btn_regresar = New Button()
        btnCargarArchivo = New Button()
        btn_ingresarMateriales = New Button()
        Label1 = New Label()
        dgvMateriales = New DataGridView()
        OpenFileDialog1 = New OpenFileDialog()
        ProgressBarCarga = New ProgressBar()
        lblEstadoCarga = New Label()
        CType(dgvMateriales, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btn_regresar
        ' 
        btn_regresar.BackColor = Color.Transparent
        btn_regresar.BackgroundImage = CType(resources.GetObject("btn_regresar.BackgroundImage"), Image)
        btn_regresar.BackgroundImageLayout = ImageLayout.Stretch
        btn_regresar.Cursor = Cursors.Hand
        btn_regresar.FlatStyle = FlatStyle.Popup
        btn_regresar.Location = New Point(268, 432)
        btn_regresar.Name = "btn_regresar"
        btn_regresar.Size = New Size(59, 45)
        btn_regresar.TabIndex = 0
        btn_regresar.UseVisualStyleBackColor = False
        ' 
        ' btnCargarArchivo
        ' 
        btnCargarArchivo.BackColor = Color.CornflowerBlue
        btnCargarArchivo.Font = New Font("Segoe UI Symbol", 7.8F, FontStyle.Bold)
        btnCargarArchivo.Location = New Point(243, 70)
        btnCargarArchivo.Name = "btnCargarArchivo"
        btnCargarArchivo.Size = New Size(124, 46)
        btnCargarArchivo.TabIndex = 2
        btnCargarArchivo.Text = "Cargar Archivo"
        btnCargarArchivo.UseVisualStyleBackColor = False
        ' 
        ' btn_ingresarMateriales
        ' 
        btn_ingresarMateriales.BackColor = Color.CornflowerBlue
        btn_ingresarMateriales.Font = New Font("Segoe UI Symbol", 7.8F, FontStyle.Bold)
        btn_ingresarMateriales.Location = New Point(243, 352)
        btn_ingresarMateriales.Name = "btn_ingresarMateriales"
        btn_ingresarMateriales.Size = New Size(124, 58)
        btn_ingresarMateriales.TabIndex = 3
        btn_ingresarMateriales.Text = "Ingresar Materiales"
        btn_ingresarMateriales.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSlateGray
        Label1.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(54, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(490, 35)
        Label1.TabIndex = 4
        Label1.Text = "Seleccione la ficha de cubicación"
        ' 
        ' dgvMateriales
        ' 
        dgvMateriales.BackgroundColor = Color.AliceBlue
        dgvMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMateriales.Location = New Point(54, 122)
        dgvMateriales.Name = "dgvMateriales"
        dgvMateriales.RowHeadersWidth = 51
        dgvMateriales.Size = New Size(490, 179)
        dgvMateriales.TabIndex = 5
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' ProgressBarCarga
        ' 
        ProgressBarCarga.Location = New Point(189, 329)
        ProgressBarCarga.Name = "ProgressBarCarga"
        ProgressBarCarga.Size = New Size(243, 17)
        ProgressBarCarga.TabIndex = 6
        ' 
        ' lblEstadoCarga
        ' 
        lblEstadoCarga.AutoSize = True
        lblEstadoCarga.BackColor = Color.Transparent
        lblEstadoCarga.Font = New Font("Segoe UI Symbol", 7.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEstadoCarga.ForeColor = SystemColors.ControlLightLight
        lblEstadoCarga.Location = New Point(189, 310)
        lblEstadoCarga.Name = "lblEstadoCarga"
        lblEstadoCarga.Size = New Size(161, 17)
        lblEstadoCarga.TabIndex = 7
        lblEstadoCarga.Text = "Cargando materiales..."
        ' 
        ' Cubicacion
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.AliceBlue
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(593, 514)
        Controls.Add(lblEstadoCarga)
        Controls.Add(ProgressBarCarga)
        Controls.Add(dgvMateriales)
        Controls.Add(Label1)
        Controls.Add(btn_ingresarMateriales)
        Controls.Add(btnCargarArchivo)
        Controls.Add(btn_regresar)
        Font = New Font("Arial", 7.8F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Cubicacion"
        Text = "Cubicacion"
        CType(dgvMateriales, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btn_regresar As Button
    Friend WithEvents btnCargarArchivo As Button
    Friend WithEvents btn_ingresarMateriales As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvMateriales As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ProgressBarCarga As ProgressBar
    Friend WithEvents lblEstadoCarga As Label
End Class
