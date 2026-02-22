<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerformanceMaster
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
        Panel1 = New Panel()
        cboPageNumber = New ComboBox()
        cboPageSize = New ComboBox()
        lblPageNumber = New Label()
        lblPageSize = New Label()
        btnReset = New Button()
        btnSearch = New Button()
        dtpSearchDate = New DateTimePicker()
        lblSearchDate = New Label()
        txtSearchName = New TextBox()
        lblSearchName = New Label()
        Panel2 = New Panel()
        btnSave = New Button()
        numDuration = New NumericUpDown()
        dtpStartTime = New DateTimePicker()
        txtName = New TextBox()
        lblDuration = New Label()
        lblStartTime = New Label()
        lblName = New Label()
        Panel3 = New Panel()
        dgvPerformance = New DataGridView()
        colSTT = New DataGridViewTextBoxColumn()
        colAction = New DataGridViewButtonColumn()
        colName = New DataGridViewTextBoxColumn()
        colDate = New DataGridViewTextBoxColumn()
        colDuration = New DataGridViewTextBoxColumn()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(numDuration, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(dgvPerformance, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(cboPageNumber)
        Panel1.Controls.Add(cboPageSize)
        Panel1.Controls.Add(lblPageNumber)
        Panel1.Controls.Add(lblPageSize)
        Panel1.Controls.Add(btnReset)
        Panel1.Controls.Add(btnSearch)
        Panel1.Controls.Add(dtpSearchDate)
        Panel1.Controls.Add(lblSearchDate)
        Panel1.Controls.Add(txtSearchName)
        Panel1.Controls.Add(lblSearchName)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 100)
        Panel1.TabIndex = 0
        ' 
        ' cboPageNumber
        ' 
        cboPageNumber.FormattingEnabled = True
        cboPageNumber.Location = New Point(448, 52)
        cboPageNumber.Name = "cboPageNumber"
        cboPageNumber.Size = New Size(56, 28)
        cboPageNumber.TabIndex = 9
        ' 
        ' cboPageSize
        ' 
        cboPageSize.FormattingEnabled = True
        cboPageSize.Items.AddRange(New Object() {"10", "20", "30"})
        cboPageSize.Location = New Point(269, 54)
        cboPageSize.Name = "cboPageSize"
        cboPageSize.Size = New Size(71, 28)
        cboPageSize.TabIndex = 8
        ' 
        ' lblPageNumber
        ' 
        lblPageNumber.AutoSize = True
        lblPageNumber.Location = New Point(381, 57)
        lblPageNumber.Name = "lblPageNumber"
        lblPageNumber.Size = New Size(49, 20)
        lblPageNumber.TabIndex = 7
        lblPageNumber.Text = "Trang:"
        ' 
        ' lblPageSize
        ' 
        lblPageSize.AutoSize = True
        lblPageSize.Location = New Point(219, 57)
        lblPageSize.Name = "lblPageSize"
        lblPageSize.Size = New Size(29, 20)
        lblPageSize.TabIndex = 6
        lblPageSize.Text = "Số:"
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(597, 51)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(128, 29)
        btnReset.TabIndex = 5
        btnReset.Text = "Đặt lại"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(597, 16)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(128, 29)
        btnSearch.TabIndex = 4
        btnSearch.Text = "Tìm"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' dtpSearchDate
        ' 
        dtpSearchDate.Location = New Point(278, 15)
        dtpSearchDate.Name = "dtpSearchDate"
        dtpSearchDate.Size = New Size(226, 27)
        dtpSearchDate.TabIndex = 3
        ' 
        ' lblSearchDate
        ' 
        lblSearchDate.AutoSize = True
        lblSearchDate.Location = New Point(219, 19)
        lblSearchDate.Name = "lblSearchDate"
        lblSearchDate.Size = New Size(47, 20)
        lblSearchDate.TabIndex = 2
        lblSearchDate.Text = "Ngày:"
        lblSearchDate.TextAlign = ContentAlignment.TopCenter
        ' 
        ' txtSearchName
        ' 
        txtSearchName.Location = New Point(53, 16)
        txtSearchName.Name = "txtSearchName"
        txtSearchName.Size = New Size(133, 27)
        txtSearchName.TabIndex = 1
        ' 
        ' lblSearchName
        ' 
        lblSearchName.AutoSize = True
        lblSearchName.Location = New Point(12, 19)
        lblSearchName.Name = "lblSearchName"
        lblSearchName.Size = New Size(35, 20)
        lblSearchName.TabIndex = 0
        lblSearchName.Text = "Tên:"
        lblSearchName.TextAlign = ContentAlignment.TopRight
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnSave)
        Panel2.Controls.Add(numDuration)
        Panel2.Controls.Add(dtpStartTime)
        Panel2.Controls.Add(txtName)
        Panel2.Controls.Add(lblDuration)
        Panel2.Controls.Add(lblStartTime)
        Panel2.Controls.Add(lblName)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 100)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(800, 63)
        Panel2.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(694, 18)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(94, 29)
        btnSave.TabIndex = 6
        btnSave.Text = "Thêm mới"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' numDuration
        ' 
        numDuration.Location = New Point(597, 18)
        numDuration.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        numDuration.Name = "numDuration"
        numDuration.Size = New Size(79, 27)
        numDuration.TabIndex = 5
        numDuration.Value = New Decimal(New Integer() {120, 0, 0, 0})
        ' 
        ' dtpStartTime
        ' 
        dtpStartTime.Location = New Point(278, 18)
        dtpStartTime.Name = "dtpStartTime"
        dtpStartTime.Size = New Size(207, 27)
        dtpStartTime.TabIndex = 4
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(50, 20)
        txtName.Name = "txtName"
        txtName.Size = New Size(136, 27)
        txtName.TabIndex = 3
        ' 
        ' lblDuration
        ' 
        lblDuration.AutoSize = True
        lblDuration.Location = New Point(510, 21)
        lblDuration.Name = "lblDuration"
        lblDuration.Size = New Size(88, 20)
        lblDuration.TabIndex = 2
        lblDuration.Text = "Thời lượng: "
        ' 
        ' lblStartTime
        ' 
        lblStartTime.AutoSize = True
        lblStartTime.Location = New Point(219, 21)
        lblStartTime.Name = "lblStartTime"
        lblStartTime.Size = New Size(47, 20)
        lblStartTime.TabIndex = 1
        lblStartTime.Text = "Ngày:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(12, 21)
        lblName.Name = "lblName"
        lblName.Size = New Size(35, 20)
        lblName.TabIndex = 0
        lblName.Text = "Tên:"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(dgvPerformance)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 163)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(800, 287)
        Panel3.TabIndex = 2
        ' 
        ' dgvPerformance
        ' 
        dgvPerformance.AllowUserToAddRows = False
        dgvPerformance.AllowUserToDeleteRows = False
        dgvPerformance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPerformance.Columns.AddRange(New DataGridViewColumn() {colSTT, colAction, colName, colDate, colDuration})
        dgvPerformance.Dock = DockStyle.Fill
        dgvPerformance.Location = New Point(0, 0)
        dgvPerformance.MultiSelect = False
        dgvPerformance.Name = "dgvPerformance"
        dgvPerformance.ReadOnly = True
        dgvPerformance.RowHeadersVisible = False
        dgvPerformance.RowHeadersWidth = 51
        dgvPerformance.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPerformance.Size = New Size(800, 287)
        dgvPerformance.TabIndex = 0
        ' 
        ' colSTT
        ' 
        colSTT.FillWeight = 71.65775F
        colSTT.HeaderText = "STT"
        colSTT.MinimumWidth = 6
        colSTT.Name = "colSTT"
        colSTT.ReadOnly = True
        colSTT.Width = 60
        ' 
        ' colAction
        ' 
        colAction.FillWeight = 128.34227F
        colAction.HeaderText = "Hành động"
        colAction.MinimumWidth = 6
        colAction.Name = "colAction"
        colAction.ReadOnly = True
        colAction.Text = "Sửa | Xóa"
        colAction.UseColumnTextForButtonValue = True
        colAction.Width = 120
        ' 
        ' colName
        ' 
        colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colName.DataPropertyName = "Name"
        colName.HeaderText = "Tên"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        ' 
        ' colDate
        ' 
        colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDate.DataPropertyName = "StartTime"
        colDate.HeaderText = "Ngày"
        colDate.MinimumWidth = 6
        colDate.Name = "colDate"
        colDate.ReadOnly = True
        ' 
        ' colDuration
        ' 
        colDuration.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDuration.DataPropertyName = "Duration"
        colDuration.HeaderText = "Thời lượng (Phút)"
        colDuration.MinimumWidth = 6
        colDuration.Name = "colDuration"
        colDuration.ReadOnly = True
        ' 
        ' frmPerformanceMaster
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "frmPerformanceMaster"
        Text = "frmPerformanceMaster"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(numDuration, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        CType(dgvPerformance, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblSearchName As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtpSearchDate As DateTimePicker
    Friend WithEvents lblSearchDate As Label
    Friend WithEvents txtSearchName As TextBox
    Friend WithEvents cboPageNumber As ComboBox
    Friend WithEvents cboPageSize As ComboBox
    Friend WithEvents lblPageNumber As Label
    Friend WithEvents lblPageSize As Label
    Friend WithEvents numDuration As NumericUpDown
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblDuration As Label
    Friend WithEvents lblStartTime As Label
    Friend WithEvents lblName As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvPerformance As DataGridView
    Friend WithEvents colSTT As DataGridViewTextBoxColumn
    Friend WithEvents colAction As DataGridViewButtonColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colDuration As DataGridViewTextBoxColumn
End Class
