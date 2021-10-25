using OpenQA.Selenium.Remote;
using OrangeHRMAutomationSpecFlow.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Steps
{
    public class BaseSteps
    {
        public static RemoteWebDriver Driver;

        // Declare Home Page URL
        public string OrangeHRMUrl { get; set; }

        // Page object declarations
        public LoginPageObjects LoginPage { get; set; }
        public UtilitySteps Utils { get; set; }

        public BaseSteps(SeleniumContext seleniumContext)
        {
        Driver = seleniumContext.Driver;

            LoginPage = new LoginPageObjects(Driver);
        }
    
    }
}
