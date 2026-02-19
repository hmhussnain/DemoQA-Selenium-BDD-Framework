Feature: Web Tables functionality

  Scenario: Add new record
    Given User navigates to Web Tables page
    When User adds a new record
    Then Record should appear in table

  Scenario: Edit record
    Given User navigates to Web Tables page
    When User edits first record
    Then Record should be updated

  Scenario: Delete record
    Given User navigates to Web Tables page
    When User deletes first record
    Then Record should be removed