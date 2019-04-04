using KYC_Domain.Base_Page;
using KYCTests.Regression_Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYCTests.ApiTestHarness
{
    public class CommonTestHarnessSteps
    {
        public static void SearchSubmission(string strProvince, string strBaseEntPrName, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("************TC_InternalCallTestHarness - Execution Begin**************");
            KYC_Domain.Harness.TestClientPage.LoginPage
                .RadioButtonSelect()
                .SelectDropDown()
                .NavBar.GoToUserAccountSetup()
                .SelectUser()
                .NavBar.GoToSearchSubmit()
                .SubmitSearchDetails(strProvince, strBaseEntPrName)
                .SelectEnterprise()
                .SelectServices(serviceNames)
                .NavBar.SignOut();
            CommonSteps.AdminLoginAndCompleteSearch("KYC Testing PDF.pdf", serviceNames.Length);
            KYC_Domain.Harness.TestClientPage.LoginPage
                .RadioButtonSelect()
                .SelectDropDown()
                .NavBar.GoToCompletedPackageItem()
                .NavigateToPackage()
                .downloadPDFClick();
        }

        public static void SearchSubmissionWithAutoClient(string strProvince, string strBaseEntPrName, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("************TC_InternalCallTestHarness - Execution Begin**************");
            KYC_Domain.Harness.TestClientPage.LoginPage
                .RadioButtonSelect()
                .SelectDropDown()
                .NavBar.GoToUserAccountSetup()
                .SelectUser()
                .NavBar.GoToSearchSubmit()
                .SubmitSearchDetails(strProvince, strBaseEntPrName)
                .SelectEnterprise()
                .SelectServices(serviceNames)
                .NavBar.SignOut();
            CommonSteps.AdminLoginAndGetPackageId("", serviceNames.Length);
            CommonSteps.AutoClientComplete();
            CommonSteps.ClientLoginAndCheckResults(strProvince, serviceNames);
        }
        public static void WebAPISearchSubmissionWithAutoClient(string strProvince, string strBaseEntPrName, string[] serviceNames)
        {
            BasePage.validation.StringLogger.LogWrite("************TC_InternalCallTestHarness - Execution Begin**************");
            KYC_Domain.Harness.TestClientPage.LoginPage
                //.RadioButtonSelect()
                .WebApiradiobuttonselect()
                .SelectDropDown()
                .NavBar.GoToUserAccountSetup()
                .SelectUser()
                .NavBar.GoToSearchSubmit()
                .SubmitSearchDetails(strProvince, strBaseEntPrName)
                .SelectEnterprise()
                .SelectServices(serviceNames)
                .NavBar.SignOut();
            CommonSteps.AdminLoginAndGetPackageId("", serviceNames.Length);
            CommonSteps.AutoClientComplete();
            CommonSteps.ClientLoginAndCheckResults(strProvince, serviceNames);
        }
    }
}
