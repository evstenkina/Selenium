using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Framework.Features
{
    public class WaitHelper
    {
        public static IWebDriver Driver;
        
        public static readonly WebDriverWait wait;

        public WaitHelper(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitForElement(By element)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}