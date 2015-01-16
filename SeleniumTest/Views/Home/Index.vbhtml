@Code
    ViewData("Title") = "Home"
End Code

<h2>Home</h2>

<p>@ViewData("Greeting")</p>

<p>
    <label for="name" id="nameLabel">Enter your name:</label>
    <input type="text" name="name" id="name" />
</p>

<p>
    <label for="sex" id="sexLabel">Select your sex:</label>
    <input type="radio" name="sex" id="male" value="male" checked="checked">Male
    <input type="radio" name="sex" id="female" value="female">Female
</p>

<p>
    <label for="car" id="carLabel">Select your car:</label>
    <select id="car" name="car">
        <option value="volvo">Volvo</option>
        <option value="saab">Saab</option>
        <option value="mercedes">Mercedes</option>
        <option value="audi">Audi</option>
    </select>
</p>

<p>
    <label for="terms" id="termsLabel">I agree to the terms and conditions</label>
    <input type="checkbox" name="terms" id="terms" value="Terms and conditions">
</p>

<p>
    <input type="submit" id="Next" value="Next">
</p>