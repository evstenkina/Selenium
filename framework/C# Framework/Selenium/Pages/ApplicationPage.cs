using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;
using OpenQA.Selenium;
using Selenium.Framework.Features;

namespace Selenium.Pages
{
    public class ApplicationPage : BasePage
    {
        private HomePage Homepage;

        public ApplicationPage(IWebDriver driver) : base(driver)
        {
            Homepage = new HomePage(driver);
        }

        public IWebElement Application =>
            Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=Application Information 1']"));

        public IWebElement Download => Driver.FindElement(By.XPath("//a[contains(text(), 'Download')]"));

        public IWebElement AddNewApp => Driver.FindElement(By.XPath("//a[text()='Click to add new application']"));
        public IWebElement Title => Driver.FindElement(By.XPath("//input[@name='title']"));
        public IWebElement Description => Driver.FindElement(By.XPath("//textarea[@name='description']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@value='Create']"));

        public IWebElement CreatedApp =>
            Driver.FindElement(
                By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']"));

        public IWebElement Image => Driver.FindElement(By.XPath("//input[@name='image']"));
        public IWebElement Icon => Driver.FindElement(By.XPath("//input[@name='icon']"));
        public IWebElement Edit => Driver.FindElement(By.XPath("//a[text()='Edit']"));
        public IWebElement Update => Driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement AppUpdated => Driver.FindElement(By.ClassName("flash"));

        public string AppUpdatedText => AppUpdated.Text;

        public IWebElement Delete => Driver.FindElement(By.XPath("//a[text()='Delete']"));

        public IWebElement PopularApp =>
            Driver.FindElement(By.XPath("//div[contains(text(), 'This is title for new application')]"));

        //JSON
        public IWebElement JSONText =>
            Driver.FindElement(By.XPath("//pre[contains(text(), 'Application Information')]"));

        public void OpenApplicationPage()
        {
            Application.Click();
        }

        public void DownloadApp()
        {
            Download.Click();
        }

        public void OpenMyApplicationPage()
        {
            Homepage.MyApplication.Click();
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