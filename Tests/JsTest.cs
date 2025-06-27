using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class JsTest : BaseTest
    {
        [ThreadStatic] private static JsFeatures JSFeatures;

        [SetUp]
        protected void Initialize()
        {
            JSFeatures = new JsFeatures(Driver);
        }

        [Test]
        public void GetCoordinates()
        {
            string expectedAlertText = "Whoo Hoooo! Correct!";
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");
            
            HeaderFeatures.OpenJsTestPage();
            JSFeatures.Execute();
            
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.That(expectedAlertText, Is.EqualTo(alert.Text));
        }
    }
}