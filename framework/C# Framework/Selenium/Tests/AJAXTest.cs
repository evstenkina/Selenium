using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class AJAXTest : BaseTest
    {
        private LoginFeature LoginFeature;
        private AJAXPage ajaxPage;
        private HomePage homePage;
        private AJAXFeatures ajaxFeatures;

        [SetUp]
        protected void Initialize()
        {
            LoginFeature = new LoginFeature(Driver);
            ajaxPage = new AJAXPage(Driver);
            homePage = new HomePage(Driver);
            ajaxFeatures = new AJAXFeatures(Driver);
            SiteNavigator.NavigateToLoginPage(Driver);
        }

        [Test]
        public void ValidCalculation()
        {
            string expectedText = "Result is: 3.0";
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");
            homePage.OpenAjaxPage();
            ajaxFeatures.ElementsSetUp(1, 2);

            string actualText = ajaxPage.GetResultText();
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        public void InvalidCalculation()
        {
            string expectedText = "Result is: Incorrect data";
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");
            homePage.OpenAjaxPage();
            ajaxFeatures.ElementsSetUp(1, "a");

            string actualText = ajaxPage.GetResultText();
            Assert.That(actualText.Equals(expectedText));
        }
    }
}