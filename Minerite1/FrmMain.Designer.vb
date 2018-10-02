<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Un1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataDataSet = New Minerite1.dataDataSet()
        Me.Un1TableAdapter = New Minerite1.dataDataSetTableAdapters.Un1TableAdapter()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDinchDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDmmDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVmDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Un1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(12, 12)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "ADD"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "EDIT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 109)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "DELETE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.CDinchDataGridViewTextBoxColumn, Me.DVftDataGridViewTextBoxColumn, Me.CDmmDataGridViewTextBoxColumn, Me.DVmDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.Un1BindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(94, 13)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(577, 335)
        Me.DataGridView1.TabIndex = 3
        '
        'Un1BindingSource
        '
        Me.Un1BindingSource.DataMember = "Un1"
        Me.Un1BindingSource.DataSource = Me.DataDataSet
        '
        'DataDataSet
        '
        Me.DataDataSet.DataSetName = "dataDataSet"
        Me.DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Un1TableAdapter
        '
        Me.Un1TableAdapter.ClearBeforeFill = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'CDinchDataGridViewTextBoxColumn
        '
        Me.CDinchDataGridViewTextBoxColumn.DataPropertyName = "CD_inch"
        Me.CDinchDataGridViewTextBoxColumn.HeaderText = "CD_inch"
        Me.CDinchDataGridViewTextBoxColumn.Name = "CDinchDataGridViewTextBoxColumn"
        Me.CDinchDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DVftDataGridViewTextBoxColumn
        '
        Me.DVftDataGridViewTextBoxColumn.DataPropertyName = "DV_ft"
        Me.DVftDataGridViewTextBoxColumn.HeaderText = "DV_ft"
        Me.DVftDataGridViewTextBoxColumn.Name = "DVftDataGridViewTextBoxColumn"
        Me.DVftDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CDmmDataGridViewTextBoxColumn
        '
        Me.CDmmDataGridViewTextBoxColumn.DataPropertyName = "CD_mm"
        Me.CDmmDataGridViewTextBoxColumn.HeaderText = "CD_mm"
        Me.CDmmDataGridViewTextBoxColumn.Name = "CDmmDataGridViewTextBoxColumn"
        Me.CDmmDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DVmDataGridViewTextBoxColumn
        '
        Me.DVmDataGridViewTextBoxColumn.DataPropertyName = "DV_m"
        Me.DVmDataGridViewTextBoxColumn.HeaderText = "DV_m"
        Me.DVmDataGridViewTextBoxColumn.Name = "DVmDataGridViewTextBoxColumn"
        Me.DVmDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 360)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnAdd)
        Me.Name = "FrmMain"
        Me.Text = "Minerite1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Un1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnAdd As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents CartridgeDiameterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DetonationVelocityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataDataSet As dataDataSet
    Friend WithEvents Un1BindingSource As BindingSource
    Friend WithEvents Un1TableAdapter As dataDataSetTableAdapters.Un1TableAdapter
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CDinchDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DVftDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CDmmDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DVmDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
