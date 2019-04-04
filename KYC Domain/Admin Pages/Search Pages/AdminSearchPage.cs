using AventStack.ExtentReports;
using KYC_Domain.Helper_Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace KYC_Domain.Admin_Pages
{
    public class AdminSearchPage : AdminPages
    {
        static string dateFromBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtDateFrom";
        static string dateToBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtDateTo";
        static string searchButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnSearch";
        static string packageTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_grdEnhancedSearch";
        static string rowsReturnedTextId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lblTotalRowsCount";
        static string clientSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlClient";
        static string resetButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnReset";
        static string errorMessageId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lblErrorMessage";

        static int enterpriseNameColumnIndex = 3;
        static int referenceNumberColumnIndex = 6;
        static int packageStatusColumnIndex = 8;
        static int viewLinkColumnIndex = 10;

        TableInterface table;
        TableInterface Table
        {
            get
            {
                table = table ?? new TableInterface(packageTableId, driver);
                return table;
            }
        }

        protected override bool IsAt()
        {
            return driver.Url.Contains("Search_Home");
        }

        public AdminSearchPage WriteCurrentDateToDateFromBox()
        {
            Thread.Sleep(5000);
            try
            {
                DateTime thisDay = DateTime.Today.Date;
                //Format is yyyy-mm-dd
                string formattedDate = thisDay.Year + "-" + (thisDay.Month < 10 ? "0" : "") + thisDay.Month + "-" + (thisDay.Day < 10 ? "0" : "") + thisDay.Day;
                driver.FindElement(By.Id(dateFromBoxId)).SendKeys(formattedDate);
                validation.StringLogger.LogWrite("Validation for Entering Current Date in Date From Box is Passed");
                _test.Log(Status.Pass, "Validation for Entering Current Date in Date From Box is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Entering Current Date in Date From Box is Failed");
            }
            return this;
        }

        public AdminSearchPage SubmitSearch()
        {
            try
            {
                driver.FindElement(By.Id(searchButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Search Button is Passed");
                _test.Log(Status.Pass, "Validation for Search Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Search Button is Failed");
            }
            return this;
        }

        public AdminSearchPage VerifyRowsReturnedExists()
        {
            try
            {
                driver.FindElement(By.Id(rowsReturnedTextId));
                validation.StringLogger.LogWrite("Validation for the Existance of Rows Returned is Passed");
                _test.Log(Status.Pass, "Validation for the Existance of Rows Returned is Passed");
            }
            catch (Exception)
            {

                validation.AssertFail("Rows returned does not exist");
                _test.Log(Status.Fail, "Rows returned does not exist");
            }
            return this;
        }

        public PackageSummaryPage ViewPackageByReferenceNumberAndEnterpriseName(string referenceNumber, string enterpriseName)
        {
            try
            {
                int lastRowIndex = Table.GetLastRowIndex();
                for (int i = lastRowIndex; i >= 0; --i)
                {
                    if (Table.GetElementByIndexes(i, referenceNumberColumnIndex).Text == referenceNumber
                        && Table.GetElementByIndexes(i, enterpriseNameColumnIndex).Text == enterpriseName
                        && Table.GetElementByIndexes(i, packageStatusColumnIndex).Text != "Cancelled")
                    {
                        Table.GetElementByIndexes(i, viewLinkColumnIndex).Click();
                        break;
                    }
                }
                validation.StringLogger.LogWrite("Validation for Viewing Package by Reference Number & Enterprise Name is Passed");
                _test.Log(Status.Pass, "Validation for Viewing Package by Reference Number & Enterprise Name is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Viewing Package by Reference Number & Enterprise Name is Failed");
            }
            return new PackageSummaryPage();
        }

        public void CleanAdminPages(string dateFrom, string dateTo)
        {
            driver.FindElement(By.Id(dateFromBoxId)).SendKeys(dateFrom);
            driver.FindElement(By.Id(dateToBoxId)).SendKeys(dateTo);
            SubmitSearch();

            int rows = int.Parse(driver.FindElement(By.Id(rowsReturnedTextId)).Text.Substring(15));

            for (int i = 0; i < rows; ++i)
            {
                if (Table.GetElementByIndexes(i, packageStatusColumnIndex).Text == "Invalid")
                {
                    Table.GetElementByIndexes(i, viewLinkColumnIndex).Click();
                    var summaryPage = new PackageSummaryPage();
                    summaryPage.CancelAllPackageItems();
                    summaryPage.BackToSearch();
                    driver.FindElement(By.Id(dateFromBoxId)).SendKeys(dateFrom);
                    driver.FindElement(By.Id(dateToBoxId)).SendKeys(dateTo);
                    SubmitSearch();
                }
            }
        }

        public AdminSearchPage VerifyOrganizationExists(string organizationName)
        {
            try
            {
                driver.SelectTextById(clientSelectId, organizationName);
                validation.StringLogger.LogWrite("Validation for the Existance of Organization - " + organizationName + " is Passed");
                _test.Log(Status.Pass, "Validation for the Existance of Organization - " + organizationName + " is Passed");
            }
            catch (Exception)
            {
                validation.AssertFail("Organization by name '" + organizationName + "' does not exist");
                _test.Log(Status.Fail, "Validation for the Existance of Organization - " + organizationName + " is Failed");

            }
            return this;
        }

        public AdminSearchPage ClickResetButton()
        {
            try
            {
                driver.ClickById(resetButtonId);
                validation.StringLogger.LogWrite("Validation for Clicking Reset Button is Passed");
                _test.Log(Status.Pass, "Validation for Clicking Reset Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clicking Reset Button is Failed");
            }
            return this;
        }

        public AdminSearchPage VerifyFieldsReset()
        {
            try
            {
                validation.AssertAreEqual("", driver.FindElement(By.Id(dateFromBoxId)).Text);
                validation.StringLogger.LogWrite("Validation for Fields To Reset is Passed");
                _test.Log(Status.Pass, "Validation for Fields To Reset is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Fields To Reset is Failed");
            }
            return this;
        }

        public AdminSearchPage VerifyErrorMessageAppeared()
        {
            try
            {
                validation.AssertIsTrue(driver.FindElement(By.Id(errorMessageId)).Text.Length > 0);
                validation.StringLogger.LogWrite("Validation for Error Message is Passed");
                _test.Log(Status.Pass, "Validation for Error Message is Passed");

            }
            catch (Exception)
            {
                validation.AssertFail();
                validation.StringLogger.LogWrite("Validation for Error Message is Failed");
                _test.Log(Status.Fail, "Validation for Error Message is Failed");
            }

            return this;
        }
    }
}
