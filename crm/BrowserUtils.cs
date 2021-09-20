using Crm.Drivers;
using OpenQA.Selenium;
using System;


namespace Crm
{
    class BrowserUtils
    {
        public static string GetScreenshot(string name)
        {
            // name the screenshot with the current date time to avoid duplicate name
            string date = DateTime.Now.ToString("yyyyMMddhhmmss");
            // TakesScreenshot ---> interface from selenium which takes screenshots
            //Take the screenshot
            Screenshot image = ((ITakesScreenshot)Driver.Get()).GetScreenshot();
            // full path to the screenshot location
            string target = "C:/Users/ferhat/source/repos/vytrack/vytrack/screenshoots/" + name + date + ".png";
            //Save the screenshot
            image.SaveAsFile(target);

            return target;
        }

        /**
     * Switches to new window by the exact title. Returns to original window if target title not found
     * @param targetTitle
     */
        public static void SwitchToWindow(String targetTitle, IWebDriver driver)
        {
            String origin = Driver.Get().CurrentWindowHandle;
            foreach (String handle in Driver.Get().WindowHandles)
            {
                Driver.Get().SwitchTo().Window(handle);
                if (Driver.Get().Title.Equals(targetTitle))
                {
                    return;
                }
            }
            Driver.Get().SwitchTo().Window(origin);
        }
    }

    /**
     * Moves the mouse to given element
     *
     * @param element on which to hover
     */
    /*public static void Hover(IWebElement element)
    {
        Action action = new Action(Driver.Get());

        action.MoveToElement(element).Build.Perform();
    }*/


    /**
     * return a list of string from a list of elements
     *
     * @param list of webelements
     * @return list of string
     */
   



}
