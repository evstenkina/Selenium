using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.Framework.Models;
using log4net;
using Selenium.Framework.Pages;

namespace Selenium.Framework.Features
{
    public class JsFeatures
    {
        private readonly JsPage JsPage;
        private readonly IWebDriver Driver;
        private readonly ILog Logger;

        public JsFeatures(IWebDriver driver)
        {
            Driver = driver;
            JsPage = new JsPage(driver);
            Logger = LogManager.GetLogger(typeof(JsFeatures));//todo сделать класс для логера
        }
        
        public void Execute()
        {
            GetCoordinates();
            JsPage.TopInputField.SendKeys(GetCoordinates().Top.ToString());
            Logger.Info("Top coordinate is set");
            JsPage.LeftInputField.SendKeys(GetCoordinates().Left.ToString());
            Logger.Info("Left coordinate is set");
            JsPage.Process.Click();
            Logger.Info("Result is procced");
        }

        private JSCoordinates.Coordinates GetCoordinates()
        {
            //Приводим Driver к типу IJavaScriptExecutor, чтобы можно было выполнять JavaScript-код в контексте браузера.
            IJavaScriptExecutor JSExecutor = (IJavaScriptExecutor)Driver;
            string script = @"
            var el = arguments[0];
            var rect = el.getBoundingClientRect();
            return {
                top: rect.top + window.scrollY,
                left: rect.left + window.scrollX
            }";
            // Приводит результат выполнения Javascript в словарь
            //Выполняем JavaScript в браузере и передаём туда JSElement (элемент, координаты которого хотим получить).
            // Получаем результат в виде словаря (ключи: "top" и "left"), потому что JS возвращает объект.
            var result = (Dictionary<string, object>)JSExecutor.ExecuteScript(script, JsPage.JsElement);
            //Извлекаем значения top и left из словаря и конвертируем их в int, чтобы использовать в C# как числа.
            var top = Convert.ToInt32(result["top"]);
            var left = Convert.ToInt32(result["left"]);

            return new JSCoordinates.Coordinates(top, left);
        }
    }
}