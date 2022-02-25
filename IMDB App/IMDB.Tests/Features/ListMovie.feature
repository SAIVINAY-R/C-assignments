Feature: ListMovie
		 In order to display list og movies
		 When user selects List Movies Option

Scenario: When Movies List is not Empty
	Given what do want to do '1'
	When movies list is not empty
	Then the result should be 'ListofMovies'

Scenario: When Movies List is Empty
	Given what do want to do '1'
	When movies list is empty
	Then the result should be 'null'
