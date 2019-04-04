using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace KYC_Domain.Client_Pages
{
    public class HomePage : ClientPages
    {
        static string launchSearchButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ctrlFeatureWindow_DataList1_ctl01_FeatureWindow_HyperLink2";
        static string launchResultsButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ctrlFeatureWindow_DataList1_ctl02_FeatureWindow_HyperLink2";
        static string launchDashboardButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ctrlFeatureWindow_DataList1_ctl03_FeatureWindow_HyperLink2";
        static string launchManageUserButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ctrlFeatureWindow_DataList1_ctl04_FeatureWindow_HyperLink2";

        protected override bool IsAt()
        {
            return driver.Url.Contains("Home");
        }

        public SearchCriteriaPage LaunchSearch()
        {
            try
            {
               // driver.FindElement(By.Id(launchSearchButtonId)).Click();
                driver.FindElement(By.Id(launchSearchButtonId)).SendKeys(Keys.Enter);
                validation.StringLogger.LogWrite("Validation for Launch Search Button is Passed");
                _test.Log(Status.Pass, "Validation for Launch Search Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Launch Search Button is Failed");
            }
            return new SearchCriteriaPage();
        }

        public ResultQueuePage LaunchResults()
        {
            try
            {
                driver.FindElement(By.Id(launchResultsButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Launch Results Button is Passed");
                _test.Log(Status.Pass, "Validation for Launch Results Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Launch Results Button is Failed");
            }
            return new ResultQueuePage();
        }

        public DashboardHubPage LaunchDashboard()
        {
            try
            {
                driver.FindElement(By.Id(launchDashboardButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Launch Dashboard Button is Passed");
                _test.Log(Status.Pass, "Validation for Launch Dashboard Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Launch Dashboard Button is Failed");
            }
            return new DashboardHubPage();
        }

        public ManageUsersPage LaunchManageUser()
        {
            try
            {
                driver.FindElement(By.Id(launchManageUserButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Launch Manage User Button is Passed");
                _test.Log(Status.Pass, "Validation for Launch Manage User Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Launch Manage User Button is Failed");
            }
            return new ManageUsersPage();
        }
    }
}
