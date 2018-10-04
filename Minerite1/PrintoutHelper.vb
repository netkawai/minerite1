Imports System.Drawing.Printing

' Implement IDisposable for PrintDocument
Public Class PrintoutHelper
    Implements IDisposable

    ' PrintDocument
    WithEvents PrintDoc As PrintDocument

    ' DataGridView in FrmMain
    Private Dgv As DataGridView
    ' Title
    Private PrintTitle = "Un1 Produt Data Sheet"
    Private Const CellTopPadding = 5
    Private Const CellLeftPadding = 5

    Private Const CellHeightExtraPadding = CellTopPadding * 2
    Private Const CellWidthExtraPadding = CellLeftPadding * 2
    ' Parameters for generating print image.
    Dim PageNo As Integer
    Dim NewPage As Boolean
    Dim HeaderHeight As Integer
    Dim CellHeight As Integer
    Dim RowPos As Integer
    Dim ColumnLefts As New ArrayList()
    Dim ColumnWidths As New ArrayList()
    Dim RowsPerPage As Integer

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="datagrid"></param>
    Public Sub New(ByRef dataGrid As DataGridView)
        PrintDoc = New PrintDocument
        ResetPrintParams()
        Dgv = dataGrid
    End Sub


    ''' <summary>
    ''' Open Printpreview dialog
    ''' </summary>
    ''' <param name="frm"></param>
    Public Sub PrintPreview(ByRef frm As Form)
        Using previewDialog = New PrintPreviewDialog()
            previewDialog.Document = PrintDoc
            previewDialog.ShowDialog(frm)
        End Using
    End Sub

    ''' <summary>
    ''' Reset page printing parameter
    ''' </summary>
    Private Sub ResetPrintParams()
        PageNo = 1
        RowPos = 0
        RowsPerPage = 0
        NewPage = True
        ColumnLefts.Clear()
        ColumnWidths.Clear()
    End Sub

    ''' <summary>
    ''' Printout the DataGridView
    ''' reference: https://www.codeproject.com/Articles/16670/DataGridView-Printing-by-Selecting-Columns-and-Row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim tmpWidth = 0
        Dim tmpTop = e.MarginBounds.Top
        Dim tmpLeft = e.MarginBounds.Left
        Dim i As Integer

        ' To calculate width in the fist page
        If PageNo = 1 Then
            For Each gridCol As DataGridViewColumn In Dgv.Columns
                If Not gridCol.Visible Then Continue For

                tmpWidth = gridCol.Width + CellWidthExtraPadding

                HeaderHeight = CInt((e.Graphics.MeasureString(gridCol.HeaderText, gridCol.InheritedStyle.Font, tmpWidth).Height)) + CellHeightExtraPadding
                ColumnLefts.Add(tmpLeft)
                ColumnWidths.Add(tmpWidth)
                tmpLeft += tmpWidth
            Next
        End If

        ' Print out the data
        While RowPos <= Dgv.Rows.Count - 1
            Dim GridRow As DataGridViewRow = Dgv.Rows(RowPos)
            CellHeight = GridRow.Height

            ' No space, go to a next page
            If tmpTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                NewPage = True
                PageNo += 1
                e.HasMorePages = True
                Return
            Else
                If NewPage Then
                    ' Print title
                    e.Graphics.DrawString(PrintTitle, New Font(Dgv.Font, FontStyle.Bold), Brushes.Black,
                                          e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(PrintTitle, New Font(Dgv.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)
                    ' Print Date
                    Dim s As String = DateTime.Now.ToLongDateString() & " " + DateTime.Now.ToShortTimeString()
                    e.Graphics.DrawString(s, New Font(Dgv.Font, FontStyle.Bold), Brushes.Black,
                                          e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(s, New Font(Dgv.Font, FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top - e.Graphics.MeasureString(PrintTitle, New Font(New Font(Dgv.Font, FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13)


                    tmpTop = e.MarginBounds.Top
                    i = 0
                    ' Print Column
                    For Each GridCol As DataGridViewColumn In Dgv.Columns
                        If Not GridCol.Visible Then Continue For
                        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(CInt(ColumnLefts(i)), tmpTop, CInt(ColumnWidths(i)), HeaderHeight))
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(CInt(ColumnLefts(i)), tmpTop, CInt(ColumnWidths(i)), HeaderHeight))
                        e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, New SolidBrush(GridCol.InheritedStyle.ForeColor),
                                              New RectangleF(CInt(ColumnLefts(i)) + CellTopPadding, tmpTop + CellTopPadding, CInt(ColumnWidths(i)), HeaderHeight), StringFormat.GenericTypographic)
                        i += 1
                    Next

                    NewPage = False
                    tmpTop += HeaderHeight
                End If

                i = 0
                ' Print Each Cell
                For Each Cel As DataGridViewCell In GridRow.Cells
                    If Not Cel.OwningColumn.Visible Then Continue For

                    e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                          New SolidBrush(Cel.InheritedStyle.ForeColor),
                                          New RectangleF(CInt(ColumnLefts(i)) + CellTopPadding, CSng(tmpTop) + CellTopPadding, CInt(ColumnWidths(i)), CSng(CellHeight)),
                                          StringFormat.GenericTypographic)
                    e.Graphics.DrawRectangle(Pens.Black,
                                             New Rectangle(CInt(ColumnLefts(i)), tmpTop, CInt(ColumnWidths(i)), CellHeight))
                    i += 1
                Next

                tmpTop += CellHeight
            End If

            'Next Row position
            RowPos += 1
            ' Check how many rows can print per page
            If PageNo = 1 Then RowsPerPage += 1
        End While

        If RowsPerPage = 0 Then Return
        'DrawFooter(e, RowsPerPage)
        ' No more page, reset parameters
        ResetPrintParams()
        e.HasMorePages = False
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        PrintDoc.Dispose()
    End Sub
End Class
