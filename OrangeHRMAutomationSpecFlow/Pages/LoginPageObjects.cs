using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OrangeHRMAutomationSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMAutomationSpecFlow.Pages
{
    public class LoginPageObjects : BasePageObjects
    {
        public LoginPageObjects(RemoteWebDriver webDriver) : base(webDriver)
        {

        }

        #region Element Locators
        private IWebElement UserNameTextField => Wait.Until(d => Driver.FindElementById("txtUsername"));

        private IWebElement PassowrdTextField => Wait.Until(d => Driver.FindElementById("txtPassword"));

        private IWebElement LoginButton => Wait.Until(d => Driver.FindElementById("btnLogin"));

        #endregion

        #region Non-Public Methods
        private void TypeIntoUserNameField(string username)
        {
            Driver.WaitAndReinitialiseElements(this);

            UserNameTextField.SendKeys(username);
        }
        private void TypeIntoPasswordeField(string password)
        {
            Driver.WaitAndReinitialiseElements(this);

            PassowrdTextField.SendKeys(password);
        }
        private void ClickLoginButton()
        {
            Driver.WaitAndReinitialiseElements(this);

            LoginButton.Click();
        }

        private void SubmitLoginDetails(string username, string password)
        {
            TypeIntoUserNameField(username);
            TypeIntoPasswordeField(password);
            ClickLoginButton();
        }

        #endregion

        #region Public Methods

        
        public void LoginWithAdminCredentials()
        {
            SubmitLoginDetails(UserConstants.Username, UserConstants.Password);
        }

        public void LoginWithUsernameAndPassword(string username, string password)
        {
            SubmitLoginDetails(username, password);
        }
        #endregion
    }
}
