<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        btnGestionar = New Button()
        btnRestablecer = New Button()
        btnTotal = New Button()
        btnMenu = New Button()
        dgvInventario = New DataGridView()
        CType(dgvInventario, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnGestionar
        ' 
        btnGestionar.Location = New Point(1049, 75)
        btnGestionar.Name = "btnGestionar"
        btnGestionar.Size = New Size(138, 23)
        btnGestionar.TabIndex = 0
        btnGestionar.Text = "Gestionar inventario"
        btnGestionar.UseVisualStyleBackColor = True
        ' 
        ' btnRestablecer
        ' 
        btnRestablecer.Location = New Point(1049, 133)
        btnRestablecer.Name = "btnRestablecer"
        btnRestablecer.Size = New Size(138, 23)
        btnRestablecer.TabIndex = 1
        btnRestablecer.Text = "Restablecer inventario"
        btnRestablecer.UseVisualStyleBackColor = True
        ' 
        ' btnTotal
        ' 
        btnTotal.Location = New Point(1049, 104)
        btnTotal.Name = "btnTotal"
        btnTotal.Size = New Size(138, 23)
        btnTotal.TabIndex = 2
        btnTotal.Text = "Total Material"
        btnTotal.UseVisualStyleBackColor = True
        ' 
        ' btnMenu
        ' 
        btnMenu.Location = New Point(1049, 162)
        btnMenu.Name = "btnMenu"
        btnMenu.Size = New Size(138, 23)
        btnMenu.TabIndex = 3
        btnMenu.Text = "Menu"
        btnMenu.UseVisualStyleBackColor = True
        ' 
        ' dgvInventario
        ' 
        dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInventario.Location = New Point(24, 75)
        dgvInventario.Name = "dgvInventario"
        dgvInventario.Size = New Size(992, 579)
        dgvInventario.TabIndex = 4
        ' 
        ' InventarioGlobal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1236, 780)
        Controls.Add(dgvInventario)
        Controls.Add(btnMenu)
        Controls.Add(btnTotal)
        Controls.Add(btnRestablecer)
        Controls.Add(btnGestionar)
        Name = "InventarioGlobal"
        Text = "InventarioGlobal"
        CType(dgvInventario, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnGestionar As Button
    Friend WithEvents btnRestablecer As Button
    Friend WithEvents btnTotal As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents dgvInventario As DataGridView
End Class
