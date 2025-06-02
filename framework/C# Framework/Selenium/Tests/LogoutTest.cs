using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class LogoutTests : BaseTest
    {
        private User user;
        LoginPage LoginPage;
        string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        private LoginFeature LoginFeature;
        private ApplicationFeatures ApplicationFeatures;
        private Header Header;

        [SetUp]
        protected void Initialize()
        {
            user = TestDataUsers.GetDefaultUser();
            LoginPage = SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature = new LoginFeature(Driver);
            ApplicationFeatures = new ApplicationFeatures(Driver);
            Header = new Header(Driver);
        }

        [Test]
        public void LogoutTest()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert user login");
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open(arguments[0], '_blank');", baseUrl);
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Header.Logout();
            List<string> tabs = Driver.WindowHandles.ToList();
            Driver.SwitchTo().Window(tabs[0]);
            ApplicationFeatures.OpenApplicationPage();
            Assert.That(LoginPage.LoginButton.Displayed, Is.True);;
        }
    }
 }   
