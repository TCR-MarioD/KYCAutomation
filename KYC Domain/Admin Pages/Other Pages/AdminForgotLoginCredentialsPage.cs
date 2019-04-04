using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace KYC_Domain.Admin_Pages
{
    public class AdminForgotLoginCredentialsPage : AdminPages
    {
        static string cancelButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnBack";

        protected override bool IsAt()
        {
            return driver.Url.Contains("ForgotPassword") && driver.Url.Contains("admin");
        }

        public AdminLoginPage ClickCancelButton()
        {
            try
            {
                driver.ClickById(cancelButtonId);
                validation.StringLogger.LogWrite("Validation for Cancel button is Passed");
                _test.Log(Status.Pass, "Validation for Cancel button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Cancel button is Failed");
            }

            return new AdminLoginPage();
        }
    }
}

