using System.Drawing.Drawing2D;
using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement AjaxPage => Driver.FindElement(By.XPath("//a[text()='Ajax test page']"));
        public IWebElement MyApplication => Driver.FindElement(By.XPath("//a[text()='My applications']"));
        public IWebElement JSTestPage => Driver.FindElement(By.XPath("//a[text()='JS test page']"));
    }
}
//TODO add header elements