using AventStack.ExtentReports;
using KYC_Domain.Helper_Classes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class ManualWorkQueuePage : AdminPages
    {
        static string availableTabId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_rpMenu_ctl00_btnMenuItem";
        static string toBeParsedTabId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_rpMenu_ctl01_btnMenuItem";
        static string invalidTabId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_rpMenu_ctl02_btnMenuItem";
        static string waitingTabId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_rpMenu_ctl03_btnMenuItem";
        static string packageTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_gvWorkQueues";
        static string jurisdictionSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlJurisdiction";
        static string filterButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnFilter";

        static int jurisdictionIndex = 2;
        static int viewLinkIndex = 7;

        TableInterface table;

        internal ManualWorkQueuePage() : base(true)
        {
            table = new TableInterface(packageTableId, driver);
        }

        protected override bool IsAt()
        {
            if (!driver.Url.Contains("Dashboard_WorkQueue"))
                return false;
            try
            {
                return driver.FindElement(By.ClassName("bigheading")).Text.Contains("Manual Work Queue");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ManualWorkQueuePage ClickAvailableTab()
        {
            try
            {

                driver.ClickById(availableTabId);
                validation.StringLogger.LogWrite("Validation for Clicking Available Tab is Passed");
                _test.Log(Status.Pass, "Validation for Clicking Available Tab is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clicking Available Tab is Failed");
            }
            return this;
        }

        public ManualWorkQueuePage ClickToBeParsedTab()
        {
            try
            {
                driver.ClickById(toBeParsedTabId);
                validation.StringLogger.LogWrite("Validation for Clicking Parsed Tab is Passed");
                _test.Log(Status.Pass, "Validation for Clicking Parsed Tab is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clicking Parsed Tab is Failed");
            }
            return this;
        }

        public ManualWorkQueuePage ClickInvalidTab()
        {
            try
            {
                driver.ClickById(invalidTabId);
                validation.StringLogger.LogWrite("Validation for Clicking Invalid Tab Passed");
                _test.Log(Status.Pass, "Validation for Clicking Invalid Tab is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clicking Invalid Tab is Failed");
            }
            return this;
        }

        public ManualWorkQueuePage ClickWaitingTab()
        {
            try
            {
                driver.ClickById(waitingTabId);
                validation.StringLogger.LogWrite("Validation for Clicking Waiting Tab is Passed");
                _test.Log(Status.Pass, "Validation for Clicking Waiting Tab is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clicking Waiting Tab is Failed");
            }
            return this;
        }

        public PackageResultsPage ViewFirstPackage()
        {
            try
            {
                table.GetElementByIndexes(0, viewLinkIndex).Click();
                validation.StringLogger.LogWrite("Validation for Viewing First Package is Passed");
                _test.Log(Status.Pass, "Validation for Viewing First Package is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Viewing First Package is Failed");
            }
            return new PackageResultsPage();
        }

        public ManualWorkQueuePage SelectJurisdiction(string jurisdiction)
        {
            try
            {
                driver.SelectValueById(jurisdictionSelectId, jurisdiction);
                validation.StringLogger.LogWrite("Validation for Selecting Jurisdiction is Passed");
                _test.Log(Status.Pass, "Validation for Selecting Jurisdiction is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Selecting Jurisdiction is Failed");
            }

            return this;
        }

        public ManualWorkQueuePage VerifyPackageIsOfJurisdiction(string jurisdiction)
        {
            try
            {
                validation.AssertAreEqual(jurisdiction, table.GetElementByIndexes(0, jurisdictionIndex).Text);
                validation.StringLogger.LogWrite("Validation for Package is of " + jurisdiction + " is Passed");
                _test.Log(Status.Pass, "Validation for Package is of " + jurisdiction + " is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Package is of " + jurisdiction + " is Failed");
            }
            return this;
        }

        public ManualWorkQueuePage ClickFilterButton()
        {
            try
            {
                driver.ClickById(filterButtonId);
                validation.StringLogger.LogWrite("Validation for Clicking Filter Button is Passed");
                _test.Log(Status.Pass, "Validation for Clicking Filter Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clicking Filter Button is Failed");
            }
            return this;
        }
    }
}
