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
        public NavBarPageObjects NavBarPage { get; set; }
        public UserManagementPageObjects UserPage { get; set; }
        public UtilitySteps Utils { get; set; }

        public BaseSteps(SeleniumContext seleniumContext)
        {
            Driver = seleniumContext.Driver;

            // Instantiate PageObjects for tests
            LoginPage = new LoginPageObjects(Driver);
            NavBarPage = new NavBarPageObjects(Driver);
            UserPage = new UserManagementPageObjects(Driver);

            // Instantiate helper classes
            Utils = new UtilitySteps();
        }
    
    }
}
