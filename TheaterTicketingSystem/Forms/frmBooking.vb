Public Class frmBooking
    Dim remaining As Integer = 0

    Private Sub frmBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitSeatType()
            LoadPerformances()
            ClearForm()
        Catch ex As Exception
            AppLogger.LogError(ex, "frmBooking_Load")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitSeatType()
        cboSeatType.DataSource = [Enum].GetValues(GetType(SeatType))
    End Sub

    Private Sub LoadPerformances()
        Dim items = BookingService.GetInstance.GetPerformanceOptions()

        cboPerformance.DisplayMember = "Name"
        cboPerformance.ValueMember = "Id"
        cboPerformance.DataSource = items

        If cboPerformance.Items.Count > 0 Then
            cboPerformance.SelectedIndex = 0
        End If
    End Sub

    Private Sub ClearForm()
        txtCustomerName.Clear()
        txtPhoneNumber.Clear()
        numQuantity.Value = 1
        cboSeatType.SelectedItem = SeatType.Standard
        lblUnitPriceValue.Text = "0"
        lblTotalValue.Text = "0"
        UpdatePricePreview()
        UpdateRemainingSeats()
    End Sub

    Private Sub UpdatePricePreview()
        If cboSeatType.SelectedItem Is Nothing Then Return

        Dim seatType = CType(cboSeatType.SelectedItem, SeatType)
        Dim unitPrice = PricingHelper.GetUnitPrice(seatType)
        Dim quantity = CInt(numQuantity.Value)
        Dim total = unitPrice * quantity

        lblUnitPriceValue.Text = unitPrice.ToString("N0")
        lblTotalValue.Text = total.ToString("N0")
    End Sub

    Private Function ValidateInput(ByRef performanceId As Integer,
                                   ByRef customerName As String,
                                   ByRef phoneNumber As String,
                                   ByRef seatType As SeatType,
                                   ByRef quantity As Integer,
                                   ByRef unitPrice As Decimal) As Boolean

        If cboPerformance.SelectedValue Is Nothing Then
            MessageBox.Show("Vui lòng chọn suất diễn.")
            cboPerformance.Focus()
            Return False
        End If

        performanceId = CInt(cboPerformance.SelectedValue)

        customerName = If(txtCustomerName.Text, String.Empty).Trim()
        If String.IsNullOrWhiteSpace(customerName) Then
            MessageBox.Show("Vui lòng nhập tên khách hàng.")
            txtCustomerName.Focus()
            Return False
        End If

        phoneNumber = If(txtPhoneNumber.Text, String.Empty).Trim()
        If String.IsNullOrWhiteSpace(phoneNumber) Then
            MessageBox.Show("Vui lòng nhập số điện thoại.")
            txtPhoneNumber.Focus()
            Return False
        End If

        If phoneNumber.Length > 20 Then
            MessageBox.Show("Số điện thoại tối đa 20 ký tự.")
            txtPhoneNumber.Focus()
            Return False
        End If

        If cboSeatType.SelectedItem Is Nothing Then
            MessageBox.Show("Vui lòng chọn loại ghế.")
            cboSeatType.Focus()
            Return False
        End If

        seatType = CType(cboSeatType.SelectedItem, SeatType)

        quantity = CInt(numQuantity.Value)
        If quantity <= 0 Then
            MessageBox.Show("Số lượng vé phải lớn hơn 0.")
            numQuantity.Focus()
            Return False
        End If

        unitPrice = PricingHelper.GetUnitPrice(seatType)
        Return True
    End Function

    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        Dim performanceId As Integer
        Dim customerName As String = Nothing
        Dim phoneNumber As String = Nothing
        Dim seatType As SeatType
        Dim quantity As Integer
        Dim unitPrice As Decimal

        If Not ValidateInput(performanceId, customerName, phoneNumber, seatType, quantity, unitPrice) Then Return

        If quantity > remaining Then
            MessageBox.Show($"Chỉ còn {remaining} ghế trống. Vui lòng giảm số lượng vé.", "Không đủ ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim booking As New Booking With {
                .PerformanceId = performanceId,
                .CustomerName = customerName,
                .PhoneNumber = phoneNumber,
                .SeatType = seatType,
                .Quantity = quantity,
                .UnitPrice = unitPrice,
                .TotalPrice = unitPrice * quantity
            }

            BookingService.GetInstance.Add(booking)

            MessageBox.Show("Đặt vé thành công.")
            ClearForm()
        Catch ex As Exception
            AppLogger.LogError(ex, "btnBook_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            ClearForm()
        Catch ex As Exception
            AppLogger.LogError(ex, "btnReset_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboSeatType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeatType.SelectedIndexChanged
        Try
            UpdatePricePreview()
        Catch ex As Exception
            AppLogger.LogError(ex, "cboSeatType_SelectedIndexChanged")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub numQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numQuantity.ValueChanged
        Try
            UpdatePricePreview()
        Catch ex As Exception
            AppLogger.LogError(ex, "numQuantity_ValueChanged")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboPerformance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPerformance.SelectedIndexChanged
        Try
            UpdateRemainingSeats()
        Catch ex As Exception
            AppLogger.LogError(ex, "cboPerformance_SelectedIndexChanged")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateRemainingSeats()
        If cboPerformance.SelectedValue Is Nothing Then
            lblRemainingSeats.Text = "Ghế: --"
            Return
        End If

        Try
            Dim performanceId = CInt(cboPerformance.SelectedValue)
            Dim totalSeats = AppConstants.DefaultTotalSeats
            Dim bookedSeats = BookingService.GetInstance.GetBookedSeatCount(performanceId)
            remaining = totalSeats - bookedSeats

            lblRemainingSeats.Text = $"Ghế: {remaining}/{totalSeats}"

            If remaining <= 0 Then
                lblRemainingSeats.ForeColor = Color.Red
            ElseIf remaining <= totalSeats * 0.2 Then
                lblRemainingSeats.ForeColor = Color.OrangeRed
            Else
                lblRemainingSeats.ForeColor = Color.Green
            End If
        Catch ex As Exception
            AppLogger.LogError(ex, "UpdateRemainingSeats")
            lblRemainingSeats.Text = "Ghế còn lại: (lỗi)"
            lblRemainingSeats.ForeColor = Color.Gray
        End Try
    End Sub
End Class
