Feature: AddItemToMenu
		 In to Add Item to Menu
		 As a Restaurant Manager

Scenario: Adding new item to menu
	Given I am a 'manager'
	When I select the 'Add Item To Menu' Query
	And Enter new item name and price
	Then the result should be New Item added to the Menu

Scenario: Adding already existing item
	Given I am a 'manager'
	When I select the 'Add Item To Menu' Query
	And Enter already existing item name and price
	Then the result should be Item already exists