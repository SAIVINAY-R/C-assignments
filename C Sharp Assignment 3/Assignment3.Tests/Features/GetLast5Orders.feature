Feature: GetLast5Orders
		 In order to get the last 5 orders
		 As a Restaurant Manager


Scenario: Get Last 5 Orders When the OrdersList is not empty
	Given the user type '2'
	When the input is '2'
	Then the result should be last 5 orders

Scenario: Get Last 5 Orders When the OrdersList is empty
	Given the user type '2'
	When the input is '2'
	Then the result should be Order History is Empty
