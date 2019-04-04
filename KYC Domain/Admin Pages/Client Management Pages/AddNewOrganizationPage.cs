using AventStack.ExtentReports;
using KYC_Domain.Data_Management;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class AddNewOrganizationPage : AdminPages
    {
        static string organizationNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtName";
        static string organizationInitialsBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtNameInitial";
        static string organizationTypeSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlOrganizationTypes";

        static string contactNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtContact";
        static string contactStreetNumberBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtStreet";
        static string contactStreetNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtStreetName";
        static string contactCityNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtCity";
        static string contactJurisdictionSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlJurisdictions";
        static string contactPostalOrZipBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtPostalCode";
        static string contactCountrySelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlCountries";
        static string phoneBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtPhone";
        static string emailBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtEmail";

        static string transitNumberBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtTransit";
        static string branchNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtBranchName";
        static string billingStreetNumberBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtStreet1";
        static string billingStreetNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtStreetName1";
        static string billingCityNameBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtCity1";
        static string billingJurisdictionSelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlJurisdictions1";
        static string billingPostalOrZipBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtPostalCode1";
        static string billingCountrySelectId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ddlCountry";

        static string addOrganizationButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnSubmitOrganization";

        public AddNewOrganizationPage FillOrganizationInformation()
        {
            try
            {
                OrganizationInfo orgInfo = reference.OrganizationInfo;
                DynamicTestInformation.organizationName = orgInfo.Name + random.Next(0, int.MaxValue);
                driver.SendKeysById(organizationNameBoxId, DynamicTestInformation.organizationName);
                driver.SendKeysById(organizationInitialsBoxId, orgInfo.Initials);
                driver.SelectValueById(organizationTypeSelectId, orgInfo.Type);
                validation.StringLogger.LogWrite("Validation for Filling Organization Information is Passed");
                _test.Log(Status.Pass, "Validation for Filling Organization Information is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Filling Organization Information is Failed");
            }
            return this;
        }

        public AddNewOrganizationPage FillContactInformation()
        {
            try
            {
                ContactInfo contactInfo = reference.ContactInfo;
                driver.SendKeysById(contactNameBoxId, contactInfo.Name);
                driver.SendKeysById(contactStreetNumberBoxId, contactInfo.StreetNumber);
                driver.SendKeysById(contactStreetNameBoxId, contactInfo.StreetName);
                driver.SendKeysById(contactCityNameBoxId, contactInfo.CityName);
                driver.SelectValueById(contactJurisdictionSelectId, contactInfo.Jurisdiction);
                driver.SendKeysById(contactPostalOrZipBoxId, contactInfo.PostalOrZip);
                driver.SelectValueById(contactCountrySelectId, contactInfo.Country);
                driver.SendKeysById(phoneBoxId, contactInfo.Phone);
                driver.SendKeysById(emailBoxId, contactInfo.Email);

                validation.StringLogger.LogWrite("Validation for Filling Contact Information is Passed");
                _test.Log(Status.Pass, "Validation for Filling Contact Information is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Filling Contact Information is Failed");
            }
            return this;
        }

        public AddNewOrganizationPage FillBillingInformation()
        {
            try
            {
                BillingInfo billingInfo = reference.BillingInfo;
                driver.SendKeysById(transitNumberBoxId, billingInfo.TransitNumber);
                driver.SendKeysById(branchNameBoxId, billingInfo.BranchName);
                driver.SendKeysById(billingStreetNumberBoxId, billingInfo.StreetNumber);
                driver.SendKeysById(billingStreetNameBoxId, billingInfo.StreetName);
                driver.SendKeysById(billingCityNameBoxId, billingInfo.City);
                driver.SelectValueById(billingJurisdictionSelectId, billingInfo.Jurisdiction);
                driver.SendKeysById(billingPostalOrZipBoxId, billingInfo.PostalOrZip);
                driver.SelectValueById(billingCountrySelectId, billingInfo.Country);

                validation.StringLogger.LogWrite("Validation for Filling Billing information is Passed");
                _test.Log(Status.Pass, "Validation for Filling Billing information is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Filling Billing information is Failed");
            }
            return this;
        }

        public AdminDashboardPage AddOrganization()
        {
            try
            {
                driver.ClickById(addOrganizationButtonId);
                driver.AcceptAlert();
                validation.StringLogger.LogWrite("Validation for Adding Organization is Passed");
                Thread.Sleep(5000);
                _test.Log(Status.Pass, "Validation for Adding Organization is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Adding Organization is Failed");
            }
            return new AdminDashboardPage();
        }

        protected override bool IsAt()
        {
            return driver.Url.Contains("OrganizationManagement.aspx");
        }
    }
}
