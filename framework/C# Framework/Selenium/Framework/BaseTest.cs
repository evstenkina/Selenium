using System;
using System.Threading;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework.Features;

namespace Selenium.Framework
{
    public class BaseTest
    {
        private static ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>();
        protected IWebDriver Driver => threadDriver.Value;
        protected ILog Logger;
        
        [SetUp]
        public virtual void Init()
        {
            Logger = LogManager.GetLogger(GetType());
            Logger.Info("log4net initialized");
            threadDriver.Value = Settings.GetDriver();
            Driver.Manage().Window.Maximize();
            Logger.Info("Test started");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Logger.Info("10 seconds wait is setup");
        }

        [TearDown]
        public virtual void Cleanup()
        {
            ScreenshotHelper.TakeScreenshot(Driver);
            Driver.Quit();
        }
    } 
}
