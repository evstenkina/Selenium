using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using log4net;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class LogoutFeatures
    {
        private readonly IWebDriver Driver;
        private readonly LoginPage LoginPage;
        protected readonly ILog Logger;
        
        public bool IsLoginButtDisp() => LoginPage.LoginButton.Displayed;
        
        public LogoutFeatures(IWebDriver driver)
        {
            Driver = driver;
            LoginPage = new LoginPage(Driver);
            Logger = LogManager.GetLogger(typeof(LogoutFeatures));
        }
        
        public void OpenNewBrowserTab()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open(arguments[0], '_blank');", Settings.GetBaseUrl());
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Logger.Info("New browser tab is opened");
        }

        public void NavigateToFirstTab()
        {
            List<string> tabs = Driver.WindowHandles.ToList();
            Driver.SwitchTo().Window(tabs[0]);
            Logger.Info("First browser tab is opened");
        }
    }
}