using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Helper_Classes
{
    public enum Order
    {
        Ascending,
        Descending
    };

    public class TableInterface
    {
        //The purpose of this class is to provide a unified interface for dealing with the specific kind of
        //tables seen throughout the KYC client and admin sites. The specific type of table can be found
        //on the following non-exclusive list of pages.

        //AdminSearchPage
        //PackageSummaryPage
        //ResultQueuePage
        //ResultSummaryPage - can use TableInterface without perfectly fitting the archetype
        //NUANSSearchResultsPage

        //Some common characteristics of the tables are:
        //First row are column titles
        //Last row can a "PagerStyle" class table containing links to the other rows in the table

        IWebElement Table => tableFromId ? driver.FindElement(By.Id(tableId)) : tableByElement;
        int numColumns;
        string tableId;
        ConcreteDriver driver;
        IWebElement tableByElement;

        int numRowsPerPage;
        bool numRowsPerPageIsKnown = false;
        bool tableFromId = true;

        /// <summary>
        /// Constructs a new TableInterface object
        /// Warning: If the page updates, TableInteface objects made using this constructor will break
        /// </summary>
        /// <param name="table">The table element</param>
        /// <param name="driver">The current WebDriver</param>
        /// <param name="numColumns">The manual override for the number of columns</param>
        public TableInterface(IWebElement table, ConcreteDriver driver, int numColumns)
        {
            tableFromId = false;
            tableByElement = table;
            this.driver = driver;
            this.numColumns = numColumns;
        }

        /// <summary>
        /// Constructs a new TableInterface object
        /// </summary>
        /// <param name="tableId">The element Id of the desired table</param>
        /// <param name="driver">The current WebDriver to be used to get the table</param>
        public TableInterface(string tableId, ConcreteDriver driver)
        {
            this.tableId = tableId;
            this.driver = driver;
            numColumns = this.Table.FindElements(By.TagName("tr"))[0].FindElements(By.TagName("th")).Count;
        }

        /// <summary>
        /// Constructs a new TableInterface object using a manual override for the number of columns. Useful
        /// when the number of columns can't be determined from the column titles.
        /// </summary>
        /// <param name="tableId">The element Id of the desired table</param>
        /// <param name="driver">The current WebDriver to be used to get the table</param>
        /// <param name="numColumns">The manual override for the number of columns</param>
        public TableInterface(string tableId, ConcreteDriver driver, int numColumns)
        {
            this.tableId = tableId;
            this.driver = driver;
            this.numColumns = numColumns;
        }

        /// <summary>
        /// Used to grab a specific web element by indexes. Will automatically cycle to the necessary page to
        /// find the required row
        /// Note: Ignores column header row. A row index of 0 is the first row of data
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the row in the table that contains the desired element</param>
        /// <param name="columnIndex">The zero-based index of the column in the table that contains the desired element</param>
        /// <returns>The element at the specified indexes</returns>
        public IWebElement GetElementByIndexes(int rowIndex, int columnIndex)
        {
            if (columnIndex >= numColumns || columnIndex < 0)
                throw new IndexOutOfRangeException("columnIndex " + columnIndex + " out of bounds");

            int numRowsPerPage = GetNumRowsPerPage();
            GoToPage(rowIndex / numRowsPerPage + 1);
            int visibleRowIndex = rowIndex % numRowsPerPage;
            return Table.FindElements(By.XPath("./tbody/tr[" + (visibleRowIndex + 2) + "]/td"))[columnIndex];
        }

        /// <summary>
        /// Used to grab the column header element at the specified column index
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public IWebElement GetColumnHeaderElement(int columnIndex)
        {
            if (columnIndex >= numColumns || columnIndex < 0)
                throw new IndexOutOfRangeException("columnIndex " + columnIndex + " out of bounds");

            return Table.FindElements(By.XPath("./tbody/tr[1]/th"))[columnIndex];
        }

        /// <summary>
        /// Determines if the table has any results in it
        /// </summary>
        /// <returns>True if table has results, false if table is empty</returns>
        public bool HasResults()
        {
            return (Table.FindElements(By.XPath("./tbody/tr")).Count - 1) == 0;
        }

        /// <summary>
        /// Retrieves the index of the last row in the table. Useful for searching the table from the back.
        /// </summary>
        /// <returns>An int index representing the last row in the table</returns>
        public int GetLastRowIndex()
        {
            int numRowsPerPage = GetNumRowsPerPage();
            if (PageLinksExist())
            {
                while (true)
                {
                    var links = GetPageLinkElements();
                    if (links.Count == 1 && links.Last().Text == "...")
                    {
                        break;
                    }
                    if (links.Last().Text == "...")
                        links.Last().Click();
                    else if (Int32.Parse(links.Last().Text) > GetCurrentPage())
                    {
                        links.Last().Click();
                        break;
                    }
                    else if (Int32.Parse(links.Last().Text) < GetCurrentPage())
                    {
                        break;
                    }
                }
            }
            int tableRows = Table.FindElements(By.XPath("./tbody/tr")).Count - 1; //- 1 for the column titles
            if (PageLinksExist())
                tableRows -= 1;
            return (tableRows - 1) + (GetCurrentPage() - 1) * numRowsPerPage;
        }

        /// <summary>
        /// Retrieves the total quantity of rows in the table.
        /// </summary>
        /// <returns>An int representing the number of rows in the table</returns>
        public int GetTotalNumRows()
        {
            return GetLastRowIndex() + 1;
        }

        /// <summary>
        /// Uses the page links at the bottom of the table to navigate to the desired page number
        /// </summary>
        /// <param name="desiredPageNumber"></param>
        public void GoToPage(int desiredPageNumber)
        {
            if (desiredPageNumber == GetCurrentPage())
                return;
            if (!PageLinksExist())
                throw new IndexOutOfRangeException("Page " + desiredPageNumber + " cannot be found.");

            while (true)
            {
                var pageLinkElements = GetPageLinkElements();
                foreach (var element in pageLinkElements)
                {
                    if (element.Text != "..." && Int32.Parse(element.Text) == desiredPageNumber)
                    {
                        element.Click();
                        return;
                    }
                }
                if (desiredPageNumber > GetCurrentPage()) //Is in a further set of pages
                {
                    if (pageLinkElements.Last().Text != "...")
                        throw new IndexOutOfRangeException("Page " + desiredPageNumber + " cannot be found.");
                    pageLinkElements.Last().Click();
                }
                if (desiredPageNumber < GetCurrentPage()) //Is in a previous set of pages
                {
                    if (pageLinkElements.First().Text != "...")
                        throw new IndexOutOfRangeException("Page " + desiredPageNumber + " cannot be found.");
                    pageLinkElements.First().Click();
                }
            }
        }

        public int GetCurrentPage()
        {
            driver.RemoveImplicitWait();
            int currentPage;
            try
            {
                currentPage = Int32.Parse(this.Table.FindElement(By.ClassName("PagerStyle")).FindElement(By.TagName("span")).Text);
            }
            catch (Exception)
            {
                currentPage = 1;
            }
            driver.AddImplicitWait();
            return currentPage;
        }

        /// <summary>
        /// Checks if the specified column in the table is in a specified sorted order.
        /// Check involves checking the first three rows on the first page, and the first
        /// row on the second page.
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="order">Indicates the expected sorted order</param>
        /// <returns></returns>
        public bool IsColumnInSortedOrder(int columnIndex, Order order)
        {
            try
            {
                string earlierText = GetElementByIndexes(0, columnIndex).Text;
                string laterText = GetElementByIndexes(1, columnIndex).Text;
                if (!CompareByOrder(earlierText, laterText, order))
                    return false;
                earlierText = laterText;
                laterText = GetElementByIndexes(2, columnIndex).Text;
                if (!CompareByOrder(earlierText, laterText, order))
                    return false;

                int numRowsPerPage = GetNumRowsPerPage();
                if (numRowsPerPage >= 3 && PageLinksExist())
                {
                    earlierText = laterText;
                    laterText = GetElementByIndexes(numRowsPerPage, columnIndex).Text; //Should be first element on second page, if it exists
                    return CompareByOrder(earlierText, laterText, order);
                }
            }
            catch (IndexOutOfRangeException) { }
            return true;
        }

        /// <summary>
        /// This method retrieves the string names of the headers of all the columns in the table
        /// </summary>
        /// <returns></returns>
        public List<string> GetColumnHeaderNames()
        {
            var headerElements = Table.FindElements(By.XPath("./tbody/tr[1]/th"));

            List<string> headerNames = new List<string>(headerElements.Count);
            foreach (var element in headerElements)
            {
                headerNames.Add(element.Text);
            }

            return headerNames;
        }

        public int GetNumColumns()
        {
            return numColumns;
        }

        /// <summary>
        /// Note: Excludes the current page, which is not a link, but a span.
        /// </summary>
        /// <returns></returns>
        private IReadOnlyCollection<IWebElement> GetPageLinkElements()
        {
            if (PageLinksExist())
            {
                IWebElement pagerStyleElement = Table.FindElement(By.ClassName("PagerStyle"));
                return pagerStyleElement.FindElements(By.XPath("./td/table/tbody/tr//a"));
            }
            return null;
        }

        private bool PageLinksExist()
        {
            driver.RemoveImplicitWait();
            try
            {
                this.Table.FindElement(By.ClassName("PagerStyle"));
                driver.AddImplicitWait();
                return true;
            }
            catch (Exception) { }
            driver.AddImplicitWait();
            return false;
        }

        private bool IsOnLastPage()
        {
            if (!PageLinksExist())
            {
                return true;
            }
            var pageLinks = GetPageLinkElements();
            string lastVisiblePageText = pageLinks.Last().Text;
            if (lastVisiblePageText == "..." && pageLinks.Count == 1)
                return true;
            return (lastVisiblePageText != "..." && Int32.Parse(lastVisiblePageText) <= GetCurrentPage());
        }

        private int GetNumRowsPerPage()
        {
            if (numRowsPerPageIsKnown)
                return numRowsPerPage;

            if (PageLinksExist() && IsOnLastPage())
                GoToPage(GetCurrentPage() - 1);
            int tableRows = Table.FindElements(By.XPath("./tbody/tr")).Count - 1; //- 1 for the column titles
            if (PageLinksExist())
                tableRows -= 1;
            numRowsPerPageIsKnown = true;
            numRowsPerPage = tableRows;
            return numRowsPerPage;
        }

        private bool CompareByOrder(string first, string second, Order order)
        {
            if (order == Order.Ascending)
                return (first.CompareTo(second) <= 0);
            if (order == Order.Descending)
                return (first.CompareTo(second) >= 0);

            throw new NotImplementedException(order.ToString() + " not implemented");
        }
    }
}
