using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class SearchForExistingUserPage : ClientPages
    {
        static string titleXPath = "//*[@id='ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_pnlFilterEdit']/table[1]/tbody/tr/td/div/div/h3";
        static string firstNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtFirstName";
        static string middleNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtMiddleName";
        static string lastNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtLastName";
        static string roleSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_ddlRole";
        static string transitBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtTransit";
        static string searchButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_btnSearch";
        static string firstUserEditLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_gvSearchResult_ctl02_lbEdit";
        static string cancelButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_btnBack";

        protected override bool IsAt()
        {
            if (driver.Url.Contains("UserManagement"))
            {
                try
                {
                    return driver.FindElement(By.XPath(titleXPath)).Text == "Edit Existing User";
                }
                catch (Exception) { }
            }
            return false;
        }

        public SearchForExistingUserPage WriteToFirstNameBox(string firstName)
        {
            try
            {
                driver.FindElement(By.Id(firstNameBoxId)).SendKeys(firstName);
                validation.StringLogger.LogWrite("Validation for Write To First Name Box is Passed");
                _test.Log(Status.Pass, "Validation for Write To First Name Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Write To First Name Box is Failed");
            }
            return this;
        }

        public SearchForExistingUserPage WriteToMiddleNameBox(string middleName)
        {
            try
            {
                driver.FindElement(By.Id(middleNameBoxId)).SendKeys(middleName);
                validation.StringLogger.LogWrite("Validation for Write To Middle Name Box is Passed");
                _test.Log(Status.Pass, "Validation for Select Write To Middle Name Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Select Write To Middle Name Box is Failed");
            }
            return this;
        }

        public SearchForExistingUserPage WriteToLastNameBox(string lastName)
        {
            try
            {
                driver.FindElement(By.Id(lastNameBoxId)).SendKeys(lastName);
                validation.StringLogger.LogWrite("Validation for Write To Last Name Box is Passed");
                _test.Log(Status.Pass, "Validation for Write To Last Name Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Write To Last Name Box is Failed");
            }
            return this;
        }

        public SearchForExistingUserPage WriteToTransitBox(string transitText)
        {
            try
            {
                driver.FindElement(By.Id(transitBoxId)).SendKeys(transitText);
                validation.StringLogger.LogWrite("Validation for Write To Transit Box is Passed");
                _test.Log(Status.Pass, "Validation for Write To Transit Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Write To Transit Box is Failed");
            }
            return this;
        }

        public SearchForExistingUserPage SelectRole(string role)
        {
            try
            {
                new SelectElement(driver.FindElement(By.Id(roleSelectId))).SelectByText(role);
                validation.StringLogger.LogWrite("Validation for Select Role is Passed");
                _test.Log(Status.Pass, "Validation for Select Role is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Select Role is Failed");
            }
            return this;
        }

        public SearchForExistingUserPage SearchForExistingUser()
        {
            try
            {
                driver.FindElement(By.Id(searchButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Click Search Button is Passed");
                _test.Log(Status.Pass, "Validation for Click Search Button is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Select First Transit is Failed");
            }
            return this;
        }

        public EditExistingUserPage EditFirstUser()
        {
            try
            {
                driver.FindElement(By.Id(firstUserEditLinkId)).Click();
                validation.StringLogger.LogWrite("Validation for Select First User is Passed");
                _test.Log(Status.Pass, "Validation for Select First User is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Select First User is Failed");
            }
            return new EditExistingUserPage();
        }

        public ManageUsersPage BackToManageUsersPage()
        {
            try
            {
                driver.ClickById(cancelButtonId);
                validation.StringLogger.LogWrite("Validation for Cancel Button is Passed");
                _test.Log(Status.Pass, "Validation for Cancel Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Cancel Button is Failed");
            }
            return new ManageUsersPage();
        }
    }
}
