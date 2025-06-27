using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Helpers;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : BaseTest
    {
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