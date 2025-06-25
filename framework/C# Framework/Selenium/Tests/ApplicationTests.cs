using System;
using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    /*[TestFixture]
    [Parallelizable(ParallelScope.All)]*/
    public class ApplicationTests : BaseTest
    {
        private LoginFeature LoginFeature;
        private ApplicationFeatures ApplicationFeatures;
        private HomeFeatures HomeFeatures;
        private HeaderFeatures HeaderFeatures;

        [SetUp]
        protected void Initialize()
        {
            LoginFeature = new LoginFeature(Driver);
            ApplicationFeatures = new ApplicationFeatures(Driver);
            HomeFeatures = new HomeFeatures(Driver);
            HeaderFeatures = new HeaderFeatures(Driver);
        }

        [Test]
        public void CreateAppWithoutImage()
        {
            ApplicationFeatures.CreateApp();
            HomeFeatures.OpenCreatedApp();
            
            Assert.That(ApplicationFeatures.IsDownloadedEnabled, Is.True);
        }

        [Test]
        public void CreateAppWithImage()
        {
            ApplicationFeatures.CreateApp(false);
            HomeFeatures.OpenCreatedApp();
            
            Assert.That(ApplicationFeatures.IsDownloadedEnabled, Is.True);
        }

        [Test]
        public void UpdateAppWithoutImage()
        {
            ApplicationFeatures.CreateApp();
            HomeFeatures.OpenCreatedApp();
            
            ApplicationFeatures.EditAppFeature();
            ApplicationFeatures.UpdateApp();
            
            Assert.That(ApplicationFeatures.AppUpdatedConfirmationTextTitle, Is.True);
        }

        [Test]
        public void DeleteApp()
        {
            ApplicationFeatures.CreateApp();
            HomeFeatures.OpenCreatedApp();
            
            ApplicationFeatures.DeleteAppFeature();

            Driver.SwitchTo().Alert().Accept();
            
            Assert.That(ApplicationFeatures.ConfirmDeletedApp, Is.True);

            HeaderFeatures.OpenMyApplicationPage();

            Assert.That(ApplicationFeatures.CheckThatDeletedAppIsNotDisplayed(), Is.True);
        }


        [Test]
        public void PopularApps()
        {
            string expectedTitle = "This is title for new application";
            ApplicationFeatures.CreateApp();
            HomeFeatures.OpenCreatedApp();

            int downloadNumber = new Random().Next(1, 7);
            ApplicationFeatures.DownloadAppMultipleTimes(downloadNumber);
            
            Assert.That(HomeFeatures.GetPupolarAppTitle(), Is.EqualTo(expectedTitle));
        }

        [Test]
        public void JSONTest()
        {
            string expectedTitle = "Application Information 1";
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");

            HomeFeatures.OpenApplicationPage();
            ApplicationFeatures.DownloadAppFeature();
            ApplicationFeatures.GetJSONText();
            
            Assert.That(ApplicationFeatures.GetApplicationJSONData().title, Is.EqualTo(expectedTitle));
        }
    }
}