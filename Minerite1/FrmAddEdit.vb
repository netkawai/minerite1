Public Class FrmAddEdit

    Private _selectedRecordID As Integer = 0
    Private ParentMain As FrmMain = Me.ParentForm

    Public Property SelectedRecordID As Integer
        Get
            Return _selectedRecordID
        End Get
        Private Set(value As Integer)
            _selectedRecordID = value
        End Set
    End Property



    Public Sub New(ByVal selectedId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        SelectedRecordID = selectedId

        ' To open this form with selected row, that is Edit mode
        If selectedId > 0 Then
            If Me.CmbUnit.SelectedText.ToUpper = "INCH" Then
                TbInput.Text = Me.ParentMain.DiameterInch
            Else
                TbInput.Text = Me.ParentMain.DiameterMM
            End If
        End If
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click

        Const Inch_mm_ratio As Double = 25.4
        Const foot_m_ratio As Double = 12

        ' Validating input only positive numbers.
        ' Calculating detonation velocity
        ' To check whether inch or mm
        Try
            Dim diameter As Double = Double.Parse(Me.TbInput.Text)
            If diameter < 0 Then
                Throw New FormatException
            End If

            Dim velocity As Double = Calculate_Velocity(diameter)

            Dim diameter_inch, diameter_mm, velocity_ft, velocity_m
            ' cacluation other unit
            If Me.CmbUnit.SelectedText.ToUpper = "INCH" Then
                diameter_inch = diameter
                diameter_mm = diameter_inch * Inch_mm_ratio
                velocity_ft = velocity
                velocity_m = velocity_ft * foot_m_ratio
            Else
                diameter_mm = diameter
                diameter_inch = diameter_mm / Inch_mm_ratio
                velocity_m = velocity
                velocity_ft = velocity_m / foot_m_ratio
            End If

            ' Call to save data
            Dim tableAdapter = ParentMain.Un1TableAdapter
            If SelectedRecordID = 0 Then
                ' With Output clause in Query, this Insert return the new inserted Id
                SelectedRecordID = tableAdapter.Insert(diameter_inch, velocity_ft, diameter_mm, velocity_m)
            Else
                tableAdapter.Update(diameter_inch, velocity_ft, diameter_mm, velocity_m, Me.SelectedRecordID)
            End If

            ' Refill the updated data
            tableAdapter.Fill(ParentMain.DataDataSet.Un1)

        Catch ex As ArgumentException
        Catch ex As FormatException
        Catch ex As OverflowException
            MessageBox.Show("Please input positive float number")
            Return
        Catch ex1 As Exception
            MessageBox.Show("Can not save data. Please check disk or network")
            Return
        End Try
    End Sub

    ''' <summary>
    ''' Calculation of Detonation Velocity
    ''' </summary>
    ''' <param name="diameter"></param>
    ''' <returns></returns>
    Private Function Calculate_Velocity(diameter As Double) As Double
        ' Formular constatns (to follow pdf)
        Const consA As Double = 5981.326
        Const consB As Double = 2833.804
        Const consC As Double = -556.407

        Dim velocity = consA + consB * diameter + consC * Math.Exp(-1 * diameter)
        Return velocity
    End Function
End Class
