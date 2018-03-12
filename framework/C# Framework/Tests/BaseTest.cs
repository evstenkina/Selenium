using System;
using Selenium.Framework;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;

public class BaseTest
{

    protected IWebDriver Driver;
    protected ILog Logger;

    [SetUp]
    public virtual void Init()
    {
        this.Logger = LogManager.GetLogger(GetType());
        this.Logger.Info("log4net initialized");
        this.Driver = Settings.GetDriver();
        this.Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        this.Logger.Info("Test started");
    }

    [TearDown]
    public virtual void Cleanup()
    {
        this.Driver.Quit();
    }
}
