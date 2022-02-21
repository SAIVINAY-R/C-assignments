Feature: GetMostPopularItem
		 In order to get the most popular item
		 As a Restaurant Manager


Scenario: When the OrdersList is not empty
	Given I am a 'manager'
	And I select the 'Get the most popular item' Query
	When the order list is not empty
	Then the result should be Most Popular Item

Scenario: When the OrdersList is empty
	Given I am a 'manager'
	And I select the 'Get the most popular item' Query
	When the order list is empty
	Then the result should be Order History is Empty