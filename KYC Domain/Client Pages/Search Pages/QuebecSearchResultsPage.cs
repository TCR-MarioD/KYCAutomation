using KYC_Domain.Helper_Classes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYC_Domain.Data_Management;

namespace KYC_Domain.Client_Pages
{
    public class QuebecSearchResultsPage : BaseSearchResultsPage
    {
        static string continueButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchCIDREQ_UserControl_SearchCIDREQ_btnSubmit";
        static string quebecNamesDatabaseTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchCIDREQ_grdSearchCIDREQ";

        static int selectEnterpriseColumnIndex = 0;
        static int enterpriseNameColumnIndex = 1;
        static int enterpriseJurisdictionColumnIndex = 3;
        static int enterpriseStatusColumnIndex = 5;

        TableInterface table;

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Search"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("data_heading")).Text == "Search Criteria Results";
                    //return driver.FindElement(By.ClassName("data_heading")).Text == "Quebec Names Database";
                }
                catch (Exception) { }
            }
            return false;
        }

        public QuebecSearchResultsPage() : base()
        {
            table = new TableInterface(quebecNamesDatabaseTableId, driver);
        }

        public override ServiceSelectionPage ClickContinueButton()
        {
            driver.FindElement(By.Id(continueButtonId)).Click();
            return new ServiceSelectionPage();
        }

        public override bool IsActiveEnterprise(int enterpriseRowIndex)
        {
            try
            {
                string description = table.GetElementByIndexes(enterpriseRowIndex, enterpriseStatusColumnIndex).Text;
                return description.Contains("Immatriculée") && description.Contains("En vigueur");
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

        // only functional when search returns results
        public override BaseSearchResultsPage VerifyPreSearchCriteria(string preSearchEnterpriseName, string preSearchJurisdiction)
        {
            bool nameMatch = table.GetElementByIndexes(0, enterpriseNameColumnIndex).Text.ToLower().Contains(preSearchEnterpriseName.ToLower());
            bool jurisdictionMatch = table.GetElementByIndexes(0, enterpriseJurisdictionColumnIndex).Text == preSearchJurisdiction;
            validation.AssertIsTrue(nameMatch && jurisdictionMatch, "Pre-search criteria does not match Quebec results");
            return this;
        }
    }
}
