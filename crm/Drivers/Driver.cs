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
                // this line will tell which browser should open based on the value from properties file
                string browser = "chrome";
                switch (browser)
                {
                    case "chrome":
                        driver = new ChromeDriver();
                        break;
                        /* case "chrome-headless":
                             WebDriverManager.chromedriver().setup();
                             driver = new ChromeDriver(new ChromeOptions().setHeadless(true));
                             break;
                         case "firefox":
                             WebDriverManager.firefoxdriver().setup();
                             driver = new FirefoxDriver();
                             break;
                         case "firefox-headless":
                             WebDriverManager.firefoxdriver().setup();
                             driver = new FirefoxDriver(new FirefoxOptions().setHeadless(true));
                             break;
                         case "ie":
                             if (!System.getProperty("os.name").toLowerCase().contains("windows"))
                                 throw new WebDriverException("Your OS doesn't support Internet Explorer");
                             WebDriverManager.iedriver().setup();
                             driver = new InternetExplorerDriver();
                             break;

                         case "edge":
                             if (!System.getProperty("os.name").toLowerCase().contains("windows"))
                                 throw new WebDriverException("Your OS doesn't support Edge");
                             WebDriverManager.edgedriver().setup();
                             driver = new EdgeDriver();
                             break;

                         case "safari":
                             if (!System.getProperty("os.name").toLowerCase().contains("mac"))
                                 throw new WebDriverException("Your OS doesn't support Safari");
                             WebDriverManager.getInstance(SafariDriver.class).setup();
             driver = new SafariDriver();
                         break;*/
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
