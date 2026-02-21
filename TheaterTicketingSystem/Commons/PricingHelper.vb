Public Class PricingHelper

    Private Shared ReadOnly _prices As New Dictionary(Of SeatType, Decimal) From {
        {SeatType.Standard, 100000D},
        {SeatType.Vip, 150000D},
        {SeatType.Couple, 200000D}
    }

    Private Shared ReadOnly _names As New Dictionary(Of SeatType, String) From {
        {SeatType.Standard, "Standard"},
        {SeatType.Vip, "Vip"},
        {SeatType.Couple, "Couple"}
    }

    Public Shared Function GetUnitPrice(seatType As SeatType) As Decimal
        Dim price As Decimal = 0
        _prices.TryGetValue(seatType, price)
        Return price
    End Function

    Public Shared Function GetUnitName(seatType As SeatType) As String
        Dim name As String = ""
        _names.TryGetValue(seatType, name)
        Return name
    End Function
End Class