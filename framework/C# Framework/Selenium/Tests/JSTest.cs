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
        private User _testDataUsers;
        private LoginFeature loginFeature;
        private JSPage JSPage;
        private JSFeatures JSFeatures;

        [SetUp]
        protected void Initialize()
        {
            _testDataUsers = TestDataUsers.GetDefaultUser();
            loginFeature = new LoginFeature(Driver);
            JSPage = new JSPage(Driver);
            JSFeatures = new JSFeatures(Driver);
        }

        [Test]
        public void GetCoordinates()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            loginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            JSPage.OpenJSTestPage();
            JSFeatures.GetCoordinates();
            JSFeatures.SetTopInputField();
            JSFeatures.SetLeftInputField();
            JSPage.ClickProcessButton();
            IAlert alert = Driver.SwitchTo().Alert();
            string expectedAlertText = "Whoo Hoooo! Correct!";
            Assert.That(expectedAlertText, Is.EqualTo(alert.Text));
        }
    }
}