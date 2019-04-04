using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC_Domain.Client_Pages
{
    public class SetupDashboardPage : ClientPages
    {
        protected override bool IsAt()
        {
            if (driver.Url.Contains("Dashboard"))
            {
                try
                {
                    return driver.FindElement(By.ClassName("bigheading")).Text == "Dashboard Setup";
                }
                catch (Exception) { }
            }
            return false;
        }

        public void DVSetupAndAddUser()
        {
            var DVSetupMyUser = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_DashboardSetup_rpMenu_ctl00_btnMyUsers"));
            DVSetupMyUser.Click();

            var DVAddNewUser = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyUsers_btnAddUser"));
            DVAddNewUser.Click();

            var BackAddNewUser = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_AddUser_btnAddUserBack"));
            BackAddNewUser.Click();
        }

        public void BackDVSetupAndAddUser()
        {
            var DVBack = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyUsers_btnMyUsersBack"));
            DVBack.Click();
        }

        public void DVSetupAndAddTransit()
        {
            var DVSetupMyTransit = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_DashboardSetup_rpMenu_ctl00_btnMyTransits"));
            DVSetupMyTransit.Click();

            var DVAddNewTransit = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyTransits_btnAddTransit"));
            DVAddNewTransit.Click();

            var BackAddNewTransit = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_AddTransit_btnAddTransitBack"));
            BackAddNewTransit.Click();
        }

        public void DVBackTransit()
        {

            var BackTransit = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyTransits_btnMyTransitsBack"));
            BackTransit.Click();
        }

        public void PDSetupandAddNewUser()
        {
            var PDSetupMyUsers = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_DashboardSetup_rpMenu_ctl01_btnMyUsers"));
            PDSetupMyUsers.Click();
            var PDAddNewUser = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyUsers_btnAddUser"));
            PDAddNewUser.Click();

            var PDBack = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_AddUser_btnAddUserBack"));
            PDBack.Click();
        }

        public void PDBack()
        {
            var PDhBack = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyUsers_btnMyUsersBack"));
            PDhBack.Click();
        }

        public void PDSetupandAddNewTransit()
        {
            var PDSetupMyTransit = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_DashboardSetup_rpMenu_ctl01_btnMyTransits"));
            PDSetupMyTransit.Click();

            var PDAddNewTransit = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyTransits_btnAddTransit"));
            PDAddNewTransit.Click();

            var PDTBAck = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_AddTransit_btnAddTransitBack"));
            PDTBAck.Click();
        }
        public void BackPDNewUser()
        {
            var PDThBack = driver.FindElement(By.Id("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder_Body_Dashboard_MyTransits_btnMyTransitsBack"));
            PDThBack.Click();
        }
    }
}
