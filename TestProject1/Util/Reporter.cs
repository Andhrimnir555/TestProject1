using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using TestProject1.Base;

namespace TestProject1.Util
{
    class Reporter
    {
        private static Reporter instance;

        private Reporter()
        {
            var dir = Constants.REPORT_DIR;
            var fileName = $"{GetType()}-{Environment.MachineName}.html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);

            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

            BaseTest.Extent = new ExtentReports();
            BaseTest.Extent.AttachReporter(htmlReporter);
        }

        public static Reporter Initialize()
        {
            if (instance == null)
                instance = new Reporter();
            return instance;
        }
    }
}
