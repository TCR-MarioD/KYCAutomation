using AventStack.ExtentReports;
using KYC_Domain.Base_Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class AdminNavBar : AdminPages
    {
        static string dashboardButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl0_NavigationBar_HyperLink";
        static string searchButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl1_NavigationBar_HyperLink";
        static string reportingButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl2_NavigationBar_HyperLink";
        static string manageUserButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl3_NavigationBar_HyperLink";
        static string billingPricingButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl4_NavigationBar_HyperLink";
        static string clientManagementButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl5_NavigationBar_HyperLink";
        static string maintenanceButtonId = "ctl00_ctl00_ContentPlaceHolder1_NavBar_Master_NavLinks_ctrl6_NavigationBar_HyperLink";
        static string logoutLinkId = "ctl00_ctl00_ContentPlaceHolder1_btnLogout";

        public AdminDashboardPage GoToDashboard()
        {
            try
            {
                driver.FindElement(By.Id(dashboardButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for AdminNavBar Dashboard Button is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Dashboard Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Dashboard Button is Failed");
            }
            return new AdminDashboardPage();
        }

        public AdminSearchPage GoToSearch()
        {
            try
            {
                driver.FindElement(By.Id(searchButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for AdminNavBar Search functionality is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Search functionality is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Search functionality is Failed");
            }

            return new AdminSearchPage();
        }

        public AdminReportingPage GoToReporting()
        {
            try
            {
                driver.FindElement(By.Id(reportingButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for AdminNavBar Reporting Button is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Reporting Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Reporting Button is Failed");
            }

            return new AdminReportingPage();
        }

        public AdminManageUserPage GoToManageUser()
        {
            try
            {
                driver.FindElement(By.Id(manageUserButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for AdminNavBar Manage User Button is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Manage User Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Manage User Button is Failed");
            }
            return new AdminManageUserPage();
        }

        public BillingPricingPage GoToBillingPricing()
        {
            try
            {
                driver.FindElement(By.Id(billingPricingButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for AdminNavBar Billing Pricing Button is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Billing Pricing Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Billing Pricing Button is Failed");
            }

            return new BillingPricingPage();
        }

        public ClientManagementPage GoToClientManagement()
        {
            try
            {

                driver.FindElement(By.Id(clientManagementButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for AdminNavBar Client Management Button is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Client Management Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Client Management Button is Failed");
            }
            return new ClientManagementPage();
        }

        public MaintenancePage GoToMaintenance()
        {
            try
            {
                driver.FindElement(By.Id(maintenanceButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for AdminNavBar Maintenance Button is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Maintenance Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Maintenance Button is Failed");
            }
            return new MaintenancePage();
        }

        public NeedHelpPageTemp<AdminPages> NeedHelp()
        {
            try
            {
                driver.FindElement(By.LinkText("Need Help")).Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                validation.StringLogger.LogWrite("Validation for AdminNavBar Need Help Link is Passed");
                _test.Log(Status.Pass, "Validation for AdminNavBar Need Help Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for AdminNavBar Need Help Link is Failed");
            }
            return new NeedHelpPageTemp<AdminPages>(this);
        }

        public void LogOut()
        {
            Thread.Sleep(5000);
            try
            {
                driver.FindElement(By.Id(logoutLinkId)).Click();
                validation.StringLogger.LogWrite("Successfully Logged out");
                _test.Log(Status.Pass, "Successfully Logged out");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Logout is not successfull");
            }

        }

        protected override bool IsAt()
        {
            try
            {
                driver.FindElement(By.Id(dashboardButtonId));
                return true;
            }
            catch (Exception) { }
            return false;
        }

        public AdminNavBar VerifyBreadcrumbExists(string linkText)
        {
            try
            {
                driver.FindElement(By.LinkText(linkText));
                validation.StringLogger.LogWrite("Validation for AdminNavBar " + linkText + " Bread Crumb Existance is Passed");
            }
            catch (Exception)
            {
                validation.AssertFail("Breadcrumb link '" + linkText + "' can't be found");
                validation.StringLogger.LogWrite("Validation for AdminNavBar" + linkText + " Bread Crumb Existance is Failed");
            }

            return this;
        }
    }
}
