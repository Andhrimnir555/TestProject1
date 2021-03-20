using TestProject1.Pages;

namespace TestProject1.Actions
{
    class SearchPageActionsEnter : ISearchPage
    {
        #region singleton
        private static SearchPageActionsEnter instance;

        private SearchPageActionsEnter() { }

        public static SearchPageActionsEnter GetInstance()
        {
            if (instance == null)
                instance = new SearchPageActionsEnter();
            return instance;
        }
        #endregion
        #region actions
        public void SearchGoogle(string request)
        {
            MainPage.GetInstance().SearchInput(request);
            MainPage.GetInstance().PressEnterAtSearchInput();
        }
        #endregion
    }
}
