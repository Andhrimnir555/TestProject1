using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using TestProject1.Util;

namespace TestProject1.Base
{
    class BaseTest
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        [ThreadStatic] private static IWebDriver driver;

        public static ExtentReports Extent { get { return extent; } set { extent = value; } }
        public static ExtentTest Test { get { return test; } }
        public static IWebDriver Driver { get { return driver; } }

        public static void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }
        [OneTimeSetUp]
        public void SetUp()
        {
            Reporter.Initialize();
        }
        [SetUp]
        public void BeforeMethod()
        {
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            // add other browsers if needed
            string browser = TestContext.Parameters.Get("browser", "chrome");
            switch (browser)
            {
                default:
                case "chrome":
                    {
                        StartChrome();
                        break;
                    }
            }
        }
        [TearDown]
        public void TearDown()
        {
            SetTestStatus();
            driver.Quit();
        }
        [OneTimeTearDown]
        protected void OneTearDown()
        {
            extent.Flush();
        }
        public void SetTestStatus()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                test.Log(Status.Fail, "URL = " + Driver.Url.ToString());
                test.Log(Status.Error, TestContext.CurrentContext.Result.Message);
                test.Log(Status.Error, TestContext.CurrentContext.Result.StackTrace);
            }
            else if (TestContext.CurrentContext.Result.SkipCount > 0)
            {
                test.Log(Status.Skip, "Test was skipped");
                test.Log(Status.Skip, TestContext.CurrentContext.Result.Message);
            }
            else
            {
                test.Log(Status.Pass, "Test passed!");
            }
            extent.Flush();
        }
        public void StartChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArgument("--window-size=1920,1080");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.ELEMENT_TIMEOUT_SECONDS);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Window.Maximize();

        }
        protected void LogInfoMessage(string message)
        {
            test.Log(Status.Info, message);
        }
    }
}
