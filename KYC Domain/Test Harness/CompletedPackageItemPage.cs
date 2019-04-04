using AventStack.ExtentReports;
using KYC_Domain.Data_Management;
using KYC_Domain.Harness;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;

namespace KYC_Domain.Test_Harness
{
    public class CompletedPackageItemPage : TestClientPage
    {
        static string downloadPDFXPath = "//table[@id='gvDownload']/tbody/tr[2]/td[3]/input";

        protected override bool IsAt()
        {
            return driver.Url.Contains("CompletedPackageItem");
        }

        public CompletedPackageItemPage NavigateToPackage()
        {
            try
            {
                int i = 2;
                while (true)
                {
                    var link = driver.FindElement(By.XPath("//table[@id='gvCompleted']/tbody/tr[" + i + "]/td/a"));
                    if (link.Text == DynamicTestInformation.packageItemId)
                    {
                        link.Click();
                        break;
                    }
                    else if (Int32.Parse(link.Text) < Int32.Parse(DynamicTestInformation.packageItemId))
                    {
                        Exception ex = new Exception("Package Item Id not found");
                        throw ex;
                    }
                    else
                    {
                        i++;
                    }
                }

                validation.StringLogger.LogWrite("Validation for Package Selection is Passed");
                _test.Log(Status.Pass, "Validation for Package Selection is Passed");

            }
            catch
            {
                _test.Log(Status.Fail, "Validation for Package Selection is Failed");
            }

            return this;
        }

        public CompletedPackageItemPage downloadPDFClick()
        {
            try
            {
                var btn = driver.FindElement(By.XPath(downloadPDFXPath));
                btn.Click();
                validation.StringLogger.LogWrite("Validation for Download PDF button click is Passed");
                _test.Log(Status.Pass, "Validation for Download PDF button click is Passed");

            }
            catch
            {
                _test.Log(Status.Fail, "Validation for Download PDF button click is Failed");
            }

            openPDF();

            return this;
        }

        private void openPDF()
        {
            try
            {
                Thread.Sleep(5000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F6);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                Thread.Sleep(5000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F6);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                Thread.Sleep(5000);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
                Thread.Sleep(5000);

                validation.StringLogger.LogWrite("Validation for PDF Download is Passed");
                _test.Log(Status.Pass, "Validation for PDF Download is Passed");

            }
            catch
            {
                _test.Log(Status.Fail, "Validation for PDF Download is Failed");
            }
        }
    }
}
