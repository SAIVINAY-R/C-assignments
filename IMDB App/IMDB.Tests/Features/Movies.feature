Feature: Movies
		 In order to perform operations on movies

@listMovies
Scenario: Movies List is not Empty
	Given I want to see the movies
	Then List of movies should be like
	| name   | year | plot        | actorIDs | producerID |
	| movie1 | 2000 | movie1 plot | 1        | 1          |
	| movie2 | 1998 | Movie2 plot | 1        | 1          |

Scenario: Movies List is Empty
	Given I want to see the movies
	Then List of movies should be like
	| name   | year | plot        | actorIDs | producerID |

@addMovie
Scenario: user adds movie with valid data
	Given the inputs are Name: '<name>' Year: '<year>' Plot: '<plot>' Actors: '<actors>' and Producer: '<producer>'
	When I add the movie
	Then List of movies should be like
	| name   | year   | plot        | actorIDs | producerID |
	| movie1 | 2000   | movie1 plot | 1        | 1          |
	| movie2 | 1998   | Movie2 plot | 1        | 1          |
	| <name> | <year> | <plot>      | <actors> | <producer> |
	Examples: 
	| name     | year | plot                | actors | producer |
	| testName | 2000 | This is a test plot | 1,2    | 1        |
	| testName | 2000 | This is a test plot | 1      | 1        |

@addMovie
Scenario: user adds an existing movie
	Given the inputs are Name: '<name>' Year: '<year>' Plot: '<plot>' Actors: '<actors>' and Producer: '<producer>'
	When I add the movie
	Then List of movies should be like
	| name   | year   | plot        | actorIDs | producerID |
	| movie1 | 2000   | movie1 plot | 1        | 1          |
	| movie2 | 1998   | Movie2 plot | 1        | 1          |
	Examples: 
	| name   | year | plot        | actors | producer |
	| movie1 | 2000 | movie1 plot | 1      | 1        |

@addMovie
Scenario: user adds a movie with invalid data
	Given the inputs are Name: '<name>' Year: '<year>' Plot: '<plot>' Actors: '<actors>' and Producer: '<producer>'
	When I add the movie
	Then I should have an error "Invalid arguments"
	And List of movies should be like
	| name   | year   | plot        | actorIDs | producerID |
	| movie1 | 2000   | movie1 plot | 1        | 1          |
	| movie2 | 1998   | Movie2 plot | 1        | 1          |
	Examples: 
	| name     | year | plot     | actors | producer |
	| testName | 2000 |          | 1      | 1        |
	|          | 2000 | testPlot | 1      | 1        |
	|          | 2000 |          | 1      | 1        |
	| testName | 1    | testPlot | 1      | 1        |
	| testName | 2000 | testPlot | -1     | 1        |
	| testName | 2000 | testPlot | 1      | -1       |