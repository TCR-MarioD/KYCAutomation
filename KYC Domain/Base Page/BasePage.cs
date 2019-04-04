using DHUIFramework;
using KYC_Domain.Data_Management;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;


namespace KYC_Domain.Base_Page
{
    public abstract class BasePage
    {
        protected static ConcreteDriver driver;
        public static Validation validation;
        protected static string absolutePath; //Absolute path to the repo
        protected static Random random;
        protected static ReferenceData reference;
        protected static WebDriverWait wait;
        public static ExtentReports _extent;
        public static ExtentTest _test;

        protected abstract bool IsAt();

        protected virtual bool ElementsExist()
        {
            return true;
        }

        protected bool ElementExistsById(string elementId)
        {
            try
            {
                driver.FindElement(By.Id(elementId));
                return true;
            }
            catch (Exception) { }
            return false;
        }

        protected BasePage(bool shouldAssertIsAt)
        {
            if (shouldAssertIsAt)
                AssertIsAt();
        }

        protected void AssertIsAt()
        {
            try
            {
                validation.AssertIsTrue(IsAt(), "Page Navigation to " + GetType() + " failed");

            }
            catch
            {
                _test.Log(Status.Fail, "Page Navigation to " + GetType() + " failed");
                Assert.Fail();
            }
            driver.RemoveImplicitWait();
            try
            {
                validation.AssertIsTrue(ElementsExist(), "Element Missing on " + GetType() + " page");
            }
            catch
            {
                _test.Log(Status.Fail, "Element Missing on " + GetType() + " page");
                Assert.Fail();
            }
            driver.AddImplicitWait();

        }

        public static void InitializePages(string driverName)
        {
            driver = new ConcreteDriver(driverName);
            //validation = new Validation(new Logger("Testing123"));
            absolutePath = new Uri(Environment.CurrentDirectory.ToString() + @"\..\..\..\..").LocalPath.ToString();
            random = new Random();
            reference = new ReferenceData(absolutePath);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public static void CloseDriver()
        {
            try
            {
                driver.Close();
            }
            catch (Exception ex) { }
        }

        public static void EnableDisableLogs()
        {
            absolutePath = new Uri(Environment.CurrentDirectory.ToString() + @"\").LocalPath.ToString();
            var inputDirectory = new DirectoryInfo(absolutePath);
            var myFile = inputDirectory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            if ((ConfigurationManager.AppSettings["Logs"]) == "No")
                File.Delete(myFile.ToString());


        }

        public static ExtentReports getInstance()
        {
            return _extent;
        }
        //[OneTimeSetUp]
        public static ExtentReports ReportSetup()
        {

            var dir = new Uri(Environment.CurrentDirectory.ToString() + @"\..\..\").LocalPath.ToString() + "Results\\";
            var fileName = "KYC_Result_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);
            htmlReporter.LoadConfig(new Uri(Environment.CurrentDirectory.ToString() + @"\..\..\").LocalPath.ToString() + "extent-config.xml");

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            return _extent;

        }

        // [SetUp]
        public static void BeforeTest(String TestName)
        {
            _test = _extent.CreateTest(TestName);

        }

        [TearDown]
        public static void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
         
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }
        public static string Capture(string screenShotName)
        {

            Screenshot screenshot = driver.ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Results\\ErrorScreenshots\\" + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath);
            return localpath;
        }


        // [OneTimeTearDown]
        public static void TearDown()
        {
            _extent.Flush();
        }

    }
}
