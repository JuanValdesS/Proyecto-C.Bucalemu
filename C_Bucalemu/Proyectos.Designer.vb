﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proyectos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Proyectos))
        DataGridView1 = New DataGridView()
        btn_ingresar = New Button()
        btn_crear = New Button()
        Label1 = New Label()
        btnInventario = New Button()
        btnGestionarInventario = New Button()
        btn_eliminar = New Button()
        btn_logout = New Button()
        btn_registro = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.AliceBlue
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(47, 75)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(722, 524)
        DataGridView1.TabIndex = 0
        ' 
        ' btn_ingresar
        ' 
        btn_ingresar.BackColor = Color.CornflowerBlue
        btn_ingresar.Cursor = Cursors.Hand
        btn_ingresar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_ingresar.Location = New Point(811, 75)
        btn_ingresar.Name = "btn_ingresar"
        btn_ingresar.Size = New Size(107, 59)
        btn_ingresar.TabIndex = 1
        btn_ingresar.Text = "Ingresar al proyecto"
        btn_ingresar.UseVisualStyleBackColor = False
        ' 
        ' btn_crear
        ' 
        btn_crear.BackColor = Color.CornflowerBlue
        btn_crear.Cursor = Cursors.Hand
        btn_crear.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_crear.Location = New Point(811, 268)
        btn_crear.Name = "btn_crear"
        btn_crear.Size = New Size(107, 57)
        btn_crear.TabIndex = 2
        btn_crear.Text = "Crear Proyecto"
        btn_crear.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSlateGray
        Label1.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(47, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(272, 35)
        Label1.TabIndex = 3
        Label1.Text = "Proyectos activos"
        ' 
        ' btnInventario
        ' 
        btnInventario.BackColor = Color.CornflowerBlue
        btnInventario.Cursor = Cursors.Hand
        btnInventario.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnInventario.Location = New Point(811, 139)
        btnInventario.Name = "btnInventario"
        btnInventario.Size = New Size(107, 59)
        btnInventario.TabIndex = 5
        btnInventario.Text = "Inventario"
        btnInventario.UseVisualStyleBackColor = False
        ' 
        ' btnGestionarInventario
        ' 
        btnGestionarInventario.BackColor = Color.CornflowerBlue
        btnGestionarInventario.Cursor = Cursors.Hand
        btnGestionarInventario.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btnGestionarInventario.Location = New Point(811, 203)
        btnGestionarInventario.Name = "btnGestionarInventario"
        btnGestionarInventario.Size = New Size(107, 59)
        btnGestionarInventario.TabIndex = 6
        btnGestionarInventario.Text = "Gestionar Inventario"
        btnGestionarInventario.UseVisualStyleBackColor = False
        ' 
        ' btn_eliminar
        ' 
        btn_eliminar.BackColor = Color.IndianRed
        btn_eliminar.Cursor = Cursors.Hand
        btn_eliminar.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_eliminar.Location = New Point(811, 331)
        btn_eliminar.Name = "btn_eliminar"
        btn_eliminar.Size = New Size(107, 63)
        btn_eliminar.TabIndex = 7
        btn_eliminar.Text = "Eliminar proyecto"
        btn_eliminar.UseVisualStyleBackColor = False
        ' 
        ' btn_logout
        ' 
        btn_logout.BackColor = Color.Transparent
        btn_logout.BackgroundImage = CType(resources.GetObject("btn_logout.BackgroundImage"), Image)
        btn_logout.BackgroundImageLayout = ImageLayout.Stretch
        btn_logout.Cursor = Cursors.Hand
        btn_logout.FlatStyle = FlatStyle.Popup
        btn_logout.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold)
        btn_logout.Location = New Point(834, 538)
        btn_logout.Name = "btn_logout"
        btn_logout.Size = New Size(64, 61)
        btn_logout.TabIndex = 8
        btn_logout.UseVisualStyleBackColor = False
        ' 
        ' btn_registro
        ' 
        btn_registro.BackColor = Color.Transparent
        btn_registro.BackgroundImage = CType(resources.GetObject("btn_registro.BackgroundImage"), Image)
        btn_registro.BackgroundImageLayout = ImageLayout.Stretch
        btn_registro.Cursor = Cursors.Hand
        btn_registro.FlatStyle = FlatStyle.Popup
        btn_registro.Font = New Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_registro.ForeColor = SystemColors.ControlText
        btn_registro.Location = New Point(834, 468)
        btn_registro.Name = "btn_registro"
        btn_registro.Size = New Size(64, 61)
        btn_registro.TabIndex = 9
        btn_registro.UseVisualStyleBackColor = False
        ' 
        ' Proyectos
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1002, 629)
        Controls.Add(btn_registro)
        Controls.Add(btn_logout)
        Controls.Add(btn_eliminar)
        Controls.Add(btnGestionarInventario)
        Controls.Add(btnInventario)
        Controls.Add(Label1)
        Controls.Add(btn_crear)
        Controls.Add(btn_ingresar)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Proyectos"
        Text = "Proyectos"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_ingresar As Button
    Friend WithEvents btn_crear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnInventario As Button
    Friend WithEvents btnGestionarInventario As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents btn_logout As Button
    Friend WithEvents btn_registro As Button
End Class
