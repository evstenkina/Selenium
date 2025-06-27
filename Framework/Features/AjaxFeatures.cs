using OpenQA.Selenium;
using log4net;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class AjaxFeatures
    {
        private readonly AjaxPage AjaxPage;
        private readonly ILog Logger;

        public AjaxFeatures(IWebDriver driver)
        {
            AjaxPage = new AjaxPage(driver);
            Logger = LogManager.GetLogger(typeof(AjaxFeatures)); 
        }
        
        public string ElementsSetUp(dynamic X, dynamic Y)
        {
            AjaxPage.X.SendKeys(X.ToString());
            Logger.Info("X is set");
            AjaxPage.Y.SendKeys(Y.ToString());
            Logger.Info("Y is set");
            AjaxPage.SumButton.Click();
            Logger.Info("Result is displayed");
            
            return AjaxPage.GetResultText();
        }
    }
}