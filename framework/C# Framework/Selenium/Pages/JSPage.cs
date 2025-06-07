using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.Framework.Features;

namespace Selenium.Pages
{
    public class JSPage : BasePage
    {
        private HomePage HomePage;
        public JSPage(IWebDriver driver) : base(driver)
        {
            HomePage = new HomePage(driver);
        }
        
        public IWebElement JSElement => Driver.FindElement(By.XPath("//div[@class='flash']"));

        public IWebElement TopInputField => Driver.FindElement(By.XPath("//input[@id='top']"));

        public IWebElement LeftInputField => Driver.FindElement(By.XPath("//input[@id='left']"));

        public IWebElement Process => Driver.FindElement(By.XPath("//button[@id='process']"));
        

        public void OpenJSTestPage()
        {
            HomePage.JSTestPage.Click();
        }

        public void ClickProcessButton()
        {
            Process.Click();
        }
    }
}