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
        public static string GetBaseUrl()
        {
            return ConfigurationManager.AppSettings["http://selenium-courses.ipa.dataart.net:8080/"];
        }

        
        //TODO сделать переменную для PATH
        public static IWebDriver GetDriver()
        {
            /*new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--disable-build-check"); */
            
            switch (GetBrowserType())
            {
                case "chrome":
                    return new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));
                case "firefox":
                    return new FirefoxDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));
                default:
                    throw new Exception("Unknown browser type!");
            }
        }

        public static string GetBrowserType()
        {
            return ConfigurationManager.AppSettings["browserType"];
        }
    }
}