'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports ControlsSAP


Partial Public Class frmConsultaFacturas
    Inherits ControlsSAP.Forms.FormWizard
    
    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer
    
    Private Page5 As System.Windows.Forms.TabPage
    
    Private Page6 As System.Windows.Forms.TabPage
    
    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>  _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (Not (components) Is Nothing) Then
                components.Dispose
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Private Sub InitializeComponent()
        Me.Page5 = New System.Windows.Forms.TabPage()
        Me.txtFechaH = New ControlsSAP.Controls.SAPTextBox()
        Me.txtFechaD = New ControlsSAP.Controls.SAPTextBox()
        Me.lblFechaH = New ControlsSAP.Controls.SAPLabel()
        Me.lblFechaD = New ControlsSAP.Controls.SAPLabel()
        Me.lstCCliente = New ControlsSAP.Controls.SAPListBox()
        Me.lblCCliente = New ControlsSAP.Controls.SAPLabel()
        Me.Page6 = New System.Windows.Forms.TabPage()
        Me.SapGrid1 = New ControlsSAP.Controls.SAPGrid()
        Me.TabControl1.SuspendLayout()
        Me.Page5.SuspendLayout()
        Me.Page6.SuspendLayout()
        CType(Me.SapGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Page5)
        Me.TabControl1.Controls.Add(Me.Page6)
        Me.TabControl1.Size = New System.Drawing.Size(591, 250)
        '
        'Page5
        '
        Me.Page5.Controls.Add(Me.txtFechaH)
        Me.Page5.Controls.Add(Me.txtFechaD)
        Me.Page5.Controls.Add(Me.lblFechaH)
        Me.Page5.Controls.Add(Me.lblFechaD)
        Me.Page5.Controls.Add(Me.lstCCliente)
        Me.Page5.Controls.Add(Me.lblCCliente)
        Me.Page5.Location = New System.Drawing.Point(4, 21)
        Me.Page5.Name = "Page5"
        Me.Page5.Size = New System.Drawing.Size(583, 225)
        Me.Page5.TabIndex = 0
        Me.Page5.Text = "Filtro"
        '
        'txtFechaH
        '
        Me.txtFechaH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaH.DataType = ControlsSAP.Controls.SAPTextBox.DataTypes.Fecha
        Me.txtFechaH.Location = New System.Drawing.Point(185, 90)
        Me.txtFechaH.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.txtFechaH.MaxLength = 10
        Me.txtFechaH.Name = "txtFechaH"
        Me.txtFechaH.Size = New System.Drawing.Size(150, 14)
        Me.txtFechaH.TabIndex = 3
        '
        'txtFechaD
        '
        Me.txtFechaD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaD.DataType = ControlsSAP.Controls.SAPTextBox.DataTypes.Fecha
        Me.txtFechaD.Location = New System.Drawing.Point(185, 60)
        Me.txtFechaD.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.txtFechaD.MaxLength = 10
        Me.txtFechaD.Name = "txtFechaD"
        Me.txtFechaD.Size = New System.Drawing.Size(150, 14)
        Me.txtFechaD.TabIndex = 2
        '
        'lblFechaH
        '
        Me.lblFechaH.Location = New System.Drawing.Point(61, 92)
        Me.lblFechaH.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(120, 14)
        Me.lblFechaH.TabIndex = 3
        Me.lblFechaH.Text = "Fecha Hasta"
        '
        'lblFechaD
        '
        Me.lblFechaD.Location = New System.Drawing.Point(63, 60)
        Me.lblFechaD.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(120, 14)
        Me.lblFechaD.TabIndex = 2
        Me.lblFechaD.Text = "Fecha Desde"
        '
        'lstCCliente
        '
        Me.lstCCliente.BackColor = System.Drawing.SystemColors.Window
        Me.lstCCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstCCliente.Location = New System.Drawing.Point(185, 29)
        Me.lstCCliente.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.lstCCliente.Name = "lstCCliente"
        Me.lstCCliente.Size = New System.Drawing.Size(150, 14)
        Me.lstCCliente.TabIndex = 1
        '
        'lblCCliente
        '
        Me.lblCCliente.Location = New System.Drawing.Point(61, 29)
        Me.lblCCliente.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.lblCCliente.Name = "lblCCliente"
        Me.lblCCliente.Size = New System.Drawing.Size(120, 14)
        Me.lblCCliente.TabIndex = 0
        Me.lblCCliente.Text = "Código Cliente"
        '
        'Page6
        '
        Me.Page6.Controls.Add(Me.SapGrid1)
        Me.Page6.Location = New System.Drawing.Point(4, 21)
        Me.Page6.Name = "Page6"
        Me.Page6.Size = New System.Drawing.Size(583, 225)
        Me.Page6.TabIndex = 1
        Me.Page6.Text = "Resultados"
        '
        'SapGrid1
        '
        Me.SapGrid1.FocusedColumn = Nothing
        Me.SapGrid1.FocusedRowHandle = -2147483647
        Me.SapGrid1.FocusedValue = Nothing
        Me.SapGrid1.FocusIndex = -2147483647
        Me.SapGrid1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SapGrid1.Location = New System.Drawing.Point(3, 3)
        Me.SapGrid1.Name = "SapGrid1"
        Me.SapGrid1.Size = New System.Drawing.Size(580, 220)
        Me.SapGrid1.TabIndex = 0
        '
        'frmConsultaFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(591, 387)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(607, 403)
        Me.MinimumSize = New System.Drawing.Size(607, 403)
        Me.Name = "frmConsultaFacturas"
        Me.Text = "Consulta de Facturas"
        Me.TabControl1.ResumeLayout(False)
        Me.Page5.ResumeLayout(False)
        Me.Page6.ResumeLayout(False)
        CType(Me.SapGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCCliente As ControlsSAP.Controls.SAPLabel
    Friend WithEvents lstCCliente As ControlsSAP.Controls.SAPListBox
    Friend WithEvents lblFechaD As ControlsSAP.Controls.SAPLabel
    Friend WithEvents lblFechaH As ControlsSAP.Controls.SAPLabel
    Friend WithEvents txtFechaH As ControlsSAP.Controls.SAPTextBox
    Friend WithEvents txtFechaD As ControlsSAP.Controls.SAPTextBox
    Friend WithEvents SapGrid1 As ControlsSAP.Controls.SAPGrid
End Class
