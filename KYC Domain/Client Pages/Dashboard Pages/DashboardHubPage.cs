using OpenQA.Selenium;
using System;
using System.Threading;

namespace KYC_Domain.Client_Pages
{
    public class DashboardHubPage : ClientPages
    {
        static string diarizedVerificationLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_DashboardHome_lbtnDiariesVerificationDashboard";
        static string productivityLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_DashboardHome_lbtnProductivityDashboard";
        static string setupLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_DashboardHome_lbtnDashboardSetup";

        protected override bool IsAt()
        {
            if (driver.Url.Contains("Dashboard"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "Dashboard";
                }
                catch (Exception) { }
            }
            return false;
        }

        public DiarizedVerificationDashboardPage GoToDiarizedVerificationDashboardPage()
        {
            driver.FindElement(By.Id(diarizedVerificationLinkId)).Click();
            return new DiarizedVerificationDashboardPage();
        }

        public ProductivityDashboardPage GoToProductivityDashboardPage()
        {
            driver.FindElement(By.Id(productivityLinkId)).Click();
            return new ProductivityDashboardPage();
        }

        public SetupDashboardPage GoToSetupDashboardPage()
        {
            driver.FindElement(By.Id(setupLinkId)).Click();
            return new SetupDashboardPage();
        }
    }
}

