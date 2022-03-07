using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_App;
using IMDB_App.Services;
using IMDB.Domain;

namespace IMDB.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "AddMovie")]
    internal class AddMovieSteps
    {
        IMDBService iMDBService;
        dynamic result;
        [Given(@"what do want to do '([^']*)'")]
        public void GivenWhatDoWantToDo(string p0)
        {
            iMDBService = new();
            iMDBService.AddProducer("testProducer", "01/01/1000");
            iMDBService.AddActor("testActor", "01/01/1001");
        }

        [When(@"user provieds all the fields")]
        public void WhenUserProviedsAllTheFields(Table table)
        {
            if (table.Rows[0]["name"] == "testName1")
            {
                result = iMDBService.AddMovie(table.Rows[0]["name"], 
                    int.Parse(table.Rows[0]["year"]), 
                    table.Rows[0]["plot"], 
                    table.Rows[0]["actors"].Split(), 
                    int.Parse(table.Rows[0]["producer"]));
            }
            result = iMDBService.AddMovie(table.Rows[0]["name"], 
                int.Parse(table.Rows[0]["year"]), 
                table.Rows[0]["plot"], 
                table.Rows[0]["actors"].Split(" "), 
                int.Parse(table.Rows[0]["producer"]));
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

        [When(@"user provieds all the fields Name: '([^']*)' Year: '([^']*)' Plot: '([^']*)' Actors: '([^']*)' and Producer: '([^']*)'")]
        public void WhenUserProviedsAllTheFieldsNameYearPlotActorsAndProducer(string testName, string p1, string testPlot, string p3, string p4)
        {
            if (string.IsNullOrEmpty(p1))
            {
                p1 = "1";
            }
            result = iMDBService.AddMovie(
                testName,
                int.Parse(p1),
                testPlot,
                p3.Split(),
                int.Parse(p4)
            );
        }
    }
}
