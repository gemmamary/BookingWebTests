Feature: Star Rating Filter
    In order to find accommodation at a certain standard
    As a user booking accommodation
    I would like to only see results with a given star rating

Scenario Outline: Filter results by star rating
    Given I am on the booking.com website
    And I select the destination Dublin
    And I select a check in date
    And I select a check out date
    And I submit my booking details
    When I filter the results by a star rating of <starRating> stars
    Then My results contain only <starRating> star accommodation 

    Examples: 
        | starRating |
        | 1          |
        | 2          |
        | 3          |
        | 4          |
        | 5          |

Scenario: Filter results by unrated accommodation
    Given I am on the booking.com website
    And I select the destination Dublin
    And I select a check in date
    And I select a check out date
    And I submit my booking details
    When I filter the results by unrated accommodation
    Then My results contain only unrated accommodation
    