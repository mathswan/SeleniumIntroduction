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
            'MsgBox("Name: " + user.Name + " Gender: " + user.Gender.ToString + " Terms: " + user.TermsAndConditions.ToString)

            'If ModelState.IsValid Then
            'Return View("Index")
            'Else
            'Return View("Index")
            'End If

            Return View("Index")
        End Function
    End Class

End Namespace
