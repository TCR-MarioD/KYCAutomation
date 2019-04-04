using KYC_Domain.Harness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Test_Harness
{
    public class HistoricDataPage : TestClientPage
    {
        protected override bool IsAt()
        {
            return driver.Url.Contains("Search");
        }
    }
}
