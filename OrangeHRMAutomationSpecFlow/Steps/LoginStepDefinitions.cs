using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRMAutomationSpecFlow.Drivers;
using TechTalk.SpecFlow;

namespace OrangeHRMAutomationSpecFlow.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {

        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    
        [Given(@"I navigate to the to OrangeHRM app")]
        public void GivenINavigateToTheToOrangeHRMApp()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").setup();

            driver.Url = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";
        }

        [When(@"I enter the user name")]
        public void WhenIEnterTheUserName()
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            
        }

        [When(@"I enter the password")]
        public void WhenIEnterThePassword()
        {
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
        }

        [When(@"I click Login")]
        public void WhenIClickLogin()
        {
            driver.FindElement(By.Id("btnLogin")).Click();
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("welcome")).Displayed);
        }

    }
}
