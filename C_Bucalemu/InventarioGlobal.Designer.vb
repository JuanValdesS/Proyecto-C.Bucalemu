﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventarioGlobal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioGlobal))
        btnGestionar = New Button()
        btnRestablecer = New Button()
        btnTotal = New Button()
        btnMenu = New Button()
        dgvInventario = New DataGridView()
        txtBuscar = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        CType(dgvInventario, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnGestionar
        ' 
        btnGestionar.BackColor = Color.CornflowerBlue
        btnGestionar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGestionar.Location = New Point(65, 219)
        btnGestionar.Margin = New Padding(3, 4, 3, 4)
        btnGestionar.Name = "btnGestionar"
        btnGestionar.Size = New Size(187, 38)
        btnGestionar.TabIndex = 0
        btnGestionar.Text = "Gestionar inventario"
        btnGestionar.UseVisualStyleBackColor = False
        ' 
        ' btnRestablecer
        ' 
        btnRestablecer.BackColor = Color.IndianRed
        btnRestablecer.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRestablecer.Location = New Point(65, 284)
        btnRestablecer.Margin = New Padding(3, 4, 3, 4)
        btnRestablecer.Name = "btnRestablecer"
        btnRestablecer.Size = New Size(187, 36)
        btnRestablecer.TabIndex = 1
        btnRestablecer.Text = "Restablecer inventario"
        btnRestablecer.UseVisualStyleBackColor = False
        ' 
        ' btnTotal
        ' 
        btnTotal.BackColor = Color.CornflowerBlue
        btnTotal.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTotal.Location = New Point(65, 155)
        btnTotal.Margin = New Padding(3, 4, 3, 4)
        btnTotal.Name = "btnTotal"
        btnTotal.Size = New Size(187, 38)
        btnTotal.TabIndex = 2
        btnTotal.Text = "Total Material"
        btnTotal.UseVisualStyleBackColor = False
        ' 
        ' btnMenu
        ' 
        btnMenu.BackColor = Color.Transparent
        btnMenu.BackgroundImage = CType(resources.GetObject("btnMenu.BackgroundImage"), Image)
        btnMenu.BackgroundImageLayout = ImageLayout.Stretch
        btnMenu.Cursor = Cursors.Hand
        btnMenu.FlatStyle = FlatStyle.Popup
        btnMenu.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenu.Location = New Point(122, 353)
        btnMenu.Margin = New Padding(3, 4, 3, 4)
        btnMenu.Name = "btnMenu"
        btnMenu.Size = New Size(60, 48)
        btnMenu.TabIndex = 3
        btnMenu.UseVisualStyleBackColor = False
        ' 
        ' dgvInventario
        ' 
        dgvInventario.BackgroundColor = Color.AliceBlue
        dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInventario.Location = New Point(360, 78)
        dgvInventario.Margin = New Padding(3, 4, 3, 4)
        dgvInventario.Name = "dgvInventario"
        dgvInventario.RowHeadersWidth = 51
        dgvInventario.Size = New Size(1110, 741)
        dgvInventario.TabIndex = 4
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(37, 78)
        txtBuscar.Margin = New Padding(3, 4, 3, 4)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.PlaceholderText = "Ingrese material a buscar"
        txtBuscar.Size = New Size(244, 27)
        txtBuscar.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSlateGray
        Label1.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(715, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(328, 35)
        Label1.TabIndex = 6
        Label1.Text = "Inventario Remanente"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.DarkSlateGray
        Label2.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.HighlightText
        Label2.Location = New Point(37, 24)
        Label2.Name = "Label2"
        Label2.Size = New Size(159, 35)
        Label2.TabIndex = 7
        Label2.Text = "Busqueda"
        ' 
        ' InventarioGlobal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1566, 864)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtBuscar)
        Controls.Add(dgvInventario)
        Controls.Add(btnMenu)
        Controls.Add(btnTotal)
        Controls.Add(btnRestablecer)
        Controls.Add(btnGestionar)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        Name = "InventarioGlobal"
        Text = "InventarioGlobal"
        CType(dgvInventario, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnGestionar As Button
    Friend WithEvents btnRestablecer As Button
    Friend WithEvents btnTotal As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents dgvInventario As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
