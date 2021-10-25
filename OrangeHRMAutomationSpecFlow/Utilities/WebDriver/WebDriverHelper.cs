using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Utilities
{
    /// <summary>
    /// Custom helpers class for working with webdriver functions.
    /// </summary>
    public static class WebdriverHelpers
    {
        /// <summary>
        /// Wait for the page to finish loading, then reinitialise the page factory.
        /// This is needed to avoid StaleElementReference errors
        /// </summary>
        /// <param name="webDriver">The webdriver object</param>
        /// <param name="page">The page facotry class to use</param>
        public static void WaitAndReinitialiseElements(this RemoteWebDriver webDriver, object page)
        {
            // Javascript to wait for the page ready state to be completed
            // This will check the page state for up to 5 seconds or until the page state is complete.
            var jsWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));

            // This waits for the document to be in a ready state.
            jsWait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));

            // This makes sure these elements are hidden
            if (webDriver.DoesElementExist(By.Id("uiBlocker"))) webDriver.WaitForElementToNoLongerExist(By.Id("uiBlocker"));
            if (webDriver.DoesElementExist(By.Id("basketOverlay"))) webDriver.WaitForElementToNoLongerExist(By.Id("basketOverlay"));
            if (webDriver.DoesElementExist(By.Id("loader"))) webDriver.WaitForElementToNoLongerExist(By.Id("loader"));
            if (webDriver.DoesElementExist(By.ClassName("loader"))) webDriver.WaitForElementToNoLongerExist(By.ClassName("loader"));
            if (webDriver.DoesElementExist(By.CssSelector("div.notification"))) webDriver.WaitForElementToNoLongerExist(By.CssSelector("div.notification"));
            if (webDriver.DoesElementExist(By.CssSelector("a.cookiePolicy_inner-link")) &&
                webDriver.FindElement(By.CssSelector("a.cookiePolicy_inner-link"))
                    .Displayed)
                webDriver.FindElementByCssSelector("a.cookiePolicy_inner-link")
                    .Click();
        }

        /// <summary>
        /// Waits for an element to no longer exist in the DOM
        /// </summary>
        /// <param name="webDriver">the webdriver object</param>
        /// <param name="theElement">The By locator of the element we want to wait for.</param>
        public static void WaitForElementToNoLongerExist(this RemoteWebDriver webDriver, By theElement)
        {
            var sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed < TimeSpan.FromSeconds(10))
            {
                if (!webDriver.DoesElementExist(theElement)) break;
            }
        }


        /// <summary>
        /// Waits for an element to no longer exist in the DOM
        /// </summary>
        /// <param name="webDriver">the webdriver object</param>
        /// <param name="theElement">The By locator of the element we want to wait for.</param>
        public static void WaitForElementToNoLongerExist(this RemoteWebDriver webDriver, IWebElement theElement)
        {
            var sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed < TimeSpan.FromSeconds(10))
            {
                if (!webDriver.DoesElementExist(theElement)) break;
            }
        }

        /// <summary>
        /// Checks if an element is visible and enabled to ensure its existence on the page.
        /// </summary>
        /// <param name="webDriver">the webdriver object</param>
        /// <param name="theElement"></param>
        /// <returns>True if the element is visible and enabled, False if not.</returns>
        public static bool DoesElementExist(this RemoteWebDriver webDriver, IWebElement theElement)
        {
            try
            {
                // Try to move the mouse to the element, if its not visible an exception will be thrown, if it is visible the action will perform normally.
                var builder = new Actions(webDriver);
                builder.MoveToElement(theElement).Build().Perform();

                // If not exception is thrown return true.
                return true;
            }
            catch (NoSuchElementException)
            {
                // If we get an exception then return flase.
                return false;
            }
            catch (StaleElementReferenceException)
            {
                // If we get an exception then return flase.
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                // If we get a timeout then return flase.
                return false;
            }
        }

        /// <summary>
        /// Checks if an element is locatable, visible and enabled to ensure its existence on the page.
        /// </summary>
        /// <param name="webDriver">The webdriver object</param>
        /// <param name="theElementByLocator">the By locator for the element</param>
        /// <returns>True if the element is visible and enabled, False if not</returns>
        public static bool DoesElementExist(this RemoteWebDriver webDriver, By theElementByLocator)
        {
            try
            {
                var theElement = webDriver.FindElement(theElementByLocator);

                // Try to move the mouse to the element, if its not visible an exception will be thrown, if it is visible the action will perform normally.
                var builder = new Actions(webDriver);
                builder.MoveToElement(theElement).Build().Perform();

                // If no exception is thrown return true.
                return true;
            }
            catch (NoSuchElementException)
            {
                // If we get an exception then return false.
                return false;
            }
            catch (StaleElementReferenceException)
            {
                // If we get an exception then return false.
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                // If we get a timeout then return flase.
                return false;
            }
        }

        /// <summary>
        /// Checks if an element is both visible and enabled, then returns the element.
        /// </summary>
        /// <param name="webDriver">The remote webdriver object</param>
        /// <param name="element">The element we want ot check</param>
        /// <returns>the IWebElement object</returns>
        public static IWebElement IsElementClickable(IWebElement element)
        {
            var sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed < TimeSpan.FromSeconds(10))
            {
                if (element.Displayed && element.Enabled) break;
            }

            return element;
        }

        /// <summary>
        /// Checks if an element is both visible and enabled, then returns the element.
        /// </summary>
        /// <param name="elementByLocator">The element we want ot check</param>
        /// /// <param name="webDriver">The remote webdriver object</param>
        /// <returns>true if visible and enabled false if not</returns>
        public static bool IsElementClickable(this RemoteWebDriver webDriver, By elementByLocator)
        {
            var element = webDriver.FindElement(elementByLocator);
            var sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed < TimeSpan.FromSeconds(10))
            {
                if (element.Displayed && element.Enabled) return true;
            }

            return false;
        }

        /// <summary>
        /// Wait for the page to finish loading, get the page URL.        
        /// </summary>
        /// <param name="webDriver">The webdriver object</param>        
        public static string WaitAndGetPageUrl(this RemoteWebDriver webDriver)
        {
            // Javascript to wait for the page ready state to be completed
            // This will check the page state for up to 5 seconds or until the page state is complete.
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));

            // Get the page URL
            return webDriver.Url;
        }

        /// <summary>
        /// Forces an element into view by scrolling it to the top of the page.
        /// Use this when working with elements that may be hidden by the bottom floating nav bar.
        /// </summary>
        /// <param name="webDriver">The webdriver object</param>
        /// <param name="element">The element to scroll into view</param>
        /// <returns>the passed in web element.</returns>
        public static IWebElement ForceElementIntoView(this RemoteWebDriver webDriver, IWebElement element)
        {
            // Create a javascript executor.
            var js = webDriver as IJavaScriptExecutor;

            // uses javascript scrollIntoView: https://developer.mozilla.org/en-US/docs/Web/API/Element/scrollIntoView
            js?.ExecuteScript("arguments[0].scrollIntoView({behavior: 'instant', block: 'center', inline: 'nearest'});", element);

            return element;
        }

        /// <summary>
        /// Sets the value of an element to the given value. 
        /// This is useful for date picker or other elements that don't necessarily expose all their child elements within the DOM.
        /// </summary>
        /// <param name="webDriver">The driver object.</param>
        /// <param name="element">The element who's value we need to set.</param>
        /// <param name="value">The value we want to set the element to.</param>
        public static void SetElementValue(this RemoteWebDriver webDriver, IWebElement element, string value)
        {
            // Create a javascript executor.
            var js = webDriver as IJavaScriptExecutor;

            // Uses JavaScript to set an elements value.
            js?.ExecuteScript($"arguments[0].value='{value}';", element);
        }

        /// <summary>
        /// Switch webdrivers focus to a given iframe
        /// </summary>
        /// <param name="webDriver">the webdriver object</param>
        /// <param name="iFrameElement">The IFrame web element</param>
        public static void SwitchFocusToIFrame(this RemoteWebDriver webDriver, IWebElement iFrameElement)
        {
            try
            {
                webDriver.SwitchTo().Frame(iFrameElement);
            }
            catch (NoSuchElementException)
            {
                Console.Write("There is no IFrame to use so the feature is off.");
            }

        }

        /// <summary>
        /// After we have finished working with an iframe we need to tell webdriver to refer to the main content again.
        /// </summary>
        /// <param name="webDriver"></param>
        public static void SwitchFocusToDefaultContent(this RemoteWebDriver webDriver)
        {
            webDriver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Checks if an element has a given attribute
        /// </summary>
        /// <param name="webDriver">The webdriver object</param>
        /// <param name="element">The element we want to check.</param>
        /// <param name="attribute">The attribute we are looking for.</param>
        /// <returns></returns>
        public static bool IsAttributePresent(this RemoteWebDriver webDriver, IWebElement element, string attribute)
        {
            var result = false;

            try
            {
                // Try to get the value of our attribute, if the attribute isn't present then we will get a null value. 
                // If its not null then we know the attribute is there
                var value = element.GetAttribute(attribute);

                if (value != null)
                    result = true;
            }
            catch (Exception)
            {
                // ignored
            }

            return result;
        }

        /// <summary>
        /// Switches to the next browser tab browser tab.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="currentHandle"></param>
        public static void SwitchToNewTab(this RemoteWebDriver webDriver, string currentHandle)
        {
            IList<string> handles = webDriver.WindowHandles;

            webDriver.SwitchTo().Window(handles[handles.Count - 1]);

        }

        /// <summary>
        /// Returns the value of a specific attribute of an element
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="element"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string GetElementAttributeValue(this RemoteWebDriver webDriver,
            IWebElement element,
            string attribute)
        {
            return IsElementClickable(element).GetAttribute(attribute);
        }
    }
}

