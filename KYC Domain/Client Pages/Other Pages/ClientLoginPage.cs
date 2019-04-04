using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace KYC_Domain.Client_Pages
{
    public class ClientLoginPage : ClientPages
    {
        static string forgotUsernamePasswordLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_LoginUser_hlForgotPassword";
        static string usernameInputBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_LoginUser_UserName";
        static string passwordInputBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_LoginUser_Password";
        static string loginButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_LoginUser_LoginButton";
        static string loginButtonName = "ctl00$ctl00$ContentPlaceHolder1$ContentPlaceHolder_Body$ctl00$LoginUser$LoginButton";
        private readonly object _name;
        private object _driver;

        internal ClientLoginPage() : base(false)
        {
            if (!IsAt())
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["ClientUrl"]);
            AssertIsAt();
        }

        protected override bool IsAt()
        {
            return driver.Url.Contains("Login") && !driver.Url.Contains("admin");
        }

        //public void EnterCaptcha()
        //{
        //    try
        //    {
        //        string verificationCode = driver.FindElement(By.Id("mainCaptcha")).Text;

        //        driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_LoginUser_txtVerificationCode")).SendKeys(verificationCode);

        //        validation.StringLogger.LogWrite("Validation for Enter Captcha is Passed");
        //        _test.Log(Status.Pass, "Validation for Enter Captcha is Passed");
        //    }
        //    catch (System.Exception)
        //    {

        //        _test.Log(Status.Fail, "Validation for Enter Captcha is Failed");
        //    }
        //}

        public HomePage LogIn()
        {
            // EnterCaptcha();
            try
            {
                driver.FindElement(By.Id(usernameInputBoxId)).SendKeys(ConfigurationManager.AppSettings["ClientUsername"]);

                driver.FindElement(By.Id(passwordInputBoxId)).SendKeys(ConfigurationManager.AppSettings["ClientPassword"]);
                driver.FindElement(By.Id(loginButtonId)).SendKeys(Keys.Enter);
                // driver.FindElement(By.Id(loginButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for LogIn Page is Passed");
                Thread.Sleep(5000);
                _test.Log(Status.Pass, "Validation for LogIn Page is Passed");
            }
            catch (System.Exception)
            {

                _test.Log(Status.Fail, "Validation for LogIn Page is Failed");
            }
            return new HomePage();
        }

        public ClientForgotLoginCredentialsPage ClickForgotUsernamePasswordLink()
        {
            try
            {
                driver.FindElement(By.Id(forgotUsernamePasswordLinkId)).Click();
                validation.StringLogger.LogWrite("Validation for Forgot Username Password Link is Passed");
                _test.Log(Status.Pass, "Validation for Forgot Username Password Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Forgot Username Password Link is Failed");
            }
            return new ClientForgotLoginCredentialsPage();
        }

        public ClientLoginPage ClickTermsandconditionsLink()
        {
            try
            {
                driver.FindElement(By.LinkText("Terms & Conditions")).Click();
                try
                {
                    driver.PageSource.Equals("mario");
                }
                catch
                {
                    Assert.Pass("Pass");
                }
                driver.FindElement(By.LinkText("Privacy & Anti-Spam")).Click();
                driver.FindElement(By.LinkText("AODA")).Click();
                Thread.Sleep(6000);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Terms & Conditions page is Failed");
            }
            return new ClientLoginPage();
                //public override ClientNavBar NavBar => throw new System.AccessViolationException("LoginPage cannot access the NavBar");
        }
    }
}
