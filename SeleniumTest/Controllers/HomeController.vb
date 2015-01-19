Imports System.Web.Mvc

Namespace SeleniumTest.Home

    Public Class HomeController
        Inherits Controller

        Function Index() As ActionResult
            Dim home As New Home

            Dim cars = New List(Of SelectListItem)
            cars.Add(New SelectListItem With {.Text = "Volvo", .Value = "Volvo"})
            cars.Add(New SelectListItem With {.Text = "Audi", .Value = "Audi"})
            cars.Add(New SelectListItem With {.Text = "Saab", .Value = "Saab"})
            cars.Add(New SelectListItem With {.Text = "Mercedes", .Value = "Mercedes"})

            ViewBag.Greeting = home.Greeting
            ViewBag.Cars = cars
            Return View()
        End Function

        <HttpPost>
        Function Details() As ActionResult

            Return View("Details")
        End Function
    End Class

End Namespace
