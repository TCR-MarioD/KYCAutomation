using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using DHUIFramework;
using System.Data;

namespace KYC_Domain.Data_Management
{
    public class TestData
    {
        DataRow dataRow;
        DataRow manageUserDataRow;

        public TestData(string testDataPath, string testName)
        {
            var dataTable1 = DataHelper.LoadExcel(testDataPath, "Sheet1");
            dataTable1.PrimaryKey = new DataColumn[] { dataTable1.Columns["TestCaseID"] };
            dataRow = dataTable1.Rows.Find(testName);

            var dataTable2 = DataHelper.LoadExcel(testDataPath, "ManageUser");
            dataTable2.PrimaryKey = new DataColumn[] { dataTable2.Columns["TestCaseID"] };
            manageUserDataRow = dataTable2.Rows.Find(testName);
        }

        public string Jurisdiction => (string)dataRow["Jurisdiction"];

        public string BaseEnterpriseName => (string)dataRow["Base Enterprise Name"];

        public string BaseEnterpriseNum => (string)dataRow["Base Enterprise Number"];

        public string[] ServiceNames => ParseServiceNames((string)dataRow["Service(s)"]);

        // Fields for Manage User Test Cases
        public string FirstName => (string)manageUserDataRow["First Name"];
        public string MiddleName => (string)manageUserDataRow["Middle Name"];
        public string LastName => (string)manageUserDataRow["Last Name"];
        public string Role => (string)manageUserDataRow["Role"];
        public string Email => (string)manageUserDataRow["Email"];
        public string Username => (string)manageUserDataRow["Username"];

        private string[] ParseServiceNames(string serviceNames)
        {
            string[] rawServiceNames = serviceNames.Split(',');
            string[] processedServiceNames = new string[rawServiceNames.Length];
            for (int i = 0; i < rawServiceNames.Count(); ++i)
            {
                string lowerServiceName = rawServiceNames[i].ToLower();
                if (lowerServiceName.Contains("trade name") || lowerServiceName.Contains("partnership report"))
                    processedServiceNames[i] = "Trade Name / Partnership Report";

                else if (lowerServiceName.Contains("business name"))
                    processedServiceNames[i] = "Business Names Report";

                else if (lowerServiceName.Contains("corporate") && !lowerServiceName.Contains("usa") && !lowerServiceName.Contains("int"))
                    processedServiceNames[i] = "Corporate Profile Search";

                else if (lowerServiceName.Contains("article") && lowerServiceName.Contains("incorp"))
                    processedServiceNames[i] = "Articles of Incorporation";

                else if (lowerServiceName.Contains("certificate") && lowerServiceName.Contains("status") && !lowerServiceName.Contains("usa"))
                    processedServiceNames[i] = "Certificate of Status";

                else if (lowerServiceName.Contains("bank") && lowerServiceName.Contains("security"))
                    processedServiceNames[i] = "Bank Act Security - Notice of Intention";

                else if (lowerServiceName.Contains("usa") && lowerServiceName.Contains("certificate"))
                    processedServiceNames[i] = "USA Good Standing Certificate / Certificate of Existence";

                else if (lowerServiceName.Contains("usa") && !lowerServiceName.Contains("certificate") && lowerServiceName.Contains("corporate"))
                    processedServiceNames[i] = "USA Corporate Annual Report";

                else if (lowerServiceName.Contains("inter") && !lowerServiceName.Contains("usa") && lowerServiceName.Contains("corporate"))
                    processedServiceNames[i] = "International Corporate Profile Search";

                else
                    throw new Exception("Service with name: '" + rawServiceNames[i] + "' not recognized.");
            }
            if (processedServiceNames.Length != processedServiceNames.Distinct().Count())
                throw new Exception("Parsing has produced two identical services");
            return processedServiceNames;
        }
    }
}