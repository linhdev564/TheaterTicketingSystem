Imports System.ComponentModel.DataAnnotations

Public Class Performance
    Inherits BaseEntity

    <Required>
    Public Property Name As String
    Public Property StartTime As DateTime
    Public Property Duration As Integer

End Class
