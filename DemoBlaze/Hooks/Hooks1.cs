using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using DemoBlaze.Drivers;

namespace DemoBlaze.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private IWebDriver driver = Driver.Get();

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {

            if (scenarioContext.TestError != null)
            {
                string date = DateTime.Now.ToString("yyyyMMddhhmmss");
                // TakesScreenshot ---> interface from selenium which takes screenshots
                Screenshot image = ((ITakesScreenshot)Driver.Get()).GetScreenshot();
                // full path to the screenshot location
                string target = "C:/Users/ferhat/source/repos/" + date + ".png";
                //Save the screenshot
                image.SaveAsFile(target);
            }
            Driver.CloseDriver();
        }
    }
}
