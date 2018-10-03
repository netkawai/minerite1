﻿Imports System.IO
Imports System.Text

Public Class SaveHelper

    Private Const CsvSeparator = ","

    Public Shared Sub SaveToFile(ByRef Dgv As DataGridView)
        Using dialog = New SaveFileDialog

            ' TODO: set file extension

            If dialog.ShowDialog = DialogResult.OK Then
                Dim fstream As FileStream = dialog.OpenFile()
                If fstream IsNot Nothing Then
                    Dim txtWriter = New StreamWriter(fstream)
                    Dim strBuf = New StringBuilder()
                    For i As Integer = 0 To Dgv.Rows.Count - 1
                        Dim GridRow As DataGridViewRow = Dgv.Rows(i)
                        For j As Integer = 0 To GridRow.Cells.Count - 1
                            Dim cel = GridRow.Cells(j)
                            If Not cel.OwningColumn.Visible Then Continue For

                            strBuf.Append(cel.Value.ToString)
                            If j < GridRow.Cells.Count - 1 Then
                                strBuf.Append(CsvSeparator)
                            End If
                        Next
                        txtWriter.WriteLine(strBuf)
                        strBuf.Clear
                    Next
                    txtWriter.Flush()
                    fstream.Close()
                End If
            End If
        End Using
    End Sub
End Class
