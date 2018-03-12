using System.Configuration;
using OpenQA.Selenium;

namespace Selenium.Framework
{
    public class SiteNavigator
    {
        public static LoginPage NavigateToLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseUrl"]);
            return new LoginPage(driver);
        }
    }
}