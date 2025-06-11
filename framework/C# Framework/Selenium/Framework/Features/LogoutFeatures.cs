using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework.Features
{
    public class LogoutFeatures
    {
        private IWebDriver Driver;
        private LoginPage LoginPage;
        
        public bool IsLoginButtDisp() => LoginPage.LoginButton.Displayed;
        
        public LogoutFeatures(IWebDriver driver)
        {
            Driver = driver;
            LoginPage = new LoginPage(Driver);
        }
        string baseURL = SiteNavigator.baseURL;
        
        public void OpenNewBrowserTab()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open(arguments[0], '_blank');", baseURL);
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        public void NavigateToFirstTab()
        {
            List<string> tabs = Driver.WindowHandles.ToList();
            Driver.SwitchTo().Window(tabs[0]);
        }
    }
}