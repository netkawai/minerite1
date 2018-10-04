Public Class FrmMain

    ' Keep Selected Row through Id
    ' SelectedId = 0 means no selection
    Private SelectedId As Integer = 0

    ' Kepp current use's choice of Unit
    Public Property SelectedUnit As FrmAddEdit.LengthUnit = FrmAddEdit.LengthUnit.INCH

    ' Property for diameter(inch)
    ' Allow to access from other forms
    Private _diameterInch As Double = 0
    Public Property DiameterInch As Double
        Get
            Return _diameterInch
        End Get
        Private Set(value As Double)
            _diameterInch = value
        End Set
    End Property

    ' Property for diameter(inch)
    Private _diameterMM As Double = 0
    Public Property DiameterMM As Double
        Get
            Return _diameterMM
        End Get
        Private Set(value As Double)
            _diameterMM = value
        End Set
    End Property


    ''' <summary>
    ''' Setup FrmMain loading from database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RefreshDataGridView(0)
        Catch ex As Exception
            MessageBox.Show(Me, "Please check mdf file and connection settings", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Add button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Using dialog As New FrmAddEdit(0)
            ' Modaless Dialog to prevent the access to DataGridView 
            ' during user data input.
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                ' Refresh 
                RefreshDataGridView(dialog.SelectedId)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Edit button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Using dialog As New FrmAddEdit(Me.SelectedId)
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                'Refresh
                RefreshDataGridView(Me.SelectedId)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Delete button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If MessageBox.Show(Me, "Are you sure to delete the selected data?", "Confirmation") = DialogResult.OK Then
            ' Delete the row
            Me.Un1TableAdapter.Delete(Me.SelectedId)
            'Refresh
            RefreshDataGridView(0)
        End If
    End Sub

    ''' <summary>
    ''' Trigger the SelectionChanged to monitor the changed of the selected row 
    ''' 1. Enable or disable Edit and Delete the row
    ''' 2. Update the current selected data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DgvDataSheet_SelectionChanged(sender As Object, e As EventArgs) Handles DgvDataSheet.SelectionChanged
        Dim isSelectedRow As Boolean = DgvDataSheet.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0

        ' Check whether any rows are selected
        If isSelectedRow Then
            Dim selected As DataGridViewRow = DgvDataSheet.SelectedRows.Item(0)

            ' Store values for editting
            Me.SelectedId = selected.Cells.Item(0).Value
            Me.DiameterInch = selected.Cells.Item(1).Value
            Me.DiameterMM = selected.Cells.Item(2).Value

            EnableEditDeleteBtn(True)
        Else
            Me.SelectedId = Me.DiameterInch = Me.DiameterMM = 0
            EnableEditDeleteBtn(False)
        End If
    End Sub

    ''' <summary>
    ''' Print Button Handle
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Using printHelper = New PrintoutHelper(Me.DgvDataSheet)
            printHelper.PrintPreview(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Save Button Handle
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SaveHelper.SaveToFile(DgvDataSheet)
    End Sub

    ''' <summary>
    ''' Refresh DataGridView
    ''' Refill DataGridView and jump to the selectedId row
    ''' </summary>
    ''' <param name="selectedId"></param>
    Private Sub RefreshDataGridView(ByVal selectedId As Integer)
        Me.Un1TableAdapter.Fill(Me.Minerite1DataSet.Un1)
        Me.SelectedId = selectedId
        If selectedId = 0 Then
            DgvDataSheet.ClearSelection()
        Else
            ' Obtain the row which contains the selectedId(LINQ)
            Dim row As DataGridViewRow = DgvDataSheet.Rows.Cast(Of DataGridViewRow)().Where(Function(r) r.Cells("IdDataGridViewTextBoxColumn").Value.Equals(selectedId)).First()
            row.Selected = True
            ' Scroll jump
            DgvDataSheet.FirstDisplayedScrollingRowIndex = row.Index
        End If
    End Sub

    ''' <summary>
    ''' Enable and Disable the buttons of Edit and Delete
    ''' </summary>
    ''' <param name="isEnable"></param>
    Private Sub EnableEditDeleteBtn(ByVal isEnable As Boolean)
        If isEnable Then
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
        End If
    End Sub
End Class
