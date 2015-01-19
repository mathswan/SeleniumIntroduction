﻿@ModelType UserModel
@Code
    ViewBag.Title = "Home"
    Html.BeginForm("Details", "Home", method:=FormMethod.Post)
End Code

<h2>Home</h2>

<p>@ViewBag.Greeting</p>

    
@Html.LabelFor(Function(model) model.Name, "Enter your name: ")
@Html.TextBoxFor(Function(model) model.Name) <br /><br />

@Html.LabelFor(Function(model) model.Gender, "What is your gender: ")  
@Html.RadioButtonFor(Function(model) model.Gender, "Male", New With {.id = "Male", .checked = "checked"}) Male
@Html.RadioButtonFor(Function(model) model.Gender, "Female", New With {.id = "Female"}) Female <br /><br />
   
@Html.LabelFor(Function(model) model.Car, "Select a car: ")
@Html.DropDownListFor(Function(model) model.Car, CType(ViewBag.cars, List(Of SelectListItem)), "Select One") <br /><br />

@Html.LabelFor(Function(model) model.TermsAndConditions, "I agree to the terms and conditions: ")
@Html.CheckBoxFor(Function(model) model.TermsAndConditions) <br /><br />

<input type="submit" id="Next" value="Next">