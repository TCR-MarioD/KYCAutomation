using AventStack.ExtentReports;
using KYC_Domain.Helper_Classes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class ProductivityDashboardPage : ClientPages
    {
        static string runReportId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_btnRunReport";
        static string detailedReportId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_RadioButtonList1_0";
        static string productivityReportId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_RadioButtonList1_1";
        static string detailedReportTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_gvProductivityDetailedDashboard";
        static string productivityReportTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_gvProductivityDashboard";
        static string dateFromId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_txtDateFrom";
        static string dateToId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_txtDateTo";
        static string backBtnId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_btnProductivityDashboardBack";
        static string showCompletedId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_RadioButtonList2_0";
        static string showCompletedAndInProgressId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_RadioButtonList2_1";
        static string showCancelledId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_ProductivityDashboard_RadioButtonList2_2";

        TableInterface table;

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Dashboard"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "Productivity Dashboard";
                }
                catch (Exception) { }
            }
            return false;
        }

        private void selectRadioOption(string radioBtn)
        {
            try
            {
                var radio = driver.FindElement(By.Id(radioBtn));
                radio.Click();

                validation.StringLogger.LogWrite("Validation for Selecting Radio Option is Passed");
                _test.Log(Status.Pass, "Validation for Selecting Radio Option is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Selecting Radio Option is Failed");
            }
        }

        /// <summary>
        /// Performs three comparisons of the detailed report table and productivity report table,
        ///     one comparison for each of Show Completed, Show Completed and In-Progress, and Show Cancelled
        /// </summary>
        public ProductivityDashboardPage compareReports()
        {
            selectRadioOption(showCompletedId);
            productivityDashboardCheckEqual();
            selectRadioOption(showCompletedAndInProgressId);
            productivityDashboardCheckEqual();
            selectRadioOption(showCancelledId);
            productivityDashboardCheckEqual();
            return this;
        }

        /// <summary>
        /// Performs search with fields Date From as the first of the month and Date To as the current date
        /// </summary>
        /// <returns>ProductivityDashboardPage</returns>
        public ProductivityDashboardPage ProductivityDashboardEnterFields()
        {
            // Today's date
            DateTime today = DateTime.Today;
            string s_today = today.ToString("MM/dd/yyyy");

            // Date of the 1st day of the month
            var aStringBuilder = new StringBuilder(s_today);
            aStringBuilder.Remove(3, 2);
            aStringBuilder.Insert(3, "01");
            string s_first = aStringBuilder.ToString();

            try
            {
                var DF = driver.FindElement(By.Id(dateFromId));
                DF.SendKeys(s_first);

                var DT = driver.FindElement(By.Id(dateToId));
                DT.SendKeys(s_today);

                validation.StringLogger.LogWrite("Validation for Entering Date From and Date To is Passed");
                _test.Log(Status.Pass, "Validation for Entering Date From and Date To is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Entering Date From and Date To is Failed");
            }
            return this;

        }

        private void productivityDashboardCheckEqual()
        {
            if (CountItemsDetailedReport() == CountItemsProductivityReport())
            {
                validation.StringLogger.LogWrite("Validation for Item Count and Compare is Passed");
                _test.Log(Status.Pass, "Validation for Item Count and Compare is Passeed");
            }
            else
            {
                _test.Log(Status.Fail, "Validation for Item Count and Compare is Failed");
                Exception ex = new Exception("Validation for Item Count and Compare is Failed");
                throw ex;
            }
        }

        private int countDetailed()
        {
            int numRow = table.GetTotalNumRows();
            return numRow;
        }

        /// <summary>
        /// Counts number of rows in table, which should align with the registry search column
        /// if the search yields no result, no table is produced, hence 0 is returned
        /// </summary>
        /// <returns>number of rows</returns>
        private int CountItemsDetailedReport()
        {
            try
            {
                var checkDetailedReport = driver.FindElement(By.Id(detailedReportId));
                checkDetailedReport.Click();

                var RunReport = driver.FindElement(By.Id(runReportId));
                RunReport.Click();

                validation.StringLogger.LogWrite("Validation for Checking and Running Detailed Report is Passed");
                _test.Log(Status.Pass, "Validation for Checking and Running Detailed Report is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Checking and Running Detailed Report is Failed");
            }

            // Checks whether table exits
            if (driver.FindElements(By.Id(detailedReportTableId)).Count != 0)
            {
                table = new TableInterface(detailedReportTableId, driver);
                return countDetailed();
            }
            else
                return 0;
        }

        private int countProductivity()
        {
            int rows = table.GetTotalNumRows();
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                sum += Int32.Parse(table.GetElementByIndexes(i, 4).Text);
            }

            return sum;
        }

        /// <summary>
        /// Counts total of items in the registry search column, which should align with number of rows in detailed report
        /// if the search yields no result, no table is produced, hence 0 is returned
        /// </summary>
        /// <returns>total number of items in registry search column</returns>
        private int CountItemsProductivityReport()
        {
            try
            {
                var checkProductivityReport = driver.FindElement(By.Id(productivityReportId));
                checkProductivityReport.Click();

                var RunReport = driver.FindElement(By.Id(runReportId));
                RunReport.Click();

                validation.StringLogger.LogWrite("Validation for Checking and Running Productivity Report is Passed");
                _test.Log(Status.Pass, "Validation for Checking and Running Productivity Report is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Checking and Running Productivity Report is Failed");
            }

            // Checks whether table exits
            if (driver.FindElements(By.Id(productivityReportTableId)).Count != 0)
            {
                table = new TableInterface(productivityReportTableId, driver);
                return countProductivity();
            }
            else
                return 0;
        }

        public DashboardHubPage ProductivityDashboardBack()
        {
            try
            {
                var back = driver.FindElement(By.Id(backBtnId));
                back.Click();

                validation.StringLogger.LogWrite("Validation for Clicking Back Button is Passed");
                _test.Log(Status.Pass, "Validation for Clicking Back Button is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Clicking Back Button is Failed");
            }

            return new DashboardHubPage();

        }
    }
}
