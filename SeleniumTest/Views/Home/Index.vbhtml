@ModelType UserModel
@Code
    ViewBag.Title = "Home"
    Html.BeginForm("Index", "Home", method:=FormMethod.Post)
End Code

<h2>Home</h2>

<p>@ViewBag.Greeting</p>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)
    @<fieldset>

    @Html.LabelFor(Function(model) model.Name, "Enter your name: ")
    @Html.TextBoxFor(Function(model) model.Name)<br /><br />

    @Html.LabelFor(Function(model) model.Gender, "What is your gender: ")  
    @Html.RadioButtonFor(Function(model) model.Gender, "Male", New With {.id = "Male", .checked = "checked"}) Male
    @Html.RadioButtonFor(Function(model) model.Gender, "Female", New With {.id = "Female"}) Female<br /><br />

    @Html.LabelFor(Function(model) model.TermsAndConditions, "I agree to the terms and conditions: ")
    @Html.CheckBoxFor(Function(model) model.TermsAndConditions)<br /><br />

    <input type="submit" id="Next" value="Next">
    </fieldset>
End Using
    