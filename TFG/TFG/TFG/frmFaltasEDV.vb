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


<Forms.FormDescription("Faltas empleados dep. ventas")>  _
Public Class frmFaltasEDV
    
    Private _company As SAPBobsCOM.Company
    
    Private _obj As FaltasEDV
    Public Sub New()
        MyBase.New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        Me.InitializeComponent()
        '
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _company = Addon2Core.Addon.CB1App.Company

    End Sub
    
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCode.ReadOnly = True

        'Configuración de los controles
        Me.lstTFG_CODEEMP.Company = Me._company

        'Configuramos los campos que aparecerán en la busqueda
        Me.ViewColumnInSearch("Code", "Código")
        Me.ViewColumnInSearch("Name", "Descripción")
        Me.ViewColumnInSearch("U_TFG_CODEEMP", "Code Empleado Dep Ventas")
        Me.ViewColumnInSearch("U_TFG_FECHAFALTA", "Fecha del día de la falta")
        Me.ViewColumnInSearch("U_TFG_HORASFALTADAS", "Horas faltadas")

        'Instanciamos el objeto de negocio que utilizará el formulario
        Me._obj = New FaltasEDV(Me._company)
        Me.GetAllObjects(Me._obj)

        'Control con el foco inicial

        Me.txtName.Select()
        'Indicamos de donde va a coger los valores de la lista el lstTFG_CODEEMP
        With lstTFG_CODEEMP

            .Company = _company
            .Table = "OSLP"
            .ValueMember = "SlpCode"
            .Condition = "SlpCode >0"
            .DisplayMember = "SlpCode"
            .Columns.AddColumn("Codigo", "SlpCode")
            .Columns.AddColumn("Nombre", "SlpName")


        End With
        'Indicamos que por defecto el formulario se va a abrir en modo consulta e ira al último registro añadido
        Me.GoToLast()
    End Sub
    'Método sobreescribible que se por defecto tiene establecido poner todos los campos vacios, yo lo que añado aquí es el valor para el campo code
    Public Overrides Sub DoAdd()
        Dim msql As String
        Dim dt As DataTable

        MyBase.DoAdd()
        'Valores iniciales al crear
        Try
            msql = "select top 1 Code from [@tfg_faltasempdv] order by abs(Code) desc "
            Using conn As New Addon2Core.DataEngine.CDBConnection
                dt = conn.ExecQuery(msql)

               
            End Using
        Catch ex As Exception
        End Try
        If dt.Rows.Count = 0 Then
            Me.txtCode.Text = 0
        Else : Me.txtCode.Text = CInt(dt.Rows(0).Item("Code")) + 1
        End If



        Me.txtCode.Select()
    End Sub
    
    Public Overrides Sub LoadFormWithObject()
        'Asignamos los valores del objeto en los controles correspondientes
        Me.txtCode.Text = Me._obj.Code
        Me.txtName.Text = Me._obj.Name
        Me.lstTFG_CODEEMP.SelectedValue = Me._obj.TFG_CODEEMP
        Me.txtTFG_FECHAFALTA.Text = Me._obj.TFG_FECHAFALTA
        Me.txtTFG_HORASFALTADAS.Text = Me._obj.TFG_HORASFALTADAS
    End Sub
    
    Public Overrides Sub LoadObjectWithForm()
        'Asignamos los valores de los controles en las propiedades del objeto que correspondan
        Me._obj.Name = Me.txtName.Text
        Me._obj.TFG_CODEEMP = Me.lstTFG_CODEEMP.SelectedValue
        Me._obj.TFG_FECHAFALTA = Me.txtTFG_FECHAFALTA.Text
        Me._obj.TFG_HORASFALTADAS = Me.txtTFG_HORASFALTADAS.Text
    End Sub
    'Método para el evento click del botón ok. Si el método validar devuelve true guarda el objeto
    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Validar() Then
            Try
                Me.SaveObject()
            Catch ex As System.Exception
                ControlsSAP.SAPMsg.Show(ex)
            End Try
        End If
      
    End Sub
    'Método para el evento click del botón cancel, cierra el formulario
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    'En este método indicaremos lo que se va a hacer justo después de guardar los datos del formulario
    Private Sub Form_AddedSAPObject(ByVal obj As ControlsSAP.SAPObject) Handles MyBase.AddedSAPObject
        Me.DoAdd()
    End Sub
    ' Esta función devuelve un booleano y la utilizo para comprobar que todos los campos tengan valor o que sus valores
    ' no sean superiores o inferiores a los establecidos
    Private Function Validar() As Boolean
        Dim Valida As Boolean
        Valida = True
        Dim msql As String
        Dim dt As DataTable
        Dim fechaActual As Date = Date.Now
        If Not txtName.HasValue Then
            Addon2Core.Addon.CB1App.Application.SetStatusBarMessage("Debe indicar una descripción")
            txtName.Select()
            Valida = False
        End If
        If Valida And Not txtTFG_FECHAFALTA.HasValue Then
            Addon2Core.Addon.CB1App.Application.SetStatusBarMessage("Debe seleccionar una fecha de falta")
            txtTFG_FECHAFALTA.Select()
            Valida = False
        End If
        If Valida And Not txtTFG_HORASFALTADAS.HasValue Then
            Addon2Core.Addon.CB1App.Application.SetStatusBarMessage("Debe indicar las horas faltadas")
            txtTFG_HORASFALTADAS.Select()
            Valida = False
        End If

        If Valida And CDate(txtTFG_FECHAFALTA.Text) > CDate(fechaActual) Then
            Addon2Core.Addon.CB1App.Application.SetStatusBarMessage("Tiene que indicar fechas que no sean futuras")
            txtTFG_FECHAFALTA.Select()
            Valida = False
        End If
        If Valida And Not CInt(txtTFG_HORASFALTADAS.Text) > 0 Then
            Addon2Core.Addon.CB1App.Application.SetStatusBarMessage("Las horas faltadas no pueden ser igual o menores que 0")
            txtTFG_HORASFALTADAS.Select()
            Valida = False
        End If

        msql = "SELECT Code FROM [@TFG_FALTASEMPDV] where U_TFG_CODEEMP=" & ControlsSAP.SQLActions.ToSQL(lstTFG_CODEEMP.Value) & "and U_TFG_FECHAFALTA=" & ControlsSAP.SQLActions.ToSQL(txtTFG_FECHAFALTA.Value)
        Try
            Using conn As New Addon2Core.DataEngine.CDBConnection
                dt = conn.ExecQuery(msql)
            End Using
        Catch ex As Exception
        End Try
        If Valida AndAlso dt.Rows.Count <> 0 Then

            txtName.Select()
            Addon2Core.Addon.CB1App.Application.SetStatusBarMessage("El valor se encuentra ya dentro de la bbdd")
        End If




        Return Valida
    End Function



End Class
