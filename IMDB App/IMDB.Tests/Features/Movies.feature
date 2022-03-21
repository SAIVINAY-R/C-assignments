Feature: Movies
		 In order to display list og movies
		 When user selects List Movies Option

@listMovies
Scenario: When Movies List is not Empty
	Given I have movies
	When I fetch the movies
	Then List of movies should be like
	| name   | year | plot        | actorIDs | producerID |
	| movie1 | 2000 | movie1 plot | 1        | 1          |
	| movie2 | 1998 | Movie2 plot | 1        | 1          |

Scenario: When Movies List is Empty
	Given I don't have movies
	When I fetch the movies
	Then get movies method should return null

@addMovie
Scenario: When user tries to add new movie by giving valid fields
	Given A movie with
	| name     | year | plot                | actors | producer |
	| testName | 2000 | This is a test plot | 1      | 1        |
	When I tries to add movie to the list of movies
	Then List of movies should be like
	| name     | year | plot                | actorIDs | producerID |
	| movie1   | 2000 | movie1 plot         | 1        | 1          |
	| movie2   | 1998 | Movie2 plot         | 1        | 1          |
	| testName | 2000 | This is a test plot | 1        | 1          |

@addMovie
Scenario: When user tries to add already existing movie by giving valid fields
	Given A movie with 
	| name   | year | plot        | actors | producer |
	| movie1 | 2000 | movie1 plot | 1      | 1        |
	When I tries to add movie to the list of movies
	Then List of movies should be like
	| name   | year | plot        | actorIDs | producerID |
	| movie1 | 2000 | movie1 plot | 1        | 1          |
	| movie2 | 1998 | Movie2 plot | 1        | 1          |

@addMovie
Scenario: When user tries to add movie without giving valid input
	Given A movie with Name: '<name>' Year: '<year>' Plot: '<plot>' Actors: '<actors>' and Producer: '<producer>'
	When I tries to add movie to the list of movies
	Then I should have an error "Invalid arguments"
	And List of movies should be like
	| name   | year | plot        | actorIDs | producerID |
	| movie1 | 2000 | movie1 plot | 1        | 1          |
	| movie2 | 1998 | Movie2 plot | 1        | 1          |
	Examples: 
	| name     | year | plot     | actors | producer |
	| testName | 2000 |          | 1      | 1        |
	|          | 2000 | testPlot | 1      | 1        |
	|          | 2000 |          | 1      | 1        |
	| testName | 1    | testPlot | 1      | 1        |