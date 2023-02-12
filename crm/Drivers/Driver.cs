using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Crm.Drivers
{
    public class Driver
    {
        private static IWebDriver driver;
        private Driver() 
        {
        }

        public static IWebDriver Get()
        {
            // Test
            if (driver == null)
            {
                string browser = "chrome";
                switch (browser)
                {
                    case "chrome":
                        driver = new ChromeDriver();
                        break;                               
                    case "firefox":
                        driver=new FirefoxDriver();
                        break;
                    case "ie":
                        driver= new InternetExplorerDriver();
                        break;
                    case "edge":
                        driver= new EdgeDriver();
                        break;
                    case "safari":
                        driver=new SafariDriver();    
                        break;
                }
            }
            return driver;
        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
