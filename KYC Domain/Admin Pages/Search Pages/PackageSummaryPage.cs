﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using KYC_Domain.Helper_Classes;
using AventStack.ExtentReports;
using KYC_Domain.Data_Management;

namespace KYC_Domain.Admin_Pages
{
    public class PackageSummaryPage : AdminPages
    {
        static string packageItemsTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_grdPackageItems";
        static string backButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_btnBack";
        static string commentBoxId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_txtBoxComment";
        static string addCommentButtonId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_CommentSaveButton";
        static string commentTableId = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_grdPackageComments";

        static int packageItemIdIndex = 1;
        static int commentColumnIndex = 1;
        static int viewLinkColumnIndex = 9;
        static int cancelButtonColumnIndex = 10;

        TableInterface packageItems;

        public PackageSummaryPage()
        {
            packageItems = new TableInterface(packageItemsTableId, driver);
        }

        protected override bool IsAt()
        {
            return driver.Url.Contains("Search_Package.aspx");
        }

        public PackageSummaryPage GetPackageItemId(int packageIndex)
        {
            try
            {
                DynamicTestInformation.packageItemId = packageItems.GetElementByIndexes(packageIndex, packageItemIdIndex).GetAttribute("innerHTML");
                DynamicTestInformation.packageItemId = DynamicTestInformation.packageItemId.Substring(0, DynamicTestInformation.packageItemId.Length - 1);
                validation.StringLogger.LogWrite("Validation for retrieving Package Item Id is Passed");
                _test.Log(Status.Pass, "Validation for retrieving Package Item Id is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Pass, "Validation for retrieving Package Item Id is Failed");
            }
            return this;
        }

        public PackageResultsPage ViewPackageItem(int packageIndex)
        {
            try
            {
                IWebElement page = packageItems.GetElementByIndexes(packageIndex, viewLinkColumnIndex);
                Thread.Sleep(5000);
                page.Click();
                validation.StringLogger.LogWrite("Validation for Viewing Package Item is Passed");
                _test.Log(Status.Pass, "Validation for Viewing Package Item is Passed");
            }
            catch (Exception)
            {
                _test.Log(Status.Fail, "Validation for Viewing Package Item is Failed");
            }
            return new PackageResultsPage();
        }

        public PackageSummaryPage CancelPackageItem(int packageIndex)
        {
            packageItems.GetElementByIndexes(packageIndex, cancelButtonColumnIndex).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public PackageSummaryPage CancelAllPackageItems()
        {
            int numItems = packageItems.GetTotalNumRows();
            for (int i = 0; i < numItems; ++i)
            {
                CancelPackageItem(i);
            }
            return this;
        }

        public int GetNumPackages()
        {
            return packageItems.GetTotalNumRows();
        }

        public AdminSearchPage BackToSearch()
        {
            try
            {
                driver.FindElement(By.Id(backButtonId)).Click();
                validation.StringLogger.LogWrite("Validation for Back Button is Passed");
                _test.Log(Status.Pass, "Validation for Back Button is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for Back Button is Failed");
            }
            return new AdminSearchPage();
        }

        public PackageSummaryPage VerifyCommentCanBeAdded(string comment = "Comment generated by KYC-Automation project")
        {
            TableInterface commentTable;
            int numComments;
            try
            {
                commentTable = new TableInterface(commentTableId, driver);
                numComments = commentTable.GetTotalNumRows();
            }
            catch (Exception)
            {
                numComments = 0;
            }

            try
            {
                driver.SendKeysById(commentBoxId, comment);
                driver.ClickById(addCommentButtonId);

                commentTable = new TableInterface(commentTableId, driver);

                validation.AssertAreEqual(numComments + 1, commentTable.GetTotalNumRows());
                validation.AssertAreEqual(comment, commentTable.GetElementByIndexes(numComments, commentColumnIndex).Text);
                validation.StringLogger.LogWrite("Validation for adding of Comments is Passed");
                _test.Log(Status.Pass, "Validation for adding of Comments is Passed");
            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "Validation for adding of Comments is Failed");
            }
            return this;
        }
    }
}
