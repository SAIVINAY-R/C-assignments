using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository;
using IMDB.Repository.Interfaces;

namespace IMDB_App.Services
{
    public class IMDBService : Interfaces.IMDBService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerRepository _producerRepository;
        public IMDBService()
        {
            _movieRepository = new MovieRepository();
            _actorRepository = new ActorRepository();
            _producerRepository = new ProducerRepository();
        }

        public Actor AddActor(string name, string DOB)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(DOB))
            {
                throw new ArgumentNullException("Invalid arguments");
            }
            Actor actor = new Actor() { Name = name , DOB = DateOnly.ParseExact(DOB, "dd/MM/yyyy") };
            List<Actor> Actors = _actorRepository.GetActors();
            if (Actors.FindAll(a => a.Name == actor.Name && a.DOB == actor.DOB).Count != 0 || actor == null)
            {
                return null;
            }
            return _actorRepository.AddActor(actor);
        }

        public Movie AddMovie(string name, int year, string plot, string[] actorID, int producerID)
        {
            List<Actor> Actors = _actorRepository.GetActors();
            List<string> actorsList = new();
            foreach (var id in actorID)
            {
                var actor = Actors.ElementAt(int.Parse(id) - 1).Name;
                if (!actorsList.Contains(actor))
                {
                    actorsList.Add(actor);
                }
            }
            var Producers = _producerRepository.GetProducerList();
            var producerName = Producers.ElementAt(producerID - 1).Name;
            var movie = new Movie() { Name = name, Year = year, Plot = plot, Actors = actorsList, Producer = producerName };
            if (movie.Actors == null)
            {
                Console.WriteLine("Atleast one actor should be present");
                return null;
            }
            if (String.IsNullOrEmpty(movie.Name))
            {
                Console.WriteLine("Movie name is empty");
                return null;
            }
            if (String.IsNullOrEmpty(movie.Plot))
            {
                Console.WriteLine("Movie Plot is empty");
                return null;
            }
            if (movie.Producer == null)
            {
                Console.WriteLine("Movie should have one producer");
                return null;
            } 
            // the first film was released in 1888 so minimum year is 1888
            // maximum upcoming movies release date will be planed for 2 years from current year
            if (movie.Year > (DateTime.Now.Year + 2) || movie.Year < 1888)
            {
                Console.WriteLine("Year should be between {0} and {1}", 1888, (DateTime.Now.Year + 2));
                return null;
            }
            var Movies = _movieRepository.ListMovies();
            if (Movies.FindAll(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year).Count != 0)
            {
                Console.WriteLine("Movie already exists");
                return null;
            }
            return _movieRepository.AddMovie(movie);
        }

        public Producer AddProducer(string name, string DOB)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(DOB))
            {
                throw new ArgumentNullException("Invalid arguments");
            }
            Producer producer = new Producer() { Name = name, DOB = DateOnly.ParseExact(DOB, "dd/MM/yyyy") };
            List<Producer> Producers = _producerRepository.GetProducerList();
            if (Producers.FindAll(a => a.Name == producer.Name && a.DOB == producer.DOB).Count != 0 || producer == null)
            {
                return null;
            }
            return _producerRepository.AddProducer(producer);
        }

        public Movie DeleteMovie(int movieID)
        {
            var Movies = _movieRepository.ListMovies();
            var movie = Movies.ElementAt(movieID - 1);
            if (Movies.FindAll(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year).Count == 0)
            {
                return null;
            }
            return _movieRepository.DeleteMovie(movie);
        }

        public List<Actor> GetActors()
        {
            return _actorRepository.GetActors(); 
        }

        public List<Producer> GetProducerList()
        {
            return _producerRepository.GetProducerList();
        }

        public List<Movie> ListMovies()
        {
            var list = _movieRepository.ListMovies();
            if (list.Count == 0)
            {
                return null;
            }
            return list;
        }
    }
}
