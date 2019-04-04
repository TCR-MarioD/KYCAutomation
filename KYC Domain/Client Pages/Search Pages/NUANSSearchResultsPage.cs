using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYC_Domain.Helper_Classes;
using KYC_Domain.Data_Management;

namespace KYC_Domain.Client_Pages
{
    public class NUANSSearchResultsPage : BaseSearchResultsPage
    {
        static string nuansNamesDatabaseTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchNUANS_grdSearchNUANS";
        static string continueButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchNUANS_UserControl_SearchNUANS_btnSubmit";

        static int selectEnterpriseColumnIndex = 0;
        static int enterpriseNameColumnIndex = 1;
        static int enterpriseJurisdictionColumnIndex = 3;
        static int enterpriseStatusColumnIndex = 6;

        TableInterface table;

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Search"))
            {
                try
                {
                    //return driver.FindElement(By.ClassName("data_heading")).Text == "NUANS Names Database";
                    return driver.FindElement(By.ClassName("data_heading")).Text == "Search Criteria Results";
                }
                catch (Exception) { }
            }
            return false;
        }

        public NUANSSearchResultsPage() : base()
        {
            table = new TableInterface(nuansNamesDatabaseTableId, driver);
        }

        public override bool IsActiveEnterprise(int enterpriseRowIndex)
        {
            try
            {
                return table.GetElementByIndexes(enterpriseRowIndex, enterpriseStatusColumnIndex).Text == "ACTIVE";
            }
            catch (IndexOutOfRangeException)
            {
                validation.AssertFail("No services remain that match the test data criteria");
                return false;
            }
        }

        public override BaseSearchResultsPage SelectEnterprise(int enterpriseRowIndex)
        {
            table.GetElementByIndexes(enterpriseRowIndex, selectEnterpriseColumnIndex).Click();
            DynamicTestInformation.enterpriseName = table.GetElementByIndexes(enterpriseRowIndex, enterpriseNameColumnIndex).Text;
            return this;
        }

        public override ServiceSelectionPage ClickContinueButton()
        {
            driver.FindElement(By.Id(continueButtonId)).Click();
            return new ServiceSelectionPage();
        }

        public override BaseSearchResultsPage VerifyPreSearchCriteria(string preSearchEnterpriseName, string preSearchJurisdiction)
        {
            bool nameMatch = table.GetElementByIndexes(0, enterpriseNameColumnIndex).Text.ToLower().Contains(preSearchEnterpriseName.ToLower());
            bool jurisdictionMatch = table.GetElementByIndexes(0, enterpriseJurisdictionColumnIndex).Text == preSearchJurisdiction;
            validation.AssertIsTrue(nameMatch && jurisdictionMatch, "Pre-search criteria does not match NUANS results");
            return this;
        }
    }
}
