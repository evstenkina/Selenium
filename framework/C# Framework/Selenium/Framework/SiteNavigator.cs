using System.Configuration;
using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework
{
    public class SiteNavigator
    {
        public static LoginPage NavigateToLoginPage(IWebDriver driver, bool isBaseURL = true)
        {
            string URL = isBaseURL ? ConfigurationManager.AppSettings["baseUrl"] : ConfigurationManager.AppSettings["authUrl"];
            driver.Navigate().GoToUrl(URL);
            
            return new LoginPage(driver);
        }
        
        public static RegistrationPage NavigateToRegistrationPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseUrl"]);
            
            return new RegistrationPage(driver);
        }
    }
}