Feature: Placing an Order
		 In order to place an order
		 As a customer of the Resturant

Scenario: Ordering when items are available
	Given the user type '1'
	When the item is selected
	Then the result should be 'Order Placed'

Scenario: Ordering when no item is available
	Given the user type '1'
	Then the result should be 'No items to order'
