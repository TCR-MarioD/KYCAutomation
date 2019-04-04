using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace KYC_Domain.Client_Pages
{
    public class ClientForgotLoginCredentialsPage : ClientPages
    {
        static string cancelButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_btnBack";

        protected override bool IsAt()
        {
            return driver.Url.Contains("ForgotPassword") && !driver.Url.Contains("admin");
        }

        public ClientLoginPage ClickCancelButton()
        {
            try
            {
                driver.ClickById(cancelButtonId);
                validation.StringLogger.LogWrite("Validation for Cancel Button is Passed");
                _test.Log(Status.Pass, "Validation for Cancel Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Cancel Button is Failed");
            }
            return new ClientLoginPage();
        }
    }
}

