using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;
using OpenQA.Selenium;
using Selenium.Framework.Features;

namespace Selenium.Pages
{
    public class ApplicationPage : BasePage
    {

        public ApplicationPage(IWebDriver driver) : base(driver)
        {
        }
        
        //TODO разделить локаторы и path

        public IWebElement Application => Driver.FindElement(By.XPath("//a[contains(@href, 'Information 1')]"));
        public IWebElement Download => Driver.FindElement(By.XPath("//a[contains(@href, 'download?')]"));
        public IWebElement MyApplication => Driver.FindElement(By.XPath("//a[contains(@href, 'my')]"));
        public IWebElement AddNewApp => Driver.FindElement(By.XPath("//a[contains(@href, 'new')]"));
        public IWebElement Title => Driver.FindElement(By.Name("title"));
        public IWebElement Description => Driver.FindElement(By.Name("description"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@value='Create']"));
        public IWebElement CreatedApp =>
            Driver.FindElement(By.XPath("//a[contains(@href, 'This is title for new application')]"));
        public IWebElement Image => Driver.FindElement(By.XPath("//input[@name='image']"));
        public IWebElement Icon => Driver.FindElement(By.XPath("//input[@name='icon']"));
        public const string ImagePath =
            "/Users/yevheniiastenkina/RiderProjects/estenkina-aut15/framework/C# Framework/Selenium/Image.jpg";

        public const string IconPath =
            "/Users/yevheniiastenkina/RiderProjects/estenkina-aut15/framework/C# Framework/Selenium/Icon.jpeg";
        public IWebElement Edit => Driver.FindElement(By.XPath("//a[contains(@href, 'edit?')]")); //TODO to make with text
        public IWebElement Update => Driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement AppUpdated => Driver.FindElement(By.ClassName("flash"));
        
        public string AppUpdatedText => AppUpdated.Text;
        
        public IWebElement Delete => Driver.FindElement(By.XPath("//a[contains(@href, 'delete?')]"));
        /*public IWebElement PopularAppsSection =>
            Driver.FindElement(By.XPath("//div[@class='title' and text()='Popular apps']"));*/
        public IWebElement PopularApp =>
            Driver.FindElement(By.XPath("//div[contains(text(), 'This is title for new application')]"));
        //JSON
        public IWebElement JSONText =>
            Driver.FindElement(By.XPath("//pre[contains(text(), 'Application Information')]"));
        
        //TODO to make a separate class
        public class JSONData
        {
            public string title { get; set; }
            public string description { get; set; }
        }
    }
}