Public Class FrmAddEdit

    Private _selectedRecordID As Integer = 0
    Private FrmMain As FrmMain

    Private Enum LengthUnit
        INCH
        MM
    End Enum



    Public Property SelectedRecordID As Integer
        Get
            Return _selectedRecordID
        End Get
        Private Set(value As Integer)
            _selectedRecordID = value
        End Set
    End Property

    ' TODO: Add an Event Handler to switch inch and mm
    ' If there is a value in textbox, value should be automatically calculated

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="selectedId"></param>
    Public Sub New(ByVal selectedId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        CmbUnit.SelectedIndex = 0
        SelectedRecordID = selectedId
    End Sub

    Private Sub FrmAddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmMain = Me.Owner
        ' To open this form with selected row, that is Edit mode
        If SelectedRecordID > 0 Then
            If Me.SelectedUnit = LengthUnit.INCH Then
                TbInput.Text = Me.FrmMain.DiameterInch
            Else
                TbInput.Text = Me.FrmMain.DiameterMM
            End If
        End If
        ' Set Focust on Textbox
        Me.TbInput.Focus()
    End Sub

    Private Function SelectedUnit() As LengthUnit
        If Me.CmbUnit.SelectedItem.ToUpper = "INCH" Then
            Return LengthUnit.INCH
        Else
            Return LengthUnit.MM
        End If
    End Function

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click

        Const Inch_mm_ratio As Double = 25.4
        Const foot_m_ratio As Double = 0.305

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
            ' TODO: In the document, it seems that 3 fractional digit
            ' and round up 
            If Me.SelectedUnit = LengthUnit.INCH Then
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
            Dim tableAdapter = FrmMain.Un1TableAdapter
            If SelectedRecordID = 0 Then
                ' With Output clause in Query, this Insert return the new inserted Id
                SelectedRecordID = tableAdapter.Insert(diameter_inch, velocity_ft, diameter_mm, velocity_m)
            Else
                tableAdapter.Update(diameter_inch, velocity_ft, diameter_mm, velocity_m, Me.SelectedRecordID)
            End If

            ' Refill the updated data
            ' TODO: Maybe I can add sort clause in SELECT query
            tableAdapter.Fill(FrmMain.Minerite1DataSet.Un1)

        Catch ex As ArgumentException
        Catch ex As FormatException
        Catch ex As OverflowException
            MessageBox.Show("Please input positive float number")
            Return
        Catch ex1 As Exception
            MessageBox.Show("Can not save data. Please check disk or network")
        End Try
        Me.Close()
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class
