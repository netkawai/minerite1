﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.DgvDataSheet = New System.Windows.Forms.DataGridView()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Un1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Minerite1DataSet = New Minerite1.Minerite1DataSet()
        Me.Un1TableAdapter = New Minerite1.Minerite1DataSetTableAdapters.Un1TableAdapter()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDinchDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDmmDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVmDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvDataSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Un1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Minerite1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(12, 12)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "&ADD"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(12, 58)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(75, 23)
        Me.BtnEdit.TabIndex = 1
        Me.BtnEdit.Text = "&EDIT"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(12, 109)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelete.TabIndex = 2
        Me.BtnDelete.Text = "&DELETE"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'DgvDataSheet
        '
        Me.DgvDataSheet.AllowUserToAddRows = False
        Me.DgvDataSheet.AllowUserToDeleteRows = False
        Me.DgvDataSheet.AllowUserToResizeRows = False
        Me.DgvDataSheet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvDataSheet.AutoGenerateColumns = False
        Me.DgvDataSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDataSheet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.CDinchDataGridViewTextBoxColumn, Me.DVftDataGridViewTextBoxColumn, Me.CDmmDataGridViewTextBoxColumn, Me.DVmDataGridViewTextBoxColumn})
        Me.DgvDataSheet.DataSource = Me.Un1BindingSource
        Me.DgvDataSheet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgvDataSheet.Location = New System.Drawing.Point(94, 13)
        Me.DgvDataSheet.MultiSelect = False
        Me.DgvDataSheet.Name = "DgvDataSheet"
        Me.DgvDataSheet.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DgvDataSheet.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvDataSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDataSheet.Size = New System.Drawing.Size(577, 335)
        Me.DgvDataSheet.TabIndex = 3
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(12, 160)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 4
        Me.BtnPrint.Text = "&PRINT..."
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(13, 211)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "&SAVE..."
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Un1BindingSource
        '
        Me.Un1BindingSource.DataMember = "Un1"
        Me.Un1BindingSource.DataSource = Me.Minerite1DataSet
        '
        'Minerite1DataSet
        '
        Me.Minerite1DataSet.DataSetName = "Minerite1DataSet"
        Me.Minerite1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.IdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'CDinchDataGridViewTextBoxColumn
        '
        Me.CDinchDataGridViewTextBoxColumn.DataPropertyName = "CD_inch"
        Me.CDinchDataGridViewTextBoxColumn.HeaderText = "Cartridge Diameter(inch)"
        Me.CDinchDataGridViewTextBoxColumn.Name = "CDinchDataGridViewTextBoxColumn"
        Me.CDinchDataGridViewTextBoxColumn.ReadOnly = True
        Me.CDinchDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DVftDataGridViewTextBoxColumn
        '
        Me.DVftDataGridViewTextBoxColumn.DataPropertyName = "DV_ft"
        Me.DVftDataGridViewTextBoxColumn.HeaderText = "Detonation Velocity(ft/sec)"
        Me.DVftDataGridViewTextBoxColumn.Name = "DVftDataGridViewTextBoxColumn"
        Me.DVftDataGridViewTextBoxColumn.ReadOnly = True
        Me.DVftDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CDmmDataGridViewTextBoxColumn
        '
        Me.CDmmDataGridViewTextBoxColumn.DataPropertyName = "CD_mm"
        Me.CDmmDataGridViewTextBoxColumn.HeaderText = "Cartridge Diameter(mm)"
        Me.CDmmDataGridViewTextBoxColumn.Name = "CDmmDataGridViewTextBoxColumn"
        Me.CDmmDataGridViewTextBoxColumn.ReadOnly = True
        Me.CDmmDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DVmDataGridViewTextBoxColumn
        '
        Me.DVmDataGridViewTextBoxColumn.DataPropertyName = "DV_m"
        Me.DVmDataGridViewTextBoxColumn.HeaderText = "Detonation Velocity(m/sec)"
        Me.DVmDataGridViewTextBoxColumn.Name = "DVmDataGridViewTextBoxColumn"
        Me.DVmDataGridViewTextBoxColumn.ReadOnly = True
        Me.DVmDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 360)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.DgvDataSheet)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnAdd)
        Me.Name = "FrmMain"
        Me.Text = "Minerite1"
        CType(Me.DgvDataSheet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Un1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Minerite1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents CartridgeDiameterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DetonationVelocityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DgvDataSheet As DataGridView
    Friend WithEvents Minerite1DataSet As Minerite1DataSet
    Friend WithEvents Un1BindingSource As BindingSource
    Friend WithEvents Un1TableAdapter As Minerite1DataSetTableAdapters.Un1TableAdapter
    Friend WithEvents BtnPrint As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CDinchDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DVftDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CDmmDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DVmDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
