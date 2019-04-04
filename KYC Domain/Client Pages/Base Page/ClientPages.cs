using KYC_Domain.Base_Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public abstract class ClientPages : BasePage
    {
        public static ClientLoginPage LogInPage => new ClientLoginPage();

        public ClientNavBar NavBar => new ClientNavBar();

        protected ClientPages(bool shouldAssertIsAt = true) : base(shouldAssertIsAt)
        {

        }
    }
}
