using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYC_Domain.Base_Page;
using KYC_Domain.Test_Harness;

namespace KYC_Domain.Harness
{
    public abstract class TestClientPage : BasePage
    {
        public static TestHarnessLoginPage LoginPage => new TestHarnessLoginPage();

        public TestHarnessNavBar NavBar => new TestHarnessNavBar();

        protected TestClientPage(bool shouldAssertIsAt = true) : base(shouldAssertIsAt)
        {

        }
    }
}
