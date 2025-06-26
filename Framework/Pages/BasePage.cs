using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework.Pages
{
    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
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