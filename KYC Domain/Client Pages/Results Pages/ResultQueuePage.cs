using System;
using OpenQA.Selenium;
using System.Threading;
using KYC_Domain.Helper_Classes;
using System.Collections.Generic;
using AventStack.ExtentReports;

namespace KYC_Domain.Client_Pages
{
    public class ResultQueuePage : ClientPages
    {
        static string dateFromBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsQueue_txtDateFrom";
        static string dateToBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsQueue_txtDateTo";
        static string filterButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsQueue_btnRunReport";
        static string resultsTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsQueue_grdSearchResults";
        static string resetButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsQueue_btnClearReport";

        static int numColumnsExpected = 8;
        static int enterpriseNameColumnIndex = 0;
        static int referenceNumberColumnIndex = 3;
        static int dateColumnIndex = 5;
        static int viewLinkColumnIndex = 7;

        TableInterface table;

        public ResultQueuePage()
        {
            table = new TableInterface(resultsTableId, driver);
            validation.AssertAreEqual(numColumnsExpected, table.GetNumColumns());
        }

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Results"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "eSearch Result Queue";
                }
                catch (Exception) { }
            }
            return false;
        }

        public ResultQueuePage WriteCurrentDateToDateFromBox()
        {
            Thread.Sleep(5000);
            try
            {
                DateTime thisDay = DateTime.Today.Date;
                //Format is mm/dd/yyyy
                string formattedDate = (thisDay.Month < 10 ? "0" : "") + thisDay.Month + @"/" + (thisDay.Day < 10 ? "0" : "") + thisDay.Day + @"/" + thisDay.Year;
                driver.FindElement(By.Id(dateFromBoxId)).SendKeys(formattedDate);
                validation.StringLogger.LogWrite("Validation for Entering Current Date in From Date is Passed");
                _test.Log(Status.Pass, "Validation for Entering Current Date in From Date is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Entering Current Date in From Date is Failed");
            }
            return this;
        }

        public ResultQueuePage Write1500sToDateBoxes()
        {
            try
            {
                driver.SendKeysById(dateFromBoxId, "01/01/1500");
                driver.SendKeysById(dateToBoxId, "01/01/1500");
                validation.StringLogger.LogWrite("Validation for Entering Dates in Date Boxes is Passed");
                _test.Log(Status.Pass, "Validation for Entering Dates in Date Boxes is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Entering Dates in Date Boxesn is Failed");
            }
            return this;
        }

        public string ReadFromCurrentDateBox()
        {
            return driver.FindElement(By.Id(dateFromBoxId)).Text;
        }

        public ResultQueuePage SubmitSearch()
        {
            try
            {
                driver.FindElement(By.Id(filterButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Submit Search is Passed");
                _test.Log(Status.Pass, "Validation for Submit Search is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Submit Search is Failed");
            }
            return this;
        }

        public ResultQueuePage ResetFields()
        {
            driver.FindElement(By.Id(resetButtonId)).Click();
            return this;
        }

        public ResultQueuePage GoToPageInTable(int pageNum)
        {
            table.GoToPage(pageNum);
            return this;
        }

        public int GetCurrentPage()
        {
            return table.GetCurrentPage();
        }

        public ResultSummaryPage ViewResultByReferenceNumberAndEnterpriseName(string referenceNumber, string enterpriseName)
        {
            try
            {
                int lastRowIndex = table.GetLastRowIndex();
                for (int i = lastRowIndex; i >= 0; --i)
                {
                    //ReferenceNumber table column contains a span with the actual reference number in it, hence the nested .FindElement
                    if (table.GetElementByIndexes(i, referenceNumberColumnIndex).FindElement(By.TagName("span")).GetAttribute("title") == referenceNumber
                        && table.GetElementByIndexes(i, enterpriseNameColumnIndex).Text == enterpriseName)
                    {
                        table.GetElementByIndexes(i, viewLinkColumnIndex).Click();
                        break;
                    }
                }
                validation.StringLogger.LogWrite("Validating for View result by Ref number & Enterprise name");
                _test.Log(Status.Pass, "Validation for View result by Ref number & Enterprise name is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for View result by Ref number & Enterprise name is Failed");
            }
            return new ResultSummaryPage();
        }

        public ResultSummaryPage ViewFirstResult()
        {
            try
            {
                table.GetElementByIndexes(0, viewLinkColumnIndex).Click();
                validation.StringLogger.LogWrite("Validation for Viewing First Result is Passed");
                _test.Log(Status.Pass, "Validation for Viewing First Result is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Viewing First Result is Failed");
            }
            return new ResultSummaryPage();
        }

        public string GetFirstResultEnterpriseName()
        {
            return table.GetElementByIndexes(0, enterpriseNameColumnIndex).Text;
        }

        public ResultQueuePage VerifyDatesAscendingOrder()
        {
            try
            {
                validation.AssertIsTrue(table.IsColumnInSortedOrder(dateColumnIndex, Order.Ascending));
                validation.StringLogger.LogWrite("Validation for Dates Ascending Order is Passed");
                _test.Log(Status.Pass, "Validation for Dates Ascending Order is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Dates Ascending Order is Failed");
            }
            return this;
        }

        public ResultQueuePage VerifyNamesDescendingOrder()
        {
            try
            {
                validation.AssertIsTrue(table.IsColumnInSortedOrder(enterpriseNameColumnIndex, Order.Descending));
                validation.StringLogger.LogWrite("Validation for Names in Descending Order is Passed");
                _test.Log(Status.Pass, "Validation for Names in Descending Order is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Names in Descending Order is Failed");
            }
            return this;
        }

        public ResultQueuePage SortByEnterpriseName()
        {
            try
            {
                table.GetColumnHeaderElement(enterpriseNameColumnIndex).Click();
                validation.StringLogger.LogWrite("Validation for Sort By Enterprise Name is Passed");
                _test.Log(Status.Pass, "Validation for Sort By Enterprise Name is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Sort By Enterprise Name is Failed");
            }
            return this;
        }

        public ResultQueuePage VerifyHasNoResults()
        {
            try
            {
                validation.AssertIsFalse(table.HasResults());
                validation.StringLogger.LogWrite("Validation for Table has no Results is Passed");
                _test.Log(Status.Pass, "Validation for Table has no Results is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Table has no Results is Failed");
            }
            return this;
        }
    }
}
