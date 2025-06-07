using Newtonsoft.Json;
using OpenQA.Selenium;
using Selenium.Framework.Models;
using Selenium.Pages;

namespace Selenium.Framework.Features
{
    public class ApplicationFeatures
    {
        private ApplicationPage ApplicationPage;
        private TestDataPath TestDataPath;
        private JSONData JSONData;
        
        public ApplicationFeatures(IWebDriver driver)
        {
            ApplicationPage = new ApplicationPage(driver);
            TestDataPath = new TestDataPath();
            JSONData = new JSONData();
        }
        
        public void AddAppWithoutImage()
        {
            ApplicationPage.AddNewApp.Click();
            ApplicationPage.Title.SendKeys("This is title for new application");
            ApplicationPage.Description.SendKeys("This is description for new application");
            ApplicationPage.SubmitButton.Click();
        }
        public void UpdateApp()
        {
            ApplicationPage.Description.SendKeys("This is update description for new application");
            ApplicationPage.Update.Click();
        }
       
        public void AddAppWithImage()
        {
            ApplicationPage.AddNewApp.Click();
            ApplicationPage.Title.SendKeys("This is title for new application");
            ApplicationPage.Description.SendKeys("This is description for new application");
            ApplicationPage.Icon.SendKeys(TestDataPath.IconPath);
            ApplicationPage.Image.SendKeys(TestDataPath.ImagePath);
            ApplicationPage.SubmitButton.Click();
        }
        
        public string GetJSONText()
        {
            return ApplicationPage.JSONText.Text;
        }
        
        public JSONData GetApplicationJSONData()
        {
            string json = GetJSONText();
            
            return JsonConvert.DeserializeObject<JSONData>(json);
        }
    }
}