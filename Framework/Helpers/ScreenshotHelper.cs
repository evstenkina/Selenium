using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using log4net;

namespace Selenium.Framework.Helpers
{
    public static class ScreenshotHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ScreenshotHelper));
        public static void TakeScreenshot(IWebDriver driver)
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                var testName = TestContext.CurrentContext.Test.Name;
                var fileName = $"{testName}_{timestamp}.png";
                var screenshotsDir = TestDataPath.ScreenshotsPath;
                var filePath = Path.Combine(screenshotsDir, fileName);
                screenshot.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath, "Screenshot on Failure");
                Logger.Info("Screenshot on failure is created");
            }
        }
    }
}