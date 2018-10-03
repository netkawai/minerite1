﻿Public Class FrmMain

    Private SelectedId As Integer = 0

    Private _diameterInch As Double = 0
    Private _diameterMM As Double = 0

    Public Property DiameterInch As Double
        Get
            Return _diameterInch
        End Get
        Private Set(value As Double)
            _diameterInch = value
        End Set
    End Property

    Public Property DiameterMM As Double
        Get
            Return _diameterMM
        End Get
        Private Set(value As Double)
            _diameterMM = value
        End Set
    End Property


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefillDataGridView()
    End Sub

    Private Sub RefillDataGridView()
        Me.Un1TableAdapter.Fill(Me.DataDataSet.Un1)
    End Sub

    Private Sub SelectAndJumpEditedRecord(ByVal selectedId As Integer)
        If selectedId > 0 Then

        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Using frm As New FrmAddEdit(0)
            ' Modaless Dialog to prevent the access to DataGridView during the new data input.
            frm.ShowDialog(Me)
            ' Here jump to a new record line
            SelectAndJumpEditedRecord(frm.SelectedRecordID)
        End Using
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Using frm As New FrmAddEdit(SelectedId)
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("Delete the selected data") = DialogResult.OK Then
            ' Delete the row
            Me.Un1TableAdapter.Delete(Me.SelectedId)
            RefillDataGridView()
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

    ''' <summary>
    ''' Trigger the SelectionChanged to monitor the changed of the selected row 
    ''' 1. Enable or disable Edit and Delete the row
    ''' 2. Update the current selected data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DgvDataSheet_SelectionChanged(sender As Object, e As EventArgs) Handles DgvDataSheet.SelectionChanged
        Dim isSelectedRow As Boolean = DgvDataSheet.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0

        If isSelectedRow Then
            Dim selected As DataGridViewRow = DgvDataSheet.SelectedRows.Item(0)

            Me.SelectedId = selected.Cells.Item(0).Value
            For Each cell As DataGridViewCell In selected.Cells
                Debug.WriteLine(cell.Value)
            Next
            Me.DiameterInch = selected.Cells.Item(1).Value
            Me.DiameterMM = selected.Cells.Item(2).Value

            EnableEditDeleteBtn(True)

        Else
            Me.SelectedId = Me.DiameterInch = Me.DiameterMM = 0
            EnableEditDeleteBtn(False)
        End If

    End Sub
End Class
