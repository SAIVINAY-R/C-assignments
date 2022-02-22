Feature: GetLast5Orders
		 In order to get the last 5 orders
		 As a Restaurant Manager


Scenario: When the OrdersList is not empty
	Given I am a manager
	When the order list is not empty and selected Get Last five Orders
	Then the result should be '202 Ok'

Scenario: When the OrdersList is empty
	Given I am a manager
	When the order list is empty and selected Get Last five Orders
	Then the result should be '202 Error'