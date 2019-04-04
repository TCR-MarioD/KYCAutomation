using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class SystemFeeManagementPage : AdminPages
    {
        protected override bool IsAt()
        {
            if (!driver.Url.Contains("PricingManagement"))
                return false;
            try
            {
                return driver.FindElement(By.ClassName("bigheading")).Text == "KYC System Fee Management";
            }
            catch (Exception) { }
            return false;
        }
    }
}
