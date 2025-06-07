using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class AJAXTest : BaseTest
    {
        private User _testDataUsers;
        private LoginFeature loginFeature;
        private AJAXPage ajaxPage;
        private WaitHelper WaitHelper;

        [SetUp]
        protected void Initialize()
        {
            _testDataUsers = TestDataUsers.GetDefaultUser();
            loginFeature = new LoginFeature(Driver);
            ajaxPage = new AJAXPage(Driver);
            WaitHelper = new WaitHelper(Driver);
            SiteNavigator.NavigateToLoginPage(Driver);
        }

        [Test]
        public void ValidCalculation()
        {
            string expectedText = "Result is: 3.0";
            loginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ajaxPage.OpenAjaxPage();
            ajaxPage.SetX("1");
            ajaxPage.SetY(2);
            ajaxPage.ClickSumButton();
            string result = ajaxPage.GetResultText();
            Assert.That(result, Is.EqualTo(expectedText));
        }

        [Test]
        public void InvalidCalculation()
        {
            loginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert _testDataUsers login");
            ajaxPage.OpenAjaxPage();
            ajaxPage.SetX(1);
            ajaxPage.SetY("a");
            ajaxPage.ClickSumButton();
            ajaxPage.GetResultText();
            string resultText = "Result is: Incorrect data"; 
            Assert.That(ajaxPage.GetResultText().Equals(resultText));
        }
    }
}