Feature: As a user, I should be able to navigate "Calendar" page so that user can filter and search, display, add and track
	the tasks or events on "Calendar" page.

Scenario: Verify that HR User should be able to add new important event with description by specifying the start-end dates in the specific time zones, adding certain location, adding attendees, color as "Pink" and availability as "Occupied"
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks add and enters the below event details
		| Details                 |       |
		| Event name              | ***** |
		| Description             | ***** |
		| This event is important | ***** |
		| Event date              | ***** |
		| Event end date          | ***** |
		| Time zone               | ***** |
		| Location                | ***** |
		| Attendees               | ***** |
		| Event color             | ***** |
		| Availability            | ***** |
	Then user should be able to add event by clicking SAVE button and display event on calendar

Scenario: Verify that HR User should be able to edit the 1st AC's task color as "Navy" by using "other color".
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks event and selects edit
	Then user should be able to change event color as "Navy"

Scenario: Verify that HR user should be able to edit the 1st AC's privacy as "Private event".
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks event and selects edit
	Then user should be able to change privacy as "Private Event"

Scenario: Verify that Marketing user should not be able to display the 3rd AC's private event on his/her calendar.
	Given User logins with "Marketing" credentials
	And user clicks "Calendar" menu
	When user clicks Schedule
	Then user should not be able to display HR user's event on his-her calendar

Scenario: Verify that HR user should be able to edit his/her availability from "Occupied" to "Unsure".
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks event and selects edit
	Then user should be able to change his-her availability as "Unsure"

Scenario: Verify that HR user should be able to edit his/her event's name.
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks event and selects edit
	Then user should be able to change his-her event's name as "****"

Scenario: Verify that HR user should be able to delete attendee by editing the event.
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks event and selects edit
	Then user should be able to delete an attendee

Scenario: Verify that HR user should be able to add one more attendee by editing the event.
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks event and selects edit
	Then user should be able to add one more attendee("*****") by editing the event

Scenario: Verify that Marketing User should be able to display the invitations by using "Filter and search" box after clicking "Invitations" button.
	Given  User logins with "Marketing" credentials
	And user clicks "Calendar" menu
	When user clicks Filter and search and clicks Invitations
	Then user should be able to display "Invitations"

Scenario: Verify that HR User should be able to filter events and/or tasks by using "Filter and search" box after clicking "I'M AN ORGANISER" button.
	Given  User logins with "HR" credentials
	And user clicks "Calendar" menu
	When user clicks Filter and search and clicks I'M AN ORGANIZER
	Then user should be able to display "I'm an organiser"

Scenario: Verify that Helpdesk User should be able to reset after selecting "Yes" under "Event with participants" menu and "Invited" under "Participant status".
	Given  User logins with "Helpdesk" credentials
	And user clicks "Calendar" menu
	When user clicks Filter and search
	And user selects Yes under Event with participants, Invited under Participation status and click reset
	Then user should be able to reset user input fields to "Not specified"