Imports System.ComponentModel.DataAnnotations

Public Class SeatAssignment
    Inherits BaseEntity

    <Required>
    Public Property PerformanceId As Integer
    Public Overridable Property Performance As Performance

    <Required>
    Public Property BookingId As Integer
    Public Overridable Property Booking As Booking

    Public Property Row As String

    Public Property Number As Integer

End Class
