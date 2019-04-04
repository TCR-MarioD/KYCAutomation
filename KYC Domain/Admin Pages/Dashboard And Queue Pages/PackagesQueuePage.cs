using AventStack.ExtentReports;
using KYC_Domain.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class PackagesQueuePage : AdminPages
    {
        static string packageTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_gvQueues_Cache";
        static string filterButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnFilter";
        static string resetButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnReset";
        static string packageIdBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtPackageID";

        static int packageIdIndex = 0;
        static int dateColumnIndex = 1;
        static int viewLinkColumnIndex = 5;

        TableInterface table;
        string idEntered;

        protected override bool IsAt()
        {
            return driver.Url.Contains("Dashboard_PackageQueue");
        }

        public PackagesQueuePage(bool shouldAssertIsTrue = true) : base(shouldAssertIsTrue)
        {
            table = new TableInterface(packageTableId, driver);
        }

        public PackagesQueuePage VerifyDatesAscendingOrder()
        {
            try
            {
                validation.AssertIsTrue(table.IsColumnInSortedOrder(dateColumnIndex, Order.Ascending));
                validation.StringLogger.LogWrite("Validation for Dates Ascending Order is Passed");
                _test.Log(Status.Pass, "Validation for Dates Ascending Order is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Dates Ascending Order is Failed");
            }
            return this;
        }

        public PackagesQueuePage SortByPackageId()
        {
            try
            {
                table.GetColumnHeaderElement(packageIdIndex).Click();
                validation.StringLogger.LogWrite("Validation for Sort By Package ID is Passed");
                _test.Log(Status.Pass, "Validation for Sort By Package ID is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Sort By Package ID is Failed");
            }
            return this;
        }

        public PackagesQueuePage VerifyPackageIdAscendingOrder()
        {
            try
            {
                validation.AssertIsTrue(table.IsColumnInSortedOrder(packageIdIndex, Order.Ascending));
                validation.StringLogger.LogWrite("Validation for FackageID Ascending Order is Passed");
                _test.Log(Status.Pass, "Validation for FackageID Ascending Order is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for FackageID Ascending Order is Failed");
            }

            return this;
        }

        public PackagesQueuePage WriteRandomToPackageIdBox()
        {
            try
            {
                idEntered = random.Next(1, 10).ToString();

                driver.SendKeysById(packageIdBoxId, idEntered);

                validation.StringLogger.LogWrite("Validation for Entering Values in Package ID Box is Passed");
                _test.Log(Status.Pass, "Validation for Entering Values in Package ID Box is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Entering Values in Package ID Box is Failed");
            }
            return this;
        }

        public PackagesQueuePage ClickFilterButton()
        {
            try
            {
                driver.ClickById(filterButtonId);
                validation.StringLogger.LogWrite("Validation for Filter Button is Passed");
                _test.Log(Status.Pass, "Validation for Filter Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Filter Button is Failed");
            }
            return this;
        }

        public PackagesQueuePage ClickResetButton()
        {
            try
            {
                driver.ClickById(resetButtonId);
                validation.StringLogger.LogWrite("Validation for Reset Button is Passed");
                _test.Log(Status.Pass, "Validation for Reset Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Reset Button is Failed");
            }
            return this;
        }

        public PackagesQueuePage VerifyPackagesFilteredByRandom()
        {
            try
            {
                validation.AssertIsTrue(table.GetElementByIndexes(0, packageIdIndex).Text.StartsWith(idEntered));
                validation.StringLogger.LogWrite("Validation for Packages Filtered By Indexes is Passed");
                _test.Log(Status.Pass, "Validation for Packages Filtered By Indexes is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Packages Filtered By Indexes is Failed");
            }
            return this;
        }

        public PackageSummaryPage ViewFirstPackage()
        {
            try
            {

                table.GetElementByIndexes(0, viewLinkColumnIndex).Click();
                validation.StringLogger.LogWrite("Validation for Viewing First Package is Passed");
                _test.Log(Status.Pass, "Validation for Viewing First Package is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Viewing First Package is Passed");
            }
            return new PackageSummaryPage();
        }
    }
}
