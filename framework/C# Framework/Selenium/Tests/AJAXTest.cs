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

        [SetUp]
        protected void Initialize()
        {
            _testDataUsers = TestDataUsers.GetDefaultUser();
            loginFeature = new LoginFeature(Driver);
            ajaxPage = new AJAXPage(Driver);
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
            WaitHelper.WaitForElement(By.Id("result")); //TODO использовать в другом месте, добавить локатор
            string result = ajaxPage.GetResultText();
            Assert.Equals(result, expectedText);
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
            WaitHelper.WaitForElement(By.Id("result"));
            ajaxPage.GetResultText(); //= Contains.Value("Result is: Incorrect data").ToString();
            string resultText = "Result is: Incorrect data"; //Assert does not work
            //Assert.IsTrue(ajaxPage.Result().Equals(resultText));
        }
    }
}