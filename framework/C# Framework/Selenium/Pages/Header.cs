using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class Header : BasePage
    {
        public Header(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement WelcomeLabel => Driver.FindElement(By.CssSelector(".welcome"));

        public IWebElement HomeLink => Driver.FindElement(By.LinkText("Home"));

        public IWebElement LogOutLink => Driver.FindElement(By.LinkText("Logout"));

        #region Methods

        public string GetWelcomeText => WelcomeLabel.Text;

        public LoginPage Logout()
        {
            LogOutLink.Click();
            return new LoginPage(Driver);
        }
        #endregion
    }
}