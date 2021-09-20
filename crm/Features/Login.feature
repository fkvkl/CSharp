Feature: Login
@mytag
Scenario: User logins with valid credentials
	Given User navigates to login page.
	When User enters username and password and clicks login button.
	Then User should be able land on the home page and page title should contain "Portal".