<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbUnit = New System.Windows.Forms.ComboBox()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TbInput = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cartridge Diameter"
        '
        'CmbUnit
        '
        Me.CmbUnit.FormattingEnabled = True
        Me.CmbUnit.Items.AddRange(New Object() {"inch", "mm"})
        Me.CmbUnit.Location = New System.Drawing.Point(143, 21)
        Me.CmbUnit.Name = "CmbUnit"
        Me.CmbUnit.Size = New System.Drawing.Size(102, 21)
        Me.CmbUnit.TabIndex = 1
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(55, 127)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(152, 127)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TbInput
        '
        Me.TbInput.Location = New System.Drawing.Point(60, 68)
        Me.TbInput.Name = "TbInput"
        Me.TbInput.Size = New System.Drawing.Size(167, 20)
        Me.TbInput.TabIndex = 4
        '
        'FrmAddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 178)
        Me.Controls.Add(Me.TbInput)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.CmbUnit)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmAddEdit"
        Me.Text = "New"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CmbUnit As ComboBox
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents TbInput As TextBox
End Class
