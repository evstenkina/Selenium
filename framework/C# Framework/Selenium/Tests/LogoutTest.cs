using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class LogoutTests : BaseTest
    {
        private LoginFeature LoginFeature;
        private ApplicationPage ApplicationPage;
        private Header Header;
        private LogoutFeatures LogoutFeatures;
        

        [SetUp]
        protected void Initialize()
        {
            LoginFeature = new LoginFeature(Driver);
            ApplicationPage = new ApplicationPage(Driver);
            Header = new Header(Driver);
            LogoutFeatures = new LogoutFeatures(Driver);
            SiteNavigator.NavigateToLoginPage(Driver);
        }

        [Test]
        public void LogoutTest()
        {
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert user login");
            LogoutFeatures.OpenNewBrowserTab();
            
            Header.Logout();
           
            LogoutFeatures.NavigateToFirstTab();
            
            ApplicationPage.OpenApplicationPage();
            Assert.That(LogoutFeatures.IsLoginButtDisp(), Is.True);
        }

       
       
    }
}