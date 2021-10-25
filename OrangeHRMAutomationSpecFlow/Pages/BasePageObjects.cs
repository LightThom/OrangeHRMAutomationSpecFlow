using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OrangeHRMAutomationSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Pages
{
    /// <summary>
    /// Base class for all page objects
    /// </summary>
    public abstract class BasePageObjects
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// The remote webdriver object we will use to drive the browser actions
        /// </summary>
        public RemoteWebDriver Driver;

        /// <summary>
        /// The wait object that will be used to force WebDriver to wait for elements.
        /// </summary>
        public WebDriverWait Wait;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        protected BasePageObjects(RemoteWebDriver webDriver)
        {
            Driver = webDriver;

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(WebDriverException),
                typeof(InvalidOperationException));
        }

        protected string GetDefaultUsername()
        {
            return UserConstants.Username;
        }
        protected string GetDefaultPassword()
        {
            return UserConstants.Password;
        }

        protected bool DoesElementExist(IWebElement theElement)
        {
            try
            {
                var builder = new Actions(Driver);
                builder.MoveToElement(theElement).Build().Perform();

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
                {
                    return false;
                }
            
        }
    }
}
