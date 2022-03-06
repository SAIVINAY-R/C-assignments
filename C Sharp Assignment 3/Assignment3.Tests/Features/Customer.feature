Feature: Customer
		 In order to place an order
		 As a customer of the Resturant

Scenario: Placing order When items are available and selected valid item
	Given I am a customer
	When the items are available and user selects an item '1'
	Then the result should be '1'

Scenario: Placing order When items are available and selected Invalid item
	Given I am a customer
	When the items are available and user selects an item '3'
	Then the result should be '0'

Scenario: Placing order When no item is available
	Given I am a customer
	When items are not available
	Then the result should be '-1'