using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.Framework.Features;

namespace Selenium.Pages
{
    public class JSPage : BasePage
    {
        public JSPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement JSElement => Driver.FindElement(By.XPath("//div[@class='flash']"));
        public IWebElement TopInputField => Driver.FindElement(By.XPath("//input[@id='top']"));
        public IWebElement LeftInputField => Driver.FindElement(By.XPath("//input[@id='left']"));
        public IWebElement Process => Driver.FindElement(By.XPath("//button[@id='process']"));

        public void ClickProcessButton()
        {
            Process.Click();
        }
        public void TopInputFieldSendKeys(string text)
        {
            TopInputField.SendKeys(text);
        }
        public void LeftInputFieldSendKeys(string text)
        {
            LeftInputField.SendKeys(text);
        }
    }
}