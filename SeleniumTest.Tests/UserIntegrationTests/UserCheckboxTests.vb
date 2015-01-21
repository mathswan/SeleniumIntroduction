Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class UserCheckboxTests

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