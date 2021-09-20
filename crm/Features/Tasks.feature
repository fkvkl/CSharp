Feature: As a user, I should be able to use Tasks function on Activity Stream

  Scenario: Verify that user can be able to display tasks "In progress" by clicking "All" tab
    Given User enters username and password and clicks login button.
    When user clicks "Tasks" menu
    And user clicks "All" tab
    Then User should be able to display tasks "In progress"

  Scenario: Verify that user can be able to display tasks "Ongoing" by clicking "Ongoing " tab
    Given User enters username and password and clicks login button.
    When user clicks "Tasks" menu
    And user clicks "Ongoing" tab
    Then User should be able to display tasks "Ongoing"
