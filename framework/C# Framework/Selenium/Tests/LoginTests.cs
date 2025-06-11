using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginPage LoginPage;
        private LoginFeature LoginFeature;

        [SetUp]
        protected void Initialize()
        {
            LoginPage = new LoginPage(Driver);
            LoginFeature = new LoginFeature(Driver);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ValidLoginTest(bool isBaseURL)
        {
            var user = TestDataUsers.GetDefaultUser();
            SiteNavigator.NavigateToLoginPage(Driver, isBaseURL);
            Logger.Info("Login successful");
            LoginFeature.Login(user, isBaseURL);
            Logger.Info("Assert user login");
            
            Assert.That(LoginPage.OnHeader().GetWelcomeText.Contains(user.FirstName));
        }

        [Test]
        public void InvalidLoginTest()
        {
            string expectedResultText = "invalid username or password";
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetInvalidUser());
            
            Assert.That(LoginPage.GetFlashMessage().Contains(expectedResultText));
        }
    }
}