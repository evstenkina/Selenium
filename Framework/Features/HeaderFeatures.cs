using OpenQA.Selenium;
using log4net;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class HeaderFeatures
    {
        private readonly HeaderPage HeaderPage;
        private readonly ILog Logger;

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
        
        public void OpenJsTestPage()
        {
            HeaderPage.JSTestPage.Click();
            Logger.Info("JS page is opened");
        }

        public void Logout()
        {
            HeaderPage.LogOutLink.Click();
        }
    }
}