using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Data_Management
{
    /// <summary>
    /// The purpose of this class is to store information that is gathered during execution of a test case, but required
    /// to be used in a disparate location. It allows the tester to avoid the use of variables.
    /// </summary>
    public static class DynamicTestInformation
    {
        internal static string jurisdiction;
        internal static string enterpriseName;
        internal static List<int> serviceIndexes = new List<int>();
        internal static string organizationName;
        internal static string packageItemId;

        public static string CalculatedReferenceNumber
        {
            get
            {
                string referenceNumber = jurisdiction;
                foreach (int serviceIndex in serviceIndexes)
                    referenceNumber += "-" + serviceIndex;
                return referenceNumber;
            }
        }

        public static string EnterpriseName => enterpriseName;

        public static string OrganizationName => organizationName;
    }
}
