Feature: AddMovie
		 In order to add movie to List of movies
		 When user selects Add Movie option

Scenario: When user tries to add new movie by giving valid fields
	Given what do want to do '2'
	When user provieds all the fields 
	| name     | year | plot                | actors | producer |
	| testName | 1000 | This is a test plot | 1      | 1        |
	Then the result should be 'new movie'

Scenario: When user tries to add already existing movie by giving valid fields
	Given what do want to do '2'
	When user provieds all the fields 
	| name      | year | plot     | actors | producer |
	| testName1 | 1000 | testPlot | 1      | 1        |
	Then the result should be 'Null'

Scenario: When user tries to add movie without giving valid input
	Given what do want to do '2'
	When user provieds all the fields Name: '<name>' Year: '<year>' Plot: '<plot>' Actors: '<actors>' and Producer: '<producer>'
	Then the result should be 'Null'
	Examples: 
	| name     | year | plot     | actors | producer |
	| testName | 1000 |          | 1      | 1        |
	| testName |      | testPlot | 1      | 1        |
	|          | 1000 | testPlot | 1      | 1        |
