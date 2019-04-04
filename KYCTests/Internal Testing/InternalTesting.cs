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

namespace KYCTests.Internal_Tests
{
    [TestClass]
    public class UnitTest1 : KYC_Init
    {
        public void CleanAdminSearches()
        {
            AdminPages.LogInPage
                .LogIn()
                .NavBar.GoToSearch()
                .CleanAdminPages("2018-01-02", "2018-02-14");
        }

        [TestMethod]
        public void InternalFunctionality()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_InternalFunctionality - Execution Begin**************");
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
    }
}
