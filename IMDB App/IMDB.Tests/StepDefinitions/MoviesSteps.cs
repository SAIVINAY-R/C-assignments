using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB_App.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace IMDB.Tests.StepDefinitions
{
    [Binding]
    internal class MoviesSteps
    {
        private IMDB_App.Services.Interfaces.IMDBService _imdbService;
        private string _name, _plot;
        private int _year, _producerID;
        private string[] _actorIDs;
        private List<Movie> _movies;
        private Exception _exception;

        public MoviesSteps()
        {
            _imdbService = new IMDBService();
        }

        [Given(@"I have movies")]
        public void GivenIHaveMovies()
        {
        }

        [Given(@"I don't have movies")]
        public void GivenIDontHaveMovies()
        {
        }

        [When(@"I fetch the movies")]
        public void WhenIFetchTheMovies()
        {
            _movies = _imdbService.GetMovies();
        }

        [Then(@"List of movies should be like")]
        public void ThenListOfMoviesShouldBeLike(Table table)
        {
            var movies = _imdbService.GetMovies();
            
        }

        [Then(@"get movies method should return null")]
        public void ThenGetMoviesMethodShouldReturnNull()
        {
            Assert.Null(_movies);
        }

        [Given(@"A movie with")]
        public void GivenAMovieWith(Table table)
        {
            _name = table.Rows[0]["name"];
            _year = int.Parse(table.Rows[0]["year"]);
            _plot = table.Rows[0]["plot"];
            _actorIDs = table.Rows[0]["actors"].Split();
            _producerID = int.Parse(table.Rows[0]["producer"]);
        }

        [When(@"I tries to add movie to the list of movies")]
        public void WhenITriesToAddMovieToTheListOfMovies()
        {
            try
            {
                _imdbService.AddMovie(_name, _year, _plot, _actorIDs, _producerID);
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Given(@"A movie with Name: '([^']*)' Year: '([^']*)' Plot: '([^']*)' Actors: '([^']*)' and Producer: '([^']*)'")]
        public void GivenAMovieWithNameYearPlotActorsAndProducer(string testName, string p1, string p2, string p3, string p4)
        {
            _name = testName;
            _year = int.Parse(p1);
            _plot = p2;
            _actorIDs = p3.Split();
            _producerID = int.Parse(p4);
        }

        [Then(@"I should have an error ""([^""]*)""")]
        public void ThenIShouldHaveAnError(string message)
        {
            Assert.Equal(message, _exception.Message);
        }


        [BeforeScenario("addMovie", "listMovies")]
        public void AddSampleMovies()
        {
            string[] actors = { "1" };
            _imdbService.AddActor("actor1", "01/09/2000");
            _imdbService.AddActor("actor2", "01/09/2000");
            _imdbService.AddProducer("producer1", "01/09/2000");
            _imdbService.AddProducer("producer2", "01/09/2000");
            _imdbService.AddMovie("movie1", 2000, "movie1 plot", actors, 1);
            _imdbService.AddMovie("movie2", 2000, "Movie1 plot", actors, 1);
        }
    }
}
