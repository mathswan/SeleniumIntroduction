Imports System.Web.Mvc

Namespace SeleniumTest.Home

    Public Class Home
        Public Property Greeting As String = "Welcome User"

        Public Function GenerateCarsDropDownList() As List(Of SelectListItem)
            Dim cars = New List(Of SelectListItem)
            cars.Add(New SelectListItem With {.Text = "Volvo", .Value = "Volvo"})
            cars.Add(New SelectListItem With {.Text = "Audi", .Value = "Audi"})
            cars.Add(New SelectListItem With {.Text = "Saab", .Value = "Saab"})
            cars.Add(New SelectListItem With {.Text = "Mercedes", .Value = "Mercedes"})
            Return cars
        End Function

    End Class

End Namespace


