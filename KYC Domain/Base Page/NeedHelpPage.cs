using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KYC_Domain.Base_Page
{
    public class NeedHelpPageTemp<OriginalSite> : BasePage
    {
        OriginalSite navBar;

        public NeedHelpPageTemp(OriginalSite navBar, bool shouldAssertIsAt = true) : base(shouldAssertIsAt)
        {
            this.navBar = navBar;
        }

        protected override bool IsAt()
        {
            Debug.WriteLine(driver.Url.Contains("eSearch.htm"));
            return driver.Url.Contains("eSearch.htm");
        }

        public OriginalSite ReturnToSite()
        {
            try
            {
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);
                validation.StringLogger.LogWrite("Successfully Returned to Site");
                _test.Log(Status.Pass, "Successfully Returned to Site");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Returned to Site is unsuccessfull");
            }
            return navBar;
        }
    }
}
