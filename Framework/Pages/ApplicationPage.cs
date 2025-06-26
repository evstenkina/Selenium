using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework.Pages
{
    public class ApplicationPage : BasePage
    {
        public ApplicationPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement Download => Driver.FindElement(By.XPath("//a[contains(text(), 'Download')]"));
        public IWebElement AddNewApp => Driver.FindElement(By.XPath("//a[text()='Click to add new application']"));
        public IWebElement Title => Driver.FindElement(By.XPath("//input[@name='title']"));
        public IWebElement Description => Driver.FindElement(By.XPath("//textarea[@name='description']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@value='Create']"));
        public IWebElement DeletedAppConfirm => Driver.FindElement(By.XPath("//p[@class='flash' and normalize-space()='Deleted']"));
        public IWebElement Image => Driver.FindElement(By.XPath("//input[@name='image']"));
        public IWebElement Icon => Driver.FindElement(By.XPath("//input[@name='icon']"));
        public IWebElement Edit => Driver.FindElement(By.XPath("//a[text()='Edit']"));
        public IWebElement Update => Driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement AppUpdated => Driver.FindElement(By.ClassName("flash"));
        public IWebElement Delete => Driver.FindElement(By.XPath("//a[text()='Delete']"));
        
        public IWebElement JSONText => Driver.FindElement(By.XPath("//pre[contains(text(), 'Application Information')]"));
        
        public string JSONToText() 
        {
            return JSONText.Text;
        }
        
        public static By searchForApp = By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']");
    }
}