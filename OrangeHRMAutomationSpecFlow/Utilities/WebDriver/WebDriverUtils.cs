using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Utilities
{
    /// <summary>
    /// Sets up the webdriver object.
    /// </summary>
    public class WebDriverSetup
    {
        /// <summary>
        /// This sets up any specific configurations we want for our webdriver instance of the browser
        /// We can do things like set the global implicit wait time, and browser size here
        /// </summary>
        /// <returns>Configured RemoteWebDriverObject</returns>
        public static RemoteWebDriver ConfigureDriver()
        {
            var driver = GetDriver();

            driver.Manage().Cookies.DeleteAllCookies();

            // Sets up the implicity wait, this will make WebDriver poll the DOM for 10 seconds when trying to locate elements.
            // more here: http://www.seleniumhq.org/docs/04_webdriver_advanced.jsp#implicit-waits
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }

        /// <summary>
        /// Sets the browser options for webdriver for use with the sepcific browser set in out App.config file.
        /// </summary>
        /// <returns>The RemoteWebDriverObject with ptions set for the specific browser.</returns>        
        private static RemoteWebDriver GetDriver()
        {
            SetupChromeDriver();
            // Get the browser we are using, and configure the driver object for use with it.
            switch (ConfigConstants.Browser.ToLower())
            {
                case "chrome":
                default:
                    return SetupChromeDriver();
            }
        }

        /// <summary>
        /// Sets up all the driver options specific to Chrome.
        /// </summary>
        /// <returns>RemoteWebDriver with Chrome options configured</returns>
        private static RemoteWebDriver SetupChromeDriver()
        {
            // Get the defatult ChromeOptions object
            var chromeOptions = new ChromeOptions();

            // Set any of the desired options we want
            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("--start-maximized");

            // Convert the options to capabilities this is so we can use them to configure the RemoteWebDriver
            chromeOptions.ToCapabilities();

            return new RemoteWebDriver(new Uri(ConfigConstants.SeleniumServer), chromeOptions);      
        }
    }
}
