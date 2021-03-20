using TestProject1.Base;
using TestProject1.Util.Locators;

namespace TestProject1.Pages
{
    class MainPage : BasePage
    {

        #region singleton
        private static MainPage instance;

        private MainPage() { }

        public static MainPage GetInstance()
        {
            if (instance == null)
                instance = new MainPage();
            return instance;
        }
        #endregion

        #region locators
        private static readonly Locator searchInput = new XPath("//input[@name='q']");
        private static readonly Locator mainSearchButton = new XPath("(//input[@name='btnK'])[2]");
        private static readonly Locator searchButtonInField = new XPath("(//input[@name='btnK'])[1]");
        #endregion

        #region methods
        public void SearchInput(string searchRequest)
        {
            WaitForElementVisibility(searchInput);
            Enter($"Type {searchRequest} to search input field", searchRequest, searchInput);
        }

        public void PressEnterAtSearchInput()
        {
            WaitForElementVisibility(searchInput);
            PressEnter("Press ENTER", searchInput);
        }

        public void ClickMainSearchBtn()
        {
            WaitForElementVisibility(mainSearchButton);
            WaitForElementClickable(mainSearchButton);
            Click("Click search btn", mainSearchButton);
        }

        public void ClickFieldSearchBtn()
        {
            WaitForElementVisibility(searchButtonInField);
            WaitForElementClickable(searchButtonInField);
            Click("Click search btn", searchButtonInField);
        }
        #endregion
    }
}
