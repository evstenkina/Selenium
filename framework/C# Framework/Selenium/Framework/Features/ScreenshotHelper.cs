using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.Framework.Features
{
    public static class ScreenshotHelper
    {
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
            }
        }
    }
}