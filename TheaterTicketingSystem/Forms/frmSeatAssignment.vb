Public Class frmSeatAssignment

    Private ReadOnly _seatButtons As New Dictionary(Of String, Button)(StringComparer.OrdinalIgnoreCase)
    Private _selected As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

    Private Sub frmSeatAssignment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadBookings()
            BuildSeatGrid()
            RefreshSeatMap()
        Catch ex As Exception
            AppLogger.LogError(ex, "frmSeatAssignment_Load")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBookings()
        Dim bookings = SeatAssignmentService.GetInstance.GetBookingOptions()

        cboBooking.DisplayMember = "DisplayText"
        cboBooking.ValueMember = "Id"
        cboBooking.DataSource = bookings

        If cboBooking.Items.Count > 0 Then
            cboBooking.SelectedIndex = 0
        End If
    End Sub

    Private Function GetSelectedBooking() As Booking
        Dim booking = TryCast(cboBooking.SelectedItem, Booking)
        Return booking
    End Function

    Private Sub BuildSeatGrid()
        pnlSeats.Controls.Clear()
        _seatButtons.Clear()

        Dim margin As Integer = 4
        Dim btnW As Integer = 42
        Dim btnH As Integer = 32

        For r As Integer = 0 To AppConstants.SeatRows - 1
            Dim rowChar As Char = ChrW(AscW("A"c) + r)
            For c As Integer = 1 To AppConstants.SeatCols
                Dim code = $"{rowChar}{c}"

                Dim btn As New Button()
                btn.Name = $"btnSeat_{code}"
                btn.Text = code
                btn.Width = btnW
                btn.Height = btnH
                btn.Left = (c - 1) * (btnW + margin)
                btn.Top = r * (btnH + margin)
                btn.Tag = code
                btn.BackColor = Color.White

                AddHandler btn.Click, AddressOf SeatButton_Click

                pnlSeats.Controls.Add(btn)
                _seatButtons(code) = btn
            Next
        Next
    End Sub

    Private Sub RefreshSeatMap()
        Dim booking = GetSelectedBooking()
        If booking Is Nothing Then
            lblInfo.Text = "Chưa có booking."
            pnlSeats.Enabled = False
            btnSave.Enabled = False
            Return
        End If

        pnlSeats.Enabled = True
        btnSave.Enabled = True

        Dim performance = PerformanceService.GetInstance.GetById(booking.PerformanceId)
        Dim perfId = booking.PerformanceId
        Dim quota = booking.Quantity
        lblInfo.Text = $"Suất diễn: {performance.Name} | Số vé: {quota} | Loại vé: {PricingHelper.GetUnitName(booking.SeatType)} | Tiền: {booking.TotalPrice.ToString("N0")} VND | Tên: {booking.CustomerName} | SĐT: {booking.PhoneNumber}"

        _selected.Clear()

        Dim assignedAll = SeatAssignmentService.GetInstance.GetAssignedSeats(perfId)
        Dim assignedThis = assignedAll.Where(Function(s) s.BookingId = booking.Id AndAlso Not s.IsDeleted).ToList()

        For Each s In assignedThis
            _selected.Add($"{s.Row}{s.Number}")
        Next

        For Each kv In _seatButtons
            Dim code = kv.Key
            Dim btn = kv.Value

            Dim isTakenByOther = assignedAll.Any(Function(s) Not s.IsDeleted AndAlso s.BookingId <> booking.Id AndAlso String.Equals($"{s.Row}{s.Number}", code, StringComparison.OrdinalIgnoreCase))

            If isTakenByOther Then
                btn.BackColor = Color.IndianRed
                btn.Enabled = False
            ElseIf _selected.Contains(code) Then
                btn.BackColor = Color.DeepSkyBlue
                btn.Enabled = True
            Else
                btn.BackColor = Color.White
                btn.Enabled = True
            End If
        Next

        lblSelectedCount.Text = $"Đã chọn: {_selected.Count}/{quota}"
    End Sub

    Private Sub SeatButton_Click(sender As Object, e As EventArgs)
        Try
            Dim booking = GetSelectedBooking()
            If booking Is Nothing Then Return

            Dim quota = booking.Quantity
            Dim btn = CType(sender, Button)
            Dim code = CStr(btn.Tag)

            If _selected.Contains(code) Then
                _selected.Remove(code)
                btn.BackColor = Color.White
            Else
                If _selected.Count >= quota Then
                    MessageBox.Show($"Bạn chỉ được chọn tối đa {quota} ghế.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                _selected.Add(code)
                btn.BackColor = Color.DeepSkyBlue
            End If

            lblSelectedCount.Text = $"Đã chọn: {_selected.Count}/{quota}"
        Catch ex As Exception
            AppLogger.LogError(ex, "SeatButton_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ParseSeat(code As String) As (Row As String, Number As Integer)
        code = (If(code, String.Empty)).Trim().ToUpperInvariant()
        Dim row = code.Substring(0, 1)
        Dim number = Integer.Parse(code.Substring(1))
        Return (row, number)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim booking = GetSelectedBooking()
        If booking Is Nothing Then Return

        If _selected.Count <> booking.Quantity Then
            MessageBox.Show($"Bạn phải chọn đúng {booking.Quantity} ghế trước khi lưu.", "Thiếu ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show("Lưu gán ghế cho booking này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Dim seats = _selected.Select(Function(x) ParseSeat(x)).ToList()
            SeatAssignmentService.GetInstance.SaveSeatsForBooking(booking.Id, seats)

            MessageBox.Show("Đã lưu gán ghế.")
            RefreshSeatMap()
        Catch ex As Exception
            AppLogger.LogError(ex, "btnSave_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            RefreshSeatMap()
        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            RefreshSeatMap()
        Catch ex As Exception
            AppLogger.LogError(ex, "btnReload_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboBooking_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBooking.SelectedIndexChanged
        Try
            RefreshSeatMap()
        Catch ex As Exception
            AppLogger.LogError(ex, "cboBooking_SelectedIndexChanged")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelBooking_Click(sender As Object, e As EventArgs) Handles btnCancelBooking.Click
        Try
            Dim booking = GetSelectedBooking()
            If booking Is Nothing Then
                MessageBox.Show("Chưa chọn booking nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim confirm = MessageBox.Show(
                $"Bạn có chắc muốn hủy booking của khách ""{booking.CustomerName}"" (SĐT: {booking.PhoneNumber})?{vbCrLf}Ghế đã gán (nếu có) sẽ được trả lại.",
                "Xác nhận hủy booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If confirm <> DialogResult.Yes Then Return

            Dim seats = SeatAssignmentService.GetInstance.GetAssignedSeatsForBooking(booking.Id)

            booking.IsDeleted = True
            BookingService.GetInstance.Update(booking)

            If seats IsNot Nothing AndAlso seats.Count > 0 Then
                For Each s In seats
                    s.IsDeleted = True
                    SeatAssignmentService.GetInstance.Update(s)
                Next
            End If

            MessageBox.Show("Đã hủy booking và trả ghế thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadBookings()
            RefreshSeatMap()
        Catch ex As Exception
            AppLogger.LogError(ex, "btnCancelBooking_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
