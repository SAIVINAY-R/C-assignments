Feature: GetItemsBelowThePrice
		 In order to get the items below the paticular price
		 As a Restaurant Manager

Scenario: When their is no item below the given price
	Given I am a manager
	When their is no item below the given price '1'
	Then the result should be '205 Error'

Scenario: When items below the given price are their
	Given I am a manager
	When their are items below the given price '30'
	Then the result should be '205 Ok'
