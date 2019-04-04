using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class SetupNewUserPage : AdminPages
    {
        protected override bool IsAt()
        {
            try
            {
                return driver.FindElement(By.TagName("h3")).Text == "Setup New User";
            }
            catch (Exception) { }
            return false;
        }
    }
}
