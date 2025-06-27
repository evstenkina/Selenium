using System;
using System.Threading;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework.Features;
using Selenium.Framework.Helpers;

namespace Selenium.Framework
{
    public class BaseTest
    {
        [ThreadStatic] protected static LoginFeature LoginFeature;
        [ThreadStatic] protected static HeaderFeatures HeaderFeatures;
        [ThreadStatic] protected static RegistrationFeatures RegistrationFeatures;
        
        private static ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>(()=> new Settings().GetDriver());
        protected IWebDriver Driver => threadDriver.Value;
        protected ILog Logger;
        
        [SetUp]
        public void Init()
        {
            Logger = LogManager.GetLogger(GetType());
            Logger.Info("log4net initialized");
            Driver.Manage().Window.Maximize();
            Logger.Info("Test started");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Logger.Info("10 seconds wait is setup");
            SiteNavigator.NavigateToLoginPage(Driver);
            Logger.Info("Login successful");
            
            LoginFeature = new LoginFeature(Driver);
            HeaderFeatures = new HeaderFeatures(Driver);
            RegistrationFeatures = new RegistrationFeatures(Driver);
        }

        [TearDown]
        public void Cleanup()
        {
            ScreenshotHelper.TakeScreenshot(Driver);
            Logger.Info("Taking screenshot");
            
            if (Driver != null)
            {
                Driver.Quit();
                Logger.Info("Browser is closed");
                threadDriver.Value = null;
            }
        }
    } 
}
