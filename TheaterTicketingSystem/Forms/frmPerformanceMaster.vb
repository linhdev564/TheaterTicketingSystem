Imports System.Drawing.Printing

Public Class frmPerformanceMaster
    Private isEditMode As Boolean = False
    Private editingId As Integer = 0

    Private Sub frmPerformanceMaster_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        Try
            SetAddMode()
            InitPageSize()
            InitPageNumber()
            InitNullableDatePickers()
            LoadData()
        Catch ex As Exception
            AppLogger.LogError(ex, "frmPerformanceMaster_Load")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitPageSize()
        If cboPageSize.Items.Count = 0 Then
            cboPageSize.Items.AddRange(New Object() {10, 20, 30})
        End If
        cboPageSize.SelectedIndex = 0
    End Sub

    Private Sub InitPageNumber()
        cboPageNumber.Items.Clear()
        cboPageNumber.Items.Add(1)
        cboPageNumber.SelectedIndex = 0
    End Sub

    Private Sub InitNullableDatePickers()
        SetDatePickerNull(dtpSearchDate)
        SetDatePickerNull(dtpStartTime)
    End Sub

    Private Sub SetDatePickerNull(dtp As DateTimePicker)
        dtp.Format = DateTimePickerFormat.Custom
        dtp.CustomFormat = " "
    End Sub

    Private Sub SetDatePickerValue(dtp As DateTimePicker, value As DateTime)
        dtp.Format = DateTimePickerFormat.Custom
        dtp.CustomFormat = "dd/MM/yyyy HH:mm"
        dtp.Value = value
    End Sub

    Private Function GetNullableDateValue(dtp As DateTimePicker) As DateTime?
        If dtp.CustomFormat = " " Then Return Nothing
        Return dtp.Value
    End Function

    Private Sub dtpSearchDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpSearchDate.ValueChanged
        Try
            If dtpSearchDate.CustomFormat = " " Then
                dtpSearchDate.CustomFormat = "dd/MM/yyyy"
            End If
        Catch ex As Exception
            AppLogger.LogError(ex, "dtpSearchDate_ValueChanged")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpStartTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartTime.ValueChanged
        Try
            If dtpStartTime.CustomFormat = " " Then
                dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm"
            End If
        Catch ex As Exception
            AppLogger.LogError(ex, "dtpStartTime_ValueChanged")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadData()
        Dim searchDate = GetNullableDateValue(dtpSearchDate)

        Dim pageSize = CInt(cboPageSize.SelectedItem)
        Dim pageIndex = CInt(cboPageNumber.SelectedItem)

        Dim data = PerformanceService.GetInstance.Search(
            txtSearchName.Text, searchDate, pageSize, pageIndex)
        UpdatePageNumber(data.Total)
        dgvPerformance.AutoGenerateColumns = False
        dgvPerformance.DataSource = Nothing
        dgvPerformance.DataSource = data.Items
    End Sub

    Private Sub UpdatePageNumber(total As Integer)
        Dim pageSize As Integer = CInt(cboPageSize.SelectedItem)
        If pageSize <= 0 Then Return

        Dim totalPages As Integer =
        CInt(Math.Ceiling(total / pageSize))

        If totalPages = 0 Then totalPages = 1

        Dim currentPage As Integer = 1

        If cboPageNumber.SelectedItem IsNot Nothing Then
            currentPage = CInt(cboPageNumber.SelectedItem)
        End If

        cboPageNumber.Items.Clear()

        For i As Integer = 1 To totalPages
            cboPageNumber.Items.Add(i)
        Next

        If currentPage <= totalPages Then
            cboPageNumber.SelectedItem = currentPage
        Else
            cboPageNumber.SelectedItem = totalPages
        End If
    End Sub

    Private Sub SetEditMode()
        isEditMode = True
        btnSave.BackColor = Color.Orange
        btnSave.Text = "Sửa"
    End Sub

    Private Sub SetAddMode()
        isEditMode = False
        btnSave.BackColor = Color.LightGreen
        editingId = 0
        btnSave.Text = "Thêm mới"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) _
        Handles btnSave.Click
        Try
            If isEditMode Then
                UpdatePerformance()
            Else
                AddPerformance()
            End If
        Catch ex As Exception
            AppLogger.LogError(ex, "btnSave_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidatePerformanceInput(ByRef validName As String,
                                              ByRef validStartTime As DateTime,
                                              ByRef validDuration As Integer) As Boolean

        validName = If(txtName.Text, String.Empty).Trim()

        If String.IsNullOrWhiteSpace(validName) Then
            MessageBox.Show("Vui lòng nhập tên suất diễn.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If validName.Length > 200 Then
            MessageBox.Show("Tên suất diễn tối đa 200 ký tự.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        Dim startTimeNullable = GetNullableDateValue(dtpStartTime)
        If Not startTimeNullable.HasValue Then
            MessageBox.Show("Vui lòng chọn ngày/giờ bắt đầu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpStartTime.Focus()
            Return False
        End If
        validStartTime = startTimeNullable.Value

        validDuration = CInt(numDuration.Value)
        If validDuration <= 0 Then
            MessageBox.Show("Thời lượng phải lớn hơn 0.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numDuration.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub AddPerformance()
        Dim name = txtName.Text
        Dim startTime = dtpStartTime.Value
        Dim duration = CInt(numDuration.Text)

        If Not ValidatePerformanceInput(name, startTime, duration) Then Return

        Dim newPerformance As New Performance With {
            .Name = name.Trim(),
            .StartTime = startTime,
            .Duration = duration
        }

        PerformanceService.GetInstance().Add(newPerformance)

        LoadData()
        ClearForm()
    End Sub

    Private Sub UpdatePerformance()
        Dim name = txtName.Text
        Dim startTime = dtpStartTime.Value
        Dim duration = CInt(numDuration.Text)

        If Not ValidatePerformanceInput(name, startTime, duration) Then Return

        Dim p = PerformanceService.GetInstance().GetById(editingId)

        If p Is Nothing OrElse p.IsDeleted Then
            MessageBox.Show("Bản ghi không tồn tại hoặc đã bị xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LoadData()
            ClearForm()
            SetAddMode()
            Return
        End If

        p.Name = name.Trim()
        p.StartTime = startTime
        p.Duration = duration

        PerformanceService.GetInstance().Update(p)

        LoadData()
        ClearForm()
        SetAddMode()
    End Sub

    Private Sub ClearForm()
        txtName.Clear()
        SetDatePickerNull(dtpStartTime)
        numDuration.Value = 0
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            LoadData()
        Catch ex As Exception
            AppLogger.LogError(ex, "btnSearch_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            txtSearchName.Text = ""
            SetDatePickerNull(dtpSearchDate)
            cboPageSize.SelectedIndex = 0
            cboPageNumber.SelectedIndex = 0
        Catch ex As Exception
            AppLogger.LogError(ex, "btnReset_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPerformance_RowPostPaint(
        sender As Object,
        e As DataGridViewRowPostPaintEventArgs
    ) Handles dgvPerformance.RowPostPaint
        Try
            Dim pageSize As Integer = CInt(cboPageSize.SelectedItem)
            Dim pageNumber As Integer = CInt(cboPageNumber.SelectedItem)

            Dim rowNumber =
                (pageNumber - 1) * pageSize + e.RowIndex + 1

            dgvPerformance.Rows(e.RowIndex) _
                .Cells("colSTT").Value = rowNumber
        Catch ex As Exception
            AppLogger.LogError(ex, "dgvPerformance_RowPostPaint")
        End Try
    End Sub

    Private Sub dgvPerformance_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvPerformance.CellContentClick
        Try
            If e.RowIndex < 0 Then Return

            If dgvPerformance.Columns(e.ColumnIndex).Name = "colAction" Then
                HandleActionClick(e.RowIndex)
            End If
        Catch ex As Exception
            AppLogger.LogError(ex, "dgvPerformance_CellContentClick")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HandleActionClick(rowIndex As Integer)
        Dim mousePos = dgvPerformance.PointToClient(Cursor.Position)
        Dim hit = dgvPerformance.HitTest(mousePos.X, mousePos.Y)

        Dim rect = dgvPerformance.GetCellDisplayRectangle(
        hit.ColumnIndex,
        hit.RowIndex,
        False)

        Dim clickX = mousePos.X - rect.X

        If clickX < rect.Width / 2 Then
            EditRow(rowIndex)
        Else
            DeleteRow(rowIndex)
        End If
    End Sub

    Private Sub DeleteRow(rowIndex As Integer)
        Dim item = GetItem(rowIndex)

        Dim result = MessageBox.Show(
        $"Xóa suất diễn '{item.Name}' ?",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            PerformanceService.GetInstance().DeleteById(item.Id)
            MessageBox.Show("Đã xóa")
            LoadData()
        End If
    End Sub

    Private Sub EditRow(rowIndex As Integer)
        Dim item = GetItem(rowIndex)

        editingId = item.Id
        txtName.Text = item.Name
        SetDatePickerValue(dtpStartTime, item.StartTime)
        numDuration.Value = item.Duration

        SetEditMode()
    End Sub

    Private Function GetItem(rowIndex As Integer) As Performance
        Return CType(
            dgvPerformance.Rows(rowIndex).DataBoundItem,
            Performance)
    End Function

End Class