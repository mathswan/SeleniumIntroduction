Imports System.Web.Mvc

Namespace SeleniumTest.Home

    Public Class HomeController
        Inherits Controller

        ' GET: /Home
        Function Index() As ActionResult
            Dim home As New Home
            ViewBag.Greeting = home.Greeting

            Return View()
        End Function

        <HttpPost>
        Function Details() As ActionResult

            Return View("Details")
        End Function
    End Class

End Namespace
