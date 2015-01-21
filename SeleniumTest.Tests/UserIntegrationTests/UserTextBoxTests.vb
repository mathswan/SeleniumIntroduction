Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS

<TestClass()> Public Class UserTextBoxTests

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

    <TestMethod()> Public Sub User_Page_Name_Textbox_Causes_MinLength_Validation_Error()

        myDriver.FindElement(By.Id("Name")).SendKeys("a")

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.PageSource.Contains("Name must have a length between two and 10 characters"))

    End Sub

    <TestMethod()> Public Sub User_Page_Name_Textbox_Causes_MaxLength_Validation_Error()

        myDriver.FindElement(By.Id("Name")).SendKeys("abcdefghijk")

        myDriver.FindElementById("Next").Click()

        Assert.IsTrue(myDriver.PageSource.Contains("Name must have a length between two and 10 characters"))

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