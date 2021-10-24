﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace OrangeHRMAutomationSpecFlow.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
    
        public IWebDriver setup()
        {
            var chromeOptions = new ChromeOptions();

            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions.ToCapabilities());

            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
