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
    public class SetupNewUserPage : ClientPages
    {
        static string titleXPath = "//*[@id='ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_pnlAddUser']/div/h3";
        static string firstNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_txtInputFirstName";
        static string middleNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_txtInputMiddleName";
        static string lastNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_txtInputLastName";
        static string emailBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_txtInputEmail";
        static string userNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_txtInputUserName";
        static string roleSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_ddlInputRole";
        static string transitLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_lbtnTransit";
        static string submitButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_btnSubmit";
        static string confirmationTextId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_lblAddUserMsg";
        static string returnToManageUsersLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_lnkReturn";
        static string cancelButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_CreateUser_btnCancel";

        protected override bool IsAt()
        {
            if (driver.Url.Contains("UserManagement"))
            {
                try
                {
                    return driver.FindElement(By.XPath(titleXPath)).Text == "Setup New User";
                }
                catch (Exception) { }
            }
            return false;
        }

        public SetupNewUserPage WriteToFirstNameBox(string firstName)
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

        public SetupNewUserPage WriteToMiddleNameBox(string middleName)
        {
            try
            {
                driver.FindElement(By.Id(middleNameBoxId)).SendKeys(middleName);
                validation.StringLogger.LogWrite("Validation for Write To Middle Name Box is Passed");
                _test.Log(Status.Pass, "Validation for Write To Middle Name Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Write To Middle Name Box is Failed");
            }
            return this;
        }

        public SetupNewUserPage WriteToLastNameBox(string lastName)
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

        public SetupNewUserPage WriteToEmailBox(string email)
        {
            try
            {
                driver.FindElement(By.Id(emailBoxId)).SendKeys(email);
                validation.StringLogger.LogWrite("Validation for Write To Email Box is Passed");
                _test.Log(Status.Pass, "Validation for Write To Email Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Write To Email Box is Failed");
            }
            return this;
        }

        public SetupNewUserPage WriteToUserNameBox(string userName)
        {
            try
            {
                driver.FindElement(By.Id(userNameBoxId)).SendKeys(userName);
                validation.StringLogger.LogWrite("Validation for Write To Username Box is Passed");
                _test.Log(Status.Pass, "Validation for Write To Username Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Write To Username Box is Failed");
            }
            return this;
        }

        public SetupNewUserPage SelectRole(string role)
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

        public SelectTransitPage ClickTransitLink()
        {
            try
            {
                driver.FindElement(By.Id(transitLinkId)).Click();
                validation.StringLogger.LogWrite("Validation for Click Transit Id Link is Passed");
                _test.Log(Status.Pass, "Validation for Click Transit Id Link is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Click Transit Id Link is Failed");
            }
            return new SelectTransitPage();
        }

        public SetupNewUserPage SubmitNewUser()
        {
            try
            {
                driver.FindElement(By.Id(submitButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Click Submit Button is Passed");
                _test.Log(Status.Pass, "Validation for Click Submit Button is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Click Submit Button is Failed");
            }
            return this;
        }

        public string GetConfirmationText()
        {
            return driver.FindElement(By.Id(confirmationTextId)).Text;
        }

        public ManageUsersPage ClickHereLink()
        {
            try
            {
                driver.FindElement(By.Id(returnToManageUsersLinkId)).Click();
                validation.StringLogger.LogWrite("Validation for Click Here Link is Passed");
                _test.Log(Status.Pass, "Validation for Click Here Link is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Click Here Link is Failed");
            }
            return new ManageUsersPage();
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
