using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace KYC_Domain.Admin_Pages
{
    public class ClientManagementPage : AdminPages
    {
        static string viewLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbOrganizationManagement";

        public AddNewOrganizationPage ClickAddNewOrganizationLink()
        {
            try
            {
                driver.ClickById(viewLinkId);
                validation.StringLogger.LogWrite("Validation for Adding New Organization Link is Passed");
                _test.Log(Status.Pass, "Validation for Adding New Organization Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Adding New Organization Link is Failed");
            }
            return new AddNewOrganizationPage();
        }

        protected override bool IsAt()
        {
            return driver.Url.Contains("ManageOrganizationHome.aspx");
        }
    }
}
