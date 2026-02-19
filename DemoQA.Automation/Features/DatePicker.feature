Feature: Date Picker functionality

  Scenario: Select specific date
    Given User navigates to Date Picker page
    When User selects day 15
    Then Selected date should be displayed
