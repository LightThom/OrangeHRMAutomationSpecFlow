using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OrangeHRMAutomationSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Pages
{
    public class UserManagementPageObjects : BasePageObjects
    {
        public UserManagementPageObjects(RemoteWebDriver webDriver) : base(webDriver)
        {

        }

        #region Element Locators
        private IWebElement WelcomeUserMessage => Wait.Until(d => Driver.FindElementById("welcome"));

        private IWebElement SystemUserMenu => Wait.Until(d => Driver.FindElementById("systemUser-information"));

        private IWebElement SearchButton => Wait.Until(d => Driver.FindElementById("searchBtn"));

        private IWebElement AddButton => Wait.Until(d => Driver.FindElementById("btnAdd"));

        #endregion

        #region Non-Public Methods

    #endregion

    #region Public Methods

        public bool IsUserLoggedIn()
        {
            return DoesElementExist(WelcomeUserMessage);
        }
        public bool IsSystemUsersPresent()
        {
            return DoesElementExist(SystemUserMenu);
        }


        #endregion
    }
}