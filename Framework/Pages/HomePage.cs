using OpenQA.Selenium;
using Selenium.Framework.Pages;

namespace Selenium.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        
        public IWebElement Application => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=Application Information 1']"));
        public IWebElement CreatedApp => Driver.FindElement(By.XPath("//a[text()='Details' and @href='/app?title=This is title for new application']"));
        public IWebElement PopularApp => Driver.FindElement(By.XPath("//div[contains(text(), 'This is title for new application')]"));
    }
}