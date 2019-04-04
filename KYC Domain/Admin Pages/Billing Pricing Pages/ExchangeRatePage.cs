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
    public class ExchangeRatePage : AdminPages
    {
        static string currencySelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlCurrencyType";

        protected override bool IsAt()
        {
            try
            {
                return driver.FindElement(By.TagName("h3")).Text == "Exchange Rate";
            }
            catch (Exception) { }
            return false;
        }

        public ExchangeRatePage VerifyHasAllCurrencyTypes()
        {
            try
            {
                SelectElement currencySelect = new SelectElement(driver.FindElement(By.Id(currencySelectId)));
                List<string> currencyTypesFromSelect = new List<string>();

                foreach (var option in currencySelect.Options)
                {
                    currencyTypesFromSelect.Add(option.Text);
                }
                currencyTypesFromSelect.RemoveAt(0);
                validation.CollectionAssertAreEquivalent(reference.CurrencyTypes, currencyTypesFromSelect);
                validation.StringLogger.LogWrite("Validation for List Containing All Currency Types is Passed");
                _test.Log(Status.Pass, "Validation for List Containing All Currency Types is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for List Containing All Currency Types is Failed");
            }

            return this;
        }
    }
}
