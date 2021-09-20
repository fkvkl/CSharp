
using Crm.Properties;
using OpenQA.Selenium;
using System.Configuration;

namespace Crm.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }
        IWebElement userInput => driver.FindElement(By.XPath("(//input[@class='login-inp'])[1]"));
        IWebElement passInput => driver.FindElement(By.XPath("(//input[@class='login-inp'])[2]"));
        IWebElement loginBtn => driver.FindElement(By.CssSelector(".login-btn"));

        public void login()
        {
            userInput.SendKeys(Resources.Username);
            passInput.SendKeys(Resources.Password);
            loginBtn.Click();
        }
    }
}