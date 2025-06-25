using OpenQA.Selenium;
using Selenium.Framework.TestData;
using Selenium.Pages;
using log4net;

namespace Selenium.Framework.Features
{
    public class LoginFeature
    {
        private LoginPage LoginPage;
        private HomePage HomePage;
        protected ILog Logger;

        public LoginFeature(IWebDriver driver)
        {
            LoginPage = new LoginPage(driver);
            HomePage = new HomePage(driver);
        }
        
        public HomePage Login(User user, bool isBaseURL = true)
        {
            if (isBaseURL)
            {
                LoginPage.UsernameBox.SendKeys(user.Login);
                Logger.Info("Username1 is added");
                LoginPage.PasswordBox.SendKeys(user.Password);
                Logger.Info("Password is added");
                LoginPage.LoginButton.Click();
            }
            
            return HomePage;
        }
        
        public bool IsWelcomeTextDisplayed()
        {
            var user = TestDataUsers.GetDefaultUser();
            return LoginPage.OnHeader().GetWelcomeText.Contains(user.FirstName);
        }
        
        public bool IsInvalidUserMessageDisplayed()
        {
            string expectedResultText = "invalid username or password";
            return LoginPage.GetFlashMessage().Contains(expectedResultText);
        }
    }
}