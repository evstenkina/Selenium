using Selenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class LoginPage : BasePage
{
    [FindsBy(How = How.Id, Using = "j_username")]
    protected IWebElement UsernameBox { get; set; }

    [FindsBy(How = How.Id, Using = "j_password")]
    protected IWebElement PasswordBox { get; set; }

    [FindsBy(How = How.XPath, Using = "//input[@value='Login']")]
    protected IWebElement LoginButton { get; set; }

    [FindsBy(How = How.PartialLinkText, Using = "Register")]
    protected IWebElement RegisterLink { get; set; }

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public HomePage Login(User user)
    {
        UsernameBox.SendKeys(user.Login);
        PasswordBox.SendKeys(user.Password);
        LoginButton.Click();
        return new HomePage(Driver);
    }
}