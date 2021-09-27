using OpenQA.Selenium;

namespace Crm.Pages
{
    public abstract class BasePage
    {
        public IWebDriver driver;
        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
        }
    }
}
