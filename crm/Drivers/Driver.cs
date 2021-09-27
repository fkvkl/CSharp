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
                             
                             break;
                         case "firefox":
                             
                             break;
                         case "firefox-headless":
                             
                             break;
                         case "ie":
                             
                             break;

                         case "edge":
                            
                             break;

                         case "safari":
                             
                         break;
                     */
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
