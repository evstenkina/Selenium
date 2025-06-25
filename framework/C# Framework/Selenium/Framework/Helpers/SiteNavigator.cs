using System.Configuration;
using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework.Helpers
{
    public class SiteNavigator
    {
        public static LoginPage NavigateToLoginPage(IWebDriver driver, bool isBaseURL = true)
        {
            string URL = isBaseURL
                ? Settings.GetBaseUrl()
                : Settings.GetAuthUrl();

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