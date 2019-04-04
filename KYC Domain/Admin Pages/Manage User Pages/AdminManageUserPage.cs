using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace KYC_Domain.Admin_Pages
{
    public class AdminManageUserPage : AdminPages
    {
        static string setupNewUserLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbAddUser";
        static string setupRolesLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbRoleSetup";
        static string editExistingUserLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbEditUser";
        static string setupRegionsLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbRegionSetup";

        protected override bool IsAt()
        {
            return driver.Url.Contains("UserManagement_Home.aspx");
        }

        public SetupNewUserPage ClickSetupNewUserLink()
        {
            try
            {
                driver.ClickById(setupNewUserLinkId);
                validation.StringLogger.LogWrite("Validation for Set Up New user Link is Passed");
                _test.Log(Status.Pass, "Validation for Set Up New user Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Set Up New user Link is Failed");
            }
            return new SetupNewUserPage();
        }

        public EditExistingUser ClickEditExistingUserLink()
        {
            try
            {
                driver.ClickById(editExistingUserLinkId);
                validation.StringLogger.LogWrite("Validation for Edit Existing User Link is Passed");
                _test.Log(Status.Pass, "Validation for Edit Existing User Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Edit Existing User Link is Failed");
            }
            return new EditExistingUser();
        }
    }
}
