using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public abstract class BaseSearchResultsPage : ClientPages
    {
        static string exitESearchArchiveDatabaseButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchArchive_btnPreSearch";

        public abstract bool IsActiveEnterprise(int enterpriseRowIndex);

        public abstract BaseSearchResultsPage SelectEnterprise(int enterpriseRowIndex);

        public abstract ServiceSelectionPage ClickContinueButton();

        public SearchOverridePage ContinueWithOriginalSearchCriteria()
        {
            try
            {
                driver.FindElement(By.LinkText("Click Here")).Click();
                validation.StringLogger.LogWrite("Validation for Continuing with Original Search Criteria is Passed");
                _test.Log(Status.Pass, "Validation for Continuing with Original Search Criteria is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Continuing with Original Search Criteria is Failed");
            }
            return new SearchOverridePage();
        }

        public abstract BaseSearchResultsPage VerifyPreSearchCriteria(string preSearchEnterpriseName, string preSearchJurisdiction);

        protected BaseSearchResultsPage() : base(false)
        {
            if (driver.FindElement(By.ClassName("data_heading")).Text == "eSearch Archive Database")
                driver.FindElement(By.Id(exitESearchArchiveDatabaseButtonId)).Click();

            AssertIsAt();

        }
    }
}
