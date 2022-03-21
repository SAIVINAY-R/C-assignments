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

        [When(@"I add the movie")]
        public void WhenIAddTheMovie()
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

        [Given(@"I want to see the movies")]
        public void GivenIWantToSeeTheMovies()
        {
        }


        [Given(@"the inputs are Name: '([^']*)' Year: '([^']*)' Plot: '([^']*)' Actors: '([^']*)' and Producer: '([^']*)'")]
        public void GivenTheInputsAreNameYearPlotActorsAndProducer(string p0, string p1, string p2, string p3, string p4)
        {
            _name = p0;
            _year = int.Parse(p1);
            _plot = p2;
            _actorIDs = p3.Split(",");
            _producerID = int.Parse(p4);
        }


        [Then(@"List of movies should be like")]
        public void ThenListOfMoviesShouldBeLike(Table table)
        {
            var movies = _imdbService.GetMovies();
            foreach (var row in table.Rows)
            {
                var actorIDs = row["actorIDs"].Split(",");
                List<int> actorsList = new();
                foreach (var id in actorIDs)
                {
                    var actorID = int.Parse(id);
                    actorsList.Add(actorID);
                }
                Assert.Contains(movies, 
                   b => b.Name == row["name"] && b.Year == int.Parse(row["year"]) &&
                    b.Plot == row["plot"] && b.ProducerID == int.Parse(row["producerID"]) &&
                    b.ActorIDs.SequenceEqual(actorsList.ToArray())
                    );
            }
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
            _imdbService.AddMovie("movie2", 1998, "Movie2 plot", actors, 1);
        }
    }
}
