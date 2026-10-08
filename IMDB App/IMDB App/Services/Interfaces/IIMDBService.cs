using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;

namespace IMDB_App.Services.Interfaces
{
    internal interface IIMDBService
    {
        public List<Movie> ListMovies();
        public Movie AddMovie(string name, int year, string plot, string[] actorID, int producerID);
        public Movie DeleteMovie(int movieID);
        public Actor AddActor(string name, string DOB);
        public Producer AddProducer(string name, string DOB);
        public List<Actor> GetActors();
        public List<Producer> GetProducerList();
    }
}
