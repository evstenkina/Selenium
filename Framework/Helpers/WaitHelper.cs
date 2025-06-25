using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Framework.Helpers
{
    public class WaitHelper
    {
        private readonly WebDriverWait wait;

        public WaitHelper(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
        }

        public void WaitForElement(By locator, int timeout = 10)
        {
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        
        public void WaitForElementNotExist(By locator, int timeout = 10)
        {
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator)); 
        }
    }
}