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
        private JSPage JSPage;
        private JSFeatures JSFeatures;

        [SetUp]
        protected void Initialize()
        {
            loginFeature = new LoginFeature(Driver);
            JSPage = new JSPage(Driver);
            JSFeatures = new JSFeatures(Driver);
        }

        [Test]
        public void GetCoordinates()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            loginFeature.Login(TestDataUsers.GetDefaultUser());
            JSFeatures.OpenJSTestPage();
            JSFeatures.GetCoordinates();
            JSFeatures.SetTopInputField();
            JSFeatures.SetLeftInputField();
            JSFeatures.ClickProcessButton();
            IAlert alert = Driver.SwitchTo().Alert();
            string alertText = "Whoo Hoooo! Correct!";
            Assert.That(alertText, Is.EqualTo(alert.Text));
        }
    }
}