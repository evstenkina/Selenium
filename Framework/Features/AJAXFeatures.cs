using OpenQA.Selenium;
using Selenium.Pages;
using log4net;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class AJAXFeatures
    {
        private AJAXPage AJAXPage;
        protected ILog Logger;

        public AJAXFeatures(IWebDriver driver)
        {
            AJAXPage = new AJAXPage(driver);
            Logger = LogManager.GetLogger(typeof(AJAXFeatures)); 
        }
        
        public string ElementsSetUp(dynamic X, dynamic Y)
        {
            AJAXPage.X.SendKeys(X.ToString());
            Logger.Info("X value is set");
            AJAXPage.Y.SendKeys(Y.ToString());
            Logger.Info("Y is set");
            AJAXPage.SumButton.Click();
            Logger.Info("Result is displayed");
            
            return AJAXPage.GetResultText();
        }
    }
}