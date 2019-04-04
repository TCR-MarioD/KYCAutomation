using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class TransitManagementPage : AdminPages
    {
        protected override bool IsAt()
        {
            if (!driver.Url.Contains("TransitManagement"))
                return false;
            try
            {
                return driver.FindElement(By.ClassName("bigheading")).Text == "Transit Management";
            }
            catch (Exception) { }
            return false;
        }
    }
}
