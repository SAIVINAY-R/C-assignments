Feature: Placing an Order
		 In order to place an order
		 As a customer of the Resturant

Scenario: When items are available
	Given I am a 'customer'
	And Customer selects an item
	When the items are available
	Then the result should be 'Order Placed'

Scenario: When no item is available
	Given I am a 'customer'
	When items are not available
	Then the result should be 'No items to order'
