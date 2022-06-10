Imports Addon2Core
Imports Addon2Core.PluginEngine
Imports Addon2Core.UI
Imports Addon2Core.UI.Forms
Imports Addon2Core.UI.Controls
Imports Addon2Core.EventEngine
Imports Addon2Core.ConfigEngine

'Clase del Addon que hemos creado.Contiene información del plugin como el nombre, descripción, creador, versión etc...
'Ejecuta la creación de campos en SAP ejecutando métodos de la clase que hemos creado (cCreacionCampos). Tambien crea los menus y submenus
' Y abre formularios dependiendo en que menú pulsemos

<Addon2Core.PluginEngine.Plugin("TFG_TFG", "TFG", "Supuestos TFG", "José Ramón Buitrago", "1.0", False, "1.0")> _
Public Class cPluginTFG
    Inherits Addon2Core.PluginEngine.CPlugin
    Implements InitEngine.InitJobs.ICreacionCamposSap
    Private WithEvents _oMenu, _oMenu1, _oMenu2, oMenu3 As Addon2Core.UI.CB1Menu
    Public Overrides Sub Run()
        _oMenu = New UI.CB1Menu("TFG_MENUTFG", "43520", "Supuestos TFG", SAPbouiCOM.BoMenuType.mt_POPUP)
        _oMenu1 = New UI.CB1Menu("TFG_TFG1", "TFG_MENUTFG", "Consulta de Facturas", AddressOf onMenu1Click)
        _oMenu2 = New UI.CB1Menu("TFG_TFG2", "TFG_MENUTFG", "Faltas Empleados Dep. Ventas", AddressOf onMenu2Click)
        _oMenu3 = New UI.CB1Menu("TFG_TFG3", "TFG_MENUTFG", "Consulta Faltas Empleados Dep. Ventas", AddressOf onMenu3Click)
    End Sub
    Public Sub Start() Implements Addon2Core.InitEngine.InitJobs.ICreacionCamposSap.Start
        cCreacionCampos.CrearCampos_TFG_TFGFALTASEMP()
        cCreacionCampos.CrearCampos_OSLP2()
    End Sub
    <SynchronizedEvent()> _
    Private Sub onMenu1Click(ByVal sender As Object, ByVal event_info As CB1MenuEventArgs)
        Dim frm As New frmConsultaFacturas()
        Addon2Core.Addon.CB1App.EmbedIntoSAP(frm)
        frm.Show()
    End Sub
    <SynchronizedEvent()> _
    Private Sub onMenu2Click(ByVal sender As Object, ByVal event_info As CB1MenuEventArgs)
        Dim frm As New frmFaltasEDV()
        Addon2Core.Addon.CB1App.EmbedIntoSAP(frm)
        frm.Show()
    End Sub
    <SynchronizedEvent()> _
    Private Sub onMenu3Click(ByVal sender As Object, ByVal event_info As CB1MenuEventArgs)
        Dim frm As New frmConsultaFaltas()
        Addon2Core.Addon.CB1App.EmbedIntoSAP(frm)
        frm.Show()
    End Sub
End Class

