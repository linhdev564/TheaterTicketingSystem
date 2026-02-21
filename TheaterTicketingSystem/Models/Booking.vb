Imports System.ComponentModel.DataAnnotations

Public Class Booking
    Inherits BaseEntity

    <Required>
    Public Property PerformanceId As Integer

    Public Overridable Property Performance As Performance

    <Required>
    Public Property CustomerName As String

    <Required>
    <MaxLength(20)>
    Public Property PhoneNumber As String

    Public Property SeatType As SeatType

    Public Property Quantity As Integer

    Public Property UnitPrice As Decimal

    Public Property TotalPrice As Decimal

    Public ReadOnly Property DisplayText As String
        Get
            Return $"{CustomerName} - {PhoneNumber}"
        End Get
    End Property

    Public Overridable Property SeatAssignments As ICollection(Of SeatAssignment)
End Class
