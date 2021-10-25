using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Utilities
{
    public class ConfigConstants
    {
        public static readonly string SeleniumServer = ConfigurationManager.AppSettings.Get("SeleniumServerUrl");
        public static readonly string ScreenshotDir = ConfigurationManager.AppSettings.Get("ScreenshotDir");
        public static readonly string Browser = ConfigurationManager.AppSettings.Get("BrowserName");
        public static readonly string Environment = ConfigurationManager.AppSettings.Get("EnvironmentId");
        public static readonly string ImageDir = ConfigurationManager.AppSettings.Get("ImageDir");

        public const string LoginPage = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";

    }
}
