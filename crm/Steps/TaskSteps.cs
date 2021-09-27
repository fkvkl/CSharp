using Crm.Drivers;
using Crm.Pages;
using Crm.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Crm.Steps
{
    [Binding]
    public class TasksSteps
    {
        private readonly IWebDriver driver;
        public TasksSteps() => driver = Driver.Get();

        [Given(@"User enters username and password and clicks login button\.")]
        public void WhenUserEntersUsernameAndPasswordAndClicksLoginButton_()
        {
            Driver.Get().Navigate().GoToUrl(Resources.Url);
            new LoginPage(driver).login();
        }
        [When(@"user clicks ""(.*)"" menu")]
        public void WhenUserClicksMenu(string menu)
        {
            new HomePage(driver).navigateToMenu(menu);
        }
        [When(@"user clicks ""(.*)"" tab")]
        public void WhenUserClicksTab(string tab)
        {
            new HomePage(driver).navigateToTab(tab);
        }
        [Then(@"User should be able to display tasks ""(.*)""")]
        public void ThenUserShouldBeAbleToDisplayTasks(string expected)
        {
            string actual = new HomePage(driver).tasksContainer.Text;
            Assert.IsTrue(actual.Contains(expected));

        }

    }

}
