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

        /*public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void EnterUsername(string username)
        {
            UsernameBox.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordBox.SendKeys(password);
        }*/
    }
}