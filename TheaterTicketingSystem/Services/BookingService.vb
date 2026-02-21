Imports Microsoft.EntityFrameworkCore

Public Class BookingService
    Inherits BaseService(Of Booking)

    Private Shared ReadOnly _instance As New Lazy(Of BookingService)(
        Function() New BookingService()
    )

    Public Shared ReadOnly Property GetInstance As BookingService
        Get
            Return _instance.Value
        End Get
    End Property

    Public Function GetPerformanceOptions() As List(Of Performance)
        Using db = CreateContext()
            Return db.Performances _
            .AsEnumerable() _
            .Where(Function(p) Not p.IsDeleted) _
            .OrderByDescending(Function(p) p.StartTime) _
            .ToList()
        End Using
    End Function

    Public Function GetBookedSeatCount(performanceId As Integer) As Integer
        Using db = CreateContext()
            Return db.Bookings _
            .AsEnumerable() _
            .Where(Function(b) b.PerformanceId = performanceId AndAlso Not b.IsDeleted) _
            .Sum(Function(b) CInt(b.Quantity))
        End Using
    End Function

End Class
