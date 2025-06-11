using System;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework.Features;

namespace Selenium.Framework
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected ILog Logger;
        
        [SetUp]
        public virtual void Init()
        {
            Logger = LogManager.GetLogger(GetType());
            Logger.Info("log4net initialized");
            Driver = Settings.GetDriver();
            Driver.Manage().Window.Maximize();
            Logger.Info("Test started");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Logger.Info("10 seconds wait is setup");
        }

        [TearDown]
        public virtual void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ScreenshotHelper.TakeScreenshot(Driver);
            }
            Driver.Quit();
        }
    } 
}
