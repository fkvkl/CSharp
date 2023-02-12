using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Crm.Drivers;
using Crm.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crm.Properties;

namespace Crm.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly IWebDriver driver;
        public LoginStepDefinitions() => driver = Driver.Get();

        [Given(@"User navigates to login page\.")]
        public void GivenUserNavigatesToLoginPage_()
        {
            driver.Navigate().GoToUrl(Resources.Url);
        }

        [When(@"User enters username and password and clicks login button\.")]
        public void WhenUserEntersUsernameAndPasswordAndClicksLoginButton_()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.login();
        }

        [Then(@"User should be able land on the home page and page title should contain ""(.*)""\.")]
        public void ThenUserShouldBeAbleLandOnTheHomePageAndPageTitleShouldContain_(string p0)
        {
            BrowserUtils.waitForPageToLoad(5);
            string actual = driver.Title;
            Assert.IsTrue(actual.Contains(p0));
        }
    }
}
