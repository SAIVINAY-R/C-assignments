Feature: GetItemsBelowThePrice
		 In order to get the items below the paticular price
		 As a Restaurant Manager

Scenario: When their is no item below the given price
	Given I am a 'manager'
	And I select the 'Get items below the price' 
	And Enter the price 
	When their is no item below the given price
	Then the result should be No Item below the given price

Scenario: When items below the given price are their
	Given I am a 'manager'
	And I select the 'Get items below the price' 
	And Enter the price
	When items below the given price are their
	Then the result should be Items below the given price
