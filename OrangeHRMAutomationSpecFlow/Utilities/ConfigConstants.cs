using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Utilities
{
    public class ConfigConstants
    {
        public static readonly string SeleniumServer = ConfigurationManager.AppSettings.Get("SeleniumServerUrl");
        public static readonly string Browser = ConfigurationManager.AppSettings.Get("BrowserName");

        public const string OrangeHRMUrl = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";

    }
}
