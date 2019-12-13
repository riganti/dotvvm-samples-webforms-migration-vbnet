Imports System.Data.Entity

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        Database.SetInitializer (new AppDbInitializer())
    End Sub
End Class