Imports Addon2Core.DataEngine.B1
'En esta clase es donde se realizan los métodos para llevar a cabo la creación de tablas y campos de usuarios en SAP B1
Public Class cCreacionCampos
    Public Shared Sub CrearCampos_TFG_TFGFALTASEMP()
        Try
            Dim xmltables As New Addon2Core.DataEngine.B1.CB1Tables
            Dim Table As Addon2Core.DataEngine.B1.CB1Table
            Table = xmltables.AddUserTable("TFG_FALTASEMPDV", "Faltas empleados dep. ventas", SAPbobsCOM.BoUTBTableType.bott_NoObject)
            Table.AddAlphaField("TFG_CODEEMP", "Code Empleado Dep Ventas", 9)
            Table.AddDateField("TFG_FECHAFALTA", "Fecha del día de la falta", DateFieldSubTypes.tDate)
            Table.AddDateField("TFG_HORASFALTADAS", "Horas faltadas", DateFieldSubTypes.tHour)

            xmltables.Run()
        Catch ex As Exception

            Throw New Exception("Error en creacion Tabla TFG_FALTASEMPDV:" & ex.Message)
        End Try
    End Sub
    Public Shared Sub CrearCampos_OSLP2()
        Dim f As CB1Field
        Try
            Dim xmltables As New Addon2Core.DataEngine.B1.CB1Tables
            Dim Table As Addon2Core.DataEngine.B1.CB1Table
            Table = xmltables.Add("OSLP")
            Table.AddFloatField("TFG_COMISION2", "Comisión Especial", Addon2Core.DataEngine.B1.FloatFieldSubTypes.Percentage)
            xmltables.Run()
        Catch ex As Exception
            Throw New Exception("Error en la creacìón del campo IFG_COMISION en la tabla OSLP:" & ex.Message)
        End Try
    End Sub
End Class
