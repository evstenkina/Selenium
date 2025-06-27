using System.Configuration;
using OpenQA.Selenium;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Helpers
{
    public static class SiteNavigator
    {
        public static void NavigateToLoginPage(IWebDriver driver, bool isBaseUrl = true)
        {
            string url = isBaseUrl
                ? Settings.GetBaseUrl()
                : Settings.GetAuthUrl();

            driver.Navigate().GoToUrl(url);
        }

        public static RegistrationPage NavigateToRegistrationPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseUrl"]);

            return new RegistrationPage(driver);
        }
    }
}