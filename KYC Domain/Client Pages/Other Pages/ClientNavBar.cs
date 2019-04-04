using AventStack.ExtentReports;
using KYC_Domain;
using KYC_Domain.Base_Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class ClientNavBar : ClientPages
    {
        static string homeButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl0_NavigationBar_HyperLink";
        static string searchButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl1_NavigationBar_HyperLink";
        static string resultsButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl2_NavigationBar_HyperLink";
        static string dashboardButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl3_NavigationBar_HyperLink";
        static string manageUserButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl4_NavigationBar_HyperLink";
        static string logoutLinkId = "ctl00_ctl00_ContentPlaceHolder1_lnkLogoff";

        public HomePage GoToHome()
        {
            try
            {
                driver.FindElement(By.Id(homeButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Home Button is Passed");
                _test.Log(Status.Pass, "Validation for Home Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Home Button is Failed");
            }
            return new HomePage();
        }

        public SearchCriteriaPage GoToSearch()
        {
            try
            {
                driver.FindElement(By.Id(searchButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Search Button is Passed");
                _test.Log(Status.Pass, "Validation for Search Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Search Button is Failed");
            }
            return new SearchCriteriaPage();
        }

        public ResultQueuePage GoToResults()
        {
            while (true) //Band-aid solution (see issue #39 on github)
            {
                try
                {
                    driver.FindElement(By.Id(resultsButtonId)).Click();
                    validation.StringLogger.LogWrite("Validation for Results Button is Passed");
                    _test.Log(Status.Pass, "Validation for Results Button is Passed");
                    break;
                }
                catch (InvalidOperationException) { _test.Log(Status.Fail, "Validation for Results Button is Failed"); }
            }
            return new ResultQueuePage();
        }

        public DashboardHubPage GoToDashboard()
        {
            try
            {
                driver.FindElement(By.Id(dashboardButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Dashboard Button is Passed");
                _test.Log(Status.Pass, "Validation for Dashboard Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Dashboard Button is Failed");
            }
            return new DashboardHubPage();
        }

        public ManageUsersPage GoToManageUser()
        {
            try
            {
                driver.FindElement(By.Id(manageUserButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Manage User Button is Passed");
                _test.Log(Status.Pass, "Validation for Manage User Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Manage User Button is Failed");
            }
            return new ManageUsersPage();
        }

        public void LogOut()
        {
            Thread.Sleep(5000);
            try
            {
                driver.FindElement(By.Id(logoutLinkId)).Click();
                Thread.Sleep(5000);
                validation.StringLogger.LogWrite("Validation for Logout Link is Passed");
                _test.Log(Status.Pass, "Validation for Logout Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Logout Link is Failed");
            }
        }

        public NeedHelpPageTemp<ClientPages> NeedHelp()
        {
            try
            {
                driver.FindElement(By.LinkText("Need Help")).Click();
                Thread.Sleep(6000);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                validation.StringLogger.LogWrite("Validation for Need Help Link is Passed");
                _test.Log(Status.Pass, "Validation for Need Help Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Need Help Link is Failed");
            }
            return new NeedHelpPageTemp<ClientPages>(this);
        }

        public ClientNavBar VerifyBreadcrumbLinkExists()
        {
            try
            {
                driver.FindElement(By.LinkText("Home"));
                validation.StringLogger.LogWrite("Validation for BreadCrumb Links is Passed");
                _test.Log(Status.Pass, "Validation for BreadCrumb Links is Passed");
            }
            catch (Exception)
            {
                validation.AssertFail("Breadcrumb links missing");
                _test.Log(Status.Fail, "Validation for BreadCrumb Links is Failed");
            }
            return this;
        }

        private void ClickBreadcrumbLink(string breadcrumbLinkText)
        {
            driver.FindElement(By.LinkText(breadcrumbLinkText)).Click();
        }

        protected override bool IsAt()
        {
            try
            {
                driver.FindElement(By.Id(homeButtonId));
                return true;
            }
            catch (Exception) { }
            return false;
        }
    }
}
