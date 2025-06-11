using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Framework.Features;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Pages
{
    public class AJAXPage : BasePage
    {
        private HomePage HomePage;
        private WaitHelper WaitHelper;

        public AJAXPage(IWebDriver driver) : base(driver)
        {
            HomePage = new HomePage(driver);
            WaitHelper = new WaitHelper(driver);
        }

        By resultTextLocator = By.Id("result");
        
        public IWebElement X => Driver.FindElement(By.Id("x"));
        public IWebElement Y => Driver.FindElement(By.Id("y"));
        public IWebElement SumButton => Driver.FindElement(By.Id("calc"));
        public IWebElement ResultText => Driver.FindElement(resultTextLocator);
        
        public void SetX(int x)
        {
            X.SendKeys(x.ToString());
        }

        public void SetX(string x)
        {
            X.SendKeys(x);
        }

        public void SetY(string y)
        {
            Y.SendKeys(y);
        }

        public void SetY(int y)
        {
            Y.SendKeys(y.ToString());
        }

        public void ClickSumButton()
        {
            SumButton.Click();
        }

        public string GetResultText()
        {
            WaitHelper.WaitForElement(resultTextLocator);

            return ResultText.Text;
        }
    }
}