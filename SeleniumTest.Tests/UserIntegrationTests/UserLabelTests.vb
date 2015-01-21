Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class UserLabelTests

    <TestMethod()> Public Sub User_Page_Contains_Name_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("Enter your name"))

    End Sub

    <TestMethod()> Public Sub User_Page_Contains_Gender_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("What is your gender"))

    End Sub

    <TestMethod()> Public Sub User_Page_Contains_Terms_Label_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("I agree to the terms and conditions"))

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