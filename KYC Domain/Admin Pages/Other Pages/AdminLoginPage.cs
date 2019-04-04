using AventStack.ExtentReports;
using DHUIFramework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace KYC_Domain.Admin_Pages
{
    public class AdminLoginPage : AdminPages
    {
        static string usernameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_LoginUser_UserName";
        static string passwordBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_LoginUser_Password";
        static string loginButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_LoginUser_LoginButton";
        static string forgotUsernamePasswordLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_LoginUser_hlForgotPassword";

        protected override bool IsAt()
        {
            return driver.Url.Contains("Login") && driver.Url.Contains("admin");
        }

        public AdminLoginPage() : base(false)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["AdminUrl"]);
            AssertIsAt();
        }

        public AdminDashboardPage LogIn()
        {
            try
            {

                driver.FindElement(By.Id(usernameBoxId)).SendKeys(ConfigurationManager.AppSettings["AdminUsername"]);

                driver.FindElement(By.Id(passwordBoxId)).SendKeys(ConfigurationManager.AppSettings["AdminPassword"]);

                driver.FindElement(By.Id(loginButtonId)).SendKeys(Keys.Enter);

                Thread.Sleep(6000);
                validation.StringLogger.LogWrite("Validation for Admin Dashboard LogIn Page is Passed");
                _test.Log(Status.Pass, "Admin Login is Successfull");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Admin Login is Failed");
            }

            return new AdminDashboardPage();
        }

        public AdminForgotLoginCredentialsPage ClickForgotUsernamePasswordLink()
        {
            try
            {
                //driver.FindElement(By.XPath("//a[@id='dummyID']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_LoginUser_hlForgotPassword']")).Click();
                validation.StringLogger.LogWrite("Validation for Forgot Username Password Link is Passed");
                _test.Log(Status.Pass, "Validation for Forgot Username Password Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Forgot Username Password Link is Failed");
            }
            return new AdminForgotLoginCredentialsPage();

        }
    }
}
