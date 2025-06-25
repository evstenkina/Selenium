using Newtonsoft.Json;
using OpenQA.Selenium;
using Selenium.Framework.Models;
using Selenium.Framework.TestData;
using Selenium.Pages;
using log4net;
using Selenium.Framework.Helpers;

namespace Selenium.Framework.Features
{
    public class ApplicationFeatures : BaseTest
    {
        private ApplicationPage ApplicationPage;
        private WaitHelper WaitHelper;
        private LoginFeature LoginFeature;
        private HeaderFeatures HeaderFeatures;
        public static IWebDriver Driver;
        protected ILog Logger;

        public ApplicationFeatures(IWebDriver driver)
        {
            ApplicationPage = new ApplicationPage(driver);
            WaitHelper = new WaitHelper(driver);
            LoginFeature = new LoginFeature(driver);
            HeaderFeatures = new HeaderFeatures(driver);
            Driver = driver;
        }
        
        public void UpdateApp()
        {
            ApplicationPage.Description.SendKeys("This is update description for new application");
            ApplicationPage.Update.Click();
            Logger.Info("Application is updated");
        }

        public void OpenAddNewAppPage()
        {
            ApplicationPage.AddNewApp.Click();
            Logger.Info("New application is opened");
        }
        
        public void LoginAndOpenMyApp()
        {
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            HeaderFeatures.OpenMyApplicationPage();
            Logger.Info("My application page is opened");
        }
        
        public void AddApplication(bool withImage = true)
        {
            ApplicationPage.AddNewApp.Click();
            ApplicationPage.Title.SendKeys("This is title for new application");
            Logger.Info("Title is added");
            ApplicationPage.Description.SendKeys("This is description for new application");
            Logger.Info("Description is added");
            if (withImage)
            {
                ApplicationPage.Icon.SendKeys(TestDataPath.IconPath);
                ApplicationPage.Image.SendKeys(TestDataPath.ImagePath);
                Logger.Info("Images are added");
            }
            ApplicationPage.SubmitButton.Click();
            Logger.Info("New application  is created");
        }

        public void CreateApp(bool withImage = false)
        {
            LoginAndOpenMyApp();
            AddApplication(withImage);
            Logger.Info("New application  is created");
        }

        public void GetJSONText()
        {
            ApplicationPage.JSONToText();
        }
            
        public JSONData GetApplicationJSONData()
        {
            string json = ApplicationPage.JSONToText();

            return JsonConvert.DeserializeObject<JSONData>(json);
        }
        
        public bool CheckThatDeletedAppIsNotDisplayed()
        { 
            WaitHelper.WaitForElementNotExist(ApplicationPage.searchForApp);
            Logger.Info("Deleted application is not found");
            return true;
        }
        
        public void DownloadAppMultipleTimes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ApplicationPage.Download.Click();
                Logger.Info("Application is downloaded");
                Driver.Navigate().Back();
            }  
        }
        
        /*public List<IWebElement> ApplicationList => Driver.FindElements(By.XPath("//div[@class='name']")).ToList();
        public bool FindApplicationFromTheList(string expectedTitle)
        {
            var a = ApplicationList.Where(x => x.Text == expectedTitle).FirstOrDefault();
            
            return a != null;
        }*/

        public void EditAppFeature()
        {
            ApplicationPage.Edit.Click();
            Logger.Info("Application edit mode is opened");
        }

        public void DeleteAppFeature()
        {
            ApplicationPage.Delete.Click();
            Logger.Info("Application is deleted");
        }

        public void DownloadAppFeature()
        {
            ApplicationPage.Download.Click();
            Logger.Info("Application is downloaded");
        }

        public bool ConfirmDeletedApp()
        {
            return ApplicationPage.DeletedAppConfirm.Displayed;
        }
        
        public bool AppUpdatedConfirmationTextTitle() 
        {
            return ApplicationPage.AppUpdated.Displayed;
        }

        public bool IsDownloadedEnabled()
        {
            return ApplicationPage.Download.Enabled;
        }
    }
}