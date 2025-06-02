using Newtonsoft.Json;
using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework.Features
{
    public class ApplicationFeatures
    {
        private ApplicationPage ApplicationPage;
        
        public ApplicationFeatures(IWebDriver driver)
        {
            ApplicationPage = new ApplicationPage(driver);
        }
        
        //TODO действия с локаторами перенести в пейдж
        
        public void OpenApplicationPage()
        {
            ApplicationPage.Application.Click();
            //return "Application Information 1";
        }
        public void DownloadApp()
        {
            ApplicationPage.Download.Click();
        }
        public void OpenMyApplicationPage()
        {
           ApplicationPage.MyApplication.Click();
        }
        public void OpenAddNewAppPage()
        {
            ApplicationPage.AddNewApp.Click();
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
        public void OpenCreatedAppPage()
        {
            ApplicationPage.CreatedApp.Click();
        }
        public void AddAppWithImage()
        {
            ApplicationPage.AddNewApp.Click();
            ApplicationPage.Title.SendKeys("This is title for new application");
            ApplicationPage.Description.SendKeys("This is description for new application");
            ApplicationPage.Icon.SendKeys(ApplicationPage.IconPath);
            ApplicationPage.Image.SendKeys(ApplicationPage.ImagePath);
            ApplicationPage.SubmitButton.Click();
        }
        public void EditApp()
        {
            ApplicationPage.Edit.Click();
        }
        public void DeleteApp()
        {
            ApplicationPage.Delete.Click();
        }
        
        public string PopularAppTitle()
        {
            return ApplicationPage.PopularApp.Text;
        }
        
        public string GetJSONText()
        {
            return ApplicationPage.JSONText.Text;
        }
        
        public ApplicationPage.JSONData GetApplicationJSONData()
        {
            string json = GetJSONText();
            
            return JsonConvert.DeserializeObject<ApplicationPage.JSONData>(json);
        }
    }
}