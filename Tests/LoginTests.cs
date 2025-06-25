using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.Helpers;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginFeature LoginFeature;

        [SetUp]
        protected void Initialize()
        {
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
            
            Assert.That(LoginFeature.IsWelcomeTextDisplayed(), Is.True);
        }

        [Test]
        public void InvalidLoginTest()
        {
            LoginFeature.Login(TestDataUsers.GetInvalidUser());
            
            Assert.That(LoginFeature.IsInvalidUserMessageDisplayed(), Is.True);
        }
    }
}