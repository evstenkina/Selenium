using OpenQA.Selenium;
using Selenium.Framework.TestData;
using log4net;
using Selenium.Framework.Models;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class LoginFeature
    {
        private readonly LoginPage LoginPage;
        private readonly ILog Logger;
        
        private const string ExpectedResultText = "invalid username or password";

        public LoginFeature(IWebDriver driver)
        {
            LoginPage = new LoginPage(driver);
            Logger = LogManager.GetLogger(typeof(LoginFeature)); 
        }
        
        public void Login(User user, bool isBaseURL = true)
        {
            if (isBaseURL)
            {
                LoginPage.UsernameBox.SendKeys(user.Login);
                Logger.Info("Username is added");
                LoginPage.PasswordBox.SendKeys(user.Password);
                Logger.Info("Password is added");
                LoginPage.LoginButton.Click();
            }
        }
        
        public bool IsWelcomeTextDisplayed()
        {
            return LoginPage.OnHeader().GetWelcomeText.Contains(TestDataUsers.GetDefaultUser().FirstName);
        }
        
        public bool IsInvalidUserMessageDisplayed()
        {
            return LoginPage.GetFlashMessage().Contains(ExpectedResultText);
        }
    }
}