using System;
using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ApplicationTests : BaseTest
    {
        private LoginFeature LoginFeature;
        private ApplicationPage ApplicationPage;
        private ApplicationFeatures ApplicationFeatures;
        private HomePage HomePage;

        [SetUp]
        protected void Initialize()
        {
            LoginFeature = new LoginFeature(Driver);
            ApplicationPage = new ApplicationPage(Driver);
            ApplicationFeatures = new ApplicationFeatures(Driver);
            HomePage = new HomePage(Driver);
        }

        [Test]
        public void CreateAppWithoutImage()
        {
            ApplicationFeatures.LoginAndOpenMyApp();
            ApplicationFeatures.AddAppWithoutImage();
            ApplicationPage.OpenCreatedAppPage();

            var downloadOption = ApplicationPage.Download;
            Assert.That(downloadOption.Enabled);
        }

        [Test]
        public void CreateAppWithImage()
        {
            ApplicationFeatures.LoginAndOpenMyApp();
            ApplicationFeatures.AddAppWithImage();
            ApplicationPage.OpenCreatedAppPage();

            var downloadOption = ApplicationPage.Download;
            Assert.That(downloadOption.Enabled);
        }

        [Test]
        public void UpdateAppWithoutImage()
        {
            string expectedText = "Application edited";
            ApplicationFeatures.LoginAndOpenMyApp();
            ApplicationFeatures.AddAppWithoutImage();

            ApplicationPage.OpenCreatedAppPage();
            ApplicationPage.EditApp();
            ApplicationFeatures.UpdateApp();

            string actualText = ApplicationPage.AppUpdatedConfirmation();
            Assert.That(actualText.Equals(expectedText));
        }

        [Test]
        public void DeleteApp()
        {
            ApplicationFeatures.LoginAndOpenMyApp();
            ApplicationFeatures.AddAppWithoutImage();
            ApplicationPage.OpenCreatedAppPage();
            ApplicationPage.DeleteApp();

            Driver.SwitchTo().Alert().Accept();
            var extectedText = ApplicationPage.DeletedAppConfirm;
            Assert.That(extectedText.Displayed);

            HomePage.OpenMyApplicationPage();

            Assert.That(ApplicationFeatures.SearchForDeletedApp(), Is.True);
        }


        [Test]
        public void PopularApps()
        {
            string expectedTitle = "This is title for new application";
            ApplicationFeatures.LoginAndOpenMyApp();
            ApplicationFeatures.AddAppWithoutImage();
            ApplicationPage.OpenCreatedAppPage();

            int downloadNumber = new Random().Next(1, 7);
            ApplicationFeatures.DownloadAppMultipleTimes(downloadNumber);

            string actualTitle = ApplicationPage.PopularAppTitle();
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
            
            //ApplicationFeatures.FindApplicationFromTheList(expectedTitle);
        }

        [Test]
        public void JSONTest()
        {
            string expectedTitle = "Application Information 1";
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");

            ApplicationPage.OpenApplicationPage();
            ApplicationPage.DownloadApp();
            ApplicationFeatures.GetJSONText();

            string actualTitle = ApplicationFeatures.GetApplicationJSONData().title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        }
    }
}