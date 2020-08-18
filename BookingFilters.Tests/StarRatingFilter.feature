Feature: Star Rating Filter
    In order to find accommodation at a certain standard
    As a user booking accommodation
    I would like to only see results with a given star rating

Scenario: Filter accommodation by star rating
    Given I am on the booking.com website
    And I select a destination
    And I select a check in date
    And I select a check out date
    And I submit my booking details
    When I filter the results by a star rating of 3 stars
    Then My results contain only 3 star hotels 
    