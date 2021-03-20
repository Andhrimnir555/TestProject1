using TestProject1.Pages;

namespace TestProject1.Actions
{
    class ResultsPageActions : ISearchResult
    {
        #region singleton
        private static ResultsPageActions instance;

        private ResultsPageActions() { }

        public static ResultsPageActions GetInstance()
        {
            if (instance == null)
                instance = new ResultsPageActions();
            return instance;
        }

        #endregion
        #region actions

        public string GetSearchResult(int rowNumber)
        {
            return ResultsPage.GetInstance().GetResultsByRowNumber(rowNumber);
        }
        #endregion
    }
}
