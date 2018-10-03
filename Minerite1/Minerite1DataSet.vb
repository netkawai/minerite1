Imports System.Data.SqlClient

Partial Class Minerite1DataSet


End Class

Namespace Minerite1DataSetTableAdapters

    Partial Public Class Un1TableAdapter
        Public Overridable Overloads Function Insert(ByVal CD_inch As Double, ByVal DV_ft As Integer, ByVal CD_mm As Double, ByVal DV_m As Integer, ByRef LastId As Integer) As Integer
            Me.Adapter.InsertCommand.Parameters(0).Value = CType(CD_inch, Double)
            Me.Adapter.InsertCommand.Parameters(1).Value = CType(DV_ft, Integer)
            Me.Adapter.InsertCommand.Parameters(2).Value = CType(CD_mm, Double)
            Me.Adapter.InsertCommand.Parameters(3).Value = CType(DV_m, Integer)
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.InsertCommand.Connection.State
            If ((Me.Adapter.InsertCommand.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.InsertCommand.Connection.Open()
            End If
            Try
                Dim reader As SqlDataReader = Me.Adapter.InsertCommand.ExecuteReader
                While reader.Read
                    LastId = reader.GetInt32(0)
                End While
                Return 1
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.InsertCommand.Connection.Close()
                End If
            End Try
        End Function
    End Class
End Namespace
