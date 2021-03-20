using NUnit.Framework;
using TestProject1.Actions;
using TestProject1.Base;
using TestProject1.Util;

namespace TestProject1.Tests
{
    class GoogleSearchTests : BaseTest
    {
        [SetUp]
        public void SecondSetUp()
        {
            Driver.Navigate().GoToUrl(Constants.BASE_URL);
        }
        [Test]
        public void SearchTestButton()
        {
            SearchPageActions.GetInstance().SearchGoogle(Constants.SEARCH_REQUEST);
            Assert.IsTrue(ResultsPageActions.GetInstance().GetSearchResult(4).Contains(Constants.SEARCH_RESULT));
        }
        [Test]
        public void SearchTestEnter()
        {
            SearchPageActionsEnter.GetInstance().SearchGoogle(Constants.SEARCH_REQUEST);
            Assert.IsTrue(ResultsPageActionsList.GetInstance().GetSearchResult(4).Contains(Constants.SEARCH_RESULT));
        }
    }
}
