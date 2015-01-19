Imports System.Web.Mvc

Namespace SeleniumTest.Home

    Public Class HomeController
        Inherits Controller

        Function Index() As ActionResult
            Dim home As New Home

            ViewBag.Greeting = home.Greeting
            ViewBag.Cars = home.GenerateCarsDropDownList
            Return View()
        End Function

        <HttpPost>
        Function Details() As ActionResult

            Return View("Details")
        End Function
    End Class

End Namespace
