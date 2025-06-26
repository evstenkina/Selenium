using OpenQA.Selenium;

namespace Selenium.Framework.Pages
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
    }
}