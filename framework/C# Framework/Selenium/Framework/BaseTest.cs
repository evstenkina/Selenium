using System;
using System.Threading;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework.Helpers;

namespace Selenium.Framework
{
    public class BaseTest
    {
        // private ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>();
        private ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>(()=> new Settings().GetDriver());
        protected IWebDriver Driver => threadDriver.Value;
        protected ILog Logger;
        
        [SetUp]
        public void Init()
        {
            Logger = LogManager.GetLogger(GetType());
            Logger.Info("log4net initialized");
            // threadDriver.Value = new Settings().GetDriver();
            Driver.Manage().Window.Maximize();
            Logger.Info("Test started");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Logger.Info("10 seconds wait is setup");
            SiteNavigator.NavigateToLoginPage(Driver);
        }

        [TearDown]
        public void Cleanup()
        {
            ScreenshotHelper.TakeScreenshot(Driver);
            Driver.Quit();
            Logger.Info("Browser is closed");
        }
    } 
}
