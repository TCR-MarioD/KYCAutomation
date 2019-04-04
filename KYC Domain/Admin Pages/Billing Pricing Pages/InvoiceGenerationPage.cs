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
    public class InvoiceGenerationPage : AdminPages
    {
        static string corporationSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlClient";

        protected override bool IsAt()
        {
            try
            {
                return driver.FindElement(By.TagName("h3")).Text == "Invoice Generation";
            }
            catch (Exception) { }
            return false;
        }

        public InvoiceGenerationPage SelectCorporation(string corporation)
        {
            try
            {
                driver.SelectTextById(corporationSelectId, corporation);
                validation.StringLogger.LogWrite("Validation for Selecting Corporation as " + corporation + " is Passed");
                _test.Log(Status.Pass, "Validation for Selecting Corporation as " + corporation + " is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Selecting Corporation as " + corporation + " is Failed");
            }
            return this;
        }
    }
}
