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
        
        /*public List<IWebElement> UsersList => Driver.FindElements(By.CssSelector("#usersList")).ToList();
        //метод, который ищет определенный элемент среди всех элементов
        public bool isElementExist(string expectedAppName)
        {
            // var a = UsersList.Where(x => x.Text == expectedAppName).FirstOrDefault();
            var ab = UsersList.Where(x => x.Text == expectedAppName).Count();
            
            return UsersList.Where(x => x.Text == expectedAppName).Count() > 0;
            // return a != null;
        }*/


        //public IWebElement CreatedApp => Driver.FindElement(By.XPath($"//a[text()='Details' and @href='/app?title={addedTitle}']"));
        // private IWebElement Application => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=Application Information 1']"));
        public IWebElement Download => Driver.FindElement(By.XPath("//a[contains(text(), 'Download')]"));
        public IWebElement AddNewApp => Driver.FindElement(By.XPath("//a[text()='Click to add new application']"));
        public IWebElement Title => Driver.FindElement(By.XPath("//input[@name='title']"));
        public IWebElement Description => Driver.FindElement(By.XPath("//textarea[@name='description']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@value='Create']"));
        // private IWebElement CreatedApp => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']"));
        public IWebElement DeletedAppConfirm => Driver.FindElement(By.XPath("//p[@class='flash' and normalize-space()='Deleted']"));
        public IWebElement Image => Driver.FindElement(By.XPath("//input[@name='image']"));
        public IWebElement Icon => Driver.FindElement(By.XPath("//input[@name='icon']"));
        public IWebElement Edit => Driver.FindElement(By.XPath("//a[text()='Edit']"));
        public IWebElement Update => Driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement AppUpdated => Driver.FindElement(By.ClassName("flash"));
        public IWebElement Delete => Driver.FindElement(By.XPath("//a[text()='Delete']"));
        // private IWebElement PopularApp => Driver.FindElement(By.XPath("//div[contains(text(), 'This is title for new application')]"));

        //JSON
        public IWebElement JSONText => Driver.FindElement(By.XPath("//pre[contains(text(), 'Application Information')]"));
        
        public string JSONToText() 
        {
            return JSONText.Text;
        }
        
        public static By searchForApp = By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']");

        /*public void OpenApplicationPage()
        {
            Application.Click();
        }*/
        

        /*public void OpenCreatedAppPage()
        {
            CreatedApp.Click();
        }*/
        

        /*public string PopularAppTitle()
        {
            return PopularApp.Text;
        }*/
    }
}