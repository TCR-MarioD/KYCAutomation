using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KYC_Domain.Admin_Pages
{
    public class EditExistingUser : AdminPages
    {
        protected override bool IsAt()
        {
            try
            {
                return driver.FindElement(By.TagName("h3")).Text == "Edit Existing User";
            }
            catch (Exception) { }
            return false;
        }
    }
}
