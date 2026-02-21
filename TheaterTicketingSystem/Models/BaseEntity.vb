Imports System.ComponentModel.DataAnnotations

Public Class BaseEntity
    <Key>
    Public Property Id As Integer

    <Required>
    Public Property CreatedAt As DateTime

    Public Property UpdatedAt As DateTime?

    <Required>
    Public Property IsDeleted As Boolean
End Class
