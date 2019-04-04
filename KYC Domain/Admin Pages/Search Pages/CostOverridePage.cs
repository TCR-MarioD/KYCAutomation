using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace KYC_Domain.Admin_Pages
{
    public class CostOverridePage : AdminPages
    {
        static string waiveDHFeeId = "chbWaiveDHFee";
        static string waiveDisbursementFeeId = "chbDisbursment";
        static string saveButtonId = "btnSave";
        static string backButtonXPath = "//*[@id='form1']/div[3]/table/tbody/tr/td/table/tbody/tr/td[3]/input";

        public CostOverridePage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
        }

        public CostOverridePage WaiveDHFee()
        {
            try
            {
                driver.FindElement(By.Id(waiveDHFeeId)).Click();
                validation.StringLogger.LogWrite("Validation for Waive DH Fee Link is Passed");
                _test.Log(Status.Pass, "Validation for Waive DH Fee Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Waive DH Fee Link is Failed");
            }
            return this;
        }

        public CostOverridePage WaiveDisbursementFee()
        {
            try
            {
                driver.FindElement(By.Id(waiveDisbursementFeeId)).Click();
                validation.StringLogger.LogWrite("Validation for Waive Disbursement Fee link is Passed");
                _test.Log(Status.Pass, "Validation for Waive Disbursement Fee link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Waive Disbursement Fee link is Failed");
            }
            return this;
        }

        public CostOverridePage SaveOverride()
        {
            //driver.FindElement(By.Id(saveButtonId)).Click();
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    driver.FindElement(By.Id(saveButtonId)).Click();
                    staleElement = false;
                    validation.StringLogger.LogWrite("Validation for Save Override Button is Passed");
                    _test.Log(Status.Pass, "Validation for Save Override Button is Passed");
                }
                catch (Exception)
                {
                    staleElement = true;
                }
            }


            return this;
        }

        public PackageResultsPage BackToPackageResults()
        {
            //driver.FindElement(By.XPath(backButtonXPath)).Click();
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    driver.FindElement(By.XPath(backButtonXPath)).Click();
                    staleElement = false;
                    validation.StringLogger.LogWrite("Validation for Back To Package Results Page is Passed");
                    _test.Log(Status.Pass, "Validation for Back To Package Results Page is Passed");
                }
                catch (Exception)
                {
                    staleElement = true;
                }
            }

            driver.SwitchTo().DefaultContent();
            return new PackageResultsPage();
        }

        protected override bool IsAt()
        {
            return true; //Needs revisiting
        }
    }
}
