using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using OpenQA.Selenium;
using Selenium.Framework.TestData;
using Selenium.Pages;

namespace Selenium.Framework.Features
{
    public class RegistrationFeatures
    {
        private RegistrationPage RegistrationPage;
        private Header Header;
        
        public RegistrationFeatures(IWebDriver driver)
        {
            RegistrationPage = new RegistrationPage(driver);
            Header = new Header(driver);
        }
        
        public List<User> ReadUsersFromCsv(string a)
        {
            var reader = new StreamReader(a);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
             
            return csv.GetRecords<User>().ToList();
        }
        
        public void RegisterUsers(List<User> users)
        {
            foreach (var user in users)
            {
                RegisterUser(user);
                Header.Logout();
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

            return RegistrationPage.OnHeader().GetWelcomeText; 
        }
        

        /*public void RegisterDeveloper(User user)
        {
            RegistrationPage.RegisterNewUserButton.Click();
            RegistrationPage.NameBox.SendKeys(user.FirstName);
            RegistrationPage.FirstNameBox.SendKeys(user.FirstName);
            RegistrationPage.LastNameBox.SendKeys(user.LastName);
            RegistrationPage.Password.SendKeys(user.Password);
            RegistrationPage.ConfirmPassword.SendKeys(user.Password);
            RegistrationPage.RoleDeveloper.Click();
            RegistrationPage.RegisterButton.Click();
        }*/
        
    }
}