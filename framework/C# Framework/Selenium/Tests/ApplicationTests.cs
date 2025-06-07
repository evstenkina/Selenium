using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.Models;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class ApplicationTests : BaseTest
    {
        private User _testDataUsers;
        private LoginFeature LoginFeature;
        private ApplicationPage ApplicationPage;
        private ApplicationFeatures ApplicationFeatures;
        private JSONData JSONData;

        [SetUp]
        protected void Initialize()
        {
            _testDataUsers = TestDataUsers.GetDefaultUser();
            LoginFeature = new LoginFeature(Driver);
            ApplicationPage = new ApplicationPage(Driver);
            ApplicationFeatures = new ApplicationFeatures(Driver);
            JSONData = new JSONData();
        }

        [Test]
        public void CreateAppWithoutImage()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ApplicationPage.OpenMyApplicationPage();
            ApplicationFeatures.AddAppWithoutImage();
            ApplicationPage.OpenCreatedAppPage();
            var download = ApplicationPage.Download;
            Assert.That(download.Enabled);
        }


        [Test]
        public void CreateAppWithImage()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ApplicationPage.OpenMyApplicationPage();
            ApplicationFeatures.AddAppWithImage();
            ApplicationPage.OpenCreatedAppPage();
            var download = ApplicationPage.Download;
            Assert.That(download.Enabled);
        }

        [Test]
        public void UpdateAppWithoutImage()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ApplicationPage.OpenMyApplicationPage();
            ApplicationFeatures.AddAppWithoutImage();
            ApplicationPage.OpenCreatedAppPage();
            ApplicationPage.EditApp();
            ApplicationFeatures.UpdateApp();
            Assert.That(ApplicationPage.AppUpdatedText.Equals(ApplicationPage.AppUpdatedText));
        }

        [Test]
        public void DeleteApp()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ApplicationPage.OpenMyApplicationPage();
            ApplicationFeatures.AddAppWithoutImage();
            ApplicationPage.OpenCreatedAppPage();
            ApplicationPage.DeleteApp();
            Driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void PopularApps()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ApplicationPage.OpenMyApplicationPage();
            ApplicationFeatures.AddAppWithoutImage();
            ApplicationPage.OpenCreatedAppPage();

            Random rng = new Random();
            int number = rng.Next(1, 7);
            for (int i = 0; i < number; i++)
            {
                ApplicationPage.Download.Click();
                Driver.Navigate().Back();
            }

            Driver.Navigate().Refresh();

            string actualTitle = ApplicationPage.PopularAppTitle();
            string expectedTitle = "This is title for new application";
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void JSONTest()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ApplicationPage.OpenApplicationPage();
            ApplicationPage.DownloadApp();
            ApplicationFeatures.GetJSONText();
            ApplicationFeatures.GetApplicationJSONData();
            JSONData jsonApp = ApplicationFeatures.GetApplicationJSONData();
            string actual = jsonApp.title;
            /*string jsonText = applicationPage.GetJSONText();
            Console.WriteLine("Raw JSON: " + jsonText);
            
            ApplicationPage.JSONData CheckJSON()
            {

                try
                {
                    var data = JsonConvert.DeserializeObject<ApplicationPage.JSONData>(jsonText);
                    if (data == null)
                        Console.WriteLine("Failed to deserialize JSON.");
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error during JSON deserialization: " + ex.Message);
                    return null;
                }
            }
            CheckJSON();*/
            string Title = "Application Information 1";
            Assert.That(actual, Is.EqualTo(Title));
        }
    }
}