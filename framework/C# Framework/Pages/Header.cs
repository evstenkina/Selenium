namespace Selenium.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class Header : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "welcome")]
        protected IWebElement WelcomeLabel { get; set; }

        [FindsBy(How = How.LinkText, Using = "Home")]
        protected IWebElement HomeLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Logout")]
        protected IWebElement LogOutLink { get; set; }

        public string WelcomeText => WelcomeLabel.Text;
        
        public Header(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage Logout()
        {
            LogOutLink.Click();
            return new LoginPage(Driver);
        }
    }
}
