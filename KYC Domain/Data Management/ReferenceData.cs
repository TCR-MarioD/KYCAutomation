using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Data_Management
{
    public struct OrganizationInfo
    {
        public string Name;
        public string Initials;
        public string Type;
    }

    public struct ContactInfo
    {
        public string Name;
        public string StreetNumber;
        public string StreetName;
        public string CityName;
        public string Jurisdiction;
        public string PostalOrZip;
        public string Country;
        public string Phone;
        public string Email;
    }

    public struct BillingInfo
    {
        public string TransitNumber;
        public string BranchName;
        public string StreetNumber;
        public string StreetName;
        public string City;
        public string Jurisdiction;
        public string PostalOrZip;
        public string Country;
    }

    public class ReferenceData
    {
        private string referenceDataPath;

        public ReferenceData(string absolutePath)
        {
            referenceDataPath = absolutePath + @"\Reference Data\";
        }

        public List<string> NUANSJurisdictions
        {
            get
            {
                List<string> jurisdictions = new List<string>();
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "NUANSJurisdictions"))
                {
                    try
                    {
                        while (!file.EndOfStream)
                            jurisdictions.Add(file.ReadLine());
                    }
                    catch (Exception) { }
                }
                return jurisdictions;
            }
        }

        public List<string> USJurisdictions
        {
            get
            {
                List<string> jurisdictions = new List<string>();
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "USJurisdictions"))
                {
                    try
                    {
                        while (!file.EndOfStream)
                            jurisdictions.Add(file.ReadLine());
                    }
                    catch (Exception) { }
                }
                return jurisdictions;
            }
        }

        public List<string> InternationalJurisdictions
        {
            get
            {
                List<string> jurisdictions = new List<string>();
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "InternationalJurisdictions"))
                {
                    try
                    {
                        while (!file.EndOfStream)
                            jurisdictions.Add(file.ReadLine());
                    }
                    catch (Exception) { }
                }
                return jurisdictions;
            }
        }

        public List<string> QuebecJurisdictions
        {
            get
            {
                List<string> jurisdictions = new List<string>();
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "QCJurisdiction"))
                {
                    try
                    {
                        while (!file.EndOfStream)
                            jurisdictions.Add(file.ReadLine());
                    }
                    catch (Exception) { }
                }
                return jurisdictions;
            }
        }

        public string[] AllJurisdictions
        {
            get
            {
                return NUANSJurisdictions.Union(USJurisdictions).Union(InternationalJurisdictions).Union(QuebecJurisdictions).ToArray();
            }
        }

        public OrganizationInfo OrganizationInfo
        {
            get
            {
                OrganizationInfo orgInfo = new OrganizationInfo { Name = "", Initials = "", Type = "" };
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "OrganizationInfo"))
                {
                    orgInfo.Name = file.ReadLine().Split('|')[1];
                    orgInfo.Initials = file.ReadLine().Split('|')[1];
                    orgInfo.Type = file.ReadLine().Split('|')[1];
                }
                return orgInfo;
            }
        }

        public ContactInfo ContactInfo
        {
            get
            {
                ContactInfo contactInfo;
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "ContactInfo"))
                {
                    contactInfo.Name = file.ReadLine().Split('|')[1];
                    contactInfo.StreetNumber = file.ReadLine().Split('|')[1];
                    contactInfo.StreetName = file.ReadLine().Split('|')[1];
                    contactInfo.CityName = file.ReadLine().Split('|')[1];
                    contactInfo.Jurisdiction = file.ReadLine().Split('|')[1];
                    contactInfo.PostalOrZip = file.ReadLine().Split('|')[1];
                    contactInfo.Country = file.ReadLine().Split('|')[1];
                    contactInfo.Phone = file.ReadLine().Split('|')[1];
                    contactInfo.Email = file.ReadLine().Split('|')[1];
                }
                return contactInfo;
            }
        }

        public BillingInfo BillingInfo
        {
            get
            {
                BillingInfo billingInfo;
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "BillingInfo"))
                {
                    billingInfo.TransitNumber = file.ReadLine().Split('|')[1];
                    billingInfo.BranchName = file.ReadLine().Split('|')[1];
                    billingInfo.StreetNumber = file.ReadLine().Split('|')[1];
                    billingInfo.StreetName = file.ReadLine().Split('|')[1];
                    billingInfo.City = file.ReadLine().Split('|')[1];
                    billingInfo.Jurisdiction = file.ReadLine().Split('|')[1];
                    billingInfo.PostalOrZip = file.ReadLine().Split('|')[1];
                    billingInfo.Country = file.ReadLine().Split('|')[1];
                }
                return billingInfo;
            }
        }

        public string[] CurrencyTypes
        {
            get
            {
                List<string> currencyTypes = new List<string>();
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "CurrencyTypes"))
                {
                    try
                    {
                        while (!file.EndOfStream)
                            currencyTypes.Add(file.ReadLine());
                    }
                    catch (Exception) { }
                }
                return currencyTypes.ToArray();
            }
        }

        public string[] PricingTypes
        {
            get
            {
                List<string> pricingTypes = new List<string>();
                using (System.IO.StreamReader file = new System.IO.StreamReader(referenceDataPath + "PricingTypes"))
                {
                    try
                    {
                        while (!file.EndOfStream)
                            pricingTypes.Add(file.ReadLine());
                    }
                    catch (Exception) { }
                }
                return pricingTypes.ToArray();
            }
        }

        public string[] ResultMatchTypes
        {
            get
            {
                return new string[] { "Exact Match", "In-Exact Match", "No Match" };
            }
        }
    }
}
