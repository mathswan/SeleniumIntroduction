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
        myDriver.Navigate.GoToUrl("http://localhost:1231")
    End Sub

    <TestCleanup()>
    Public Sub Cleanup()
        myDriver.Close()
    End Sub

    'Dim myDriver As New ChromeDriver("C:\Users\snaithm\Downloads\chromedriver_win32")
    Dim myDriver As New PhantomJSDriver("C:\Users\snaithm\Downloads\phantomjs-1.9.8-windows\phantomjs-1.9.8-windows")

End Class