using System;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KYC_Domain.Client_Pages
{
    public class MaterialChangesPage : ClientPages
    {
        static string materialChangesLabelNoDataId = "MaterialChanges_LabelNoData";
        static string closeButtonId = "cboxClose";

        public MaterialChangesPage() : base(false)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
            AssertIsAt();
        }

        protected override bool IsAt()
        {
            try
            {
                return driver.FindElement(By.ClassName("bigheading")).Text == "Material Changes";
            }
            catch (Exception) { }
            return false;
        }

        public MaterialChangesPage VerifyNoMaterialChanges()
        {
            try
            {
                validation.AssertIsTrue(driver.FindElement(By.Id(materialChangesLabelNoDataId)).Text.Contains("no 'Material Changes'"));
                validation.StringLogger.LogWrite("Validation for Text Displaying as 'No Material Changes' is Passed");
                _test.Log(Status.Pass, "Validation for Text Displaying as 'No Material Changes' is Passed");
            }
            catch (Exception) { _test.Log(Status.Fail, "Validation for Text Displaying as 'No Material Changes' is Failed"); }
            return this;
        }

        public ResultSummaryPage BackToResultSummary()
        {
            try
            {
                driver.FindElement(By.ClassName("submit")).Click();
                driver.SwitchTo().DefaultContent();
                validation.StringLogger.LogWrite("Validation for Back to Result Summary page is Passed");
                _test.Log(Status.Pass, "Validation for Back to Result Summary page is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Back to Result Summary page is Failed");
            }
            //driver.ClickById(closeButtonId);
            return new ResultSummaryPage();
        }
    }
}
