using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class AdminDashboardPage : AdminPages
    {
        static string viewPackagesQueueLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_hplPackageView";
        static string viewAutomationWorkQueueLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_hplAutoView";
        static string processManualWorkQueueLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_hplManualProcess";

        protected override bool IsAt()
        {
            return driver.Url.Contains("Dashboard_Home");
        }

        public PackagesQueuePage ClickViewPackagesQueueLink()
        {
            try
            {
                driver.ClickById(viewPackagesQueueLinkId);
                validation.StringLogger.LogWrite("Validation for View Package Queue Link is Passed");
                _test.Log(Status.Pass, "Click View Packages Queue Link is Successfull");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for View Package Queue Link is Failed");
            }
            return new PackagesQueuePage();
        }

        public AutomationWorkQueuePage ClickViewAutomatonWorkQueueLink()
        {
            try
            {
                driver.ClickById(viewAutomationWorkQueueLinkId);
                validation.StringLogger.LogWrite("Validation for View Automation Work Queue Link is Passed");
                _test.Log(Status.Pass, "Validation for View Automation Work Queue Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for View Automation Work Queue Link is Failed");
            }
            return new AutomationWorkQueuePage();
        }

        public ManualWorkQueuePage ClickProcessManualWorkQueueLinkId()
        {
            try
            {
                driver.ClickById(processManualWorkQueueLinkId);
                validation.StringLogger.LogWrite("Validation for Process Manual Work Queue LinkID is Passed");
                _test.Log(Status.Pass, "Validation for Process Manual Work Queue LinkID is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Process Manual Work Queue LinkID is Failed");
            }
            return new ManualWorkQueuePage();
        }
    }
}
