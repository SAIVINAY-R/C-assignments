using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository.Interfaces;

namespace IMDB.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = new List<Movie>();
        public Movie AddMovie(Movie movie)
        {
            _movies.Add(movie);
            return movie;
        }

        public Movie DeleteMovie(Movie movie)
        {
            _movies.RemoveAll(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year);
            return movie;
        }

        public List<Movie> ListMovies()
        {
            return _movies;
        }
    }
}
