Feature: GetMostPopularItem
		 In order to get the most popular item
		 As a Restaurant Manager


Scenario: When the OrdersList is not empty
	Given I am a manager
	When the order list is not empty and selected get most popular item
	Then the result should be '203 Ok'

Scenario: When the OrdersList is empty
	Given I am a manager
	When the order list is empty and selected get most popular item
	Then the result should be '203 Error'