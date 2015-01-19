Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class HomeIntegrationSpec

#Region "Page Tests"
    <TestMethod()> Public Sub Home_Page_Title_Is_Correct()

        Assert.AreEqual(myDriver.Title, "Home")

    End Sub

    <TestMethod()> Public Sub Home_Page_Contains_Welcome_User_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("Welcome User"))

    End Sub
#End Region

#Region "Label Tests"

    <TestMethod()> Public Sub Home_Page_Contains_Name_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("Enter your name"))

    End Sub

    <TestMethod()> Public Sub Home_Page_Contains_Gender_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("What is your gender"))

    End Sub

    <TestMethod()> Public Sub Home_Page_Contains_Car_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("Select a car"))

    End Sub

    <TestMethod()> Public Sub Home_Page_Contains_Terms_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("I agree to the terms and conditions"))

    End Sub

#End Region

#Region "Textbox Tests"

    <TestMethod()> Public Sub Home_Page_Contains_Name_Textbox()

        Assert.IsTrue(myDriver.FindElements(By.Id("Name")).Count = 1)

    End Sub

    <TestMethod()> Public Sub Home_Page_Name_Textbox_Contains_Text_When_Entered()

        Dim nameList As List(Of String) = TextboxTestList()

        For count = 0 To (nameList.Count - 1)
            ClearNameTextbox()
            myDriver.FindElement(By.Id("Name")).SendKeys(nameList.Item(count))

            Dim result As String = myDriver.FindElement(By.Id("Name")).GetAttribute("value")

            Assert.AreEqual(nameList.Item(count), result)
        Next count

    End Sub

    Public Sub ClearNameTextbox()
        myDriver.FindElement(By.Id("Name")).Clear()
    End Sub

    Public Function TextboxTestList() As List(Of String)
        Dim nameList As New List(Of String)
        nameList.Add("John Smith")
        nameList.Add("Thomas Williams")
        nameList.Add("Jane Jones")

        Return nameList
    End Function

#End Region

#Region "Radio Button Tests"

    <TestMethod()> Public Sub Home_Page_Contains_Male_Radio()

        Dim result = myDriver.FindElements(By.Id("male")).Count = 1

        Assert.IsTrue(result)

    End Sub

    <TestMethod()> Public Sub Home_Page_Contains_Female_Radio()

        Assert.IsTrue(myDriver.FindElements(By.Id("male")).Count = 1)

    End Sub

    <TestMethod()> Public Sub Home_Page_Male_Radio_Checked_Default()

        Assert.IsTrue(myDriver.FindElement(By.Id("male")).Selected)

    End Sub

    <TestMethod()> Public Sub Home_Page_Female_Radio_Unchecked_Default()

        Assert.IsFalse(myDriver.FindElement(By.Id("female")).Selected)

    End Sub

    <TestMethod()> Public Sub Home_Page_Male_Radio_Unchecked_When_Female_Checked()

        myDriver.FindElementById("female").Click()

        Assert.IsFalse(myDriver.FindElement(By.Id("male")).Selected)
        Assert.IsTrue(myDriver.FindElement(By.Id("female")).Selected)

    End Sub
#End Region

#Region "Drop Down Tests"

    <TestMethod()> Public Sub Home_Page_Contains_Car_Dropdown()

        Assert.IsTrue(myDriver.FindElements(By.Id("Car")).Count = 1)

    End Sub

    <TestMethod()> Public Sub Home_Page_Default_Dropdown_Option()

        Dim result As String = myDriver.FindElement(By.Id("Car")).GetAttribute("value")

        Assert.AreEqual(result, "volvo")

    End Sub

    <TestMethod()> Public Sub Home_Page_Select_Alternative_Option()

        myDriver.FindElement(By.Id("Car")).SendKeys("Audi")
        Dim result As String = myDriver.FindElement(By.Id("Car")).GetAttribute("value")

        Assert.AreEqual(result, "audi")

    End Sub

#End Region

#Region "Checkbox Tests"

    <TestMethod()> Public Sub Home_Page_Contains_Terms_Checkbox()

        Assert.IsTrue(myDriver.FindElements(By.Id("TermsAndConditions")).Count = 1)

    End Sub

    <TestMethod()> Public Sub Home_Page_Terms_Unchecked_Default()

        Assert.IsFalse(myDriver.FindElement(By.Id("TermsAndConditions")).Selected)

    End Sub

    <TestMethod()> Public Sub Home_Page_Terms_Checked_On_Click()
        myDriver.FindElementById("TermsAndConditions").Click()

        Assert.IsTrue(myDriver.FindElement(By.Id("TermsAndConditions")).Selected)

    End Sub

#End Region

#Region "Button Tests"
    <TestMethod()> Public Sub Home_Page_Contains_Next_Button()

        Assert.IsTrue(myDriver.FindElements(By.Id("Next")).Count = 1)

    End Sub

    <TestMethod()> Public Sub Home_Page_Next_Button_Redirects()

        myDriver.FindElementById("Next").Click()

        Assert.IsFalse(myDriver.Title = "Home")

    End Sub

#End Region

#Region "Test Methods"
    <TestInitialize()>
    Public Sub InitialiseDriver()
        myDriver.Navigate.GoToUrl("http://localhost:1231")
    End Sub

    <TestCleanup()>
    Public Sub Cleanup()
        myDriver.Close()
    End Sub

    'Dim myDriver As New ChromeDriver("C:\Users\snaithm\Downloads\chromedriver_win32")
    Dim myDriver As New PhantomJSDriver("C:\Users\snaithm\Downloads\phantomjs-1.9.8-windows\phantomjs-1.9.8-windows")
#End Region

End Class