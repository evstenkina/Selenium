using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework.TestData;
using Selenium.Pages;
using log4net;
using Selenium.Framework.Helpers;
using Selenium.Framework.Models;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class RegistrationFeatures
    {
        private RegistrationPage RegistrationPage;
        private WaitHelper WaitHelper;
        private ApplicationPage ApplicationPage;
        private HeaderFeatures HeaderFeatures;
        protected ILog Logger;

        public RegistrationFeatures(IWebDriver driver)
        {
            RegistrationPage = new RegistrationPage(driver);
            WaitHelper = new WaitHelper(driver);
            ApplicationPage = new ApplicationPage(driver);
            HeaderFeatures = new HeaderFeatures(driver);
            Logger = LogManager.GetLogger(typeof(RegistrationFeatures));
        }
        
        public void RegisterUsersAndValidate(List<User> users)
        {
            foreach (var user in users)
            {
                var headerText = RegisterUser(user);
                Assert.That(headerText.Equals($"Welcome {user.FirstName} {user.LastName}"));
                HeaderFeatures.Logout();
            }
        }

        public string RegisterUser(User user)
        {
            RegistrationPage.RegisterNewUserButton.Click();
            RegistrationPage.NameBox.SendKeys(user.FirstName);
            RegistrationPage.FirstNameBox.SendKeys(user.FirstName);
            RegistrationPage.LastNameBox.SendKeys(user.LastName);
            RegistrationPage.Password.SendKeys(user.Password);
            RegistrationPage.ConfirmPassword.SendKeys(user.Password);

            if (user.Role == TestDataUsers.DeveloperRole)
            {
                RegistrationPage.RoleDeveloper.Click();
            }
            else
            {
                RegistrationPage.RoleUser.Click();
            }

            RegistrationPage.RegisterButton.Click();
            Logger.Info("User is registered and logged in");

            return RegistrationPage.OnHeader().GetWelcomeText;
        }
        
        public bool SearchForUploadOption()
        {
            WaitHelper.WaitForElementNotExist(RegistrationPage.uploadOption);
            
            return true;
        }

        public bool IsSubmitButtonDisplayed()
        {
            return ApplicationPage.SubmitButton.Displayed;
        }

        public bool IsWelcomeTextDisplayed()
        {
            return RegistrationPage.OnHeader().GetWelcomeText.Contains(TestDataUsers.GetStenkinaUser().FirstName);
        }
    }
}