using AventStack.ExtentReports;
using KYC_Domain.Harness;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Test_Harness
{
    public class TestHarnessNavBar : TestClientPage
    {
        static string userAccountSettingsId = "Menu1_HyperLink1";
        static string searchSubmitId = "Menu1_HyperLink2";
        static string historicDataId = "Menu1_HyperLink3";
        static string completedPackageItemId = "Menu1_HyperLink4";
        static string signOutId = "Menu1_btnLogout";

        protected override bool IsAt()
        {
            try
            {
                driver.FindElement(By.Id(userAccountSettingsId));
                driver.FindElement(By.Id(searchSubmitId));
                driver.FindElement(By.Id(historicDataId));
                driver.FindElement(By.Id(completedPackageItemId));
                return true;
            }
            catch (Exception) { }
            return false;
        }

        public UserAccountPage GoToUserAccountSetup()
        {
            try
            {
                driver.FindElement(By.Id(userAccountSettingsId)).Click();
                validation.StringLogger.LogWrite("Validation for navigation to User Account Setup is Passed");
                _test.Log(Status.Pass, "Validation for navigation to User Account Setup is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for navigation to User Account Setup is Failed");
            }
            return new UserAccountPage();
        }

        public SearchSubmissionPage GoToSearchSubmit()
        {
            try
            {
                driver.FindElement(By.Id(searchSubmitId)).Click();
                validation.StringLogger.LogWrite("Validation for navigation to Search Submit Page is Passed");
                _test.Log(Status.Pass, "Validation for navigation to Search Submit Page is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for navigation to Search Submit Page is Failed");
            }
            return new SearchSubmissionPage();
        }

        public HistoricDataPage GoToHistoricData()
        {
            try
            {
                driver.FindElement(By.Id(historicDataId)).Click();
                validation.StringLogger.LogWrite("Validation for navigation to Historic Data Page is Passed");
                _test.Log(Status.Pass, "Validation for navigation to Historic Data Page is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for navigation to Historic Data Page is Failed");
            }
            return new HistoricDataPage();
        }

        public CompletedPackageItemPage GoToCompletedPackageItem()
        {
            try
            {
                driver.FindElement(By.Id(completedPackageItemId)).Click();
                validation.StringLogger.LogWrite("Validation for navigation to Completed Package Item is Passed");
                _test.Log(Status.Pass, "Validation for navigation to Completed Package Item is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for navigation to Completed Package Item is Failed");
            }
            return new CompletedPackageItemPage();
        }

        public void SignOut()
        {
            try
            {
                driver.FindElement(By.Id(signOutId)).Click();
                validation.StringLogger.LogWrite("Validation for SignOut Link is Passed");
                _test.Log(Status.Pass, "Validation for SignOut Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for SignOut Link is Failed");
            }
        }
    }
}
