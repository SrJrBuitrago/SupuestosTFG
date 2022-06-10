
Option Strict Off
Option Explicit On

Imports ControlsSAP


Public Class frmConsultaFacturas
    
    Private _company As SAPBobsCOM.Company
    
    Public Sub New()
        MyBase.New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        Me.InitializeComponent()
        '
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _company = Addon2Core.Addon.CB1App.Company

    End Sub
    
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        With lstCCliente
            .Company = _company
            .Table = "OCRD"
            .ValueMember = "CardCode"
            .Condition = "CardType = 'C'"
            .DisplayMember = "CardCode"
            .Columns.AddColumn("Codigo", "CardCode")
            .Columns.AddColumn("Nombre", "CardName")


        End With
    End Sub
    'Método que controla el cambio de página en el form Asistente
    Private Sub Form_PageChanging(ByVal PreviousPage As Integer, ByRef NextPage As Integer, ByRef Cancel As Boolean) Handles MyBase.PageChanging
        Dim msql As String
        Try
            'Controla que el avance sea hacia adelante
            If (PreviousPage < NextPage) Then
                If (PreviousPage = 0) Then
                    If validar() Then
                        creaQuery(msql)
                        CargarGrid(msql)
                    Else : Cancel = True
                    End If
                    'Insere el código de validación para el cambio de página 'Filtro'
                Else
                    If (PreviousPage = 1) Then
                        'Insere el código de validación para el cambio de página 'Resultados'
                    End If
                End If
            End If
        Catch ex As System.Exception
            ControlsSAP.SAPMsg.Show(ex)
        End Try
    End Sub
    'Método que se ejecuta cuando se ha cambiado de página. Cambia la descripción en función de en que página estémos.
    Private Sub Form_PageChanged(ByVal PageIndex As Integer) Handles MyBase.PageChanged
        Try
            'Asignación de textos para cada página
            If (PageIndex = 0) Then
                Me.Description = "Filtro de Facturas"
            Else
                If (PageIndex = 1) Then
                    Me.Description = "Facturas resultantes"
                End If
            End If
        Catch ex As System.Exception
            ControlsSAP.SAPMsg.Show(ex)
        End Try
    End Sub

    Private Sub Form_EndProcess(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.EndProcess
        'Código que se ejecutará al pulsar sobre 'Finalizar'
        Me.Close()
    End Sub
    'Método que carga las columnas, las opciones y asigna el datatable en el grid. Se ejecuta al cambiar de página
    Private Sub CargarGrid(ByRef msql As String)
        Dim colDocNum As DevExpress.XtraGrid.Columns.GridColumn
        Dim colCodCliente As DevExpress.XtraGrid.Columns.GridColumn
        Dim colNomCliente As DevExpress.XtraGrid.Columns.GridColumn
        Dim colFechaDoc As DevExpress.XtraGrid.Columns.GridColumn
        Dim colImporte As DevExpress.XtraGrid.Columns.GridColumn

        Try

            With Me.SapGrid1
                .GridView1.Columns.Clear()
                SapGrid1.MultiSelect = False
                SapGrid1.Editable = False
                .GridView1.OptionsCustomization.AllowSort = False

                colDocNum = .Columns.AddColumn("Número Factura", "DocNum")
                .Columns.AddLinkedButton(colDocNum, SAPbouiCOM.BoLinkedObject.lf_None)

                colCodCliente = .Columns.AddColumn("Código Cliente", "CardCode")

                .Columns.AddLinkedButton(colCodCliente, SAPbouiCOM.BoLinkedObject.lf_None)

                colNomCliente = .Columns.AddColumn("Nombre Cliente", "CardName")

                colFechaDoc = .Columns.AddColumn("Fecha Factura", "TaxDate")

                colImporte = .Columns.AddImportColumn("Importe", "DocTotal")



                Dim dt As DataTable
                Using conn As New Addon2Core.DataEngine.CDBConnection
                    msql = msql & " order by abs(DocNum)"
                    dt = conn.ExecQuery(msql)

                End Using
                .DataSource = dt

            End With

        Catch ex As Exception
            ControlsSAP.SAPMsg.Critical(ex.Message)
        End Try
    End Sub
    'Método que se ejecuta al pulsar sobre uno de los linkedbutton(flechas naranjas que hay en el grid), comprueba que 
    'columna se ha pulsado y dependiendo de si son la 0 y la 1 abre los formularios indicados con los valores de la celda
    Private Sub SapGrid1_LinkedButtonClick(Button As Controls.ButtonLinkTo, e As Controls.SAPGrid.LinkedButtonClickEventArgs) Handles SapGrid1.LinkedButtonClick
        Dim cod As String
        If e.Column.AbsoluteIndex = 0 Then
            If Not IsDBNull(SapGrid1.GridView1.GetRowCellValue(SapGrid1.GridView1.FocusedRowHandle, "DocNum")) Then
                cod = SapGrid1.GridView1.GetRowCellValue(SapGrid1.GridView1.FocusedRowHandle, "DocNum")
                Addon2Core.Addon.CB1App.OpenObjectForm(SAPbouiCOM.BoLinkedObject.lf_Invoice, cod)
            End If

            e.Cancel = True
        End If
        If e.Column.AbsoluteIndex = 1 Then
            If Not IsDBNull(SapGrid1.GridView1.GetRowCellValue(SapGrid1.GridView1.FocusedRowHandle, "CardCode")) Then
                cod = SapGrid1.GridView1.GetRowCellValue(SapGrid1.GridView1.FocusedRowHandle, "CardCode")
                Addon2Core.Addon.CB1App.OpenObjectForm(SAPbouiCOM.BoLinkedObject.lf_BusinessPartner, cod)
            End If

            e.Cancel = True
        End If
    End Sub
    'Función que devuelve true si los campos de fecha tienen ambos valores o si ambos no tienen valor. Si uno tiene valor y el otro no devuelve falso
    Private Function validar() As Boolean
        Dim valida As Boolean = True
        If txtFechaD.HasValue And Not txtFechaH.HasValue Or Not txtFechaD.HasValue And txtFechaH.HasValue Then
            Addon2Core.Addon.CB1App.Application.SetStatusBarMessage("No puedes rellenar solo uno de los dos campos")
            txtFechaD.Select()
            valida = False
        End If
        Return valida
    End Function
    'Método que recibe un string el cual va a modificar en función de si los campos tienen valor o no
    Public Sub creaQuery(ByRef msql As String)
        Dim valida As Boolean = False
        msql = "select DocNum, CardCode, CardName, TaxDate, DocTotal FROM OINV WHERE "
        If Not valida And lstCCliente.HasValue Then
            msql = msql + "CardCode =" & ControlsSAP.SQLActions.ToSQL(lstCCliente.Value)
            If txtFechaD.HasValue AndAlso txtFechaH.HasValue Then
                msql = msql + "and TaxDate between" & ControlsSAP.SQLActions.ToSQL(CDate(txtFechaD.Value)) & "and" & ControlsSAP.SQLActions.ToSQL(CDate(txtFechaH.Value))
            End If
            valida = True
        End If
        If Not valida And txtFechaD.HasValue AndAlso txtFechaH.HasValue Then
            valida = True
            msql = msql + "TaxDate between" & ControlsSAP.SQLActions.ToSQL(CDate(txtFechaD.Value)) & "and" & ControlsSAP.SQLActions.ToSQL(CDate(txtFechaH.Value))
        End If
        If Not valida And Not lstCCliente.HasValue AndAlso Not txtFechaD.HasValue AndAlso Not txtFechaH.HasValue Then
            msql = "select DocNum, CardCode, CardName, TaxDate, DocTotal FROM OINV"
            valida = True
        End If
    End Sub
End Class
