Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class UserPageTests

    <TestMethod()> Public Sub User_Page_Title_Is_Correct()

        Assert.AreEqual(myDriver.Title, "Add User")

    End Sub

    <TestMethod()> Public Sub User_Page_Contains_Welcome_User_Text()

        Assert.IsTrue(myDriver.PageSource.Contains("Welcome"))

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