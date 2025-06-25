using System;
using System.IO;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

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
                    var options = new ChromeOptions();
                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--disable-gpu");
                    options.AddArgument("--disable-dev-shm-usage");
                    
                    return new ChromeDriver(driverPath, options);
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
            return ConfigurationManager.AppSettings["authURL"];;
        }

        public static string GetBrowserType()
        {
            return ConfigurationManager.AppSettings["browserType"];
        }
    }
}