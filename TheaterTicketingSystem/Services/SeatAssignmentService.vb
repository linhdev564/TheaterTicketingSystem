Imports Microsoft.EntityFrameworkCore

Public Class SeatAssignmentService
    Inherits BaseService(Of SeatAssignment)

    Private Shared ReadOnly _instance As New Lazy(Of SeatAssignmentService)(
        Function() New SeatAssignmentService()
    )

    Public Shared ReadOnly Property GetInstance As SeatAssignmentService
        Get
            Return _instance.Value
        End Get
    End Property

    Public Function GetBookingOptions() As List(Of Booking)
        Using db = CreateContext()
            Return db.Bookings _
            .Include(Function(b) b.Performance) _
            .AsEnumerable() _
            .Where(Function(b) Not b.IsDeleted AndAlso Not b.Performance.IsDeleted) _
            .OrderByDescending(Function(b) b.CreatedAt) _
            .ToList()
        End Using
    End Function

    Public Function GetAssignedSeats(performanceId As Integer) As List(Of SeatAssignment)
        Using db = CreateContext()
            Return db.SeatAssignments _
            .AsEnumerable() _
            .Where(Function(s) Not s.IsDeleted AndAlso s.PerformanceId = performanceId) _
            .ToList()
        End Using
    End Function

    Public Function GetAssignedSeatsForBooking(bookingId As Integer) As List(Of SeatAssignment)
        Using db = CreateContext()
            Return db.SeatAssignments _
            .AsEnumerable() _
            .Where(Function(s) Not s.IsDeleted AndAlso s.BookingId = bookingId) _
            .ToList()
        End Using
    End Function

    Public Sub SaveSeatsForBooking(bookingId As Integer, selectedSeats As List(Of (Row As String, Number As Integer)))
        Using db = CreateContext()
            If bookingId <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(bookingId))
            If selectedSeats Is Nothing Then Throw New ArgumentNullException(NameOf(selectedSeats))

            Dim booking = db.Bookings _
            .AsEnumerable() _
            .FirstOrDefault(Function(b) b.Id = bookingId AndAlso Not b.IsDeleted)
            If booking Is Nothing Then Throw New InvalidOperationException("không tồn tại hoặc đã bị xóa.")

            If booking.Quantity <= 0 Then Throw New InvalidOperationException("Booking không hợp lệ (Quantity <= 0).")

            If selectedSeats.Count <> booking.Quantity Then
                Throw New InvalidOperationException($"Phải chọn đúng {booking.Quantity} ghế cho booking này.")
            End If

            Dim existing = db.SeatAssignments _
            .AsEnumerable() _
            .Where(Function(s) s.BookingId = bookingId AndAlso Not s.IsDeleted) _
            .ToList()
            For Each s In existing
                s.IsDeleted = True
            Next

            Dim perfId = booking.PerformanceId
            Dim seatsToCheck = selectedSeats.Select(Function(x) New With {Key .Row = x.Row, Key .Number = x.Number}).ToList()

            Dim conflict = db.SeatAssignments _
            .AsEnumerable() _
            .Any(Function(s) Not s.IsDeleted AndAlso s.PerformanceId = perfId AndAlso s.BookingId <> bookingId AndAlso seatsToCheck.Any(Function(x) x.Row = s.Row AndAlso x.Number = s.Number))
            If conflict Then
                Throw New InvalidOperationException("Có ghế đã được đặt bởi booking khác trong cùng suất diễn.")
            End If

            For Each seat In selectedSeats
                Dim row = (If(seat.Row, String.Empty)).Trim().ToUpperInvariant()
                Dim num = seat.Number

                Dim entity As New SeatAssignment With {
                .PerformanceId = perfId,
                .BookingId = bookingId,
                .Row = row,
                .Number = num
            }

                MyBase.Add(entity)
            Next

            db.SaveChanges()
        End Using
    End Sub
End Class
