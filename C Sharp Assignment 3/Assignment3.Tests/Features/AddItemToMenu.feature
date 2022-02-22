Feature: AddItemToMenu
		 In to Add Item to Menu
		 As a Restaurant Manager

Scenario: Adding new item to menu
	Given I am a manager
	When I select the Add Item To Menu and Enter item name 'Chapathi' and price '35'
	Then the result should be true

Scenario: Adding already existing item
	Given I am a manager
	When I select the Add Item To Menu and Enter item name 'Dosa' and price '20'
	Then the result should be false