using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRMAutomationSpecFlow.Pages;
using TechTalk.SpecFlow;

namespace OrangeHRMAutomationSpecFlow.Steps
{
    [Binding]
    public class LoginStepDefinitions : BaseSteps
    {
        public LoginStepDefinitions(SeleniumContext seleniumContext) : base(seleniumContext)
        {
        }

        [Given(@"I navigate to the to OrangeHRM app")]
        public void GivenINavigateToTheToOrangeHRMApp()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
        }

        [When(@"I attempt to login with Admin credentials")]
        public void WhenIAttemptToLoginWithAdminCredentials()
        {
            LoginPage.LoginWithAdminCredentials();
        }

        //[When(@"I enter the user name ""(.*)""")]
        //public void WhenIEnterTheUserName(string userName)
        //{
        //    LoginPageObjects.TypeIntoUserNameField();

        //}

        //[When(@"I enter the password ""(.*)""")]
        //public void WhenIEnterThePassword(string password)
        //{
        //    LoginPageObjects.TypeIntoPasswordeField();
        //}

        //[When(@"I click Login")]
        //public void WhenIClickLogin()
        //{
        //    driver.FindElement(By.Id("btnLogin")).Click();
        //}

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Assert.AreEqual(true, Driver.FindElement(By.Id("welcome")).Displayed);
        }

    }
}
