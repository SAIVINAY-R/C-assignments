Feature: GetHighestRevenueItem
		 In order to get the item with highest revenue
		 As a Restaurant Manager


Scenario: When the OrdersList is not empty
	Given I am a 'manager'
	And I select the 'Get the item with highest revenue' Query
	When the order list is not empty
	Then the result should be Item with highest revenue

Scenario: When the OrdersList is empty
	Given I am a 'manager'
	And I select the 'Get the item with highest revenue' Query
	When the order list is empty
	Then the result should be Order History is Empty
