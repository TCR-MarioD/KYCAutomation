using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYC_Domain.Data_Management;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using KYC_Domain.Base_Page;

namespace KYC_Domain.Client_Pages.Search_Pages
{
    public class SearchManualOverridePage : ClientPages
    {
        static string continueButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchOverride_UserControl_SearchOverride_btnSubmit";
        static string jurisdictionSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchOverride_ddlJurisdictions";
        static string enterpriseNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchOverride_txtName";
        static string OverrideSearchId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchNUANS_OverrideButton";
        static string enterpriseNumBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchOverride_txtNumber";

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Search"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "Search Override";
                }
                catch (Exception) { }
            }
            return false;
        }

        ///
        /// Selects jurisdiction from dropdown menu
        ///
        private void SelectJurisdictionOverride(string jurisdiction)
        {
            try
            {
                new SelectElement(driver.FindElement(By.Id(jurisdictionSelectId))).SelectByValue(jurisdiction);
                validation.StringLogger.LogWrite("Validation for Selecting Override Jurisdiction as " + jurisdiction + " is Passed");
                _test.Log(Status.Pass, "Validation for Selecting Override Jurisdiction as " + jurisdiction + " is Passed");
                Thread.Sleep(6000);
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Selecting Override Jurisdiction as " + jurisdiction + " is Failed");
                throw new Exception("No jurisdiction named " + jurisdiction + " found.");

            }
        }

        private void OverrideAndAddRandomNumber()
        {
            driver.FindElement(By.Id(OverrideSearchId)).Click();
            driver.FindElement(By.Id(enterpriseNameBoxId)).SendKeys("-" + random.Next(0, int.MaxValue));
        }

        public SearchManualOverridePage() : base(false)
        {
            if (!IsAt())
            {
                OverrideAndAddRandomNumber();
                SelectJurisdictionOverride(DynamicTestInformation.jurisdiction);
            }
            AssertIsAt();
        }

        public ServiceSelectionPage ClickContinueButton()
        {
            try
            {
                DynamicTestInformation.enterpriseName = driver.FindElement(By.Id(enterpriseNameBoxId)).GetAttribute("value");
                driver.FindElement(By.Id(continueButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Continue Button is Passed");
                _test.Log(Status.Pass, "Validation for Continue Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Continue Button is Failed");
            }
            return new ServiceSelectionPage();
        }

        public SearchManualOverridePage WriteEnterpriseNum(string text)
        {
            try
            {
                driver.SendKeysById(enterpriseNumBoxId, text);
                validation.StringLogger.LogWrite("Validation for Enterprise Number is Passed");
                _test.Log(Status.Pass, "Validation for Enterprise Number is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Enterprise Number is Failed");
            }
            return this;
        }
    }
}
