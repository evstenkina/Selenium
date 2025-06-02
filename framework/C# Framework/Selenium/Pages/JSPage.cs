using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class JSPage : BasePage
    {
        public JSPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement JSTestPage => Driver.FindElement(By.XPath("//a[contains(@href, '/js/')]"));
        
        public IWebElement JSElement => Driver.FindElement(By.XPath("//div[@class='flash']"));
        
        //TODO a separate class, locators separate block
        public class Coordinates
        {
            public int Top { get; }
            public int Left { get; }

            public Coordinates(int top, int left)
            {
                Top = top;
                Left = left;
            }
        }

        public IWebElement TopInputField => Driver.FindElement(By.XPath("//input[@id='top']"));
        
        
        public IWebElement LeftInputField => Driver.FindElement(By.XPath("//input[@id='left']"));
        
        
        public IWebElement Process => Driver.FindElement(By.XPath("//button[@id='process']"));

        
    }
}