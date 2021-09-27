using OpenQA.Selenium;

namespace DemoBlaze.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver _driver) : base(_driver)
        {
        }

        public IWebElement OpenMenu(string menu)
        {
            IWebElement locator = driver.FindElement(By.XPath("//a[.='" + menu + "']"));
            return locator;
        }
        public IWebElement SelectProduct(string product)
        {
            IWebElement locator = driver.FindElement(By.XPath("//a[.='" + product + "']"));
            return locator;
        }

        public IWebElement addToChart => driver.FindElement(By.XPath("//a[.='Add to cart']"));

        public IWebElement home => driver.FindElement(By.XPath("(//a[@href='index.html'])[2]"));

        public IWebElement Chart => driver.FindElement(By.XPath("//a[.='Cart']"));

    }
}
