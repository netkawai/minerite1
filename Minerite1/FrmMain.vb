Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataDataSet.Un1' table. You can move, or remove it, as needed.
        Me.Un1TableAdapter.Fill(Me.DataDataSet.Un1)

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Using frm As New FrmAddEdit
            frm.ShowDialog()
        End Using
    End Sub
End Class
