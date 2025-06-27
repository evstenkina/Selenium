using OpenQA.Selenium;

namespace Selenium.Framework.Pages
{
    public class HeaderPage : BasePage
    {
        public HeaderPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetWelcomeText => WelcomeLabel.Text;
        
        public IWebElement WelcomeLabel => Driver.FindElement(By.CssSelector(".welcome"));
        public IWebElement LogOutLink => Driver.FindElement(By.LinkText("Logout"));
        public IWebElement AjaxPage => Driver.FindElement(By.XPath("//a[text()='Ajax test page']"));
        public IWebElement MyApplication => Driver.FindElement(By.XPath("//a[@href='/my' and normalize-space(text())='My applications']"));
        public IWebElement JSTestPage => Driver.FindElement(By.XPath("//a[text()='JS test page']"));
    }
}