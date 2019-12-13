Imports System.Runtime.InteropServices

Public Class _Default
    Inherits Page

    Private dc As AppDbContext

    Public Sub New()
        dc = New AppDbContext()
    End Sub

    Public Function MyGrid_GetData(sortByExpression As String, maximumRows As Integer, startRowIndex As Integer, <Out()> ByRef totalRowCount As Integer) As IQueryable
        totalRowCount = dc.Customers.Count()

        If String.IsNullOrEmpty(sortByExpression) Then
            sortByExpression = NameOf(Customer.Id)
        End If

        Return dc.Customers.
            SortBy(sortByExpression).
            Skip(startRowIndex).
            Take(maximumRows)
    End Function

End Class