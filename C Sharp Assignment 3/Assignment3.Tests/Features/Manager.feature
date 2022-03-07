Feature: Manager
		 In order to Add new Item to Menu, 
					 Get Last 5 orders,
					 Get most popular item,
					 Get highest revenue item,
					 Get items below the price
		 As a Restaurant Manager

Scenario: Adding new item to menu
	Given I am a manager
	When I select the Add Item To Menu and Enter item name 'Chapathi' and price '35'
	Then the result should be true

Scenario: Adding already existing item
	Given I am a manager
	When I select the Add Item To Menu and Enter item name 'Dosa' and price '20'
	Then the result should be false

Scenario: Get last 5 orders When the OrdersList is not empty
	Given I am a manager
	When the order list is not empty and selected Get Last five Orders
	Then the result should be 'list of last 5 orders'

Scenario: Get last 5 orders When the OrdersList is empty
	Given I am a manager
	When the order list is empty and selected Get Last five Orders
	Then the result should be 'empty list'

Scenario: Get most popular item When the OrdersList is not empty
	Given I am a manager
	When the order list is not empty and selected get most popular item
	Then the result should be 'most popular item'

Scenario: Get most popular item When the OrdersList is empty
	Given I am a manager
	When the order list is empty and selected get most popular item
	Then the result should be 'No past orders in the Order History'

Scenario: Get highest revenue item When the OrdersList is not empty
	Given I am a manager
	When the order list is not empty and selected the Get the item with highest revenu
	Then the result should be 'highest revenue item'

Scenario: Get highest revenue item When the OrdersList is empty
	Given I am a manager
	When the order list is empty and selected the Get the item with highest revenu
	Then the result should be 'No past orders in the Order History'

Scenario: Get items below the price When their is no item below the given price
	Given I am a manager
	When their is no item below the given price '1'
	Then the result should be 'empty list'

Scenario: Get items below the price When items below the given price are their
	Given I am a manager
	When their are items below the given price '30'
	Then the result should be 'list of items below the given price'