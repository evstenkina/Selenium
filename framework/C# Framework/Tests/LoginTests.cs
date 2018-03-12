using Selenium.Framework;
using Selenium.Pages;
using NUnit.Framework;

public class LoginTests : BaseTest
{
    private User user;

    [SetUp]
    protected void Initialize()
    {
        user = User.GetDefaultUser();
    }

    [Test]
    public void ValidLoginTest()
    {
        HomePage homePage = SiteNavigator.NavigateToLoginPage(Driver).Login(user);
        Logger.Info("Assert user login");
        Assert.True(homePage.OnHeader().WelcomeText.Contains(user.FirstName));
    }

    [Test]
    public void InvalidLoginTest()
    {
        user.Password = "invalid";

        LoginPage loginPage = SiteNavigator.NavigateToLoginPage(Driver);
        loginPage.Login(user);
        Assert.True(loginPage.GetFlashMessage().Contains("invalid username or password"));
    }
}