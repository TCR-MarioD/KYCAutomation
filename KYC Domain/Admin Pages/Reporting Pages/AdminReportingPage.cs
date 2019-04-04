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
    public class AdminReportingPage : AdminPages
    {
        static string packageItemsTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_grdPackageItems";

        static int viewLinkIndex = 8;

        TableInterface table;

        internal AdminReportingPage()
        {
            driver.FindElement(By.LinkText("Package items on hold for Invoice")).Click();
            table = new TableInterface(packageItemsTableId, driver);
        }

        protected override bool IsAt()
        {
            return driver.Url.Contains("Reports_Home.aspx");
        }

        public PackageResultsPage ViewFirstPackageItem()
        {
            try
            {
                table.GetElementByIndexes(0, viewLinkIndex).Click();
                driver.AcceptAlert();
                validation.StringLogger.LogWrite("Validation for Viewing First Package Item is Passed");
                _test.Log(Status.Pass, "Validation for Viewing First Package Item is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Viewing First Package Item is Failed");
            }
            return new PackageResultsPage();
        }
    }
}
