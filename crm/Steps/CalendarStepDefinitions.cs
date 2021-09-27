using Crm.Drivers;
using Crm.Pages;
using Crm.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using static Crm.BrowserUtils;

namespace Crm.Steps
{
    [Binding]
    public sealed class CalendarStepDefinitions
    {
        private readonly IWebDriver driver;
        public CalendarStepDefinitions() => driver = Driver.Get();

        string user = null;
        CalendarPage calendarPage = new CalendarPage(Driver.Get());
        string event_name = "";
        string event_date = "";

        [Given(@"User logins with ""(.*)"" credentials")]
        public void GivenUserLoginsWithCredentials(string p0)
        {
            driver.Navigate().GoToUrl(Resources.Url);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.login();
        }
     

        [Given(@"user clicks ""(.*)"" menu")]
        public void GivenUserClicksMenu(string menu)
        {
            new HomePage(driver).navigateToMenu(menu);
            BrowserUtils.waitForPageToLoad(5);
        }

        [When(@"user clicks add and enters the below event details")]
        public void WhenUserClicksAddAndEntersTheBelowEventDetails(Table table)
        {
            var data = TableToDictionary(table);
            event_name = data["Event name"];
            event_date = data["Event date"];
            calendarPage.eventHandler(event_name, event_date);
            calendarPage.add.Click();
            BrowserUtils.waitForPageToLoad(5);
            if (bool.Parse(data["This event is important"]))
            {
                calendarPage.importance.Click();
            }
            calendarPage.eventName.Clear();
            calendarPage.eventName.SendKeys(event_name);
            calendarPage.dateFrom.Clear();
            calendarPage.dateFrom.SendKeys(data["Event date"]);
            calendarPage.dateTo.Clear();
            calendarPage.dateTo.SendKeys(data["Event end date"]);
            calendarPage.timeZone.Click();
            var select = new SelectElement(calendarPage.timeZoneFrom);
            select.SelectByText(data["Time zone"]);
            calendarPage.location.Click();
            calendarPage.location.SendKeys(data["Location"]);
            calendarPage.addAttendees(data["Attendees"]);
            BrowserUtils.waitForPageToLoad(10);
            calendarPage.more.Click();
            calendarPage.eventDescription(data["Description"]);
            BrowserUtils.waitForPageToLoad(10);
            calendarPage.selectColor(data["Event color"]);
            var selectAvailability = new SelectElement(calendarPage.availability);
            selectAvailability.SelectByText(data["Availability"]);
        }



        [When(@"user enters the below event details")]
        public void WhenUserEntersTheBelowEventDetails(Table table)
        {
            //
        }

        [Then(@"user should be able to add event by clicking SAVE button and display event on calendar")]
        public void ThenUserShouldBeAbleToAddEventByClickingSAVEButtonAndDisplayEventOnCalendar()
        {
            //
        }

        [When(@"user clicks event and selects edit")]
        public void WhenUserClicksEventAndSelectsEdit()
        {
            //
        }

        [Then(@"user should be able to change event color as ""(.*)""")]
        public void ThenUserShouldBeAbleToChangeEventColorAs(string p0)
        {
            //
        }

        [Then(@"user should be able to change privacy as ""(.*)""")]
        public void ThenUserShouldBeAbleToChangePrivacyAs(string p0)
        {
            //
        }

        [When(@"user clicks Schedule")]
        public void WhenUserClicksSchedule()
        {
            //
        }

        [Then(@"user should not be able to display HR user's event on his-her calendar")]
        public void ThenUserShouldNotBeAbleToDisplayHRUserSEventOnHis_HerCalendar()
        {
            //
        }

        [Then(@"user should be able to change his-her availability as ""(.*)""")]
        public void ThenUserShouldBeAbleToChangeHis_HerAvailabilityAs(string p0)
        {
            //
        }

        [Then(@"user should be able to change his-her event's name as ""(.*)""")]
        public void ThenUserShouldBeAbleToChangeHis_HerEventSNameAs(string p0)
        {
            //
        }

        [Then(@"user should be able to delete an attendee")]
        public void ThenUserShouldBeAbleToDeleteAnAttendee()
        {
           //
        }

        [Then(@"user should be able to add one more attendee\(""(.*)""\) by editing the event")]
        public void ThenUserShouldBeAbleToAddOneMoreAttendeeByEditingTheEvent(string p0)
        {
            //
        }

        [When(@"user clicks Filter and search and clicks Invitations")]
        public void WhenUserClicksFilterAndSearchAndClicksInvitations()
        {
            //
        }

        [Then(@"user should be able to display ""(.*)""")]
        public void ThenUserShouldBeAbleToDisplay(string p0)
        {
            //
        }

        [When(@"user clicks Filter and search and clicks I'M AN ORGANIZER")]
        public void WhenUserClicksFilterAndSearchAndClicksIMANORGANIZER()
        {
            //
        }

        [When(@"user clicks Filter and search")]
        public void WhenUserClicksFilterAndSearch()
        {
            //
        }

        [When(@"user selects Yes under Event with participants, Invited under Participation status and click reset")]
        public void WhenUserSelectsYesUnderEventWithParticipantsInvitedUnderParticipationStatusAndClickReset()
        {
            //
        }

        [Then(@"user should be able to reset user input fields to ""(.*)""")]
        public void ThenUserShouldBeAbleToResetUserInputFieldsTo(string p0)
        {
            //
        }

    }
}
