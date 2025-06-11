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
        private HomePage HomePage;
        private Header Header;

        [SetUp]
        protected void Initialize()
        {
            userUser = TestDataUsers.GetStenkinaUser();
            userDeveloper = TestDataUsers.GetStenkinaDeveloper();
            RegistrationFeatures = new RegistrationFeatures(Driver);
            RegistrationPage = new RegistrationPage(Driver);
            ApplicationPage = new ApplicationPage(Driver);
            LoginFeature = new LoginFeature(Driver);
            HomePage = new HomePage(Driver);
            Header = new Header(Driver);
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
            Header.Logout();
            LoginFeature.Login(TestDataUsers.GetStenkinaUser());
            
            Assert.That(RegistrationPage.OnHeader().GetWelcomeText.Contains(userUser.FirstName));
        }

        [Test]
        public void RegisterDeveloperTest()
        {
            string expectedAppButton = "Create";
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(userDeveloper);
            HomePage.OpenMyApplicationPage();
            ApplicationPage.OpenAddNewAppPage();
            
            string appText = ApplicationPage.SubmitButton.GetAttribute("value");
            Assert.That(appText.Equals(expectedAppButton));
        }

        [Test]
        public void RegisterNewUserAppTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(userUser);
            bool uploadOption = true;
            try
            {
                var element = HomePage.MyApplication;
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