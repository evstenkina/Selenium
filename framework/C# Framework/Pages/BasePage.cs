using System;

namespace Selenium.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(this.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".flash")]
        protected IWebElement FlashMessage { get; set; }

        public String GetFlashMessage()
        {
            return FlashMessage.Text;
        }

        public Header OnHeader()
        {
            return new Header(Driver);
        }
    }
}
