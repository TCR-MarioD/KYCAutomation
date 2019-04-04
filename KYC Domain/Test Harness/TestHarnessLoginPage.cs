using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Harness
{
    public class TestHarnessLoginPage : TestClientPage
    {
        static string webApiRadioBtnId = "rdoLoginType_0";
        static string externalServiceRadioBtnId = "rdoLoginType_1";
        static string nextBtnId = "btnNext";
        static string clientCertificateDrpDwnId = "ctl02_ddl_certNames";
        static string accessMethodDrpDwnId = "ctl02_drpAcessMethod";
        static string submitBtnId = "ctl02_btnSubmit";
        static string LoginBtnID = "ctl02_btnLogin";
        private string rdoLoginType_1;

        protected override bool IsAt()
        {
            return driver.Url.Contains("Login");
        }
        public TestHarnessLoginPage() : base(false)
        {
            driver.Navigate().GoToUrl("http://qa-test-kyc.devservices.dh.com/Login.aspx?ReturnUrl=%2fSearch.aspx ");
            AssertIsAt();
        }

        public TestHarnessLoginPage RadioButtonSelect()
        {
            try
            {
               
                IWebElement radio = driver.FindElement(By.Id(externalServiceRadioBtnId));
                radio.Click();
                driver.FindElement(By.Id(nextBtnId)).Click();
                validation.StringLogger.LogWrite("Validation for Test Harness Radio Button is Passed");
                _test.Log(Status.Pass, "Validation for Test Harness Radio Button is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Test Harness Radio Button is Failed");
            }
            return this;
        }
        public TestHarnessLoginPage WebApiradiobuttonselect()
        {
            try
            {
               IWebElement radio = driver.FindElement(By.Id(webApiRadioBtnId));
                radio.Click();
                driver.FindElement(By.Id(nextBtnId)).Click();
                validation.StringLogger.LogWrite("Validation for Test Harness Radio Button is Passed");
                _test.Log(Status.Pass, "Validation for Test Harness Radio Button is Passed");
                driver.FindElement(By.Id("ctl02_txtUserName")).SendKeys(ConfigurationManager.AppSettings["ClientUsername"]);
                driver.FindElement(By.Id("ctl02_txtPassword")).SendKeys(ConfigurationManager.AppSettings["ClientPassword"]);
                driver.FindElement(By.Id(LoginBtnID)).Click();
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Test Harness Radio Button is Failed");
            }
            return this;
        }
        public SearchSubmissionPage SelectDropDown()
        {
            try
            {
                SelectElement certDrpDwn = new SelectElement(driver.FindElement(By.Id(clientCertificateDrpDwnId)));
                certDrpDwn.SelectByText("RBC-kyc.devservices.dh.com");

                SelectElement accessDrpDwn = new SelectElement(driver.FindElement(By.Id(accessMethodDrpDwnId)));
                accessDrpDwn.SelectByText("JSON");

                driver.FindElement(By.Id(submitBtnId)).Click();

                validation.StringLogger.LogWrite("Validation for Test Harness Dropdown Selection is Passed");
                _test.Log(Status.Pass, "Validation for Test Harness Dropdown Selection is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Test Harness Dropdown Selection is Failed");
            }
            return new SearchSubmissionPage();
        }
    }
}
