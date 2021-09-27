using OpenQA.Selenium;

namespace DemoBlaze.Pages
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