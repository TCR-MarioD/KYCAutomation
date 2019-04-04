using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Admin_Pages
{
    public class BillingPricingPage : AdminPages
    {
        static string exchangeRateManagementLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbAddExchangeRate";
        static string invoiceGenerationManagementLinkId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_lbGenerateInvoice";

        protected override bool IsAt()
        {
            return driver.Url.Contains("Billing_Home");
        }

        public ExchangeRatePage ClickExchangeRateManagementLink()
        {
            try
            {
                driver.ClickById(exchangeRateManagementLinkId);
                validation.StringLogger.LogWrite("Validation for Exchange rate Management Link is Passed");
                _test.Log(Status.Pass, "Validation for Exchange rate Management Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Exchange rate Management Link is Failed");
            }
            return new ExchangeRatePage();
        }

        public InvoiceGenerationPage ClickInvoiceGenerationManagementLink()
        {
            try
            {
                driver.ClickById(invoiceGenerationManagementLinkId);
                validation.StringLogger.LogWrite("Validation for Invoice Generation Management Link is Passed");
                _test.Log(Status.Pass, "Validation for Invoice Generation Management Link is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Invoice Generation Management Link is Failed");
            }
            return new InvoiceGenerationPage();
        }
    }
}
