using System;
using System.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium.Framework
{
    public class Settings
    {
        public IWebDriver GetDriver()
        {
            var driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers");
            
            switch (GetBrowserType())
            {
                case "chrome":
                    return new ChromeDriver(driverPath);
                    
                case "firefox":
                    return new FirefoxDriver(driverPath);
                
                default:
                    throw new Exception("Unknown browser type!");
            }
        }
        
        public static string GetBaseUrl()
        {
            return ConfigurationManager.AppSettings["baseURL"];
        }
        public static string GetAuthUrl()
        {
            return ConfigurationManager.AppSettings["authURL"];
        }

        public static string GetBrowserType()
        {
            return ConfigurationManager.AppSettings["browserType"];
        }
    }
}