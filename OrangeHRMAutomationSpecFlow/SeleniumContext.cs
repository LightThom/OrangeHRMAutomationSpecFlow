using OpenQA.Selenium.Remote;
using OrangeHRMAutomationSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMAutomationSpecFlow
{
    public class SeleniumContext
    {
        public RemoteWebDriver Driver { get; private set; }
        public SeleniumContext()
        {
            Driver = WebDriverSetup.ConfigureDriver();
        }
    }
}
