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
        protected WaitHelper WaitHelper;
        
// TODO delete 'this'

        [SetUp]
        public virtual void Init()
        {
            this.Logger = LogManager.GetLogger(GetType());
            this.Logger.Info("log4net initialized");
            this.Driver = Settings.GetDriver();
            this.Driver.Manage().Window.Maximize();
            this.Logger.Info("Test started");
            //WaitHelper = new WaitHelper(Driver).WaitForElement();
        }

        [TearDown]
        public virtual void Cleanup()
        {
            /*if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot(TestContext.CurrentContext.Test.Name);
            }*/
            Driver.Quit();
        }
        
        Screenshot screenshot;

        public void TakeScreenshot() //перенести в отдельный класс, запустить сначала отдельно
        {
            screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var testName = TestContext.CurrentContext.Test.Name;
            var fileName = $"{testName}_{timestamp}.png";
            
            
            
            /*var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var fileName = $"{testName}_{timestamp}.png";
            var screenshotsDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotsDir); - не надо, так как каждый раз будет новая папка
            var filePath = Path.Combine(screenshotsDir, fileName);
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(filePath, "Screenshot on Failure");-??????*/
            
        }
    }
}
