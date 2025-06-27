using OpenQA.Selenium;
using log4net;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class HomeFeatures
    {
        private readonly HomePage HomePage;
        private readonly ILog Logger;

        public HomeFeatures(IWebDriver driver)
        {
            HomePage = new HomePage(driver);
            Logger = LogManager.GetLogger(typeof(HeaderFeatures)); 
        }

        public void OpenCreatedApp()
        {
            HomePage.CreatedApp.Click();
            Logger.Info("Application is opened");
        }

        public void OpenApplicationPage()
        {
            HomePage.Application.Click();
            Logger.Info("Application page is opened");
        }

        public string GetPupolarAppTitle()
        {
            return HomePage.PopularApp.Text;
        }
    }
}