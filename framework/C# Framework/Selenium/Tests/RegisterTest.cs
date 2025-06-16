using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class RegisterTest : BaseTest
    {
        private RegistrationFeatures RegistrationFeatures;
        private RegistrationPage RegistrationPage;
        private ApplicationPage ApplicationPage;
        private LoginFeature LoginFeature;
        private HomePage HomePage;
        private HeaderPage HeaderPage;

        [SetUp]
        protected void Initialize()
        {
            RegistrationFeatures = new RegistrationFeatures(Driver);
            RegistrationPage = new RegistrationPage(Driver);
            ApplicationPage = new ApplicationPage(Driver);
            LoginFeature = new LoginFeature(Driver);
            HomePage = new HomePage(Driver);
            HeaderPage = new HeaderPage(Driver);
        }

        [Test]
        public void RegisterNewUserTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaUser());
            
            Assert.That(RegistrationPage.OnHeader().GetWelcomeText.Contains(TestDataUsers.GetStenkinaUser().FirstName));
        }

        [Test]
        public void RegisterNewUserLogoutTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaUser());
            HeaderPage.Logout();
            LoginFeature.Login(TestDataUsers.GetStenkinaUser());
            
            Assert.That(RegistrationPage.OnHeader().GetWelcomeText.Contains(TestDataUsers.GetStenkinaUser().FirstName));
        }

        [Test]
        public void RegisterDeveloperTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaDeveloper());
            HomePage.OpenMyApplicationPage();
            ApplicationPage.OpenAddNewAppPage();

            Assert.That(ApplicationPage.SubmitButton.Displayed, Is.True);
        }

        [Test]
        public void RegisterNewUserAppTest()
        {
            SiteNavigator.NavigateToRegistrationPage(Driver);
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaUser());
            
            Assert.That(RegistrationFeatures.SearchForUploadOption(), Is.True);
        }

        [Test]
        public void RegisterUsersCSV()
        {
            var users = RegistrationFeatures.ReadUsersFromCsv(TestDataPath.UserForRegistrationPath);
            SiteNavigator.NavigateToLoginPage(Driver);
            RegistrationFeatures.RegisterUsersAndValidate(users);
        }
    }
}