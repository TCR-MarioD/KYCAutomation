using System;
using OpenQA.Selenium;
using KYC_Domain.Helper_Classes;
using System.Collections.Generic;
using AventStack.ExtentReports;
using OpenQA.Selenium.Interactions;
using System.Threading;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace KYC_Domain.Client_Pages
{
    public class ResultSummaryPage : ClientPages
    {
        static string searchInformationTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsSummary_tblResultsSummary";
        static string searchStatusTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsSummary_tblResultsSummaryReports";
        static string displayMaterialChangesButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsSummary_btnShow";
        static string pdfImageXPath = "//table[@id='ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsSummary_tblResultsSummaryReports']/tbody/tr[2]/td[4]/a/img";
        static string backButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_ResultsDiary_UserControl_ResultsDiary_btnBack";

        static int dataColumnIndex = 1;
        static int enterpriseNameRowIndex = 0;
        static int jurisdictionRowIndex = 4;

        static int searchTypeColumnIndex = 0;
        static int searchStatusColumnIndex = 2;

        TableInterface informationTable;
        TableInterface statusTable;

        public ResultSummaryPage()
        {
            informationTable = new TableInterface(searchInformationTableId, driver);
            statusTable = new TableInterface(searchStatusTableId, driver);
        }

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Results"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "eSearch Summary";
                }
                catch (Exception) { }
            }
            return false;
        }

        public ResultSummaryPage VerifyEnterpriseMatch(string expectedEnterprise)
        {
            try
            {
                validation.AssertAreEqual(expectedEnterprise, informationTable.GetElementByIndexes(enterpriseNameRowIndex, dataColumnIndex).Text);
                validation.StringLogger.LogWrite("Validation for Enterprise Match is Passed");
                _test.Log(Status.Pass, "Validation for Enterprise Match is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Enterprise Match is Failed");
            }
            return this;
        }

        public ResultSummaryPage VerifyJurisdictionMatch(string expectedJurisdiction)
        {
            try
            {
                validation.AssertAreEqual(expectedJurisdiction, informationTable.GetElementByIndexes(jurisdictionRowIndex, dataColumnIndex).Text);
                validation.StringLogger.LogWrite("Validation for Jurisdiction Match is Passed");
                _test.Log(Status.Pass, "Validation for Jurisdiction Match is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Jurisdiction Match is Failed");
            }
            return this;
        }

        public string GetServiceStatus(string serviceType)
        {
            int totalNumRows = statusTable.GetTotalNumRows();

            for (int i = 0; i < totalNumRows; ++i)
            {
                if (statusTable.GetElementByIndexes(i, searchTypeColumnIndex).Text == serviceType)
                    return statusTable.GetElementByIndexes(i, searchStatusColumnIndex).Text;
            }
            throw new Exception("Desired search type not found in table");
        }

        public ResultSummaryPage VerifySearchStatusCompleted(string[] servicesSearched)
        {
            try
            {
                foreach (string service in servicesSearched)
                {
                    validation.AssertAreEqual("Completed", GetServiceStatus(service));
                    validation.StringLogger.LogWrite("Validation for Completion of Search Status is Passed");
                    _test.Log(Status.Pass, "Validation for Completion of Search Status is Passed");
                }
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Completion of Search Status is Failed");
            }

            return this;
        }

        public ResultQueuePage BackToResultQueue()
        {
            try
            {
                // After using TestStack.White to send the RETURN key in the ResultSummaryPage class,
                // the IWebDriver will become unresponsive for one command. 
                // The back button is clicked twice here as a hacky workaround
                driver.FindElement(By.Id(backButtonId)).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.Id(backButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Back Button is Passed");
                _test.Log(Status.Pass, "Validation for Back Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Back Button is Failed");
            }
            return new ResultQueuePage();
        }

        /// <summary>
        /// Opens the top PDF in the table located on the ResultSummaryPage
        /// </summary>
        /// <returns>ResultSummaryPage</returns>
        public ResultSummaryPage OpenPDF()
        {

            IWebElement pdf = driver.FindElement(By.XPath(pdfImageXPath));

            try
            {
                pdf.Click();
                validation.StringLogger.LogWrite("Validation for PDF Context Click is Passed");
                _test.Log(Status.Pass, "Validation for PDF Context Click is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for PDF Context Click is Failed");
            }

            // Get the current active window
            string parentHandle = driver.CurrentWindowHandle;

            Thread.Sleep(6000);

            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F6);
            //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            //yboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(6000);

            // Ensures that the current handle is the one we want
            foreach (string handle in driver.WindowHandles)
            {
                if (handle.Equals(parentHandle))
                {
                    driver.SwitchTo().Window(handle);
                }
            }

            return this;
        }

        public MaterialChangesPage DisplayMaterialChanges()
        {
            try
            {
                driver.ClickById(displayMaterialChangesButtonId);
                validation.StringLogger.LogWrite("Validation for Display Material Changes Button is Passed");
                _test.Log(Status.Pass, "Validation for Display Material Changes Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Display Material Changes Button is Failed");
            }
            return new MaterialChangesPage();
        }

        public ResultSummaryPage VerifyTablesStructure()
        {
            try
            {
                //Checks that the various "tables" have the correct structure
                var rows = driver.FindElement(By.Id(searchInformationTableId)).FindElements(By.TagName("tr"));

                for (int i = 0; i < rows.Count; ++i)
                {
                    if (i == 0 || i == 9 || i == 13 || i == 17 || i == 21)
                        validation.AssertIsTrue(rows[i].FindElements(By.TagName("th")).Count == 3);
                    else if (i == 8 || i == 12 || i == 16 || i == 20)
                        validation.AssertIsTrue(rows[i].GetAttribute("class") == "emptyrow");
                    else if (i == 1 || i == 10 || i == 14 || i == 18 || i == 22)
                        validation.AssertIsTrue(rows[i].FindElements(By.TagName("td")).Count == 4);
                }
                validation.StringLogger.LogWrite("Validation for table Structure is Passed");
                _test.Log(Status.Pass, "Validation for table Structure is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for table Structure is Failed");
            }
            return this;
        }
    }
}
