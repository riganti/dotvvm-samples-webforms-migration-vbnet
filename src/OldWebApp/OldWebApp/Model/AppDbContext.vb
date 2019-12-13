Imports System.Data.Entity

Public Class AppDbContext
    Inherits DbContext

    Public Property Customers As DbSet(Of Customer)

    Sub New()
        MyBase.New("DB")
    End Sub

End Class