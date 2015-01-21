Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class UserRadioButtonTests

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