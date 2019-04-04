using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KYC_Domain
{
    public class ConcreteDriver : IWebDriver
    {
        IWebDriver driver;

        #region IWebDriver Interface methods
        public void Dispose()
        {
            driver.Dispose();

        }

        public IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }


        public void Close()
        {
            driver.Close();
        }

        public string CurrentWindowHandle => driver.CurrentWindowHandle;

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            return driver.Navigate();
        }

        public string PageSource => driver.PageSource;

        public void Quit()
        {
            driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        public ITakesScreenshot ts => (ITakesScreenshot)driver;

        public string Title => driver.Title;

        public string Url
        {
            get { return driver.Url; }
            set { driver.Url = value; }
        }

        public ReadOnlyCollection<string> WindowHandles => driver.WindowHandles;
        #endregion

        #region Convenience Methods

        public void SendKeysById(string id, string keys)
        {
            FindElement(By.Id(id)).SendKeys(keys);
        }

        public void ClickById(string id)
        {
            FindElement(By.Id(id)).Click();
        }

        /// <summary>
        /// For use with Select elements
        /// </summary>
        /// <param name="selectId"></param>
        /// <param name="selectValue"></param>
        public void SelectValueById(string selectId, string selectValue)
        {
            new SelectElement(FindElement(By.Id(selectId))).SelectByValue(selectValue);
        }

        /// <summary>
        /// For use with Select elements
        /// </summary>
        /// <param name="selectId"></param>
        /// <param name="selectText"></param>
        public void SelectTextById(string selectId, string selectText)
        {
            new SelectElement(FindElement(By.Id(selectId))).SelectByText(selectText);
        }

        public void AcceptAlert()
        {
            SwitchTo().Alert().Accept();
        }

        #endregion




        public ConcreteDriver(string driverName)
        {
            if (driverName == "chrome")
                driver = new ChromeDriver();
            else if (driverName == "ie")
            {
                InternetExplorerDriverService driverService = InternetExplorerDriverService.CreateDefaultService();

                driverService.LibraryExtractionPath = Environment.CurrentDirectory;

                InternetExplorerOptions options = new InternetExplorerOptions();
                options.EnableNativeEvents = true;
                options.IgnoreZoomLevel = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.EnsureCleanSession = true;

                // The followng field is a workaround for a known Selenium bug; 
                //      IE11 Driver cannot perform any actions while the download bar is visible
                options.PageLoadStrategy = PageLoadStrategy.Eager;

                driver = new InternetExplorerDriver(driverService, options, TimeSpan.FromSeconds(60));
            }
            else

                throw new NotImplementedException(driverName + " not implemented");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        public void RemoveImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public void AddImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}