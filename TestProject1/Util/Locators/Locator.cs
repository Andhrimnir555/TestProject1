using OpenQA.Selenium;
using System;

namespace TestProject1.Util.Locators
{
    public abstract class Locator
    {
        public enum Type { XPath, Css, Id, Name, TagName, ClassName };

        private readonly Type locatorType;
        private readonly string locatorValue;
        public string GetLocatorValue()
        {
            return locatorValue;
        }
        public Locator(Type locatorType, string locatorValue)
        {
            this.locatorType = locatorType;
            this.locatorValue = locatorValue;
        }

        public By GetLocator(params string[] args)
        {
            if (args == null)
            {
                return locatorType switch
                {
                    Type.XPath => By.XPath(string.Format(locatorValue)),
                    Type.Css => By.CssSelector(string.Format(locatorValue)),
                    Type.Id => By.Id(string.Format(locatorValue)),
                    Type.Name => By.Name(string.Format(locatorValue)),
                    Type.TagName => By.TagName(string.Format(locatorValue)),
                    Type.ClassName => By.ClassName(string.Format(locatorValue)),
                    _ => By.XPath(string.Format(locatorValue)),
                };
            }
            else
            {
                return locatorType switch
                {
                    Type.XPath => By.XPath(string.Format(locatorValue, args)),
                    Type.Css => By.CssSelector(string.Format(locatorValue, args)),
                    Type.Id => By.Id(string.Format(locatorValue, args)),
                    Type.Name => By.Name(string.Format(locatorValue, args)),
                    Type.TagName => By.TagName(string.Format(locatorValue, args)),
                    Type.ClassName => By.ClassName(string.Format(locatorValue, args)),
                    _ => By.XPath(string.Format(locatorValue, args)),
                };
            }
        }

        public string GetLocatorPattern()
        {
            return locatorValue;
        }

        public string ToString(Object[] args)
        {
            return string.Format(locatorValue, args);
        }
    }
}
