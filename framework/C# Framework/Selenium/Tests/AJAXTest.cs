using NUnit.Framework;
using Selenium.Framework;
using Selenium.Framework.Features;
using Selenium.Framework.TestData;

namespace Selenium.Tests
{
    public class AJAXTest : BaseTest
    {
        private LoginFeature LoginFeature;
        private AJAXFeatures AJAXFeatures;
        private HeaderFeatures HeaderFeatures;

        [SetUp]
        protected void Initialize()
        {
            LoginFeature = new LoginFeature(Driver);
            AJAXFeatures = new AJAXFeatures(Driver);
            HeaderFeatures = new HeaderFeatures(Driver);
        }

        [Test]
        public void ValidCalculation()
        {
            string expectedText = "Result is: 3.0";
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");
            HeaderFeatures.OpenAjaxPage();
            string actualText = AJAXFeatures.ElementsSetUp(1, 2);
            
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        public void InvalidCalculation()
        {
            string expectedText = "Result is: Incorrect data";
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            Logger.Info("Assert default user login");
            HeaderFeatures.OpenAjaxPage();
            string actualText = AJAXFeatures.ElementsSetUp(1, "a");
            
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
    }
}