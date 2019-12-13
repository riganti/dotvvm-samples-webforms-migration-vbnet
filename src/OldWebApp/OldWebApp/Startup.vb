Imports System.IO
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Web.Hosting
Imports Microsoft.Owin
Imports OldWebApp.DotVVM
Imports Owin

<Assembly: OwinStartup(GetType(Startup))>
Public Class Startup

    Public Sub Configuration(app As IAppBuilder)

        'get DotVVM app location
        Dim dotvvmAppLocation = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, ConfigurationManager.AppSettings("dotvvm:AppLocation"))

        'register DotVVM in the pipeline
        app.UseDotVVM(Of DotvvmStartup)(dotvvmAppLocation)

    End Sub

End Class
