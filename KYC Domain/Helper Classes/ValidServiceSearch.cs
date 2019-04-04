using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHUIFramework;
using KYC_Domain.Client_Pages;
using KYC_Domain.Data_Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KYC_Domain.Base_Page;
using System.Configuration;

namespace KYC_Domain.Helper_Classes
{
    public class ValidServiceSearch
    {
        //Purpose of this class is to generate a valid client side search.
        //This is a complicated process because it requires many steps and backtracking across multiple pages in a cycle
        //The overall process is as follows:

        //Step 1: Enter selected base enterprise name and jurisdiction.
        //Step 2: Locate next active enterprise, and open it
        //Step 3: Find next non-disabled service, and select it. If there are no non-disabled services remaining, loop back to Step 1
        //Step 4: Record information about the service/enterprise in private members
        //Step 5: Attempt to proceed with the service
        //Step 6: If stopped because the service already exists, then loop back to Step 3.

        SearchCriteriaPage searchCriteriaPage;

        string enterpriseNum;
        string baseEnterprise;
        string jurisdiction;
        string[] serviceNames;

        int startingEnterpriseRowIndex = 0;

        int currentEnterpriseRowIndex;

        public static string enterpriseSelected;

        public ValidServiceSearch(SearchCriteriaPage searchCriteriaPage, string baseEnterprise, string jurisdiction,
                                    string[] serviceNames)
        {
            this.searchCriteriaPage = searchCriteriaPage;
            this.baseEnterprise = baseEnterprise;
            this.jurisdiction = jurisdiction;
            this.serviceNames = serviceNames;
        }

        /// <summary>
        /// Constructor for Searches with Enterprise Num
        /// </summary>
        /// <param name="searchCriteriaPage"></param>
        /// <param name="enterpriseNum"></param>
        /// <param name="baseEnterprise"></param>
        /// <param name="jurisdiction"></param>
        /// <param name="serviceNames"></param>
        public ValidServiceSearch(SearchCriteriaPage searchCriteriaPage, string enterpriseNum, string baseEnterprise, string jurisdiction,
                                    string[] serviceNames)
        {
            this.searchCriteriaPage = searchCriteriaPage;
            this.enterpriseNum = enterpriseNum;
            this.baseEnterprise = baseEnterprise;
            this.jurisdiction = jurisdiction;
            this.serviceNames = serviceNames;
        }

        public ValidServiceSearch(SearchCriteriaPage searchCriteriaPage, string baseEnterprise, string jurisdiction,
                                    string[] serviceNames, int startingEnterpriseRowIndex)
        {
            this.searchCriteriaPage = searchCriteriaPage;
            this.baseEnterprise = baseEnterprise;
            this.jurisdiction = jurisdiction;
            this.serviceNames = serviceNames;
            this.startingEnterpriseRowIndex = startingEnterpriseRowIndex;
        }

        private ServiceSelectionPage ViewNextActiveEnterprise(BaseSearchResultsPage searchResultsPage)
        {
            while (true)
            {
                if (searchResultsPage.IsActiveEnterprise(currentEnterpriseRowIndex))
                {
                    return searchResultsPage.SelectEnterprise(currentEnterpriseRowIndex)
                        .ClickContinueButton();
                }
                currentEnterpriseRowIndex++;
            }
        }

        private void SelectServicesByName(ServiceSelectionPage serviceSelectionPage)
        {
            foreach (string serviceName in serviceNames)
            {
                if (!serviceSelectionPage.ServiceIsEnabledByName(serviceName))
                    throw new InvalidOperationException(serviceName + " service is not enabled");
                serviceSelectionPage.SelectServiceByName(serviceName);
            }
        }

        private BaseSearchResultsPage EnterSearchCriteria()
        {
            if (baseEnterprise == "") searchCriteriaPage.WriteToInputBox(InputBoxesEnum.EnterpriseNumberBox, enterpriseNum);
            else searchCriteriaPage.WriteToInputBox(InputBoxesEnum.EnterpriseNameBox, baseEnterprise);
            searchCriteriaPage.SelectJurisdiction(jurisdiction);
            return searchCriteriaPage.SubmitSearchCriteriaNamesDatabase();
        }

        private void RecordServiceSelectionData(ServiceSelectionPage serviceSelectionPage)
        {
            enterpriseSelected = serviceSelectionPage.GetFullEnterpriseName();
        }

        private void EnterOwnerInformation(SearchConfirmationPage searchConfirmationPage)
        {
            //SearchConfirmationPage.FillInOwnerInformationAndSave(ownerFirstName, ownerLastName);
            //SearchConfirmationPage.UploadDocument(ownerFilePath);
            throw new NotImplementedException();
        }

        private void EnterReferenceNumber(SearchConfirmationPage searchConfirmationPage)
        {
            searchConfirmationPage.WriteToReferenceNumber(DynamicTestInformation.CalculatedReferenceNumber);
        }

        /// <summary>
        /// This method attempts to run a service search in the NUANS Names Database using information
        /// previously applied to the ValidServiceSearch object through the constructor and the flag setters.
        /// The process by which a sevice is searched is summarized below:
        /// Step 1: Enter selected base enterprise name and jurisdiction
        /// Step 2: Locate next active enterprise, and open it
        /// Step 3: Select specified service(s). If disabled, return false
        /// Step 4: Record information about the service(s)/enterprise in private members
        /// Step 5: Attempt to proceed with the service
        /// Step 6: If the service search was successful, return true, else return false
        /// </summary>
        /// <returns>Returns true if the search was successful, and false if it wasn't</returns>
        private bool AttemptServiceSearch()
        {
            var searchPage = EnterSearchCriteria(); //Step 1
            var servicePage = ViewNextActiveEnterprise(searchPage); //Step 2
            try { SelectServicesByName(servicePage); } //Step 3 ArgumentException means service does not exist
            catch (InvalidOperationException) { return false; } //InvalidOperationException means service was not enabled
            RecordServiceSelectionData(servicePage); //Step 4
            var confirmationPage = servicePage.SubmitServiceSelection(); //Step 5
                                                                         //EnterOwnerInformation(confirmationPage); //Step 5
            EnterReferenceNumber(confirmationPage); //Step 5
            // Step 5: following 3 lines fill in and check the Notify box
            confirmationPage.ClearNotifyBox();
            confirmationPage.NotifyCheckBox();
            confirmationPage.WriteToNotify(ConfigurationManager.AppSettings["NotifyEmail"]);
            confirmationPage.ConfirmSubmit(); //Step 5

            return confirmationPage.WasSubmissionConfirmed(); //Step 6
        }

        /// <summary>
        /// This method selects a service in the NUANS Names Database using information
        /// previously provided to the ValidServiceSearch object through the constructor and external files
        /// The process by which a sevice is searched is summarized below:
        /// Step 1: Enter selected base enterprise name and jurisdiction
        /// Step 2: Locate next active enterprise, and open it
        /// Step 3: Select specified service(s). If disabled, then loop back to step 1
        /// Step 4: Record information about the service(s)/enterprise in private members
        /// Step 5: Attempt to proceed with the service
        /// Step 6: If the service search was unsuccessful, loop back to step 1, else finish
        /// </summary>
        public ClientNavBar SelectValidService()
        {

            currentEnterpriseRowIndex = startingEnterpriseRowIndex;
            ClientNavBar navBar = searchCriteriaPage.NavBar;

            while (!AttemptServiceSearch())
            {
                currentEnterpriseRowIndex++; //Such that the next attempt begins at the next enterprise
                navBar.GoToSearch();
                BasePage.validation.StringLogger.LogWrite("Validation for Select Valid Service is Passed");
            }
            return navBar;
        }
    }
}
