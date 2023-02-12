using Crm.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Crm.Pages
{
    public class CalendarPage : BasePage
    {
        public CalendarPage(IWebDriver _driver) : base(_driver)
        {
        }

        private string firstEventName = "event";
        private string editedEventName = "editedEvent";
        public string getFirstEventName()
        {
            return firstEventName;
        }
        
        public string getEditedEventName()
        {
            return editedEventName;
        }

        public IWebElement add => driver.FindElement(By.XPath("//button[@class='ui-btn-main']"));
        public IWebElement eventName => driver.FindElement(By.XPath("//input[@name='name']"));
        public IWebElement schedule => driver.FindElement(By.XPath("//span[@data-bx-calendar-view='list']"));
        public IWebElement importance => driver.FindElement(By.XPath("//input[@name='importance']"));
        public IWebElement dateFrom => driver.FindElement(By.XPath("//input[@name='date_from']"));
        public IWebElement dateTo => driver.FindElement(By.XPath("//input[@name='date_to']"));
        public IWebElement timeZone => driver.FindElement(By.CssSelector(".calendar-options-timezone-collapse-btn"));
        public IWebElement timeZoneFrom => driver.FindElement(By.XPath("//select[@name='tz_from']"));
        public IWebElement repeat => driver.FindElement(By.XPath("//select[@name='EVENT_RRULE[FREQ]']"));
        public IWebElement location => driver.FindElement(By.XPath("//input[@name='lo_cation']"));
        public IWebElement attendeesField => driver.FindElement(By.CssSelector(".event-grid-dest-wrap"));
        public IList<IWebElement> allAttendees => driver.FindElements(By.CssSelector(".event-grid-dest-text"));
        public IWebElement removeFirstAttendee => driver.FindElement(By.XPath("(//span[@class='feed-event-del-but'])[2]"));
        public IList<IWebElement> invitedParticipants => driver.FindElements(By.CssSelector(".calendar-slider-sidebar-user-info-name"));
        public IWebElement invitedButton => driver.FindElement(By.CssSelector(".calendar-member-total-count"));
        public IWebElement employeesAndDeps => driver.FindElement(By.CssSelector(".bx-lm-tab-department"));
        public IWebElement more => driver.FindElement(By.CssSelector(".calendar-additional-alt-promo"));
        public IWebElement otherColor => driver.FindElement(By.CssSelector(".calendar-field-colorpicker-color-item-more-link"));
        public IWebElement customColor => driver.FindElement(By.CssSelector(".main-color-picker-custom-action"));
        public IWebElement colorCode => driver.FindElement(By.CssSelector(".main-color-picker-custom-input"));
        public IWebElement availability => driver.FindElement(By.XPath("//select[@name='accessibility']"));
        public IWebElement descriptionInput => driver.FindElement(By.XPath("//body"));
        public IWebElement descriptionFrame => driver.FindElement(By.XPath("//iframe[@class='bx-editor-iframe']"));
        public IWebElement save => driver.FindElement(By.XPath("//span[Contains(text(),'Ctrl+Enter')]"));
        public IWebElement editEvent => driver.FindElement(By.XPath("//span[@class='calendar-right-block-event-info-btn'][2]"));
        public IWebElement openEvent => driver.FindElement(By.XPath("//span[@class='calendar-right-block-event-info-btn'][1]"));
        public IWebElement privateEvent => driver.FindElement(By.XPath("//input[@name='private_event']"));
        public IWebElement getAvailability => driver.FindElement(By.XPath("(//div[@class='calendar-slider-detail-option-value'])[1]"));
        public IWebElement eventDetails => driver.FindElement(By.CssSelector(".calendar-timeline-stream-content-event"));
        public IWebElement specialNotes => driver.FindElement(By.XPath("(//div[@class='calendar-slider-detail-option-value'])[3]"));
        public IList<IWebElement> allEvents => driver.FindElements(By.XPath("//*[@class='calendar-timeline-stream-content-event-name-link']"));
        public IWebElement filterAndSearch => driver.FindElement(By.CssSelector("#calendar-filter-personal_search"));
        public IWebElement currentFilter => driver.FindElement(By.CssSelector(".main-ui-square-item"));
        public IWebElement addField => driver.FindElement(By.CssSelector(".main-ui-filter-field-add-item"));
        public IWebElement participationStatus => driver.FindElement(By.XPath("//div[.='Participation status']/div"));
        public IWebElement participationStatusField => driver.FindElement(By.XPath("(//div[@data-name='MEETING_STATUS'])[2]"));
        public IWebElement eventWithParticipants => driver.FindElement(By.XPath("(//div[@data-name='IS_MEETING']/div)[1]"));
        public IWebElement participantsYes => driver.FindElement(By.XPath("//div[@data-item='{\"NAME\":\"Yes\",\"VALUE\":\"Y\"}']"));
        public IWebElement participationInvited => driver.FindElement(By.XPath("//div[@data-item='{\"NAME\":\"Invited\",\"VALUE\":\"Q\"}']/div"));
        public IWebElement invitations => driver.FindElement(By.XPath("//span[.='Invitations']"));
        public IWebElement i_am_an_organiser => driver.FindElement(By.XPath("//span[.=\"I'm an organiser\"]"));
        public IWebElement reset => driver.FindElement(By.XPath("(//span[Contains(text(),'Reset')])[2]"));
        public IWebElement delete => driver.FindElement(By.XPath("//span[.='Delete']"));

        public void eventDescription(string description)
        {
            Driver.Get().SwitchTo().Frame(descriptionFrame);
            descriptionInput.Click();
            descriptionInput.SendKeys(description);
            Driver.Get().SwitchTo().DefaultContent();
        }

        public void addAttendees(string list)
        {
            attendeesField.Click();
            employeesAndDeps.Click();
            BrowserUtils.waitForPageToLoad(5);
            if (list.Contains("/"))
            {
                string[] split = list.Split("/");
                BrowserUtils.waitForPageToLoad(3);
                foreach (string s in split)
                {
                    Driver.Get().FindElement(By.XPath("//div[@class='bx-finder-company-department-employee-name' " +
                            "and Contains(text(),'" + s + "')]")).Click();
                }
            }
            else
            {
                Driver.Get().FindElement(By.XPath("//div[@class='bx-finder-company-department-employee-name' " +
                        "and Contains(text(),'" + list + "')]")).Click();
            }
        }

        public void selectColor(string color)
        {
            Color color1 = Color.FromName(color);
            string colorAsHex = ColorTranslator.ToHtml(Color.FromArgb(color1.ToArgb()));
            otherColor.Click();
            customColor.Click();
            colorCode.SendKeys(colorAsHex + Keys.Enter);
        }

        string eventLocatorFinder(string event_, string date)
        {
            string[] array = date.Split("/");
            int year = Int32.Parse(array[2]);
            int month = Int32.Parse(array[0]);
            int day = Int32.Parse(array[1]);
            string locator = "//div[@data-bx-calendar-list-year='"
                    + year + "']/div[@data-bx-calendar-list-month='" + month + "']/div[@data-bx-calendar-list-day='"
                    + day + "']//span[@class='calendar-timeline-stream-content-event-name-link' and text()='"
                    + event_ + "']";
            return locator;
        }
        
        public IWebElement eventColor(string event_, string date)
        {
            IWebElement colorLocator;
            try
            {
                colorLocator = Driver.Get().FindElement(By.XPath(eventLocatorFinder(event_, date)));
            }
            catch (Exception e)
            {
                colorLocator = Driver.Get().FindElement(By.XPath(eventLocatorFinder(editedEventName, date)));
            }
            return colorLocator;
        }

        public bool checkEvents(string event_, string date)
        {
            IList<IWebElement> webElements = Driver.Get().FindElements(By.XPath(eventLocatorFinder(event_, date)));
            return webElements.Count > 0;
        }

        public void eventHandler(string event_, string date)
        {

            IList<IWebElement> list = Driver.Get().FindElements(By.XPath(eventLocatorFinder(event_, date)));
            if (list.Count > 0)
            {
                foreach (IWebElement webElement in list)
                {
                    webElement.Click();
                    delete.Click();
                    Driver.Get().SwitchTo().Alert().Accept();
                }
            }
            IList<IWebElement> editedEvents = Driver.Get().FindElements(By.XPath(eventLocatorFinder(editedEventName, date)));
            if (editedEvents.Count > 0)
            {
                foreach (IWebElement editedEvent in editedEvents)
                {
                    editedEvent.Click();
                    delete.Click();
                    Driver.Get().SwitchTo().Alert().Accept();
                }
            }
        }

        public IWebElement findEvent(string event_, string date)
        {
            IWebElement eventLocator;
            try
            {
                eventLocator = Driver.Get().FindElement(By.XPath(eventLocatorFinder(event_, date)));
            }
            catch (Exception e)
            {
                eventLocator = Driver.Get().FindElement(By.XPath(eventLocatorFinder(editedEventName, date)));
            }
            return eventLocator;
        }
    }
}
