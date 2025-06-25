using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.Helpers;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    /*[TestFixture]
    [Parallelizable(ParallelScope.All)]*/
    public class RegisterTest : BaseTest
    {
        private RegistrationFeatures RegistrationFeatures;
        private LoginFeature LoginFeature;
        private ApplicationFeatures ApplicationFeatures;
        private HeaderFeatures HeaderFeatures;
        private CSVReaderHelper CSVReaderHelper;

        [SetUp]
        protected void Initialize()
        {
            RegistrationFeatures = new RegistrationFeatures(Driver);
            LoginFeature = new LoginFeature(Driver);
            ApplicationFeatures = new ApplicationFeatures(Driver);
            HeaderFeatures = new HeaderFeatures(Driver);
            CSVReaderHelper = new CSVReaderHelper();
        }

        [Test]
        public void RegisterNewUserTest()
        {
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaUser());
            
            Assert.That(RegistrationFeatures.IsWelcomeTextDisplayed(), Is.True);
        }

        [Test]
        public void RegisterNewUserLogoutTest()
        {
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaUser());
            HeaderFeatures.Logout();
            LoginFeature.Login(TestDataUsers.GetStenkinaUser());
            
            Assert.That(RegistrationFeatures.IsWelcomeTextDisplayed(), Is.True);
        }

        [Test]
        public void RegisterDeveloperTest()
        {
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaDeveloper());
            HeaderFeatures.OpenMyApplicationPage();
            ApplicationFeatures.OpenAddNewAppPage();

            Assert.That(RegistrationFeatures.IsSubmitButtonDisplayed(), Is.True);
        }

        [Test]
        public void RegisterNewUserAppTest()
        {
            RegistrationFeatures.RegisterUser(TestDataUsers.GetStenkinaUser());
            
            Assert.That(RegistrationFeatures.SearchForUploadOption(), Is.True);
        }

        [Test]
        public void RegisterUsersCSV()
        {
            var users = CSVReaderHelper.ReadUsersFromCsv(TestDataPath.UserForRegistrationPath);
            RegistrationFeatures.RegisterUsersAndValidate(users);
        }
    }
}