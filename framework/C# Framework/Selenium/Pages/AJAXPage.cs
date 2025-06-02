using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Pages
{
    public class AJAXPage : BasePage
    {
        public AJAXPage(IWebDriver driver) : base(driver)
        {
        }
        
        //TODO перенести методы после локаторов

        public IWebElement AjaxPage => Driver.FindElement(By.XPath("//a[contains(@href, 'calc')]"));

        public void OpenAjaxPage()
        {
            AjaxPage.Click();
        }

        public IWebElement X => Driver.FindElement(By.Id("x"));

        public void Set1X(int x)
        {
            X.SendKeys(x.ToString());
        }

        public void SetX(string x)
        {
            X.SendKeys(x);
        }
        
        public IWebElement Y => Driver.FindElement(By.Id("y"));

        public void SetY(string y)
        {
            Y.SendKeys(y);
        }
        
        public void SetY(int y)
        {
            Y.SendKeys(y.ToString());
        }

        public IWebElement SumButton => Driver.FindElement(By.Id("calc"));

        public void ClickSumButton()
        {
            SumButton.Click();
        }

        public string GetResultText() //can I do so????
        {
            return Driver.FindElement(By.Id("result")).Text;
        }
        
 
        

        /*WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        IWebElement element => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("result")));*/
    }
}