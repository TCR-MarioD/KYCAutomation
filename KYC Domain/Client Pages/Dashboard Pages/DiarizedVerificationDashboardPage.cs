using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class DiarizedVerificationDashboardPage : ClientPages
    {
        protected override bool IsAt()
        {
            if (driver.Url.Contains("Dashboard"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "Diarized Verification Dashboard";
                }
                catch (Exception) { }
            }
            return false;
        }
    }
}
