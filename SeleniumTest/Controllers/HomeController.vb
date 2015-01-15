Imports System.Web.Mvc

Namespace SeleniumTest.Home

    Public Class HomeController
        Inherits Controller

        ' GET: /Home
        Function Index() As ActionResult
            Dim home As New Home

            ViewData("Greeting") = home.Greeting

            Return View()
        End Function
    End Class

End Namespace
