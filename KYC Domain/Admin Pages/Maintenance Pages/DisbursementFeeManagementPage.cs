using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class DisbursementFeeManagementPage : AdminPages
    {
        static string pricingTypeSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_drpPricingType";
        static string resultMatchTypeSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_drpResultMatchType";

        protected override bool IsAt()
        {
            if (!driver.Url.Contains("PricingManagement"))
                return false;
            try
            {
                return driver.FindElement(By.ClassName("bigheading")).Text == "KYC Disbursement Fee Management";
            }
            catch (Exception) { }
            return false;
        }

        public DisbursementFeeManagementPage VerifyHasAllPricingTypes()
        {
            try
            {
                SelectElement pricingSelect = new SelectElement(driver.FindElement(By.Id(pricingTypeSelectId)));
                List<string> pricingTypesFromSelect = new List<string>();
                foreach (var option in pricingSelect.Options)
                {
                    pricingTypesFromSelect.Add(option.Text);
                }
                pricingTypesFromSelect.RemoveAt(0);
                validation.CollectionAssertAreEquivalent(reference.PricingTypes, pricingTypesFromSelect);
                _test.Log(Status.Pass, "Validation to check if All pricing Types are there is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation to check if All pricing Types are there is Failed");
            }

            return this;
        }

        public DisbursementFeeManagementPage VerifyHasAllResultMatchTypes()
        {
            try
            {
                SelectElement resultMatchSelect = new SelectElement(driver.FindElement(By.Id(resultMatchTypeSelectId)));
                List<string> resultMatchTypesFromSelect = new List<string>();
                foreach (var option in resultMatchSelect.Options)
                {
                    resultMatchTypesFromSelect.Add(option.Text);
                }
                resultMatchTypesFromSelect.RemoveAt(0);
                validation.CollectionAssertAreEquivalent(reference.ResultMatchTypes, resultMatchTypesFromSelect);
                validation.StringLogger.LogWrite("Validation for List Containing All Match Types is Passed");
                _test.Log(Status.Pass, "Validation for List Containing All Match Types is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for List Containing All Match Types is Failed");
            }

            return this;
        }
    }
}
