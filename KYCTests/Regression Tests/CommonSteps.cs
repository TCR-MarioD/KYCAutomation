using KYC_Domain.Admin_Pages;
using KYC_Domain.Base_Page;
using KYC_Domain.Client_Pages;
using KYC_Domain.Auto_Client;
using KYC_Domain.Data_Management;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYCTests.Regression_Tests
{
    public static class CommonSteps
    {
        #region EndToEndFlow
        public static void ClientLoginAndSearchNamesDatabase(string baseEnterpriseName, string jurisdiction, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating ClientLoginAndSearchNamesDatabase----");
            ClientPages.LogInPage
                .LogIn()
                .LaunchSearch()
                .VerifyHasAllJurisdictions()
                .SetupValidServiceSearch(baseEnterpriseName, jurisdiction, serviceNames)
                .SelectValidService()
                .LogOut();
        }

        public static void ClientLoginAndSearchWithNum(string enterpriseNum, string jurisdiction, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating ClientLoginAndSearchNamesDatabase----");
            ClientPages.LogInPage
                .LogIn()
                .LaunchSearch()
                .VerifyHasAllJurisdictions()
                .SetupValidServiceSearchWithNum(enterpriseNum, "", jurisdiction, serviceNames)
                .SelectValidService()
                .LogOut();
        }

        public static void ClientLoginAndSearchOverride(string baseEnterpriseName, string jurisdiction, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating ClientLoginAndSearchOverride----");
            ClientPages.LogInPage
                .LogIn()
                .LaunchSearch()
                .VerifyHasAllJurisdictions()
                .WriteToInputBox(InputBoxesEnum.EnterpriseNameBox, baseEnterpriseName)
                .SelectJurisdiction(jurisdiction)
                .SubmitSearchCriteriaOverride()
                .ClickContinueButton()
                .SelectServicesByNames(serviceNames)
                .SubmitServiceSelection()
                .WriteToReferenceNumber(DynamicTestInformation.CalculatedReferenceNumber)
                .ClearNotifyBox()
                .NotifyCheckBox()
                .WriteToNotify(ConfigurationManager.AppSettings["NotifyEmail"])
                .ConfirmSubmit()
                .NavBar.LogOut();
        }

        public static void ClientLoginAndSearchOverrideAndEnterpriseNum(string baseEnterpriseName, string jurisdiction, string baseEnterpriseNum, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating ClientLoginAndSearchOverrideAndEnterpriseNum----");
            ClientPages.LogInPage
                .LogIn()
                .LaunchSearch()
                .VerifyHasAllJurisdictions()
                .WriteToInputBox(InputBoxesEnum.EnterpriseNameBox, baseEnterpriseName)
                .SelectJurisdiction(jurisdiction)
                .SubmitSearchCriteriaManualOverride()
                .WriteEnterpriseNum(baseEnterpriseNum) /// Can be extended to write to any Input Box 
                .ClickContinueButton()
                .SelectServicesByNames(serviceNames)
                .SubmitServiceSelection()
                .WriteToReferenceNumber(DynamicTestInformation.CalculatedReferenceNumber)
                .ClearNotifyBox()
                .NotifyCheckBox()
                .WriteToNotify(ConfigurationManager.AppSettings["NotifyEmail"])
                .ConfirmSubmit()
                .NavBar.LogOut();
        }

        public static PackageSummaryPage AdminCompletePackage(int numServices, PackageSummaryPage packageSummaryPage, string resultsPdfName)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating AdminCompletePackage----");
            for (int i = 0; i < numServices - 1; ++i)
            {
                packageSummaryPage
                    .ViewPackageItem(i)
                    .SetPackageStatus("Manual - Available")
                    .SavePackageItem()
                    .ViewPackageItem(i)
                    .SetPackageStatus("Manual - Completed")
                    .SetSearchResult(SearchResultType.ExactMatch)
                    .OpenCostOverrideForm()
                    .WaiveDHFee()
                    .WaiveDisbursementFee()
                    .SaveOverride()
                    .BackToPackageResults()
                    .AddTradeName()
                    .UploadResultsPdf(resultsPdfName)
                    .VerifyCommentCanBeAdded()
                    .SavePackageItem();
            }
            packageSummaryPage
                    .ViewPackageItem(numServices - 1)
                    .SetPackageStatus("Manual - Available")
                    .SavePackageItem()
                    .ViewPackageItem(numServices - 1)
                    .SetPackageStatus("Manual - Completed")
                    .SetSearchResult(SearchResultType.ExactMatch)
                    .OpenCostOverrideForm()
                    .WaiveDHFee()
                    .WaiveDisbursementFee()
                    .SaveOverride()
                    .BackToPackageResults()
                    .AddTradeName()
                    .UploadResultsPdf(resultsPdfName)
                    .VerifyCommentCanBeAdded()
                    .SavePackageItemAndCloseAlert();
            return packageSummaryPage;
        }

        public static void AdminLoginAndCompleteSearch(string resultsPdfName, int numServices)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating AdminLoginAndCompleteSearch----");
            var packageSummaryPage = AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToSearch()
                .WriteCurrentDateToDateFromBox()
                .SubmitSearch()
                .VerifyRowsReturnedExists()
                .ViewPackageByReferenceNumberAndEnterpriseName(DynamicTestInformation.CalculatedReferenceNumber, DynamicTestInformation.EnterpriseName)
                .GetPackageItemId(numServices - 1);
            /*.ViewPackageItem(0)
            .SetPackageStatus("Manual - Available")
            .SavePackageItem()
            .ViewPackageItem(0)
            .SetPackageStatus("Manual - Completed")
            .SetSearchResultExactMatch()
            .OpenCostOverrideForm()
            .WaiveDHFee()
            .WaiveDisbursementFee()
            .SaveOverride()
            .BackToPackageResults()
            .AddTradeName()
            .UploadResultsPdf(resultsPdfName)
            .AddComments()
            .SavePackageItemAndCloseAlert() */
            AdminCompletePackage(numServices, packageSummaryPage, resultsPdfName)
                .BackToSearch()
                .NavBar.LogOut();
        }

        public static void AutoClientComplete()
        {
            BasePage.validation.StringLogger.LogWrite("----Validating AutoClientCompleteSearch----");
            AutoClient.getWindow();
        }

        public static void ClientLoginAndCheckResults(string jurisdiction, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating ClientLoginAndCheckResults----");
            ClientPages.LogInPage
                .LogIn()
                .LaunchResults()
                .WriteCurrentDateToDateFromBox()
                .SubmitSearch()
                .ViewResultByReferenceNumberAndEnterpriseName(DynamicTestInformation.CalculatedReferenceNumber, DynamicTestInformation.EnterpriseName)
                .VerifyJurisdictionMatch(jurisdiction)
                .VerifyEnterpriseMatch(DynamicTestInformation.EnterpriseName)
                .VerifySearchStatusCompleted(serviceNames)
                .OpenPDF()
                .BackToResultQueue()
                .NavBar.LogOut();
        }

        public static void AdminLoginAndGetPackageId(string resultsPdfName, int numServices)
        {
            BasePage.validation.StringLogger.LogWrite("----Validating AdminLoginAndGetPackageId----");
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToSearch()
                .WriteCurrentDateToDateFromBox()
                .SubmitSearch()
                .VerifyRowsReturnedExists()
                .ViewPackageByReferenceNumberAndEnterpriseName(DynamicTestInformation.CalculatedReferenceNumber, DynamicTestInformation.EnterpriseName)
                .GetPackageItemId(numServices - 1)
                .NavBar.LogOut();
        }

        public static void EndToEndWithNamesDatabase(string baseEnterpriseName, string jurisdiction, string[] serviceNames, string resultsPdfName)
        {
            ClientLoginAndSearchNamesDatabase(baseEnterpriseName, jurisdiction, serviceNames);
            AdminLoginAndCompleteSearch(resultsPdfName, serviceNames.Length);
            ClientLoginAndCheckResults(jurisdiction, serviceNames);
        }

        public static void EndToEndWithOverride(string baseEnterpriseName, string jurisdiction, string[] serviceNames, string resultsPdfName)
        {
            ClientLoginAndSearchOverride(baseEnterpriseName, jurisdiction, serviceNames);
            AdminLoginAndCompleteSearch(resultsPdfName, serviceNames.Length);
            ClientLoginAndCheckResults(jurisdiction, serviceNames);
        }

        public static void EndToEndWithOverrideAndEnterpriseNum(string baseEnterpriseName, string jurisdiction, string baseEnterpriseNum, string[] serviceNames, string resultsPdfName)
        {
            ClientLoginAndSearchOverrideAndEnterpriseNum(baseEnterpriseName, jurisdiction, baseEnterpriseNum, serviceNames);
            AdminLoginAndGetPackageId(resultsPdfName, serviceNames.Length);
            AutoClientComplete();
            //AdminLoginAndCompleteSearch(resultsPdfName, serviceNames.Length);
            ClientLoginAndCheckResults(jurisdiction, serviceNames);
        }

        public static void EndToEndWithNamesDatabaseAndAutoClient(string baseEnterpriseName, string jurisdiction, string[] serviceNames, string resultsPdfName)
        {
            //ClientLoginAndSearchOverrideAndEnterpriseNum(baseEnterpriseName, jurisdiction, "12345", serviceNames);
            ClientLoginAndSearchNamesDatabase(baseEnterpriseName, jurisdiction, serviceNames);
            AdminLoginAndGetPackageId(resultsPdfName, serviceNames.Length);
            AutoClientComplete();
            ClientLoginAndCheckResults(jurisdiction, serviceNames);
        }

        public static void EndToEndWithNamesDatabaseEnterpriseNum(string enterpriseNum, string jurisdiction, string[] serviceNames, string resultsPdfName)
        {
            ClientLoginAndSearchWithNum(enterpriseNum, jurisdiction, serviceNames);
            AdminLoginAndGetPackageId(resultsPdfName, serviceNames.Length);
            AutoClientComplete();
            //AdminLoginAndCompleteSearch(resultsPdfName, serviceNames.Length);
            ClientLoginAndCheckResults(jurisdiction, serviceNames);
        }
        #endregion
    }
}
