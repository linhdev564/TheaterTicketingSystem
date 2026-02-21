Imports Microsoft.EntityFrameworkCore

Public Class BaseService(Of T As BaseEntity)
    Protected Function CreateContext() As TheaterContext
        Return New TheaterContext()
    End Function

    Public Overridable Function GetById(id As Integer) As T
        Using db = CreateContext()
            Return db.Set(Of T)().Find(id)
        End Using
    End Function

    Public Overridable Sub Add(entity As T)
        Using db = CreateContext()
            entity.CreatedAt = DateTime.Now
            entity.IsDeleted = False
            db.Set(Of T)().Add(entity)
            db.SaveChanges()
        End Using
    End Sub

    Public Overridable Sub Update(entity As T)
        Using db = CreateContext()
            entity.UpdatedAt = DateTime.Now
            db.Entry(entity).State = EntityState.Modified
            db.SaveChanges()
        End Using
    End Sub

    Public Overridable Sub DeleteById(id As Integer)
        Using db = CreateContext()
            Dim entity = db.Set(Of T)().Find(id)
            If entity IsNot Nothing Then
                entity.IsDeleted = True
                db.SaveChanges()
            End If
        End Using
    End Sub

End Class