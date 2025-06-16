using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement RegisterNewUserButton => Driver.FindElement(By.XPath("//*[@href='../register']"));

        public IWebElement NameBox => Driver.FindElement(By.CssSelector("input[name='name']"));

        public IWebElement FirstNameBox => Driver.FindElement(By.CssSelector("input[name='fname']"));

        public IWebElement LastNameBox => Driver.FindElement(By.CssSelector("input[name='lname']"));

        public IWebElement Password => Driver.FindElement(By.CssSelector("input[name='password']"));

        public IWebElement ConfirmPassword => Driver.FindElement(By.CssSelector("input[name='passwordConfirm']"));
        
        public IWebElement RoleUser => Driver.FindElement(By.XPath("//option[@value='USER']"));

        public IWebElement RoleDeveloper => Driver.FindElement(By.XPath("//option[@value='DEVELOPER']"));

        public IWebElement RegisterButton => Driver.FindElement(By.XPath("//input[@value='Register']"));
        
    }
}