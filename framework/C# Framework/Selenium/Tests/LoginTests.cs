using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class LoginTests : BaseTest
    {
        private User user;
        private LoginPage LoginPage;
        private LoginFeature LoginFeature;

        [SetUp]
        protected void Initialize()
        {
            user = TestDataUsers.GetDefaultUser();
            LoginPage = new LoginPage(Driver);
            LoginFeature = new LoginFeature(Driver);
        }

        [Test]
        public void ValidLoginTest()
        {
            SiteNavigator.NavigateToLoginPage(Driver, true);
            if (true)
            {
                LoginFeature.Login(TestDataUsers.GetDefaultUser());
                Logger.Info("Assert user login");
            }
            else
            {
            }

            Assert.That(LoginPage.OnHeader().GetWelcomeText.Contains(user.FirstName));
        }

        [Test]
        public void InvalidLoginTest()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetInvalidUser());
            Assert.That(LoginPage.GetFlashMessage().Contains("invalid username or password"));
        }
    }
}