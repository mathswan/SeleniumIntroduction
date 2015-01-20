Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class UserIntegrationSpec

#Region "Page Tests"
    <TestMethod()> Public Sub User_Page_Title_Is_Correct()

        Assert.AreEqual(myDriver.Title, "Add User")

    End Sub

    <TestMethod()> Public Sub User_Page_Contains_Welcome_User_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("Welcome"))

    End Sub
#End Region

#Region "Label Tests"

    <TestMethod()> Public Sub User_Page_Contains_Name_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("Enter your name"))

    End Sub

    <TestMethod()> Public Sub User_Page_Contains_Gender_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("What is your gender"))

    End Sub

    <TestMethod()> Public Sub User_Page_Contains_Terms_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("I agree to the terms and conditions"))

    End Sub

#End Region

#Region "Textbox Tests"

    <TestMethod()> Public Sub User_Page_Contains_Name_Textbox()

        Assert.IsTrue(myDriver.FindElements(By.Id("Name")).Count = 1)

    End Sub

    <TestMethod()> Public Sub User_Page_Name_Textbox_Contains_Text_When_Entered()

        Dim nameList As List(Of String) = TextboxTestList()

        For count = 0 To (nameList.Count - 1)
            ClearNameTextbox()
            myDriver.FindElement(By.Id("Name")).SendKeys(nameList.Item(count))

            Dim result As String = myDriver.FindElement(By.Id("Name")).GetAttribute("value")

            Assert.AreEqual(nameList.Item(count), result)
        Next count

    End Sub

    <TestMethod()> Public Sub User_Page_Name_Textbox_Causes_Validation_Error_When_Blank()

        myDriver.FindElement(By.Id("Name")).SendKeys("")

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.PageSource.Contains("Name is required"))

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

    <TestMethod()> Public Sub User_Page_Contains_Male_Radio()

        Dim result = myDriver.FindElements(By.Id("Male")).Count = 1

        Assert.IsTrue(result)

    End Sub

    <TestMethod()> Public Sub User_Page_Contains_Two_Radio_Options()

        Assert.IsTrue(myDriver.FindElements(By.Id("Female")).Count = 1)

    End Sub

    <TestMethod()> Public Sub User_Page_Male_Radio_Checked_Default()

        Assert.IsTrue(myDriver.FindElement(By.Id("Male")).Selected)

    End Sub

    <TestMethod()> Public Sub User_Page_Female_Radio_Unchecked_Default()

        Assert.IsFalse(myDriver.FindElement(By.Id("Female")).Selected)

    End Sub

    <TestMethod()> Public Sub User_Page_Male_Radio_Unchecked_When_Female_Checked()

        myDriver.FindElementById("Female").Click()

        Assert.IsFalse(myDriver.FindElement(By.Id("Male")).Selected)
        Assert.IsTrue(myDriver.FindElement(By.Id("Female")).Selected)

    End Sub
#End Region

#Region "Checkbox Tests"

    <TestMethod()> Public Sub User_Page_Contains_Terms_Checkbox()

        Assert.IsTrue(myDriver.FindElements(By.Id("TermsAndConditions")).Count = 1)

    End Sub

    <TestMethod()> Public Sub User_Page_Terms_Unchecked_Default()

        Assert.IsFalse(myDriver.FindElement(By.Id("TermsAndConditions")).Selected)

    End Sub

    <TestMethod()> Public Sub User_Page_Terms_Checked_On_Click()
        myDriver.FindElementById("TermsAndConditions").Click()

        Assert.IsTrue(myDriver.FindElement(By.Id("TermsAndConditions")).Selected)

    End Sub

    <TestMethod()> Public Sub User_Page_Terms_Checked_Success()
        myDriver.FindElement(By.Id("Name")).SendKeys("Test Name")
        myDriver.FindElementById("TermsAndConditions").Click()

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.PageSource.Contains("Valid submission"))

    End Sub

    <TestMethod()> Public Sub User_Page_Terms_Unchecked_Invalid()
        myDriver.FindElement(By.Id("Name")).SendKeys("Test Name")

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.PageSource.Contains("Please accept the terms and conditions"))

    End Sub

#End Region

#Region "Button Tests"
    <TestMethod()> Public Sub User_Page_Contains_Next_Button()

        Assert.IsTrue(myDriver.FindElements(By.Id("Next")).Count = 1)

    End Sub

    <TestMethod()> Public Sub User_Page_Produces_Errors_On_Blank_Form()

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.Title = "Add User")
        Assert.IsTrue(myDriver.PageSource.Contains("Name is required"))
        Assert.IsTrue(myDriver.PageSource.Contains("Please accept the terms and conditions"))

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