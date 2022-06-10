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


Public Class FaltasEDV
    Inherits ControlsSAP.SAPObject
    
    Public Sub New(ByVal c As SAPBobsCOM.Company)
        MyBase.New(c, "@TFG_FALTASEMPDV", Nothing, true)
    End Sub
    
    '''<summary>
    '''Código
    '''<br/>Field Name: <i>Code</i>.
    '''</summary>
    Public ReadOnly Property Code() As String
        Get
            Return Me.FilaActual("Code")
        End Get
    End Property
    
    '''<summary>
    '''Descripción
    '''<br/>Field Name: <i>Name</i>.
    '''</summary>
    Public Property Name() As String
        Get
            Return Me.FilaActual("Name")
        End Get
        Set
            Me.FilaActual("Name") = Value
        End Set
    End Property
    
    '''<summary>
    '''Code Empleado Dep Ventas
    '''<br/>Field Name: <i>U_TFG_CODEEMP</i>.
    '''</summary>
    Public Property TFG_CODEEMP() As String
        Get
            Return Me.FilaActual("U_TFG_CODEEMP")
        End Get
        Set
            Me.FilaActual("U_TFG_CODEEMP") = Value
        End Set
    End Property
    
    '''<summary>
    '''Fecha del día de la falta
    '''<br/>Field Name: <i>U_TFG_FECHAFALTA</i>.
    '''</summary>
    Public Property TFG_FECHAFALTA() As Date
        Get
            Return Me.FilaActual("U_TFG_FECHAFALTA")
        End Get
        Set
            Me.FilaActual("U_TFG_FECHAFALTA") = Value
        End Set
    End Property
    
    '''<summary>
    '''Horas faltadas
    '''<br/>Field Name: <i>U_TFG_HORASFALTADAS</i>.
    '''</summary>
    Public Property TFG_HORASFALTADAS() As Integer
        Get
            Return Me.FilaActual("U_TFG_HORASFALTADAS")
        End Get
        Set
            Me.FilaActual("U_TFG_HORASFALTADAS") = Value
        End Set
    End Property
    
    '''<exclude/>
    Protected Overrides Function InitializeLines() As Long
    End Function
    
    '''<exclude/>
    Protected Overrides Sub ModifyingObject()
    End Sub
End Class