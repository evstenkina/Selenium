using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium.Framework
{
    public class Settings
    {
        public static string GetBaseUrl()
        {
            return ConfigurationManager.AppSettings["baseUrl"];
        }

        public static IWebDriver GetDriver()
        {
            return new FirefoxDriver();
        }
    }
}