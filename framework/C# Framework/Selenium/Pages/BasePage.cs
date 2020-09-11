using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebElement FlashMessage => Driver.FindElement(By.CssSelector(".flash"));

        public string GetFlashMessage() => FlashMessage.Text;

        public Header OnHeader()
        {
            return new Header(Driver);
        }
    }
}