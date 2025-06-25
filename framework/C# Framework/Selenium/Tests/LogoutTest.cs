using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.Helpers;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    public class LogoutTests : BaseTest
    {
        private LoginFeature LoginFeature;
        private LogoutFeatures LogoutFeatures;
        private HomeFeatures HomeFeatures;
        private HeaderFeatures HeaderFeatures;
        

        [SetUp]
        protected void Initialize()
        {
            LoginFeature = new LoginFeature(Driver);
            LogoutFeatures = new LogoutFeatures(Driver);
            HomeFeatures = new HomeFeatures(Driver);
            HeaderFeatures = new HeaderFeatures(Driver);
            SiteNavigator.NavigateToLoginPage(Driver);
        }

        [Test]
        public void LogoutTest()
        {
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert user login");
            LogoutFeatures.OpenNewBrowserTab();
            HeaderFeatures.Logout();
            LogoutFeatures.NavigateToFirstTab();
            HomeFeatures.OpenApplicationPage();
            
            Assert.That(LogoutFeatures.IsLoginButtDisp(), Is.True);
        }
    }
}