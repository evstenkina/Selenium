using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;


namespace Selenium.Pages
{
    public class ApplicationPage : BasePage
    {
        public ApplicationPage(IWebDriver driver) : base(driver)
        {
        }
        
        public List<IWebElement> UsersList => Driver.FindElements(By.CssSelector("#usersList")).ToList();
        //метод, который ищет определенный элемент среди всех элементов
        public bool isElementExist(string expectedAppName)
        {
            var a = UsersList.Where(x => x.Text == expectedAppName).FirstOrDefault();
            
            return a != null;
        }


        //public IWebElement CreatedApp => Driver.FindElement(By.XPath($"//a[text()='Details' and @href='/app?title={addedTitle}']"));
        private IWebElement Application => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=Application Information 1']"));
        public IWebElement Download => Driver.FindElement(By.XPath("//a[contains(text(), 'Download')]"));
        public IWebElement AddNewApp => Driver.FindElement(By.XPath("//a[text()='Click to add new application']"));
        public IWebElement Title => Driver.FindElement(By.XPath("//input[@name='title']"));
        public IWebElement Description => Driver.FindElement(By.XPath("//textarea[@name='description']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@value='Create']"));
        private IWebElement CreatedApp => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']"));
        public IWebElement DeletedAppConfirm => Driver.FindElement(By.XPath("//p[@class='flash' and normalize-space()='Deleted']"));
        public IWebElement Image => Driver.FindElement(By.XPath("//input[@name='image']"));
        public IWebElement Icon => Driver.FindElement(By.XPath("//input[@name='icon']"));
        private IWebElement Edit => Driver.FindElement(By.XPath("//a[text()='Edit']"));
        public IWebElement Update => Driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement AppUpdated => Driver.FindElement(By.ClassName("flash"));
        private IWebElement Delete => Driver.FindElement(By.XPath("//a[text()='Delete']"));
        private IWebElement PopularApp => Driver.FindElement(By.XPath("//div[contains(text(), 'This is title for new application')]"));

        //JSON
        public IWebElement JSONText => Driver.FindElement(By.XPath("//pre[contains(text(), 'Application Information')]"));

        public void OpenApplicationPage()
        {
            Application.Click();
        }

        public void DownloadApp()
        {
            Download.Click();
        }

        public string AppUpdatedConfirmation()
        {
            return AppUpdated.Text;
        }

        public void OpenAddNewAppPage()
        {
            AddNewApp.Click();
        }

        public void OpenCreatedAppPage()
        {
            CreatedApp.Click();
        }

        public void EditApp()
        {
            Edit.Click();
        }

        public void DeleteApp()
        {
            Delete.Click();
        }

        public string PopularAppTitle()
        {
            return PopularApp.Text;
        }
    }
}