using OpenQA.Selenium;
using Selenium.Pages;
using log4net;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class HeaderFeatures
    {
        private HeaderPage HeaderPage;
        private IWebDriver Driver;
        protected ILog Logger;

        public HeaderFeatures(IWebDriver driver)
        {
            HeaderPage = new HeaderPage(driver);
            Logger = LogManager.GetLogger(typeof(HeaderFeatures)); 
        }
        
        public void OpenAjaxPage()
        {
            HeaderPage.AjaxPage.Click();
            Logger.Info("Ajax page is opened");
        }
        
        public void OpenMyApplicationPage()
        {
            HeaderPage.MyApplication.Click();
            Logger.Info("My application page is opened");
        }
        
        public void OpenJSTestPage()
        {
            HeaderPage.JSTestPage.Click();
            Logger.Info("JS page is opened");
        }

        public LoginPage Logout()
        {
            HeaderPage.LogOutLink.Click();

            return new LoginPage(Driver);
        }
    }
}