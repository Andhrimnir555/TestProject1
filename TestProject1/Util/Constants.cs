using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestProject1.Util
{
    class Constants
    {
        #region URL
        public static readonly string BASE_URL = "https://google.com";
        #endregion

        #region strings
        public static readonly string SEARCH_REQUEST = "Selenium IDE export to C#";
        public static readonly string SEARCH_RESULT = "Selenium IDE";
        #endregion

        #region timeouts
        public const int ELEMENT_LONG_TIMEOUT_SECONDS = 620;
        public const int ELEMENT_TIMEOUT_SECONDS = 30;
        public const int ELEMENT_TIMEOUT_SMALL_SECONDS = 20;
        #endregion

        #region local paths
        public static string PROJECT_DIR = new Uri(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)))).LocalPath;

        public static string REPORT_DIR = PROJECT_DIR + "\\Results\\";
        #endregion
    }
}
