using OpenQA.Selenium;


namespace Selenium.Pages
{
    public class ApplicationPage : BasePage
    {
        public ApplicationPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Application => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=Application Information 1']"));
        public IWebElement Download => Driver.FindElement(By.XPath("//a[contains(text(), 'Download')]"));
        public IWebElement AddNewApp => Driver.FindElement(By.XPath("//a[text()='Click to add new application']"));
        public IWebElement Title => Driver.FindElement(By.XPath("//input[@name='title']"));
        public IWebElement Description => Driver.FindElement(By.XPath("//textarea[@name='description']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@value='Create']"));
        public IWebElement CreatedApp => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']"));
        public IWebElement DeletedAppConfirm => Driver.FindElement(By.XPath("//p[@class='flash' and normalize-space()='Deleted']"));
        public IWebElement Image => Driver.FindElement(By.XPath("//input[@name='image']"));
        public IWebElement Icon => Driver.FindElement(By.XPath("//input[@name='icon']"));
        public IWebElement Edit => Driver.FindElement(By.XPath("//a[text()='Edit']"));
        public IWebElement Update => Driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement AppUpdated => Driver.FindElement(By.ClassName("flash"));
        public IWebElement Delete => Driver.FindElement(By.XPath("//a[text()='Delete']"));
        public IWebElement PopularApp => Driver.FindElement(By.XPath("//div[contains(text(), 'This is title for new application')]"));

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