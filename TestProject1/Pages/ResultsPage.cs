using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Base;
using TestProject1.Util.Locators;

namespace TestProject1.Pages
{
    class ResultsPage : BasePage
    {

        #region singleton
        private static ResultsPage instance;

        private ResultsPage() { }

        public static ResultsPage GetInstance()
        {
            if (instance == null)
                instance = new ResultsPage();
            return instance;
        }
        #endregion

        #region locators
        private static readonly Locator resultsBlock = new XPath("//div[@id='rso']");
        private static readonly Locator resultsBlockWithoutAds = new XPath(resultsBlock.GetLocatorValue() + "/div[2]");
        private static readonly Locator resultRowByNum = new XPath(resultsBlockWithoutAds.GetLocatorValue() + "/div[{0}]");
        private static readonly Locator resultRow = new XPath(resultsBlockWithoutAds.GetLocatorValue() + "/div");   //can be used to get elements, not text List or something like

        #endregion

        #region methods
        public string GetResultsByRowNumber(int rowNumber)
        {
            WaitForElementVisibility(resultsBlockWithoutAds);
            return GetElementText($"Trying to get text from row number {rowNumber}", resultRowByNum, rowNumber.ToString());
        }
        public List<string> GetResultsByRowNumberFromList()
        {
            WaitForElementVisibility(resultsBlockWithoutAds);
            List<string> res = new List<string> { };
            int counter = 1;
            while (IsElementPresent($"is row number {counter} present?", resultRowByNum, counter.ToString()))
            {
                res.Add(GetElementText("Trying to get text from row...", resultRowByNum, counter.ToString()));
                counter++;
            }
            return res;
        }
        #endregion
    }
}
