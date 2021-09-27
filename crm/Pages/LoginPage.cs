
using Crm.Properties;
using OpenQA.Selenium;

namespace Crm.Pages
{
    public class LoginPage: BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
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