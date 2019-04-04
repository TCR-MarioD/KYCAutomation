using KYC_Domain.Base_Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYCTests.ApiTestHarness
{
    [TestClass]
    public class ApiRegressionTest : KYC_Init
    {
        [TestMethod]
        public void TC_Test_Harness_Manual_Completion()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_01 - Execution Begin**************");
            CommonTestHarnessSteps.SearchSubmission(TestData.Jurisdiction, TestData.BaseEnterpriseName, TestData.ServiceNames);
        }

        [TestMethod]
        public void TC_Test_Harness_Auto_Client()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_01 - Execution Begin**************");
            CommonTestHarnessSteps.SearchSubmissionWithAutoClient(TestData.Jurisdiction, TestData.BaseEnterpriseName, TestData.ServiceNames);
        }

        [TestMethod]
        public void TC_WebAPI_Test_Harness_Auto_Client()
        {
            BasePage.validation.StringLogger.LogWrite("************TC_NUANS_Single_Service_01 - Execution Begin**************");
            CommonTestHarnessSteps.WebAPISearchSubmissionWithAutoClient(TestData.Jurisdiction, TestData.BaseEnterpriseName, TestData.ServiceNames);
        }
    }
}
