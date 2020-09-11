using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement UsernameBox => Driver.FindElement(By.Id("j_username"));
        
        public IWebElement PasswordBox => Driver.FindElement(By.Id("j_password"));
        
        public IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@value='Login']"));
        
        public IWebElement RegisterLink => Driver.FindElement(By.PartialLinkText("Register"));

        #region Methods

        public HomePage Login(User user)
        {
            UsernameBox.SendKeys(user.Login);
            PasswordBox.SendKeys(user.Password);
            LoginButton.Click();
            return new HomePage(Driver);
        }
        #endregion
    }
}