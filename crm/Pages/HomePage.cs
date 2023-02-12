using OpenQA.Selenium;

namespace Crm.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver _driver) : base(_driver)
        {
        }

        public IWebElement ongoing => driver.FindElement(By.XPath("//div[@class='main-ui-square-item'][2]"));
        public IWebElement tasksContainer => driver.FindElement(By.CssSelector(".pagetitle-flexible-space"));

        public void navigateToMenu(string menu)
        {
            driver.FindElement(By.XPath("//span[@class='menu-item-link-text' and contains(text(), '" + menu + "')]")).Click();
        }

        public void navigateToTab(string tab)
        {
            driver.FindElement(By.XPath("//span[@class='main-buttons-item-text-title' and contains(text(), '" + tab + "')]")).Click();
        }
    }
}
