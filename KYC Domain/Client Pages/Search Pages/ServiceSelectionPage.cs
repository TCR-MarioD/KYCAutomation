using AventStack.ExtentReports;
using KYC_Domain.Data_Management;
using KYC_Domain.Helper_Classes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class ServiceSelectionPage : ClientPages
    {
        static string fullEnterpriseNameXPath = "//*[@id='ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchAdHoc_tblContainer']/tbody/tr/td/div/table/tbody/tr[1]/td[2]";
        static string serviceTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchAdHoc_grdAdhocServices";
        static string submitButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_ctl00_SearchAdHoc_UserControl_SearchAdHoc_btnSubmit";

        public ServiceSelectionPage()
        {
            DynamicTestInformation.serviceIndexes.Clear();
        }

        public string GetFullEnterpriseName()
        {
            return driver.FindElement(By.XPath(fullEnterpriseNameXPath)).Text;
        }

        public string GetServiceTypeName(int serviceIndex)
        {
            var serviceTypeNameElement = driver.FindElement(By.XPath("//*[@id='" + serviceTableId + "']/tbody/tr[" + (serviceIndex + 2) + "]/td/table/tbody/tr/td[3]/label"));
            return serviceTypeNameElement.Text;
        }

        public bool ServiceIsEnabledByIndex(int serviceIndex)
        {
            var serviceRow = driver.FindElements(By.XPath("//*[@id='" + serviceTableId + "']/tbody/tr[" + (serviceIndex + 2) + "]/td"));
            return (serviceRow.Count == 1);
        }

        public ServiceSelectionPage SelectServiceByIndex(int serviceIndex)
        {
            var serviceSelector = driver.FindElement(By.XPath("//*[@id='" + serviceTableId + "']/tbody/tr[" + (serviceIndex + 2) + "]/td/table/tbody/tr/td[1]/input"));
            serviceSelector.Click();
            DynamicTestInformation.serviceIndexes.Add(serviceIndex);
            return this;
        }

        public SearchConfirmationPage SubmitServiceSelection()
        {
            try
            {
                driver.FindElement(By.Id(submitButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Submit Button is Passed");

                _test.Log(Status.Pass, "Validation for Submit Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Submit Button is Failed");
            }
            return new SearchConfirmationPage();
        }

        public int GetServiceQuantity()
        {
            return driver.FindElements(By.XPath("//*[@id='" + serviceTableId + "']/tbody/tr")).Count - 1;
        }

        public bool ServiceIsEnabledByName(string serviceName)
        {
            int numServices = GetServiceQuantity();
            for (int i = 0; i < numServices; ++i)
            {
                if (GetServiceTypeName(i) == serviceName)
                    return ServiceIsEnabledByIndex(i);
            }
            throw new ArgumentException("Service by name of " + serviceName + " does not exist");
        }

        public ServiceSelectionPage SelectServiceByName(string serviceName)
        {
            int numServices = GetServiceQuantity();
            for (int i = 0; i < numServices; ++i)
            {
                if (GetServiceTypeName(i) == serviceName)
                {
                    SelectServiceByIndex(i);
                    return this;
                }
            }
            throw new ArgumentException("Service by name of " + serviceName + " does not exist");
        }

        public ServiceSelectionPage SelectServicesByNames(string[] serviceNames)
        {
            try
            {
                foreach (string serviceName in serviceNames)
                    SelectServiceByName(serviceName);
                validation.StringLogger.LogWrite("Validation for Select Services By Names is Passed");
                _test.Log(Status.Pass, "Validation for Select Services By Names is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Select Services By Names is Failed");
            }
            return this;
        }

        public int GetServiceIndexByName(string serviceName)
        {
            int numServices = GetServiceQuantity();
            for (int i = 0; i < numServices; ++i)
            {
                if (GetServiceTypeName(i) == serviceName)
                    return i;
            }
            throw new ArgumentException("Service by name of " + serviceName + " does not exist");
        }

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Search"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "Choose Service";
                }
                catch (Exception) { }
            }
            return false;
        }
    }
}
