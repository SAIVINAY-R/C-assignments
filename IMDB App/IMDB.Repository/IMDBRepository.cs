using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository.Interfaces;

namespace IMDB.Repository
{
    public class IMDBRepository : IIMDBRepository
    {
        private readonly List<Movie> _movies = new List<Movie>();
        private readonly List<Actor> _actors = new List<Actor>();
        private readonly List<Producer> _producers = new List<Producer>();
        public Actor AddActor(Actor actor)
        {
            _actors.Add(actor);
            return actor;
        }

        public Movie AddMovie(Movie movie)
        {
            _movies.Add(movie);
            return movie;
        }

        public Producer AddProducer(Producer producer)
        {
            _producers.Add(producer);
            return producer;
        }

        public Movie DeleteMovie(Movie movie)
        {
            _movies.RemoveAll(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year);
            return movie;
        }
        

        public List<Actor> GetActors()
        {
            return _actors;
        }

        public List<Producer> GetProducerList()
        {
            return _producers;
        }

        public List<Movie> ListMovies()
        {
            return _movies;
        }
    }
}
