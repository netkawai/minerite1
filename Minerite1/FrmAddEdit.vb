Public Class FrmAddEdit

    ''' <summary>
    ''' UNIT Type
    ''' </summary>
    Public Enum LengthUnit
        INCH
        MM
    End Enum

    ' FrmMain
    Private FrmMain As FrmMain

    ' Selected id in DataGridView
    Private _selectedId As Integer
    Public Property SelectedID As Integer
        Get
            Return _selectedId
        End Get
        Private Set(value As Integer)
            _selectedId = value
        End Set
    End Property

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="selectedId"></param>
    Public Sub New(ByVal selectedId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.SelectedID = selectedId
        If selectedId = 0 Then
            Me.Text = "ADD"
        Else
            Me.Text = "EDIT"
        End If
    End Sub

    ''' <summary>
    ''' Setup dialog according to current status
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FrmAddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmMain = Me.Owner
        Me.SelectedUnit = FrmMain.SelectedUnit

        ' To open this form with selected row, that is Edit mode
        If SelectedID > 0 Then
            If Me.SelectedUnit = LengthUnit.INCH Then
                TbInput.Text = Me.FrmMain.DiameterInch
            Else
                TbInput.Text = Me.FrmMain.DiameterMM
            End If
        End If
        ' Set Focust on Textbox
        Me.TbInput.Focus()
    End Sub


    ''' <summary>
    ''' Update button
    ''' Validating input only positive numbers.
    ''' Calculating detonation velocity
    ''' To check whether inch or mm
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Const Foot_m_ratio As Double = 0.305

        Try
            Dim diameter As Double = Double.Parse(Me.TbInput.Text)
            If diameter < 0 Then
                Throw New FormatException
            End If

            Dim velocity As Double = Calculate_Velocity(diameter)

            Dim diameter_inch, diameter_mm, velocity_ft, velocity_m
            ' cacluation other unit

            If Me.SelectedUnit = LengthUnit.INCH Then
                diameter_inch = diameter
                diameter_mm = InchToMM(diameter_inch)
                velocity_ft = velocity
                velocity_m = velocity_ft * Foot_m_ratio
            Else
                diameter_mm = diameter
                diameter_inch = MMToInch(diameter_mm)
                velocity_m = velocity
                velocity_ft = velocity_m / Foot_m_ratio
            End If

            ' Call to save data
            Dim tableAdapter = FrmMain.Un1TableAdapter
            If SelectedID = 0 Then
                ' With Output clause in Query, this Insert return the new inserted Id
                tableAdapter.Insert(diameter_inch, velocity_ft, diameter_mm, velocity_m, Me.SelectedID)
            Else
                tableAdapter.Update(diameter_inch, velocity_ft, diameter_mm, velocity_m, Me.SelectedID)
            End If

        Catch ex As ArgumentException
        Catch ex As FormatException
        Catch ex As OverflowException
            MessageBox.Show("Please input positive float number")
            Return
        Catch ex1 As Exception
            MessageBox.Show("Can not save data. Please check disk or network")
            Return
        End Try
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ''' <summary>
    ''' Cancel, close dialog
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' If there is a value in textbox, value should be automatically calculated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUnit.SelectedIndexChanged
        FrmMain.SelectedUnit = Me.SelectedUnit
        Try
            Dim diameter As Double = Double.Parse(Me.TbInput.Text)
            If diameter < 0 Then
                Throw New FormatException
            End If

            If Me.SelectedUnit = LengthUnit.INCH Then
                TbInput.Text = MMToInch(diameter)
            Else
                TbInput.Text = InchToMM(diameter)
            End If
        Catch ex1 As Exception
            ' If format is not correct, do nothing
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

    ''' <summary>
    ''' Setter and Getter for Unit selection
    ''' </summary>
    ''' <returns></returns>
    Private Property SelectedUnit() As LengthUnit
        Get
            If Me.CmbUnit.SelectedIndex = 0 Then
                Return LengthUnit.INCH
            Else
                Return LengthUnit.MM
            End If
        End Get

        Set(value As LengthUnit)
            If value = LengthUnit.INCH Then
                Me.CmbUnit.SelectedIndex = 0
            Else
                Me.CmbUnit.SelectedIndex = 1
            End If
        End Set
    End Property

    ''' <summary>
    ''' Unit conversion ratio
    ''' </summary>
    Private Const Inch_mm_ratio As Double = 25.4

    Private Function InchToMM(ByVal inch As Double) As Double
        Return Double.Parse((inch * Inch_mm_ratio).ToString("N3"))
    End Function

    Private Function MMToInch(ByVal inch As Double) As Double
        Return Double.Parse((inch / Inch_mm_ratio).ToString("N3"))
    End Function

End Class
