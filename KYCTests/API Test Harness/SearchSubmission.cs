using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KYC_Domain;
using KYC_Domain.Admin_Pages;
using KYC_Domain.Harness;
using KYC_Domain.Client_Pages;
using KYC_Domain.Helper_Classes;
using System.Threading;
using KYC_Domain.Data_Management;
using KYC_Domain.Base_Page;
using DHUIFramework;
using KYCTests.Regression_Tests;

namespace KYCTests.ApiTestHarness
{
    [TestClass]
    public class UnitTest5 : KYC_Init
    {
        public void CleanAdminSearches()
        {


        }
        /*
        [TestMethod]
        public void API_Searchsubmission_Single()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_InternalCallTestHarness - Execution Begin**************");
            KYC_Domain.Harness.TestClientPage.LoginPage
                .RadioButtonSelect()
                .SelectDropDown()
                .NavBar.GoToUserAccountSetup()
                .SelectUser()
                .NavBar.GoToSearchSubmit()
                .SubmitSearchDetails(TestData.Jurisdiction, TestData.BaseEnterpriseName)
                .SelectEnterprise()
                .SelectServices(TestData.ServiceNames);
            CommonSteps.AdminLoginAndCompleteSearch("KYC Testing PDF.pdf", TestData.ServiceNames.Length);
        }
        */
    }
}
