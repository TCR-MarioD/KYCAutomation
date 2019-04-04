using AventStack.ExtentReports;
using DHUIFramework;
using KYC_Domain.Client_Pages.Search_Pages;
using KYC_Domain.Data_Management;
using KYC_Domain.Helper_Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace KYC_Domain.Client_Pages
{
    public enum InputBoxesEnum
    {
        EnterpriseNameBox,
        EnterpriseNumberBox,
        ReferenceNumberBox
    };

    public class SearchCriteriaPage : ClientPages
    {
        static string enterpriseNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchInput_txtName";
        static string jurisdictionSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchInput_ddlJurisdictions";
        static string enterpriseNumberBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchInput_txtNumber";
        static string referenceNumberBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchInput_txtReferenceNumber";
        static string searchButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchInput_UserControl_SearchInput_btnSubmit";

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Search"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "eSearch";
                }
                catch (Exception) { }
            }
            return false;
        }

        private string GetIdByEnum(InputBoxesEnum box)
        {
            if (box == InputBoxesEnum.EnterpriseNameBox)
                return enterpriseNameBoxId;
            if (box == InputBoxesEnum.EnterpriseNumberBox)
                return enterpriseNumberBoxId;
            return referenceNumberBoxId;
        }

        public SearchCriteriaPage WriteToInputBox(InputBoxesEnum box, string text)
        {
            try
            {
                driver.SendKeysById(GetIdByEnum(box), text);
                validation.StringLogger.LogWrite("Validation for Entering value in Input Box is Passed");
                _test.Log(Status.Pass, "Validation for Entering value in Input Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Entering value in Input Box is Failed");
            }
            return this;
        }

        public SearchCriteriaPage VerifyInputBoxState(InputBoxesEnum box, bool state)
        {
            try
            {
                validation.AssertAreEqual(state, driver.FindElement(By.Id(GetIdByEnum(box))).Enabled, "Box availability is wrong on Search Criteria Page.");
                validation.StringLogger.LogWrite("Validation for Input Box State is Passed");
                _test.Log(Status.Pass, "Validation for Input Box State is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Input Box State is Failed");
            }
            return this;
        }

        public SearchCriteriaPage ClearInputBox(InputBoxesEnum box)
        {
            try
            {
                driver.FindElement(By.Id(GetIdByEnum(box))).Clear();
                validation.StringLogger.LogWrite("Validation for Clear Input Box is Passed");
                _test.Log(Status.Pass, "Validation for Clear Input Box is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Clear Input Box is Failed");
            }
            return this;
        }

        /// <summary>
        /// This method submits the search criteria entered on the page and proceeds to a search results page,
        /// either NUANS or Quebec. Will not work properly with a US or International Jurisdiction. For those
        /// jurisdictions, use SubmitSearchCriteriaOverride()
        /// </summary>
        /// <returns></returns>
        public BaseSearchResultsPage SubmitSearchCriteriaNamesDatabase()
        {
            string jurisdiction = new SelectElement(driver.FindElement(By.Id(jurisdictionSelectId))).SelectedOption.Text;

            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    driver.FindElement(By.Id(searchButtonId)).Click();
                    staleElement = false;
                    validation.StringLogger.LogWrite("Validation for Save Override Button is Passed");
                    _test.Log(Status.Pass, "Validation for Save Override Button is Passed");
                }
                catch (Exception)
                {

                    staleElement = true;
                }
            }

            //driver.FindElement(By.Id(searchButtonId)).Click();

            if (jurisdiction == "Quebec")
                return new QuebecSearchResultsPage();

            return new NUANSSearchResultsPage();


        }

        /// <summary>
        /// This method submits the search criteria entered on the page and proceeds to a search override page.
        /// For use only with non-NUANS and non-Quebec jurisdictions (so for use with US or International). For
        /// NUANS and Quebec jurisdictions use SubmitSearchCriteriaNamesDatabase()
        /// </summary>
        /// <returns></returns>
        public SearchOverridePage SubmitSearchCriteriaOverride()
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
            return new SearchOverridePage();
        }

        /// <summary>
		/// This method submits the search criteria entered on the page and proceeds to a manual search override page.
		/// For use only with NUANS and Quebec jurisdictions. For
		/// </summary>
		/// <returns></returns>
		public SearchManualOverridePage SubmitSearchCriteriaManualOverride()
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
            return new SearchManualOverridePage();
        }

        public SearchCriteriaPage SelectJurisdiction(string jurisdiction)
        {
            try
            {
                SelectElement JSelect = new SelectElement(driver.FindElement(By.Id(jurisdictionSelectId)));
                JSelect.SelectByValue(jurisdiction);
                validation.StringLogger.LogWrite("Validation for Selecting Jurisdiction as " + jurisdiction + " is Passed");
                _test.Log(Status.Pass, "Validation for Selecting Jurisdiction as " + jurisdiction + " is Passed");
                Thread.Sleep(6000);
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Selecting Jurisdiction as " + jurisdiction + " is Failed");
                throw new Exception("No jurisdiction named " + jurisdiction + " found.");

            }
            DynamicTestInformation.jurisdiction = jurisdiction;
            return this;
        }

        public SearchCriteriaPage VerifyHasAllJurisdictions()
        {
            try
            {
                var jurisdictionOptions = driver.FindElements(By.XPath("//*[@id='" + jurisdictionSelectId + "']/option"));
                string[] jurisdictionArray = new string[jurisdictionOptions.Count - 1];
                for (int i = 2; i <= jurisdictionOptions.Count; ++i)
                {
                    jurisdictionArray[i - 2] = jurisdictionOptions[i - 1].GetAttribute("value");
                }
                validation.CollectionAssertAreEquivalent(reference.AllJurisdictions, jurisdictionArray);
                validation.StringLogger.LogWrite("Validation for List congtaining All Jurisdictions is Passed");
                _test.Log(Status.Pass, "Validation for List congtaining All Jurisdictions is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for List congtaining All Jurisdictions is Failed");
            }
            return this;
        }

        public ValidServiceSearch SetupValidServiceSearch(string baseEnterpriseName, string jurisdiction, string[] serviceNames)
        {
            return new ValidServiceSearch(this, baseEnterpriseName, jurisdiction, serviceNames);
        }

        public ValidServiceSearch SetupValidServiceSearchWithNum(string enterpriseNum, string baseEnterpriseName,  string jurisdiction, string[] serviceNames)
        {
            return new ValidServiceSearch(this, enterpriseNum, baseEnterpriseName, jurisdiction, serviceNames);
        }
    }
}
