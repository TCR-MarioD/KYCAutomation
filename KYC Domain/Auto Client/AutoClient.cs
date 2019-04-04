using KYC_Domain.Data_Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;

namespace KYC_Domain.Auto_Client
{
    public class AutoClient
    {
        /// <summary>
        /// This method launches the .exe, selects the "Developer Form" button and submits the Package Item Id captured from the Admin side
        /// </summary>
        public static void getWindow()
        {
            // Launch application instance
            Application application = Application.Launch(ConfigurationManager.AppSettings["PathToAutoClient"]);
            //Window window1 = application.GetWindow("Select Automation Instance", InitializeOption.NoCache);

            //// Select Default Automation from dropdown and click OK
            //// If Auto Client is configured to skip this menu, the next 4 lines can be commented out.
            //ListBox listbox = window1.Get<ListBox>();
            //listbox.Select("Default Automation");
            //Button ok = window1.Get<Button>(SearchCriteria.ByText("OK"));
            //ok.Click();

            // Select Developer Form in Menu Bar and enter package item ID
            Window window2 = application.GetWindow("eSearch Automation on QA - Default Automation", InitializeOption.NoCache);
            MenuBar menuBar = window2.MenuBar;
            menuBar.MenuItem("Developer Form").Click();

            Keyboard.Instance.Enter(DynamicTestInformation.packageItemId);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            // 30 sec sleep to allow AutoClient to complete processing before results are checked
            Thread.Sleep(30000);
        }
    }
}
