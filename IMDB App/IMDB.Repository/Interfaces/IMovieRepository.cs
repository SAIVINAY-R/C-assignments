using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;

namespace IMDB.Repository.Interfaces
{
    public interface IMovieRepository
    {
        public List<Movie> ListMovies();
        public Movie AddMovie(Movie movie);
        public Movie DeleteMovie(Movie movie);
    }
}
