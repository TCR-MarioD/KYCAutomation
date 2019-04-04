using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KYC_Domain.Harness
{
    public class UserAccountPage : TestClientPage
    {
        protected override bool IsAt()
        {
            return driver.Url.Contains("User");
        }

        public UserAccountPage SelectUser()
        {
            try
            {
                IWebElement element = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//table[@id='gvUsers']/tbody/tr[2]/td[6]/a")));
                element.Click();
                validation.StringLogger.LogWrite("Validation for Select User is Passed");
                _test.Log(Status.Pass, "Validation for Select User is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Select User is Failed");
            }
            return this;
        }

    }
}
