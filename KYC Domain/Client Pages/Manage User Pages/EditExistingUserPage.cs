using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class EditExistingUserPage : ClientPages
    {
        static string firstNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtInputFirstName";
        static string middleNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtInputMiddleName";
        static string lastNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtInputLastName";
        static string roleSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_ddlInputRole";
        static string emailBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_txtInputEmail";
        static string transitLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_lbtnTransit";
        static string submitButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_btnSubmit";
        static string confirmationTextId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_lblEditUserMsg";
        static string returnToManageUsersLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_lnkReturn";
        static string statusActiveId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_rblInputStatus_0";
        static string statusInactiveId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_UserManagement_EditUser_rblInputStatus_1";

        protected override bool IsAt()
        {
            if (driver.Url.Contains("UserManagement"))
            {
                try
                {
                    driver.FindElement(By.Id(transitLinkId));
                    return true;
                }
                catch (Exception) { }
            }
            return false;
        }

        public EditExistingUserPage AppendToFirstNameBox(string appendText)
        {
            try
            {
                driver.FindElement(By.Id(firstNameBoxId)).SendKeys(appendText);
                validation.StringLogger.LogWrite("Validation for Append To First Name Box is Passed");
                _test.Log(Status.Pass, "Validation for Append To First Name Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Append To First Name Box is Failed");
            }
            return this;
        }

        /// <summary>
        /// String parameter boxName must be one of "firstName", "middleName", "lastName", or "email"
        /// </summary>
        /// <param name="boxName"></param>
        /// <returns>EditExistingUserPage</returns>
        public EditExistingUserPage WriteToBox(string boxName, string text)
        {
            string id = "";
            switch (boxName)
            {
                case "firstName":
                    id = firstNameBoxId;
                    break;
                case "middleName":
                    id = middleNameBoxId;
                    break;
                case "lastName":
                    id = lastNameBoxId;
                    break;
                case "email":
                    id = emailBoxId;
                    break;
            }

            if (id == "")
            {
                Exception ex = new Exception("invalid Box Name");
                throw ex;
            }

            try
            {
                var box = driver.FindElement(By.Id(id));
                box.SendKeys(text);
                validation.StringLogger.LogWrite("Validation for Write To Box is Passed");
                _test.Log(Status.Pass, "Validation for Write To Box is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Write To Box is Failed");
            }
            return this;
        }

        /// <summary>
        /// String parameter boxName must be one of "firstName", "middleName", "lastName", or "email"
        /// </summary>
        /// <param name="boxName"></param>
        /// <returns>EditExistingUserPage</returns>
        public EditExistingUserPage ClearBox(string boxName)
        {
            string id = "";
            switch (boxName) {
                case "firstName":
                    id = firstNameBoxId;
                    break;
                case "middleName":
                    id = middleNameBoxId;
                    break;
                case "lastName":
                    id = lastNameBoxId;
                    break;
                case "email":
                    id = emailBoxId;
                    break;
            }
            if (id == "")
            {
                Exception ex = new Exception("invalid Box Name");
                throw ex;
            }

            try
            {
                driver.FindElement(By.Id(id)).Clear();
                validation.StringLogger.LogWrite("Validation for Box Clear is Passed");
                _test.Log(Status.Pass, "Validation for Box Clear is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Box Clear is Failed");
            }
            return this;
        }

        /// <summary>
        /// String parameter role must be one of "RBC Manager", "RBC Supervisor", or "RBC User" 
        /// </summary>
        /// <param name="role"></param>
        /// <returns>EditExistingUserPage</returns>
        public EditExistingUserPage SelectRole(string role)
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

        public EditExistingUserPage ClickActiveRadio()
        {
            try
            {
                driver.FindElement(By.Id(statusActiveId)).Click();
                validation.StringLogger.LogWrite("Validation for Click Active Radio is Passed");
                _test.Log(Status.Pass, "Validation for Click Active Radio is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Click Active Radio is Failed");
            }
            return this;
        }

        public EditExistingUserPage ClickInactiveRadio()
        {
            try
            {
                driver.FindElement(By.Id(statusInactiveId)).Click();
                validation.StringLogger.LogWrite("Validation for Click Inactive Radio is Passed");
                _test.Log(Status.Pass, "Validation for Click Inactive Radio is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Click Inactive Radio is Failed");
            }
            return this;
        }

        public SelectTransitPage ClickTransitLink()
        {
            try
            {
                driver.FindElement(By.Id(transitLinkId)).Click();
                validation.StringLogger.LogWrite("Validation for Click Transit Link is Passed");
                _test.Log(Status.Pass, "Validation for Click Transit Link is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Click Transit Link is Failed");
            }
            return new SelectTransitPage();
        }

        public EditExistingUserPage SubmitEdit()
        {
            try
            {
                driver.FindElement(By.Id(submitButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Submit Edit Button is Passed");
                _test.Log(Status.Pass, "Validation for Submit Edit Button is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Submit Edit Button is Failed");
            }
            return this;
        }

        public string GetConfirmationText()
        {
            return driver.FindElement(By.Id(confirmationTextId)).Text;
        }

        public SearchForExistingUserPage ClickHereLink()
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

            return new SearchForExistingUserPage();
        }
    }
}
