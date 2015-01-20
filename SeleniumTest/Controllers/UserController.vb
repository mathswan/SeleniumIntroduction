Imports System.Web.Mvc

Namespace SeleniumTest.Home

    Public Class UserController
        Inherits Controller

        ' GET: /Home/Index
        Function Index() As ActionResult
            Dim home As New UserViewModel
            ViewBag.Information = home.Information
            Return View()

        End Function

        ' POST: /Home/Index
        <HttpPost>
        Function Index(user As UserFormModel) As ActionResult

            If ModelState.IsValid Then
                ViewBag.Information = "Valid submission name: " + user.Name + " gender: " + user.Gender.ToString + " terms: " + user.TermsAndConditions.ToString
                ModelState.Clear()
                Return View("Index")
            Else
                ViewBag.Information = "Please correct errors"
                Return View("Index")
            End If

        End Function

    End Class

End Namespace