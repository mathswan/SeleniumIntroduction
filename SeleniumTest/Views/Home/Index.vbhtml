﻿@ModelType UserModel
@Code
    ViewBag.Title = "Home"
    Html.BeginForm("Details", "Home", method:=FormMethod.Post)
End Code

<h2>Home</h2>

<p>@ViewBag.Greeting</p>

<p>
    @Html.LabelFor(Function(model) model.Name, "Enter your name: ")
    @Html.TextBoxFor(Function(model) model.Name)
</p>

<p>
    @Html.LabelFor(Function(model) model.Gender, "What is your gender: ")  
    @Html.RadioButtonFor(Function(model) model.Gender, "Male", New With {.id = "Male", .checked = "checked"}) Male
    @Html.RadioButtonFor(Function(model) model.Gender, "Female", New With {.id = "Female"}) Female
</p>

<p>
    @Html.LabelFor(Function(model) model.Car, "Select a car: ")
    <select id="Car" name="Car">
        <option value="volvo">Volvo</option>
        <option value="saab">Saab</option>
        <option value="mercedes">Mercedes</option>
        <option value="audi">Audi</option>
    </select>
</p>

<p>
    @Html.LabelFor(Function(model) model.TermsAndConditions, "I agree to the terms and conditions: ")
    @Html.CheckBoxFor(Function(model) model.TermsAndConditions)

</p>

<p>
    <input type="submit" id="Next" value="Next">
</p>