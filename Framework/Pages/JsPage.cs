using OpenQA.Selenium;

namespace Selenium.Framework.Pages
{
    public class JsPage : BasePage
    {
        public JsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement JsElement => Driver.FindElement(By.XPath("//div[@class='flash']"));
        public IWebElement TopInputField => Driver.FindElement(By.XPath("//input[@id='top']"));
        public IWebElement LeftInputField => Driver.FindElement(By.XPath("//input[@id='left']"));
        public IWebElement Process => Driver.FindElement(By.XPath("//button[@id='process']"));
    }
}