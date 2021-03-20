using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Util;
using TestProject1.Util.Locators;

namespace TestProject1.Base
{
    class BasePage
    {
        public static TimeSpan JsDefaultTimeout = TimeSpan.FromSeconds(15);

        #region getMethods
        protected IWebElement GetElement(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            By by = locator.GetLocator(args);
            return BaseTest.Driver.FindElement(by);
        }

        protected IList<IWebElement> GetElements(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            By by = locator.GetLocator(args);
            return BaseTest.Driver.FindElements(by);
        }

        protected string GetElementAttributeValue(string attributeName, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            IWebElement element = GetElement(locator, args);
            return element.GetAttribute(attributeName);
        }

        protected string GetElementText(string message, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            BaseTest.Test.Log(Status.Info, message);
            IWebElement element = GetElement(locator, args);
            BaseTest.Test.Log(Status.Info, message + " || Result: " + element.Text);
            return element.Text;
        }

        protected string GetElementTextWithJS(string message, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            BaseTest.Test.Log(Status.Info, message);
            IWebElement element = GetElement(locator, args);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)BaseTest.Driver;
            return (string)ex.ExecuteScript("return arguments[0].innerText;", element);
        }

        public string GetUrl()
        {
            WaitForPageLoading();
            return BaseTest.Driver.Url;
        }
        #endregion

        #region typeMethods
        protected void Enter(string message, string value, Locator locator, params string[] args)
        {
            BaseTest.Test.Log(Status.Info, message);
            IWebElement inputElement = GetElement(locator, args);
            if (!String.IsNullOrEmpty(inputElement.GetAttribute("value")))
            {
                inputElement.Clear();
            }

            inputElement.SendKeys(value);
        }

        protected void TypeWithoutClearing(string message, string value, Locator locator, params string[] args)
        {
            BaseTest.Test.Log(Status.Info, message);
            IWebElement inputElement = GetElement(locator, args);
            inputElement.SendKeys(value);
        }

        protected void PressEnter(string message, Locator locator, params string[] args)
        {
            BaseTest.Test.Log(Status.Info, message);
            IWebElement inputElement = GetElement(locator, args);
            inputElement.SendKeys(Keys.Enter);
        }

        protected void Clear(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            IWebElement inputElement = GetElement(locator, args);
            inputElement.Clear();
        }

        protected void ClearManually(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            IWebElement inputElement = GetElement(locator, args);
            inputElement.Click();
            inputElement.SendKeys(Keys.Control + 'a');
            inputElement.SendKeys(Keys.Backspace);
        }
        #endregion

        #region isMethods
        protected bool IsElementPresent(string message, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            bool result = GetElementsCount(locator, args) > 0;
            BaseTest.Test.Log(Status.Info, message + " || Result:" + result.ToString().ToUpper());
            return result;
        }

        protected bool IsElementVisible(string message, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            bool result = IsElementVisibleWithWait(0, locator, args);
            BaseTest.Test.Log(Status.Info, message + " || Result:" + result.ToString().ToUpper());
            return result;
        }
        protected bool IsElementVisibleWithWait(int waitInSeconds, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            By by = locator.GetLocator(args);
            WebDriverWait wait = new WebDriverWait(BaseTest.Driver, TimeSpan.FromSeconds(waitInSeconds));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region waitMethods
        protected void WaitForElementPresent(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            By by = locator.GetLocator(args);
            WebDriverWait wait =
                new WebDriverWait(BaseTest.Driver, TimeSpan.FromSeconds(Constants.ELEMENT_TIMEOUT_SECONDS));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        protected void WaitForElementVisibility(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            By by = locator.GetLocator(args);
            WebDriverWait wait =
                new WebDriverWait(BaseTest.Driver, TimeSpan.FromSeconds(Constants.ELEMENT_TIMEOUT_SECONDS));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitForPageLoading()
        {
            new WebDriverWait(BaseTest.Driver, TimeSpan.FromSeconds(Constants.ELEMENT_TIMEOUT_SECONDS))
                .Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void WaitForElementClickable(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            By by = locator.GetLocator(args);
            WebDriverWait wait =
                new WebDriverWait(BaseTest.Driver, TimeSpan.FromSeconds(Constants.ELEMENT_TIMEOUT_SECONDS));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        protected int GetElementsCount(Locator locator, params string[] args)
        {
            WaitForPageLoading();
            return GetElementsCountWithImplicitWait(0, locator, args);
        }

        protected int GetElementsCountWithImplicitWait(int waitInSeconds, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            BaseTest.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitInSeconds);
            int size = GetElements(locator, args).Count;
            BaseTest.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.ELEMENT_TIMEOUT_SECONDS);
            return size;
        }
        #endregion

        #region clickMethods
        protected void Click(string message, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            BaseTest.Test.Log(Status.Info, message);
            IWebElement element = GetElement(locator, args);
            element.Click();
        }

        protected void ClickOnChechBox(IWebElement element, params string[] args)
        {
            WaitForPageLoading();
            element.Submit();
        }

        protected void DoubleClick(string message, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            BaseTest.Test.Log(Status.Info, message);
            IWebElement element = GetElement(locator, args);
            element.Click();
            element.Click();
        }

        protected void ClickWithJavascript(string message, Locator locator, params string[] args)
        {
            WaitForPageLoading();
            BaseTest.Test.Log(Status.Info, message);
            IWebElement element = GetElement(locator, args);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)BaseTest.Driver;
            ex.ExecuteScript("arguments[0].click();", element);
        }
        #endregion

    }
}
