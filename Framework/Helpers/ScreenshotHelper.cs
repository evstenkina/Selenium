using System;
using System.IO;
using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium.Framework.TestData;

namespace Selenium.Framework.Helpers
{
    public class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                var testName = TestContext.CurrentContext.Test.Name;
                var fileName = $"{testName}_{timestamp}.png";
                var screenshotsDir = TestDataPath.ScreenshotsPath;
                var filePath = Path.Combine(screenshotsDir, fileName);
                screenshot.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath, "Screenshot on Failure");
                LogManager.GetLogger(typeof(ScreenshotHelper)).Info("Screenshot on failure is created");
            }
        }
    }
}