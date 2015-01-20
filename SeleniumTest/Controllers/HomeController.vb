Imports System.Web.Mvc

Namespace SeleniumTest.Home

    Public Class HomeController
        Inherits Controller

        ' GET: /Home/Index
        Function Index() As ActionResult
            Dim home As New Home
            ViewBag.Greeting = home.Greeting
            Return View()

        End Function

        ' POST: /Home/Index
        <HttpPost>
        Function Index(user As UserModel) As ActionResult
            Dim home As New Home

            If ModelState.IsValid Then
                ViewBag.Greeting = "Valid submission Name: " + user.Name + " Gender: " + user.Gender.ToString + " Terms: " + user.TermsAndConditions.ToString
                Return View("Index")
            Else
                ViewBag.Greeting = "Please correct errors"
                Return View("Index")
            End If

        End Function
    End Class

End Namespace
