using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KYC_Domain;
using KYC_Domain.Admin_Pages;
using KYC_Domain.Client_Pages;
using KYC_Domain.Helper_Classes;
using System.Threading;
using KYC_Domain.Data_Management;
using KYC_Domain.Base_Page;
using DHUIFramework;

namespace KYCTests.Regression_Tests
{
    [TestClass]
    public class RegressionTests : KYC_Init
    {
        #region NUANS & QC

        // Repetitive Test Cases
        /*
        [TestMethod]
        public void TC_NUANS_Single_Service_01()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_01 - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_NUANS_Single_Service_02()

        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_02 - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }
        */

        [TestMethod]
        public void TC_NUANS_Single_Service_03()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_03 - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        // Repetitive Test Cases
        /*
        [TestMethod]
        public void TC_NUANS_Single_Service_04()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_04 - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_NUANS_Single_Service_05()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_05 - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_NUANS_Single_Service_06()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_06 - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_QC_Single_Service()
        {

            BasePage.validation.StringLogger.LogWrite("************TC_QC_Single_Service - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_NUANS_Multiple_Services()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Multiple_Services - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_QC_Multiple_Services()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_QC_Multiple_Services - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabase(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }
        #endregion

        #region US & International
        [TestMethod]
        public void TC_USA_Single_Service_01()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_USA_Single_Service_01 - Execution Begin**************");
            CommonSteps.EndToEndWithOverride(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_USA_Single_Service_02()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_USA_Single_Service_02 - Execution Begin**************");
            CommonSteps.EndToEndWithOverride(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_International_Single_Service()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_International_Single_Service - Execution Begin**************");
            CommonSteps.EndToEndWithOverride(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_USA_Both_Services()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_USA_Both_Services - Execution Begin**************");
            CommonSteps.EndToEndWithOverride(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }
        */

        [TestMethod]
        public void TC_NUANS_Enterprise_Num_Search()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Enterprise_Num_Search - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabaseEnterpriseNum(TestData.BaseEnterpriseNum, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        ///
        /// Tests manual override with NUANS or Quebec databases
        ///     - This override differs from US services since it requires an Enterprise Number
        /// 
        public void TC_Canada_Search_Override()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_Canada_Search_Override - Execution Begin**************");
            CommonSteps.EndToEndWithOverrideAndEnterpriseNum(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.BaseEnterpriseNum, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        [TestMethod]
        public void TC_Auto_Client_Completion()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_Canada_Search_Override - Execution Begin**************");
            CommonSteps.EndToEndWithNamesDatabaseAndAutoClient(TestData.BaseEnterpriseName, TestData.Jurisdiction, TestData.ServiceNames, "KYC Testing PDF.pdf");
        }

        #endregion

        #region OldTests
        /*
		[TestMethod]
		public void KYC_C05()
		{
			// <TC_Client_Login>
			ClientLoginPage.GoTo();
			Assert.IsTrue(ClientLoginPage.IsAt);
			ClientLoginPage.Login(TestData.ClientUsername, TestData.ClientPassword);
			Assert.IsTrue(HomePage.IsAt);
			// </TC_Client_Login>

			// <TC_Client_SetupNewUser>
			ClientNavBar.GoToManageUser();
			Assert.IsTrue(ManageUsersPage.IsAt);
			ManageUsersPage.GoToSetupNewUserPage();
			Assert.IsTrue(SetupNewUserPage.IsAt);

			SetupNewUserPage.WriteToFirstNameBox(TestData.First);
			SetupNewUserPage.WriteToLastNameBox(TestData.Last);
			SetupNewUserPage.WriteToEmailBox(TestData.EmailId);
			SetupNewUserPage.WriteToUserNameBox(TestData.UName);
			SetupNewUserPage.SelectRole(TestData.Designation);
			SetupNewUserPage.ClickTransitLink();

			Assert.IsTrue(SelectTransitPage.IsAt);
			SelectTransitPage.SelectFirstTransit();
			SelectTransitPage.SaveTransitSelection();
			Assert.IsTrue(SetupNewUserPage.IsAt);
			SetupNewUserPage.SubmitNewUser();
			Assert.IsTrue(SetupNewUserPage.GetConfirmationText().Contains("Your eSearch User Profile has been created"));
			Assert.IsTrue(SetupNewUserPage.GetConfirmationText().Contains(TestData.EmailId));
			SetupNewUserPage.ClickHereLink();
			Assert.IsTrue(ManageUsersPage.IsAt);
			// </TC_Client_SetupNewUser>

			// <TC_Client_EditExistingUser>
			ClientNavBar.GoToHome();
			ClientNavBar.GoToManageUser();
			Assert.IsTrue(ManageUsersPage.IsAt);
			ManageUsersPage.GoToSearchForExistingUserPage();
			Assert.IsTrue(SearchForExistingUserPage.IsAt);
			SearchForExistingUserPage.WriteToFirstNameBox(TestData.First);
			SearchForExistingUserPage.SearchForExistingUser();
			SearchForExistingUserPage.EditFirstUser();
			Assert.IsTrue(EditExistingUserPage.IsAt);
			EditExistingUserPage.AppendToFirstNameBox("A");
			EditExistingUserPage.ClickTransitLink();

			Assert.IsTrue(SelectTransitPage.IsAt);
			SelectTransitPage.SelectFirstTransit();
			SelectTransitPage.SelectFirstTransit();
			SelectTransitPage.SaveTransitSelection();

			Assert.IsTrue(EditExistingUserPage.IsAt);
			EditExistingUserPage.SubmitEdit();
			Assert.IsTrue(EditExistingUserPage.GetConfirmationText().Contains("Your eSearch User Profile has been updated"));
			EditExistingUserPage.ClickHereLink();
			Assert.IsTrue(SearchForExistingUserPage.IsAt);
			// </TC_Client_EditExistingUser>
		}

		[TestMethod]
		public void KYC_C07()
		{
			// <TC_Client_Login>
			ClientLoginPage.GoTo();
			Assert.IsTrue(ClientLoginPage.IsAt);
			ClientLoginPage.ClickForgotUsernamePasswordLink();
			Assert.IsTrue(ForgotLoginCredentialsPage.IsAt);
			ClientLoginPage.GoTo();
			ClientLoginPage.Login(TestData.ClientUsername, TestData.ClientPassword);
			Assert.IsTrue(HomePage.IsAt);
			// </TC_Client_Login>

			// <TC_Client_HomePage>
			ClientNavBar.GoToHome();
			Assert.IsTrue(HomePage.IsAt);
			ClientNavBar.ClickBreadcrumbLink("Home");
			Assert.IsTrue(HomePage.IsAt);
			ClientNavBar.LogOut();
			Assert.IsTrue(ClientLoginPage.IsAt);
			ClientLoginPage.Login(TestData.ClientUsername, TestData.ClientPassword);

			HomePage.LaunchSearch();
			Assert.IsTrue(SearchCriteriaPage.IsAt);
			ClientNavBar.GoToHome();
			HomePage.LaunchResults();
			Assert.IsTrue(ResultQueuePage.IsAt);
			ClientNavBar.GoToHome();
			HomePage.LaunchDashboard();
			Assert.IsTrue(DashboardHubPage.IsAt);
			ClientNavBar.GoToHome();
			HomePage.LaunchManageUser();
			Assert.IsTrue(ManageUsersPage.IsAt);

			ClientNavBar.NeedHelp();
			Assert.IsTrue(NeedHelpPage.IsAt);
			NeedHelpPage.ReturnToSite();
			// </TC_Client_HomePage>

			// <TC_Client_SearchPage>
			ClientNavBar.GoToSearch();
			Assert.IsTrue(SearchCriteriaPage.IsAt);
			ClientNavBar.ClickBreadcrumbLink("Search");
			Assert.IsTrue(SearchCriteriaPage.IsAt);
			//TODO: Figure out a way to detect tooltips
			SearchCriteriaPage.WriteToEnterpriseNameBox(TestData.EnterpriseName);
			SearchCriteriaPage.SubmitSearchCriteria();
			Assert.IsTrue(NUANSSearchResultsPage.IsAt);
			// </TC_Client_SearchPage>

			// <TC_Client_ResultPage>
			ClientNavBar.GoToResults();
			Assert.IsTrue(ResultQueuePage.IsAt);
			ClientNavBar.ClickBreadcrumbLink("Results");
			Assert.IsTrue(ResultQueuePage.IsAt);
			ResultQueuePage.WriteCurrentDateToDateFromBox();
			ResultQueuePage.SubmitSearch();
			if (ResultQueuePage.HasResults())
				Assert.IsTrue(ResultQueuePage.FirstResultIsFromToday());
			ResultQueuePage.ResetFields();
			Assert.IsTrue(ResultQueuePage.ReadFromCurrentDateBox() == "");

			ResultQueuePage.SubmitSearch();
			ResultQueuePage.GoToPageInTable(2);
			string enterpriseName = ResultQueuePage.GetFirstResultEnterpriseName();
			ResultQueuePage.ViewFirstResult();
			Assert.IsTrue(ResultSummaryPage.IsAt);
			Assert.IsTrue(enterpriseName == ResultSummaryPage.GetFullEnterpriseName());
			// </TC_Client_ResultPage>

			// <TC_Client_DashboardPage>
			ClientNavBar.GoToDashboard();
			Assert.IsTrue(DashboardHubPage.IsAt);
			ClientNavBar.ClickBreadcrumbLink("Dashboard");
			Assert.IsTrue(DashboardHubPage.IsAt);

			DashboardHubPage.GoToDiarizedVerificationDashboardPage();
			Assert.IsTrue(DiarizedVerificationDashboardPage.IsAt);
			ClientNavBar.GoToDashboard();
			DashboardHubPage.GoToProductivityDashboardPage();
			Assert.IsTrue(ProductivityDashboardPage.IsAt);
			ClientNavBar.GoToDashboard();
			DashboardHubPage.GoToSetupDashboardPage();
			Assert.IsTrue(SetupDashboardPage.IsAt);
			// </TC_Client_DashboardPage>

			// <TC_Client_ManageUser>
			ClientNavBar.GoToManageUser();
			Assert.IsTrue(ManageUsersPage.IsAt);
			ClientNavBar.ClickBreadcrumbLink("Manage User");
			Assert.IsTrue(ManageUsersPage.IsAt);
			ManageUsersPage.GoToSetupNewUserPage();
			Assert.IsTrue(SetupNewUserPage.IsAt);
			ClientNavBar.GoToManageUser();
			ManageUsersPage.GoToSearchForExistingUserPage();
			Assert.IsTrue(SearchForExistingUserPage.IsAt);
			// </TC_Client_ManageUser>
		}
		*/
        #endregion

        #region Client Pages Verification Methods

        private void ClientSetUpNewUser()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_New_User - Execution Begin**************");
            ClientPages.LogInPage
                .LogIn()
                .NavBar.GoToManageUser()
                .GoToSetupNewUserPage()
                .WriteToFirstNameBox(TestData.FirstName)
                .WriteToMiddleNameBox(TestData.MiddleName)
                .WriteToLastNameBox(TestData.LastName)
                .SelectRole(TestData.Role)
                .WriteToEmailBox(TestData.Email)
                .WriteToUserNameBox(TestData.Username)
                .ClickTransitLink()
                .SelectFirstTransit()
                .SaveTransitSelection()
                .SubmitNewUser()
                .ClickHereLink()
                .NavBar.LogOut();
        }

        private void ClientEditExistingUser()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_New_User - Execution Begin**************");
            ClientPages.LogInPage
                .LogIn()
                .NavBar.GoToManageUser()
                .GoToSearchForExistingUserPage()
                .WriteToFirstNameBox(TestData.FirstName)
                .WriteToMiddleNameBox(TestData.MiddleName)
                .WriteToLastNameBox(TestData.LastName)
                .SelectRole(TestData.Role)
                .SearchForExistingUser()
                .EditFirstUser()
                .ClearBox("firstName")
                .WriteToBox("firstName", TestData.FirstName)
                .ClearBox("middleName")
                .WriteToBox("middleName", TestData.MiddleName)
                .ClearBox("lastName")
                .WriteToBox("lastName", TestData.LastName)
                .ClearBox("email")              
                .WriteToBox("email", TestData.Email)
                .SubmitEdit()
                .ClickHereLink()
                .NavBar.LogOut();
        }

        private void ClientVerifyLogin()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Client Login Page----");
            ClientPages.LogInPage
               .ClickTermsandconditionsLink()
               .ClickForgotUsernamePasswordLink()
               .ClickCancelButton()
                  .LogIn()
               .NavBar.LogOut();
        }

        private void ClientVerifyHomePageNavBar()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Client Home Page NavBar----");
            ClientPages.LogInPage
                .LogIn()
                .LaunchDashboard()
                .NavBar.GoToHome()
                .LaunchManageUser()
                .NavBar.GoToHome()
                .LaunchSearch()
                .NavBar.GoToHome()
                .LaunchResults()

                .NavBar.GoToSearch()
                .NavBar.GoToResults()
                .NavBar.GoToDashboard()
                .NavBar.GoToManageUser()

                .NavBar.VerifyBreadcrumbLinkExists()
                .NeedHelp()
                .ReturnToSite()
                .NavBar.LogOut();
        }

        private void ClientVerifySearchPage()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Client Search Page----");
            ClientPages.LogInPage
                .LogIn()
                .NavBar.GoToSearch()

                .VerifyInputBoxState(InputBoxesEnum.EnterpriseNameBox, true)
                .VerifyInputBoxState(InputBoxesEnum.EnterpriseNumberBox, true)
                .VerifyInputBoxState(InputBoxesEnum.ReferenceNumberBox, true)

                .WriteToInputBox(InputBoxesEnum.ReferenceNumberBox, "1")
                .VerifyInputBoxState(InputBoxesEnum.EnterpriseNameBox, false)
                .VerifyInputBoxState(InputBoxesEnum.EnterpriseNumberBox, false)
                .ClearInputBox(InputBoxesEnum.ReferenceNumberBox)

                .WriteToInputBox(InputBoxesEnum.EnterpriseNumberBox, "1")
                .VerifyInputBoxState(InputBoxesEnum.EnterpriseNameBox, false)
                .VerifyInputBoxState(InputBoxesEnum.ReferenceNumberBox, false)
                .ClearInputBox(InputBoxesEnum.EnterpriseNumberBox)

                .WriteToInputBox(InputBoxesEnum.EnterpriseNameBox, TestData.BaseEnterpriseName)
                .VerifyInputBoxState(InputBoxesEnum.EnterpriseNumberBox, false)
                .VerifyInputBoxState(InputBoxesEnum.ReferenceNumberBox, false)

                .VerifyHasAllJurisdictions()
                .SelectJurisdiction(TestData.Jurisdiction)
                .SubmitSearchCriteriaNamesDatabase()
                .VerifyPreSearchCriteria(TestData.BaseEnterpriseName, TestData.Jurisdiction)
                .NavBar.GoToSearch()

                .WriteToInputBox(InputBoxesEnum.EnterpriseNameBox, TestData.BaseEnterpriseName)
                .SelectJurisdiction("QC")
                .SubmitSearchCriteriaNamesDatabase()
                .VerifyPreSearchCriteria(TestData.BaseEnterpriseName, "QC")
                .ContinueWithOriginalSearchCriteria()
                .NavBar.LogOut();
        }

        private void ClientVerifyResultPage()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Client Result Page----");
            ClientPages.LogInPage
                .LogIn()

                .NavBar.GoToResults()
                .VerifyDatesAscendingOrder()
                .SortByEnterpriseName()
                .VerifyNamesDescendingOrder()
                .ViewFirstResult()
                .DisplayMaterialChanges()
                .VerifyNoMaterialChanges()
                .BackToResultSummary()
                .VerifyTablesStructure()
                .NavBar.GoToResults()
                .Write1500sToDateBoxes()
                .VerifyHasNoResults()
                .NavBar.LogOut();
        }

        private void ClientVerifyManageUserPage()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Manage User Page----");
            ClientPages.LogInPage
                .LogIn()
                .NavBar.GoToManageUser()
                .GoToSetupNewUserPage()
                .BackToManageUsersPage()
                .GoToSearchForExistingUserPage()
                .BackToManageUsersPage()
                .NavBar.LogOut();
        }
        #endregion

        #region Admin Pages Verification Methods
        private void AdminVerifyLogin()
        {

            BasePage.validation.StringLogger.LogWrite("----Validating Admin Login Page----");
            AdminPages.LogInPage
                .ClickForgotUsernamePasswordLink()
                .ClickCancelButton()
                .LogIn()
                .NavBar.LogOut();
        }

        private void AdminVerifyNavBar()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Navbar----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.VerifyBreadcrumbExists("Dashboard")
                .NavBar.GoToSearch()
                .NavBar.VerifyBreadcrumbExists("Search")
                .NavBar.GoToReporting()
                .NavBar.VerifyBreadcrumbExists("Reports")
                .NavBar.GoToManageUser()
                .NavBar.VerifyBreadcrumbExists("Manage User")
                .NavBar.GoToBillingPricing()
                .NavBar.VerifyBreadcrumbExists("Billing / Pricing")
                .NavBar.GoToClientManagement()
                .NavBar.VerifyBreadcrumbExists("Manage Organization")
                .NavBar.GoToMaintenance()
                .NavBar.VerifyBreadcrumbExists("Maintenance")
                .NavBar.GoToDashboard()
                .NavBar.NeedHelp()
                .ReturnToSite()
                .NavBar.LogOut();
        }

        private void AdminVerifyPackageQueue()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Package Queue----");
            AdminPages.LogInPage
                .LogIn()
                .ClickViewPackagesQueueLink()
                .VerifyDatesAscendingOrder()
                .SortByPackageId()
                .VerifyPackageIdAscendingOrder()
                .WriteRandomToPackageIdBox()
                .ClickFilterButton()
                .VerifyPackagesFilteredByRandom()
                .ClickResetButton()
                .ViewFirstPackage()
                .NavBar.LogOut();
        }

        private void AdminVerifyManualWorkQueue()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Manual Work Queue----");
            AdminPages.LogInPage
                .LogIn()

                .ClickProcessManualWorkQueueLinkId()
                .ClickAvailableTab()
                .ViewFirstPackage()
                .VerifyPackageStatus("Manual - Available")

                .NavBar.GoToDashboard()
                .ClickProcessManualWorkQueueLinkId()
                .ClickToBeParsedTab()
                .ViewFirstPackage()
                .VerifyPackageStatus("Manual - To Be Parsed")

                .NavBar.GoToDashboard()
                .ClickProcessManualWorkQueueLinkId()
                .ClickInvalidTab()
                .ViewFirstPackage()
                .VerifyPackageStatus("Manual - Invalid")

                .NavBar.GoToDashboard()
                .ClickProcessManualWorkQueueLinkId()
                .ClickWaitingTab()
                .ViewFirstPackage()
                .VerifyPackageStatus("Manual - Waiting")

                .NavBar.GoToDashboard()
                .ClickProcessManualWorkQueueLinkId()
                .SelectJurisdiction("QC")
                .ClickFilterButton()
                .VerifyPackageIsOfJurisdiction("QC")
                .NavBar.LogOut();
        }

        private void AdminVerifyAutomationWorkQueue()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Automation Work Queue----");
            AdminPages.LogInPage
                .LogIn()
                .ClickViewAutomatonWorkQueueLink()

                .ClickAvailableTab()
                .ViewFirstPackage()
                .VerifyPackageStatus("Auto - Available")

                .NavBar.GoToDashboard()
                .ClickViewAutomatonWorkQueueLink()
                .ClickWaitingTab()
                .ViewFirstPackage()
                .VerifyPackageStatus("Auto - Waiting")

                .NavBar.GoToDashboard()
                .ClickViewAutomatonWorkQueueLink()
                .ClickExceptionTab()
                .ViewFirstPackage()
                .VerifyPackageStatus("Auto - Exception")

                .NavBar.GoToDashboard()
                .ClickViewAutomatonWorkQueueLink()
                .SelectJurisdiction("QC")
                .ClickFilterButton()
                .VerifyPackageIsOfJurisdiction("QC")
                .NavBar.LogOut();
        }

        private void AdminVerifyPackageSummary()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Package Summary----");
            AdminPages.LogInPage
                .LogIn()
                .ClickViewPackagesQueueLink()
                .ViewFirstPackage()
                .VerifyCommentCanBeAdded()
                .BackToSearch()
                .NavBar.LogOut();
        }

        private void AdminVerifyPackageResults()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Package Results----");
            AdminPages.LogInPage
                .LogIn()
                .ClickViewPackagesQueueLink()
                .ViewFirstPackage()
                .ViewPackageItem(1)
                .SetPackageStatus("Manual - Available")
                .SetSearchResult(SearchResultType.ExactMatch)
                .SetSearchResult(SearchResultType.InExactMatch)
                .SetSearchResult(SearchResultType.NoMatch)
                .VerifyCommentCanBeAdded()
                .SavePackageItem()
                .NavBar.LogOut();
        }

        private void AdminVerifySearch()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Search----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToSearch()
                .WriteCurrentDateToDateFromBox()
                .ClickResetButton()
                .VerifyFieldsReset()
                .SubmitSearch()
                .VerifyErrorMessageAppeared()
                .NavBar.LogOut();
        }

        private void AdminVerifyReporting()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Reporting----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToReporting()
                .ViewFirstPackageItem()
                .NavBar.LogOut();
        }

        private void AdminVerifyManageUser()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Manage User----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToManageUser()
                .ClickEditExistingUserLink()
                .NavBar.GoToManageUser()
                .ClickSetupNewUserLink()
                //Setup Roles, Setup Regions
                .NavBar.LogOut();
        }

        private void AdminVerifyBillingPricing()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Billing Pricing----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToBillingPricing()
                .ClickExchangeRateManagementLink()
                .VerifyHasAllCurrencyTypes()
                .NavBar.GoToBillingPricing()
                .ClickInvoiceGenerationManagementLink()
                .SelectCorporation("RBC")
                //Some stuff
                .NavBar.LogOut();
        }

        private void AdminVerifyClientManagement()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Client Management----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToClientManagement()
                .ClickAddNewOrganizationLink()
                .NavBar.LogOut();
        }

        private void AdminVerifyMaintenance()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating Admin Maintenance----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToMaintenance()
                .ClickSystemFeeManagementLink()
                .NavBar.GoToMaintenance()
                .ClickDisbursementFeeManagementLink()
                .VerifyHasAllPricingTypes()
                .VerifyHasAllResultMatchTypes()
                .NavBar.GoToMaintenance()
                .ClickTransitManagementLink()
                .NavBar.LogOut();
        }
        #endregion

        [TestMethod]
        public void TC_New_Organization()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_New_Organisation - Execution Begin**************");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToClientManagement()
                .ClickAddNewOrganizationLink()
                .FillOrganizationInformation()
                .FillContactInformation()
                .FillBillingInformation()
                .AddOrganization()
                .NavBar.GoToSearch()
                .VerifyOrganizationExists(DynamicTestInformation.OrganizationName);
        }

        /// <summary>
        /// Creates a new user, then edits the created user
        /// Currently selects the first transit number
        /// </summary>
        [TestMethod]
        public void TC_Manage_User_Functionality()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_New_User - Execution Begin**************");
            ClientSetUpNewUser();
            ClientEditExistingUser();
        }

        [TestMethod]
        public void TC_Productivity_Dashboard_Verification()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_Productivity_Dashboard_Verification - Execution Begin**************");
            ClientPages.LogInPage
                .LogIn()
                .NavBar.GoToDashboard()
                .GoToProductivityDashboardPage()
                .ProductivityDashboardEnterFields()
                .compareReports()
                .ProductivityDashboardBack()
                .NavBar.LogOut();
        }

        [TestMethod]
        public void TC_Client_Pages_Verification()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_Client_Pages_Verification - Execution Begin**************");
            
            ClientVerifyLogin();
            ClientVerifyHomePageNavBar();
            ClientVerifySearchPage();
            ClientVerifyResultPage();
            ClientVerifyManageUserPage();
        }

        [TestMethod]
        public void TC_Admin_Pages_Verification()
        {
           BasePage.validation.StringLogger.LogWrite("************TC_Admin_Pages_Verification - Execution Begin**************");
            AdminVerifyLogin();
            AdminVerifyNavBar();
            AdminVerifyPackageQueue();
            AdminVerifyManualWorkQueue();
            AdminVerifyAutomationWorkQueue();
            AdminVerifyPackageSummary();
            AdminVerifyPackageResults();
            AdminVerifySearch();
            AdminVerifyReporting();
            AdminVerifyManageUser();
            //AdminVerifyBillingPricing();
            AdminVerifyClientManagement();
            //AdminVerifyMaintenance();
        }
    }
}
