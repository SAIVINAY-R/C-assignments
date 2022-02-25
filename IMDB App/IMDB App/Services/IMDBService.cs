using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository;
using IMDB.Repository.Interfaces;
using IMDB_App.Services.Interfaces;

namespace IMDB_App.Services
{
    public class IMDBService : IIMDBService
    {
        private readonly IIMDBRepository _iMDBRepository;
        public IMDBService()
        {
                _iMDBRepository = new IMDBRepository();
        }

        public Actor AddActor(string name, string DOB)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(DOB))
            {
                throw new ArgumentNullException("Invalid arguments");
            }
            Actor actor = new Actor() { Name = name , DOB = DateOnly.ParseExact(DOB, "dd/MM/yyyy") };
            List<Actor> Actors = _iMDBRepository.GetActors();
            if (Actors.FindAll(a => a.Name == actor.Name && a.DOB == actor.DOB).Count != 0 || actor == null)
            {
                return null;
            }
            return _iMDBRepository.AddActor(actor);
        }

        public Movie AddMovie(string name, int year, string plot, string[] actorID, int producerID)
        {
            List<Actor> Actors = _iMDBRepository.GetActors();
            List<string> actorsList = new();
            foreach (var id in actorID)
            {
                var actor = Actors.ElementAt(int.Parse(id) - 1).Name;
                actorsList.Add(actor);
            }
            var Producers = _iMDBRepository.GetProducerList();
            var producerName = Producers.ElementAt(producerID - 1).Name;
            var movie = new Movie() { Name = name, Year = year, Plot = plot, Actors = actorsList, Producer = producerName };
            if (movie.Actors == null ||
                String.IsNullOrEmpty(movie.Name) ||
                String.IsNullOrEmpty(movie.Plot) ||
                movie.Producer == null ||
                movie.Year > 9999 || movie.Year < 1000)
            {
                return null;
            }
            var Movies = _iMDBRepository.ListMovies();
            if (Movies.FindAll(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year).Count != 0)
            {
                return null;
            }
            return _iMDBRepository.AddMovie(movie);
        }

        public Producer AddProducer(string name, string DOB)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(DOB))
            {
                throw new ArgumentNullException("Invalid arguments");
            }
            Producer producer = new Producer() { Name = name, DOB = DateOnly.ParseExact(DOB, "dd/MM/yyyy") };
            List<Producer> Producers = _iMDBRepository.GetProducerList();
            if (Producers.FindAll(a => a.Name == producer.Name && a.DOB == producer.DOB).Count != 0 || producer == null)
            {
                return null;
            }
            return _iMDBRepository.AddProducer(producer);
        }

        public Movie DeleteMovie(int movieID)
        {
            var Movies = _iMDBRepository.ListMovies();
            var movie = Movies.ElementAt(movieID);
            if (Movies.FindAll(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year).Count == 0)
            {
                return null;
            }
            return _iMDBRepository.DeleteMovie(movie);
        }

        public List<Actor> GetActors()
        {
            return _iMDBRepository.GetActors(); 
        }

        public List<Producer> GetProducerList()
        {
            return _iMDBRepository.GetProducerList();
        }

        public List<Movie> ListMovies()
        {
            var list = _iMDBRepository.ListMovies();
            if (list.Count == 0)
            {
                return null;
            }
            return list;
        }
    }
}
