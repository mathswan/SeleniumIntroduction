Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class UserButtonTests

    <TestMethod()> Public Sub User_Page_Contains_Next_Button()

        Assert.IsTrue(myDriver.FindElements(By.Id("Next")).Count = 1)

    End Sub

    <TestMethod()> Public Sub User_Page_Produces_Errors_On_Blank_Form()

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.Title = "Add User")
        Assert.IsTrue(myDriver.PageSource.Contains("Name is required"))
        Assert.IsTrue(myDriver.PageSource.Contains("Please accept the terms and conditions"))

    End Sub

    <TestMethod()> Public Sub User_Page_Accepts_A_Full_Form()

        myDriver.FindElement(By.Id("Name")).SendKeys("Test Name")
        myDriver.FindElementById("TermsAndConditions").Click()
        myDriver.FindElementById("Female").Click()

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.Title = "Add User")
        Assert.IsTrue(myDriver.PageSource.Contains("Valid submission name: Test Name gender: Female terms: True"))

    End Sub

    <TestInitialize()>
    Public Sub InitialiseDriver()
        setupDriver.Initialise(myDriver)
    End Sub

    <TestCleanup()>
    Public Sub Cleanup()
        setupDriver.Finalise(myDriver)
    End Sub


    'Dim myDriver As New ChromeDriver(UserIntegrationTestSetup.ChromeDriverAddress)
    Dim myDriver As New PhantomJSDriver(UserIntegrationTestSetup.PhantomJSAddress)
    Dim setupDriver As New UserIntegrationTestSetup

End Class