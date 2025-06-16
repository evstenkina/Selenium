using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Framework.Models;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Framework.Features
{
    public class ApplicationFeatures : BaseTest
    {
        private ApplicationPage ApplicationPage;
        private WaitHelper WaitHelper;
        private HomePage HomePage;
        private LoginFeature LoginFeature;
        public static IWebDriver Driver;

        public ApplicationFeatures(IWebDriver driver)
        {
            ApplicationPage = new ApplicationPage(driver);
            WaitHelper = new WaitHelper(driver);
            HomePage = new HomePage(driver);
            LoginFeature = new LoginFeature(driver);
            Driver = driver;
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
        
        By searchForApp = By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']");
       
        public bool SearchForDeletedApp()
        { 
            WaitHelper.WaitForElementNotExist(searchForApp);
            return true;
        }

        public void LoginAndOpenMyApp()
        {
            SiteNavigator.NavigateToLoginPage(Driver);
            LoginFeature.Login(TestDataUsers.GetDefaultUser());
            //Logger.Info("Assert default user login");
            HomePage.OpenMyApplicationPage();
        }

       
        public void DownloadAppMultipleTimes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ApplicationPage.Download.Click();
                Driver.Navigate().Back();
            }  
        }
        
        public List<IWebElement> ApplicationList => Driver.FindElements(By.XPath("//div[@class='name']")).ToList();
        public bool FindApplicationFromTheList(string expectedTitle)
        {
            var a = ApplicationList.Where(x => x.Text == expectedTitle).FirstOrDefault();
            
            return a != null;
        }
    }
}