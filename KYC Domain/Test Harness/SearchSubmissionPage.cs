using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using KYC_Domain.Base_Page;
using System.Threading.Tasks;
using KYC_Domain.Data_Management;

namespace KYC_Domain.Harness
{
    public class SearchSubmissionPage : TestClientPage
    {
        // Elements located on page before clicking search
        static string companyNameBoxId = "ctl04_txtCompanyName";
        static string companyNumberBoxId = "ctl04_txtCompanyNumber";
        static string jurisdictionDrpDwnId = "ctl04_ddlJurisdictions";
        static string usernameBoxId = "ctl04_txtUserName";
        static string searchBtnId = "ctl04_btnSearch";

        // Elements located on page after clicking search
        static string submitBtnId = "ctl04_btnSubmit";

        // Elements located on page after selecting enterprise from table
        static string transRefBoxId = "ctlSelectService_txtTReference";
        static string corporateProfileChkBoxId = "ctlSelectService_grdServices_ChkService_0";
        static string corporateProfileTxtBoxId = "ctlSelectService_grdServices_txtRefernce_0";
        static string articlesOfIncorpChkBoxId = "ctlSelectService_grdServices_ChkService_1";
        static string articlesOfIncorpTxtBoxId = "ctlSelectService_grdServices_txtRefernce_1";
        static string certOfStatusChkBoxId = "ctlSelectService_grdServices_ChkService_2";
        static string certOfStatusTxtBoxId = "ctlSelectService_grdServices_txtRefernce_2";
        static string bankActSecurityChkBoxId = "ctlSelectService_grdServices_ChkService_3";
        static string bankActSecurityTxtBoxId = "ctlSelectService_grdServices_txtRefernce_3";
        static string tradeNamePartnershipChkBoxId = "ctlSelectService_grdServices_ChkService_4";
        static string tradeNamePartnershipTxtBoxId = "ctlSelectService_grdServices_txtRefernce_4";
        static string redSubmitBtnId = "ctlSelectService_btnSubmit";
        static string cancelBtnId = "ctlSelectService_btnCancel";

        public SearchSubmissionPage()
        {
            DynamicTestInformation.serviceIndexes.Clear();
        }

        protected override bool IsAt()
        {
            return driver.Url.Contains("Search");
        }

        public string GetEnterpriseName()
        {
            return driver.FindElement(By.XPath("//table[@id='ctl04_gvSearchResult']/tbody/tr[2]/td[2]")).Text;
        }

        public SearchSubmissionPage SubmitSearchDetails(string strProvince, string strBaseEntPrName)
        {
            try
            {
                driver.FindElement(By.Id(companyNameBoxId)).SendKeys(strBaseEntPrName);
                SelectElement jurisdictionSelect = new SelectElement(driver.FindElement(By.Id(jurisdictionDrpDwnId)));
                jurisdictionSelect.SelectByText(strProvince);

                driver.FindElement(By.Id(searchBtnId)).Click();

                validation.StringLogger.LogWrite("Validation for Test Harness Radio Button is Passed");
                _test.Log(Status.Pass, "Validation for Test Harness Radio Button is Passed");

            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Navigation Failed");
            }

            DynamicTestInformation.jurisdiction = strProvince;

            return this;
        }

        public SearchSubmissionPage SelectEnterprise()
        {
            try
            {
                DynamicTestInformation.enterpriseName = GetEnterpriseName();
                IWebElement element = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl04_gvSearchResult_RadioButtonMarkup_0")));
                element.Click();

                driver.FindElement(By.Id(submitBtnId)).Click();

                validation.StringLogger.LogWrite("Validation for Enterprise Selection is Passed");
                _test.Log(Status.Pass, "Validation for Enterprise Selection is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Enterprise Selection is Failed");
            }
            return this;
        }

        /// <summary>
        /// Closes pop up window that confirms the order submission has been submitted
        /// </summary>
        private void CloseWebpageAlert()
        {
            try
            {
                // Get a handle to the open alert, prompt or confirmation
                IAlert alert = driver.SwitchTo().Alert();
                // Get the text of the alert or prompt
                // And acknowledge the alert (equivalent to clicking "OK")
                alert.Accept();

                validation.StringLogger.LogWrite("Validation for Confirming Order Submission is Passed");
                _test.Log(Status.Pass, "Validation for Confirming Order Submission is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Pass, "Validation for Confirming Order Submission is Failed");
            }
        }

        public void WriteToTransactionReference(string text)
        {
            try
            {
                driver.FindElement(By.Id(transRefBoxId)).SendKeys(text);
                validation.StringLogger.LogWrite("Validation for Entering Transaction Reference is Passed");
                _test.Log(Status.Pass, "Validation for Entering Transaction Reference is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Entering Transaction Reference is Failed");
            }

        }

        public SearchSubmissionPage SelectServices(string[] serviceNames)
        {
            int i = 0;
            foreach (string serviceName in serviceNames)
            {
                SubmitReferenceInformation(serviceName, i);
                i++;
            }

            WriteToTransactionReference(DynamicTestInformation.CalculatedReferenceNumber);

            try
            {
                driver.FindElement(By.Id(redSubmitBtnId)).Click();
                validation.StringLogger.LogWrite("Validation for clicking Submit Button is Passed");
                _test.Log(Status.Pass, "Validation for clicking Submit Button is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for clicking Submit Button is Failed");
            }

            CloseWebpageAlert();

            return this;
        }

        private void SubmitReferenceInformation(string serviceName, int serviceIndex)
        {
            try
            {
                CheckServiceBox(serviceName, "12345", serviceIndex);
                validation.StringLogger.LogWrite("Validation for Entering Reference Information for" + serviceName + " is Passed");
                _test.Log(Status.Pass, "Validation for Entering Reference Information for" + serviceName + " is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Entering Reference Information for" + serviceName + " is Failed");
            }
        }

        private void CheckServiceBox(string serviceName, string referenceNum, int serviceIndex)
        {
            switch (serviceName)
            {
                case "Corporate Profile Search":
                    driver.FindElement(By.Id(corporateProfileChkBoxId)).Click();
                    driver.FindElement(By.Id(corporateProfileTxtBoxId)).SendKeys(referenceNum);
                    break;
                case "Articles of Incorporation":
                    driver.FindElement(By.Id(articlesOfIncorpChkBoxId)).Click();
                    driver.FindElement(By.Id(articlesOfIncorpTxtBoxId)).SendKeys(referenceNum);
                    break;
                case "Certificate of Status":
                    driver.FindElement(By.Id(certOfStatusChkBoxId)).Click();
                    driver.FindElement(By.Id(certOfStatusTxtBoxId)).SendKeys(referenceNum);
                    break;
                case "Bank Act Security - Notice of Intention":
                    driver.FindElement(By.Id(bankActSecurityChkBoxId)).Click();
                    driver.FindElement(By.Id(bankActSecurityTxtBoxId)).SendKeys(referenceNum);
                    break;
                case "Trade Name / Partnership Report":
                    driver.FindElement(By.Id(tradeNamePartnershipChkBoxId)).Click();
                    driver.FindElement(By.Id(tradeNamePartnershipTxtBoxId)).SendKeys(referenceNum);
                    break;
            }
            DynamicTestInformation.serviceIndexes.Add(serviceIndex);
        }

        public SearchSubmissionPage returnByCancelBtn()
        {
            try
            {
                driver.FindElement(By.Id(cancelBtnId)).Click();
                validation.StringLogger.LogWrite("Validation for clicking Cancel Button is Passed");
                _test.Log(Status.Pass, "Validation for clicking Cancel Button is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for clicking Cancel Button is Failed");
            }

            return new SearchSubmissionPage();
        }
    }
}
