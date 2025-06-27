using OpenQA.Selenium;

namespace Selenium.Framework.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement FlashMessage => Driver.FindElement(By.CssSelector(".flash"));

        public string GetFlashMessage() => FlashMessage.Text;

        public HeaderPage OnHeader()
        {
            return new HeaderPage(Driver);
        }
    }
}