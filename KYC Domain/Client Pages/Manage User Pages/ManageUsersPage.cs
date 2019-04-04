using System;
using System.Threading;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KYC_Domain.Client_Pages
{
    public class ManageUsersPage : ClientPages
    {
        static string setUpNewUserLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_UserManagementHome_lbAddUser";
        static string editExistingUserLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_UserManagementHome_lbEditUser";

        protected override bool IsAt()
        {
            if (driver.Url.Contains("UserManagement"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "eSearch Manage User";
                }
                catch (Exception) { }
            }
            return false;
        }

        public SetupNewUserPage GoToSetupNewUserPage()
        {
            try
            {
                driver.ClickById(setUpNewUserLinkId);
                validation.StringLogger.LogWrite("Validation for SetUp New User Link is Passed");
                _test.Log(Status.Pass, "Validation for SetUp New User Link  is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for SetUp New User Link  is Failed");
            }
            return new SetupNewUserPage();
        }

        public SearchForExistingUserPage GoToSearchForExistingUserPage()
        {
            try
            {
                driver.ClickById(editExistingUserLinkId);
                validation.StringLogger.LogWrite("Validation for Edit user link is Passed");
                _test.Log(Status.Pass, "Validation for Edit user link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Edit user link is Failed");
            }
            return new SearchForExistingUserPage();
        }
    }
}

