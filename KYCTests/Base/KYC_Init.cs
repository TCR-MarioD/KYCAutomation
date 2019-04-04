using Microsoft.VisualStudio.TestTools.UnitTesting;
using KYC_Domain.Client_Pages;
using KYC_Domain;
using System.Configuration;
using KYC_Domain.Base_Page;
using KYC_Domain.Data_Management;
using KYC_Domain.Helper_Classes;
using DHUIFramework;
using System.IO;
using System.Linq;
using AventStack.ExtentReports;
using System.Diagnostics;
using System.Reflection;
using System;


namespace KYCTests
{
    [TestClass]
    public class KYC_Init
    {
        public static TestData TestData;


        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Init()
        {


            if (BasePage._extent != null)

            {
                BasePage.getInstance();
            }
            else
            {
                BasePage.ReportSetup();
            }
            BasePage.InitializePages(ConfigurationManager.AppSettings["Browser"]);
            string absolutePath = new System.Uri(System.Environment.CurrentDirectory.ToString() + @"\..\..\..\..").LocalPath.ToString();
            string testDataPath = absolutePath + @"\TestData.xlsx";
            TestData = new TestData(testDataPath, TestContext.TestName);
            BasePage.validation = new DHUIFramework.Validation(new Logger("Execution Starts"));
            BasePage.BeforeTest(TestContext.TestName);
            BasePage._test.Log(Status.Info, "Test execution Starts");
        }


        public string GetTestMethodName()
        {
            // for when it runs via Visual Studio locally
            var stackTrace = new StackTrace();
            foreach (var stackFrame in stackTrace.GetFrames())
            {
                MethodBase methodBase = stackFrame.GetMethod();
                Object[] attributes = methodBase.GetCustomAttributes(typeof(TestMethodAttribute), false);
                if (attributes.Length >= 1)
                {
                    return methodBase.Name;
                }
            }
            return "Not called from a test method";
        }


        [TestCleanup]
        public void TearDown()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {

                BasePage._test.Fail("Test execution ended in failure", MediaEntityBuilder.CreateScreenCaptureFromPath(BasePage.Capture("Screenshot" + DateTime.Now.ToString("yyyyMMddHHmmss"))).Build());

            }

            BasePage.CloseDriver();
            BasePage.EnableDisableLogs();
            BasePage._extent.Flush();
        }
    }
}
