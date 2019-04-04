using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class SearchConfirmationPage : ClientPages
    {
        static string submitButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_UserControl_SearchConfirmation_btnSubmit";
        static string referenceNumberBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_txtReferenceNumber";
        static string ownerFirstNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_txtOwners_FirstName";
        static string ownerLastNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_txtOwners_LastName";
        static string saveOwnerInformationButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_UserControl_SearchConfirmation_Owners_Save";
        static string uploadDocumentButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_fileOwners_UploadDocument";
        static string attachDocumentButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_UserControl_SearchConfirmation_Owners_btnAttach";
        static string notifyBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_txtConfirmationNotify";
        static string notifyCheckBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchConfirmation_chkConfirmationNotify";

        public SearchConfirmationPage ConfirmSubmit()
        {
            try
            {
                driver.FindElement(By.Id(submitButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Submit Buttton is Passed");
                _test.Log(Status.Pass, "Validation for Submit Buttton is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Submit Buttton is Failed");
            }
            return this;
        }

        public bool WasSubmissionConfirmed()
        {
            return (driver.FindElement(By.ClassName("bigheading")).Text == "eSearch Confirmation of Submission");
        }

        public SearchConfirmationPage WriteToReferenceNumber(string text)
        {
            try
            {
                driver.FindElement(By.Id(referenceNumberBoxId)).SendKeys(text);
                validation.StringLogger.LogWrite("Validation for Entering reference number is Passed");
                _test.Log(Status.Pass, "Validation for Entering reference number is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Entering reference number is Failed");
            }
            return this;
        }

        /// <summary>
        /// Enables notifications to email address, if notify is "Yes" in App.config
        /// </summary>
        /// <returns></returns>
        public SearchConfirmationPage NotifyCheckBox()
        {
            IWebElement checkBox = driver.FindElement(By.Id(notifyCheckBoxId));
            if (ConfigurationManager.AppSettings["Notify?"] == "Yes" && !checkBox.Selected ||
                ConfigurationManager.AppSettings["Notify?"] == "No" && checkBox.Selected)
            {
                try
                {
                    checkBox.Click();
                    validation.StringLogger.LogWrite("Validation for checking notify box is Passed");
                    _test.Log(Status.Pass, "Validation for checking notify box is Passed");
                }
                catch
                {
                    _test.Log(Status.Pass, "Validation for checking notify box is Failed");
                }
            }
            return this;
        }

        /// <summary>
        /// Clears notify box
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public SearchConfirmationPage ClearNotifyBox()
        {
            try
            {
                driver.FindElement(By.Id(notifyBoxId)).Clear();
                validation.StringLogger.LogWrite("Validation for Clear Notify Box is Passed");
                _test.Log(Status.Pass, "Validation for Clear Notify Box is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clear Notify Box is Failed");
            }
            return this;
        }

        /// <summary>
        /// Replaces notify email address with email listed on excel sheet
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public SearchConfirmationPage WriteToNotify(string text)
        {
            try
            {
                driver.FindElement(By.Id(notifyBoxId)).SendKeys(text);
                validation.StringLogger.LogWrite("Validation for Entering value in Notify Box is Passed");
                _test.Log(Status.Pass, "Validation for Entering value in Notify Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Entering value in Notify Box is Failed");
            }
            return this;
        }

        public SearchConfirmationPage FillInOwnerInformationAndSave(string firstName, string lastName)
        {
            driver.FindElement(By.Id(ownerFirstNameBoxId)).SendKeys(firstName);
            driver.FindElement(By.Id(ownerLastNameBoxId)).SendKeys(lastName);
            driver.FindElement(By.Id(saveOwnerInformationButtonId)).Click();
            return this;
        }

        public SearchConfirmationPage UploadDocument(string filePath)
        {
            driver.FindElement(By.Id(uploadDocumentButtonId)).SendKeys(filePath);
            driver.FindElement(By.Id(attachDocumentButtonId)).Click();
            return this;
        }

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Search"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "eSearch Confirmation";
                }
                catch (Exception) { }
            }
            return false;
        }
    }
}
