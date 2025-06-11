using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class JSTest : BaseTest
    {
        private LoginFeature loginFeature;
        private JSFeatures JSFeatures;
        private HomePage HomePage;

        [SetUp]
        protected void Initialize()
        {
            loginFeature = new LoginFeature(Driver);
            JSFeatures = new JSFeatures(Driver);
            HomePage = new HomePage(Driver);
        }

        [Test]
        public void GetCoordinates()
        {
            string expectedAlertText = "Whoo Hoooo! Correct!";
            SiteNavigator.NavigateToLoginPage(Driver);
            loginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");
            
            HomePage.OpenJSTestPage();
            JSFeatures.Execute();
            
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.That(expectedAlertText, Is.EqualTo(alert.Text));
        }
    }
}