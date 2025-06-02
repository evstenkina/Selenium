using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class RegisterTest : BaseTest
    {
        private User userUser;
        private User userDeveloper;
        private List<User> users;
        private RegistrationFeatures RegistrationFeatures;
        private RegistrationPage RegistrationPage;
        private ApplicationPage ApplicationPage;
        private LoginFeature LoginFeature;
        private ApplicationFeatures ApplicationFeatures;

        [SetUp]
        protected void Initialize()
        {
            userUser = TestDataUsers.GetStenkinaUser();
            userDeveloper = TestDataUsers.GetStenkinaDeveloper();
            RegistrationFeatures = new RegistrationFeatures(Driver);
            RegistrationPage = new RegistrationPage(Driver);
            ApplicationPage = new ApplicationPage(Driver);
            LoginFeature = new LoginFeature(Driver);
            ApplicationFeatures = new ApplicationFeatures(Driver);
        }

        [Test]
        public void RegisterNewUserTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(userUser);
            Assert.That(RegistrationPage.OnHeader().GetWelcomeText.Contains(userUser.FirstName));
        }

        [Test]
        public void RegisterNewUserLogoutTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(userUser);
            Header header = new Header(Driver);
            header.Logout();
            LoginPage loginPage = new LoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Assert.That(RegistrationPage.OnHeader().GetWelcomeText.Contains(userUser.FirstName));
        }

        [Test]
        public void RegisterDeveloperTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(userDeveloper);
            ApplicationFeatures.OpenMyApplicationPage();
            ApplicationFeatures.OpenAddNewAppPage();
            string appText = ApplicationPage.SubmitButton.Text;
            string expectedAppButton = "Create";
            Assert.That(appText, Is.EqualTo(expectedAppButton));
        }

        [Test]
        public void RegisterNewUserAppTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(userUser);
            bool uploadOption = true;
            try
            {
                var element = ApplicationPage.MyApplication;
            }
            catch (NoSuchElementException)
            {
                uploadOption = false;
            }
            Assert.That(uploadOption.Equals(false));
        }

        [Test]
        public void RegisterUsersCSV()
        {
            users = RegistrationFeatures.ReadUsersFromCsv(TestDataPath.UserForRegistrationPath);
            SiteNavigator.NavigateToLoginPage(Driver);
            RegistrationFeatures.RegisterUsers(users);
        }
    }
}