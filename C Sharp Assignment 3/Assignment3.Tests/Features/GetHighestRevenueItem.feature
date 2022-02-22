Feature: GetHighestRevenueItem
		 In order to get the item with highest revenue
		 As a Restaurant Manager


Scenario: When the OrdersList is not empty
	Given I am a manager
	When the order list is not empty and selected the Get the item with highest revenu
	Then the result should be '204 Ok'

Scenario: When the OrdersList is empty
	Given I am a manager
	When the order list is empty and selected the Get the item with highest revenu
	Then the result should be '204 Error'
