using System;
using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LogoutTests : BaseTest
    {
        [ThreadStatic] private static LogoutFeatures LogoutFeatures;
        [ThreadStatic] private static HomeFeatures HomeFeatures;

        [SetUp]
        protected void Initialize()
        {
            LogoutFeatures = new LogoutFeatures(Driver);
            HomeFeatures = new HomeFeatures(Driver);
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