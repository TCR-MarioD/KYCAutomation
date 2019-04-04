using AventStack.ExtentReports;
using KYC_Domain.Helper_Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace KYC_Domain.Admin_Pages
{
    public enum SearchResultType
    {
        ExactMatch,
        InExactMatch,
        NoMatch
    };

    public class PackageResultsPage : AdminPages
    {
        static string packageItemStatusSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlProcessStatus";
        static string exactMatchSearchResultId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_chkBoxSearchType_0";
        static string inExactMatchSearchResultId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_chkBoxSearchType_1";
        static string noMatchSearchResultId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_chkBoxSearchType_2";
        static string costOverrideButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnCostOverRide";
        static string tradeNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtTradeName";
        static string tradeNumberBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtTradeNumber";
        static string saveTradeButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnTradeNameNumber_Save";
        static string commentTextFieldId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtBoxComment";
        static string addCommentButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnSaveComment";
        static string pdfFiletypeOptionId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_RadioButtonListFileType_0";
        static string chooseFileButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ResponseUpload";
        static string uploadFileButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnUploadFile";
        static string savePackageButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnSave";
        static string commentTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_grdPackageComments";

        static int commentColumnIndex = 1;

        protected override bool IsAt()
        {
            return driver.Url.Contains("Search_PackageItem.aspx");
        }

        private string GetIdFromSearchResultType(SearchResultType type)
        {
            if (type == SearchResultType.ExactMatch)
                return exactMatchSearchResultId;
            if (type == SearchResultType.InExactMatch)
                return inExactMatchSearchResultId;
            if (type == SearchResultType.NoMatch)
                return noMatchSearchResultId;

            throw new NotImplementedException();
        }

        public PackageResultsPage VerifyPackageStatus(string expectedStatus)
        {
            try
            {
                string actualStatus = new SelectElement(driver.FindElement(By.Id(packageItemStatusSelectId))).SelectedOption.Text;
                validation.AssertAreEqual(expectedStatus, actualStatus);
                validation.StringLogger.LogWrite("Validation for Package Status as " + expectedStatus + " is Passed");
                _test.Log(Status.Pass, "Validation for Package Status as " + expectedStatus + " is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Package Status as " + expectedStatus + " is Failed");
            }
            return this;
        }

        public PackageResultsPage SetPackageStatus(string text)
        {
            try
            {
                new SelectElement(driver.FindElement(By.Id(packageItemStatusSelectId))).SelectByText(text);
                validation.StringLogger.LogWrite("Validation for Package Status as " + text + " is Passed");
                _test.Log(Status.Pass, "Validation for Package Status as " + text + " is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Package Status as " + text + " is Failed");
            }
            return this;
        }

        public PackageResultsPage SetSearchResult(SearchResultType type)
        {
            try
            {
                driver.ClickById(GetIdFromSearchResultType(type));
                validation.StringLogger.LogWrite("Validation for Set Search Result as " + type + " is Passed");
                _test.Log(Status.Pass, "Validation for Set Search Result as " + type + " is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Set Search Result as " + type + " is Failed");
            }
            return this;
        }

        public CostOverridePage OpenCostOverrideForm()
        {
            try
            {
                driver.FindElement(By.Id(costOverrideButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Open Cost Override Button is Passed");
                _test.Log(Status.Pass, "Validation for Open Cost Override Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Open Cost Override Button is Failed");
            }
            return new CostOverridePage();
        }

        public PackageResultsPage AddTradeName(string tradeName = "Delta", int tradeNumber = 1234)
        {
            driver.FindElement(By.Id(tradeNameBoxId)).SendKeys(tradeName);
            driver.FindElement(By.Id(tradeNumberBoxId)).SendKeys(tradeNumber + "");
            var saveTradeButton = driver.FindElement(By.Id(saveTradeButtonId));
            while (true) //Band-aid solution (see issue #39 on github)
            {
                try
                {
                    saveTradeButton.Click();
                    validation.StringLogger.LogWrite("Validation for Add Trade Name is Passed");
                    _test.Log(Status.Pass, "Validation for Add Trade Name is Passed");
                    break;
                }
                catch (InvalidOperationException)
                {
                    _test.Log(Status.Fail, "Validation for Add Trade Name is Failed");
                }
            }


            //WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            //wait.IgnoreExceptionTypes(typeof(InvalidOperationException));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(saveTradeButtonId)));
            //saveTradeButton.Click();

            return this;
        }

        public PackageResultsPage VerifyCommentCanBeAdded(string comment = "Comment generated by KYC-Automation project")
        {
            TableInterface commentTable;
            int numComments;
            try
            {
                commentTable = new TableInterface(commentTableId, driver);
                numComments = commentTable.GetTotalNumRows();
            }
            catch (Exception)
            {
                numComments = 0;
            }

            try
            {
                driver.SendKeysById(commentTextFieldId, comment);
                driver.ClickById(addCommentButtonId);

                commentTable = new TableInterface(commentTableId, driver);

                validation.AssertAreEqual(numComments + 1, commentTable.GetTotalNumRows());
                validation.AssertAreEqual(comment, commentTable.GetElementByIndexes(numComments, commentColumnIndex).Text);
                validation.StringLogger.LogWrite("Validation for Adding Comments is Passed");
                _test.Log(Status.Pass, "Validation for Adding Comments is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Adding Comments is Failed");
            }
            return this;
        }

        public PackageResultsPage UploadResultsPdf(string filePath)
        {
            try
            {
                driver.FindElement(By.Id(pdfFiletypeOptionId)).Click();
                driver.FindElement(By.Id(chooseFileButtonId)).SendKeys(absolutePath + @"" + filePath);
                driver.FindElement(By.Id(uploadFileButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Uploading Results PDF is Passed");
                _test.Log(Status.Pass, "Validation for Uploading Results PDF is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Uploading Results PDF is Failed");
            }
            return this;
        }

        public PackageSummaryPage SavePackageItem()
        {
            try
            {
                driver.FindElement(By.Id(savePackageButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Save Package Button is Passed");
                _test.Log(Status.Pass, "Validation for Save Package Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Save Package Button is Failed");
            }
            return new PackageSummaryPage();
        }

        public PackageSummaryPage SavePackageItemAndCloseAlert()
        {
            try
            {
                driver.FindElement(By.Id(savePackageButtonId)).Click();
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);
                validation.StringLogger.LogWrite("Validation for Save Package Item & Closing Alert is Passed");
                _test.Log(Status.Pass, "Validation for Save Package Item & Closing Alert is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Save Package Item & Closing Alert is Failed");
            }
            return new PackageSummaryPage();
        }
    }
}
