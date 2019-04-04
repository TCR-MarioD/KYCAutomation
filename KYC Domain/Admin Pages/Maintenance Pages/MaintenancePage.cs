using AventStack.ExtentReports;
using System;

namespace KYC_Domain.Admin_Pages
{
    public class MaintenancePage : AdminPages
    {
        static string systemFeeManagementLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbSystemFeeManagement";
        static string disbursementFeeManagementLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbDisbursementFeeMgmt";
        static string transitManagementLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbTransitMgmt";

        protected override bool IsAt()
        {
            return driver.Url.Contains("MaintenanceHome");
        }

        public SystemFeeManagementPage ClickSystemFeeManagementLink()
        {
            try
            {
                driver.ClickById(systemFeeManagementLinkId);
                validation.StringLogger.LogWrite("Validation for System Fee Management Link is Passed");
                _test.Log(Status.Pass, "Validation for System Fee Management Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for System Fee Management Link is Failed");
            }
            return new SystemFeeManagementPage();
        }

        public DisbursementFeeManagementPage ClickDisbursementFeeManagementLink()
        {
            try
            {
                driver.ClickById(disbursementFeeManagementLinkId);
                validation.StringLogger.LogWrite("Validation for Disbursement Fee Management Link is Passed");
                _test.Log(Status.Pass, "Validation for Disbursement Fee Management Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Disbursement Fee Management Link is Failed");
            }
            return new DisbursementFeeManagementPage();
        }

        public TransitManagementPage ClickTransitManagementLink()
        {
            try
            {
                driver.ClickById(transitManagementLinkId);
                validation.StringLogger.LogWrite("Validation for Transit Management Link is Passed");
                _test.Log(Status.Pass, "Validation for Transit Management Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Transit Management Link is Failed");
            }
            return new TransitManagementPage();
        }
    }
}