using OpenQA.Selenium;
using Selenium.Framework.Helpers;

namespace Selenium.Framework.Pages
{
    public class AjaxPage : BasePage
    {
        private WaitHelper WaitHelper;

        public AjaxPage(IWebDriver driver) : base(driver)
        {
            WaitHelper = new WaitHelper(driver);
        }

        By resultTextLocator = By.Id("result");
        
        public IWebElement X => Driver.FindElement(By.Id("x"));
        public IWebElement Y => Driver.FindElement(By.Id("y"));
        public IWebElement SumButton => Driver.FindElement(By.Id("calc"));
        public IWebElement ResultText => Driver.FindElement(resultTextLocator);

        public string GetResultText()
        {
            WaitHelper.WaitForElement(resultTextLocator);

            return ResultText.Text;
        }
    }
}