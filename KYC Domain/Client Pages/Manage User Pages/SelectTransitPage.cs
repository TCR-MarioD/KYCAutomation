using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class SelectTransitPage : ClientPages
    {
        static string firstTransitAssignBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_TransitSelections_gvTransitResult_ctl02_cbTransit";
        static string saveButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_TransitSelections_btnSubmit";

        protected override bool IsAt()
        {
            return driver.Url.Contains("TransitSelections");
        }

        public SelectTransitPage SelectFirstTransit()
        {
            try
            {
                driver.FindElement(By.Id(firstTransitAssignBoxId)).Click();
                validation.StringLogger.LogWrite("Validation for Select First Transit is Passed");
                _test.Log(Status.Pass, "Validation for Select First Transit is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Select First Transit is Failed");
            }
            return this;
        }

        public SetupNewUserPage SaveTransitSelection()
        {
            try
            {
                driver.FindElement(By.Id(saveButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Save Transit Selection is Passed");
                _test.Log(Status.Pass, "Validation for Save Transit Selection is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Save Transit Selection is Failed");
            }
            return new SetupNewUserPage();
        }
    }
}
