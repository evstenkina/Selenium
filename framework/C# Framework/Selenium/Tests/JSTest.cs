using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    public class JSTest : BaseTest
    {
        private LoginFeature LoginFeature;
        private JSFeatures JSFeatures;
        private HeaderFeatures HeaderFeatures;

        [SetUp]
        protected void Initialize()
        {
            LoginFeature = new LoginFeature(Driver);
            JSFeatures = new JSFeatures(Driver);
            HeaderFeatures = new HeaderFeatures(Driver);
        }

        [Test]
        public void GetCoordinates()
        {
            string expectedAlertText = "Whoo Hoooo! Correct!";
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");
            
            HeaderFeatures.OpenJSTestPage();
            JSFeatures.Execute();
            
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.That(expectedAlertText, Is.EqualTo(alert.Text));
        }
    }
}