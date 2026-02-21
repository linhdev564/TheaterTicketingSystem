Imports Microsoft.EntityFrameworkCore

Public Class PerformanceService
    Inherits BaseService(Of Performance)

    Private Shared ReadOnly _instance As New Lazy(Of PerformanceService)(
        Function() New PerformanceService()
        )

    Public Shared ReadOnly Property GetInstance As PerformanceService
        Get
            Return _instance.Value
        End Get
    End Property

    Public Function Search(keyword As String, fromDate As DateTime?,
                           Optional pageSize As Integer = 10, Optional pageIndex As Integer = 1) _
                            As (Items As List(Of Performance), Total As Integer)
        Using db = CreateContext()
            Dim query = db.Performances.AsEnumerable().Where(Function(p) Not p.IsDeleted)

            If Not String.IsNullOrEmpty(keyword) Then
                keyword = keyword.Trim()
                query = query.Where(Function(p) EF.Functions.ILike(p.Name, $"%{keyword}%"))
            End If

            If fromDate.HasValue Then
                query = query.Where(Function(p) p.StartTime >= fromDate.GetValueOrDefault())
            End If

            Dim total = query.Count()
            Dim items As List(Of Performance)

            If pageIndex < 1 Or pageIndex < 1 Then
                items = query.OrderByDescending(Function(p) p.CreatedAt) _
            .ToList()
            Else
                items = query.OrderByDescending(Function(p) p.CreatedAt) _
                    .Skip((pageIndex - 1) * pageSize) _
                    .Take(pageSize) _
                    .ToList()
            End If

            Return (items, total)
        End Using
    End Function

End Class
