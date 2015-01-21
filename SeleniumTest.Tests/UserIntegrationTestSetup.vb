Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports OpenQA.Selenium.PhantomJS
Public Class UserIntegrationTestSetup

    Public Function Initialise(ByVal myDriver As IWebDriver) As IWebDriver
        myDriver.Navigate.GoToUrl("http://localhost:1231")
        Return myDriver
    End Function

    Public Function Finalise(ByVal myDriver As IWebDriver) As IWebDriver
        myDriver.Close()
        Return myDriver
    End Function

    Shared Property PhantomJSAddress As String = "C:\Users\snaithm\Documents\Projects\SeleniumTest\SeleniumTest.Tests\Drivers"

    Shared Property ChromeDriverAddress As String = "C:\Users\snaithm\Downloads\chromedriver_win32"

End Class
