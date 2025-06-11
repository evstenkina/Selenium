using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework.Features
{
    public class AJAXFeatures
    {
        private AJAXPage ajaxPage;

        public AJAXFeatures(IWebDriver driver)
        {
            ajaxPage = new AJAXPage(driver);
        }

        public string ElementsSetUp(dynamic X, dynamic Y)
        {
            ajaxPage.SetX(X);
            ajaxPage.SetY(Y);
            ajaxPage.ClickSumButton();
            
            return ajaxPage.GetResultText();
        }
        
        /*public string ElementsSetUp(int X, int Y)
        {
            ajaxPage.SetX(X);
            ajaxPage.SetY(Y);
            ajaxPage.ClickSumButton();
            
            return ajaxPage.GetResultText();
        }
            
        public string ElementsSetUp(int X, string Y)
        {
            ajaxPage.SetX(X);
            ajaxPage.SetY(Y);
            ajaxPage.ClickSumButton();
            
            return ajaxPage.GetResultText();
        }*/
    
    }
}