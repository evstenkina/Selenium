using OpenQA.Selenium;

namespace Selenium.Framework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement UsernameBox => Driver.FindElement(By.Id("j_username"));
        public IWebElement PasswordBox => Driver.FindElement(By.Id("j_password"));
        public IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@value='Login']"));
    }
}