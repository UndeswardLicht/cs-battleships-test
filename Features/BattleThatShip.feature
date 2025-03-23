Feature: Playing the battleships

Background: 
	When I continue to the site even though it doesn't have secure connection
	Then The site main page is displayed

Scenario: Playing the battleships and win
	When I randomly select the battleships position
	And I select a random person to play with 
	And I click Play button
	And I wait for the other person to join
	And I use the algorithm to play the battle
	Then I win