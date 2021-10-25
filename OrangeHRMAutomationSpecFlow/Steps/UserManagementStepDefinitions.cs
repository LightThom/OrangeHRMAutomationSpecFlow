using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRMAutomationSpecFlow.Pages;
using TechTalk.SpecFlow;

namespace OrangeHRMAutomationSpecFlow.Steps
{
    [Binding]
    public sealed class UserManagementStepDefinitions : BaseSteps
    {
        public UserManagementStepDefinitions(SeleniumContext seleniumContext) : base(seleniumContext)
        {
            OrangeHRMUrl = Utils.GetOrangeHRMUrl();
        }

        [Given(@"I am logged in as an Admin")]
        public void GivenIAmLoggedInAsAnAdmin()
        {
            Driver.Navigate().GoToUrl(OrangeHRMUrl);

            LoginPage.LoginWithAdminCredentials();
        }
   
        [When(@"I navigate to the User Management screen")]
        public void WhenINavigateToTheUserManagementScreen()
        {
            NavBarPage.ClickAdminButtonInMainMenu();
        }

        [Then(@"the System Users search form is present")]
        public void ThenTheSystemUsersSearchFormIsPresent()
        {
            Assert.IsTrue(UserPage.IsSystemUsersPresent(), "The Systems User form should be displayed");
        }

        [Then(@"Search Results is present")]
        public void ThenSearchResultsIsPresent()
        {
            Assert.IsTrue(UserPage.IsSearchUsersPresent(), "The Search Results should be displayed");

        }

        [Given(@"I am on the user management screen")]
        public void GivenIAmOnTheUserManagementScreen()
        {
            Driver.Navigate().GoToUrl(OrangeHRMUrl);

            LoginPage.LoginWithAdminCredentials();

            NavBarPage.ClickAdminButtonInMainMenu();
        }

        [Given(@"I enter the Employee Name Carlos Lucas Zapata")]
        public void GivenIEnterTheUsername()
        {
            Driver.FindElement(By.Id("searchSystemUser_employeeName_empName")).SendKeys("Carlos Lucas Zapata");
        }

        [When(@"I click Search")]
        public void WhenIClickSearch()
        {
            Driver.FindElement(By.Id("searchBtn")).Click();
        }

        [Then(@"the username is present")]
        public void ThenTheUsernameIsPresent()
        {
            Assert.AreEqual(true, Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[4]/table/tbody/tr/td[4]")).Displayed);
        }

        [When(@"I click Add")]
        public void WhenIClickAdd()
        {
            Driver.FindElement(By.Id("btnAdd")).Click();
        }

        [Then(@"the Add User form is present")]
        public void ThenTheAddUserFormIsPresent()
        {
            Assert.AreEqual(true, Driver.FindElement(By.Id("frmSystemUser")).Displayed);
        }

        [Given(@"I am on the Add User form")]
        public void GivenIAmOnTheAddUserForm()
        {
            Driver.Navigate().GoToUrl(OrangeHRMUrl);

            Driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");

            Driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");

            Driver.FindElement(By.Id("btnLogin")).Click();

            Driver.FindElement(By.Id("menu_admin_viewAdminModule")).Click();

            Driver.FindElement(By.Id("btnAdd")).Click();
        }

        [Given(@"I select the User Role Admin")]
        public void GivenISelectTheUserRoleAdmin()
        {
            Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/form/fieldset/ol/li[1]/select/option[1]")).Click();
        }

        [Given(@"I search for the employee name Anthony Nolan")]
        public void GivenISearchForTheEmployeeName()
        {
            Driver.FindElement(By.Id("systemUser_employeeName_empName")).SendKeys("Anthony Nolan" + "\n");
        }

        [Given(@"I enter the user name Anthony Nolan5")]
        public void GivenIEnterTheUserName()
        {
            Driver.FindElement(By.Id("systemUser_userName")).SendKeys("Anthony Nolan5");
        }

        [Given(@"I enter and confirm the password Password1")]
        public void GivenIEnterAndConfirmThePassword()
        {
            Driver.FindElement(By.Id("systemUser_password")).SendKeys("Password1");
            Driver.FindElement(By.Id("systemUser_confirmPassword")).SendKeys("Password1");
        }

        [When(@"I click Save")]
        public void WhenIClickSave()
        {
            Driver.FindElement(By.Id("btnSave")).Click();
        }

        [When(@"I search for the username Anthony Nolan1")]
        public void WhenISearchForTheUsername()
        {
            Driver.FindElement(By.Id("searchSystemUser_userName")).SendKeys("Anthony Nolan5");
            Driver.FindElement(By.Id("searchBtn")).Click();

        }

        [Then(@"the username is present with the Admin User Role")]
        public void ThenTheUsernameIsPresentWithTheUserRole()
        {
            Assert.AreEqual(true, Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/form/div[4]/table/tbody/tr/td[2]")).Displayed);
        }


    }
}

