using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_App;
using IMDB_App.Services;

namespace IMDB.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "ListMovie")]
    internal class ListMoviesSteps
    {
        IMDBService iMDBService;
        dynamic result;
        [Given(@"what do want to do '([^']*)'")]
        public void GivenWhatDoWantToDo(string p0)
        {
            iMDBService = new IMDBService();
            iMDBService.AddProducer("testProducer", "01/01/1000");
            iMDBService.AddActor("testActor", "01/01/1001");
        }

        [When(@"movies list is not empty")]
        public void WhenMoviesListIsNotEmpty()
        {
            var temp = iMDBService.AddMovie(
                "testName",
                2000,
                "testplot",
                "1".Split(),
                1
                );
            result = iMDBService.ListMovies();
        }

        [Then(@"the result should be '([^']*)'")]
        public void ThenTheResultShouldBe(string p0)
        {
            if (p0 == "Null")
            {
                Assert.Null(result);
            }
            else
            {
                Assert.NotNull(result);
            }
        }

        [When(@"movies list is empty")]
        public void WhenMoviesListIsEmpty()
        {
            result = iMDBService.ListMovies();
        }

    }
}
