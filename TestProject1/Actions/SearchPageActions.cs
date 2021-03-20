using TestProject1.Pages;

namespace TestProject1.Actions
{
    class SearchPageActions : ISearchPage
    {
        #region singleton
        private static SearchPageActions instance;

        private SearchPageActions() { }

        public static SearchPageActions GetInstance()
        {
            if (instance == null)
                instance = new SearchPageActions();
            return instance;
        }
        #endregion
        #region actions
        public void SearchGoogle(string request)
        {
            MainPage.GetInstance().SearchInput(request);
            MainPage.GetInstance().ClickFieldSearchBtn();
        }
        #endregion
    }
}
