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
            OrangeHRMUrl = Utils.GetOrangeHRMUrl();
        }

        [Given(@"I navigate to the to OrangeHRM app")]
        public void GivenINavigateToTheToOrangeHRMApp()
        {
            Driver.Navigate().GoToUrl(OrangeHRMUrl);
        }

        [When(@"I attempt to login with Admin credentials")]
        public void WhenIAttemptToLoginWithAdminCredentials()
        {
            LoginPage.LoginWithAdminCredentials();
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Assert.IsTrue(UserPage.IsUserLoggedIn(), "The Welcome text should be displayed");
        }

    }
}
