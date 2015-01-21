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
        myDriver.Navigate.GoToUrl("http://localhost:1231")
    End Sub

    <TestCleanup()>
    Public Sub Cleanup()
        myDriver.Close()
    End Sub

    'Dim myDriver As New ChromeDriver("C:\Users\snaithm\Downloads\chromedriver_win32")
    Dim myDriver As New PhantomJSDriver("C:\Users\snaithm\Downloads\phantomjs-1.9.8-windows\phantomjs-1.9.8-windows")

End Class