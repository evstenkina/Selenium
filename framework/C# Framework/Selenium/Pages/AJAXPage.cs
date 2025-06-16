using OpenQA.Selenium;
using Selenium.Framework.Features;

namespace Selenium.Pages
{
    public class AJAXPage : BasePage
    {
        private WaitHelper WaitHelper;

        public AJAXPage(IWebDriver driver) : base(driver)
        {
            WaitHelper = new WaitHelper(driver);
        }

        By resultTextLocator = By.Id("result");
        
        private IWebElement X => Driver.FindElement(By.Id("x"));
        private IWebElement Y => Driver.FindElement(By.Id("y"));
        private IWebElement SumButton => Driver.FindElement(By.Id("calc"));
        private IWebElement ResultText => Driver.FindElement(resultTextLocator);
        
        /*public void SetX(int x)
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
        */
        
        public void SetX(object x)
        {
            X.SendKeys(x.ToString());
        }

        public void SetY(object y)
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