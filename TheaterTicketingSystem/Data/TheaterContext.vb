Imports Microsoft.EntityFrameworkCore

Public Class TheaterContext
    Inherits DbContext

    Public Sub New()
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", True)
        AppContext.SetSwitch("Npgsql.EnableLegacyParameterBehavior", True)
    End Sub

    Public Property Performances As DbSet(Of Performance)
    Public Property Bookings As DbSet(Of Booking)
    Public Property SeatAssignments As DbSet(Of SeatAssignment)

    Protected Overrides Sub OnConfiguring(ByVal optionsBuilder As DbContextOptionsBuilder)
        If Not optionsBuilder.IsConfigured Then
            Dim connectionString As String = "Host=localhost;Database=TheaterDB;Username=postgres;Password=123456"
            optionsBuilder.UseNpgsql(connectionString)
        End If
    End Sub

End Class
