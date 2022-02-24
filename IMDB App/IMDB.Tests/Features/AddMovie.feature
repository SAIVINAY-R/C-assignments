Feature: AddMovie
		 In order to add movie to List of movies
		 When user selects Add Movie option

Scenario: When user tries to add movie by giving all fields
	Given what do want to do '2'
	When user provieds all the fields
	Then the result should be movie added to list - 'success'

Scenario: When user tries to add movie without giving all fields
	Given what do want to do '2'
	When user provieds all the fields
	Then the result should be movie added to list - 'failed'