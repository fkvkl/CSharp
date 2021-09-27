﻿
using DemoBlaze.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoBlaze
{
    public class BrowserUtils
    {
        public static string GetScreenshot(string name)
        {
            // name the screenshot with the current date time to avoid duplicate name
            string date = DateTime.Now.ToString("yyyyMMddhhmmss");
            // TakesScreenshot ---> interface from selenium which takes screenshots
            //Take the screenshot
            Screenshot image = ((ITakesScreenshot)Driver.Get()).GetScreenshot();
            // full path to the screenshot location
            string target = "C:/Users/ferhat/source/repos/screenshots/" + name + date + ".png";
            //Save the screenshot
            image.SaveAsFile(target);

            return target;
        }
        public static void waitForPageToLoad(int sec)
        {
            Driver.Get().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(sec);
        }

        

        public static void waitFor(int seconds)
        {
            try
            {
                Thread.Sleep(seconds * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                e.InnerException.ToString();
            }
        }


        /**
     * Switches to new window by the exact title. Returns to original window if target title not found
     * @param targetTitle
     */
        public static void SwitchToWindow(string targetTitle, IWebDriver driver)
        {
            string origin = Driver.Get().CurrentWindowHandle;
            foreach (string handle in Driver.Get().WindowHandles)
            {
                Driver.Get().SwitchTo().Window(handle);
                if (Driver.Get().Title.Equals(targetTitle))
                {
                    return;
                }
            }
            Driver.Get().SwitchTo().Window(origin);
        }

        public static Dictionary<string, string> TableToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
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
