using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OrangeHRMAutomationSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Pages
{
    public class NavBarPageObjects : BasePageObjects
    {
        public NavBarPageObjects(RemoteWebDriver webDriver) : base(webDriver)
        {

        }

        #region Element Locators
        private IWebElement AdminMenuButton => Wait.Until(d => Driver.FindElementById("menu_admin_viewAdminModule"));

        #endregion

        #region Non-Public Methods

        #endregion

        #region Public Methods
        public void ClickAdminButtonInMainMenu()
        {
            Driver.WaitAndReinitialiseElements(this);

            AdminMenuButton.Click();
        }
        #endregion
    }
}