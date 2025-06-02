using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework.Features
{
    public class LoginFeature
    {
        private LoginPage LoginPage;
        private HomePage HomePage;

        public LoginFeature(IWebDriver driver)
        {
            LoginPage = new LoginPage(driver);
            HomePage = new HomePage(driver);
        }
        
        public HomePage Login(User user)
        {
            LoginPage.EnterUsername(user.Login);
            LoginPage.EnterPassword(user.Password);
            LoginPage.ClickLoginButton();
            
            return HomePage;
        }
    }
}