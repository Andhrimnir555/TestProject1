using TestProject1.Pages;

namespace TestProject1.Actions
{
    class ResultsPageActionsList : ISearchResult
    {
        #region singleton
        private static ResultsPageActionsList instance;

        private ResultsPageActionsList() { }

        public static ResultsPageActionsList GetInstance()
        {
            if (instance == null)
                instance = new ResultsPageActionsList();
            return instance;
        }

        #endregion
        #region actions

        public string GetSearchResult(int rowNumber)
        {
           return ResultsPage.GetInstance().GetResultsByRowNumberFromList()[rowNumber - 1];
        }
        #endregion
    }
}
