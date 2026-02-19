Feature: Forms functionality

  Scenario: Submit form with valid data
    Given User navigates to Forms page
    When User fills form with valid data
    And User submits the form
    Then Success modal should be displayed

  Scenario: Submit form with invalid email
    Given User navigates to Forms page
    When User fills form with invalid email
    And User submits the form
    Then Email validation error should be displayed