using KYC_Domain.Base_Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public abstract class AdminPages : BasePage
    {
        public static AdminLoginPage LogInPage => new AdminLoginPage();

        public AdminNavBar NavBar => new AdminNavBar();

        protected AdminPages(bool shouldAssertIsAt = true) : base(shouldAssertIsAt)
        {

        }
    }
}
