using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository;
using IMDB.Repository.Interfaces;
using IMDB_App.Exceptions;

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
                throw new InvalidArgumentException("Invalid arguments");
            }
            Actor actor = new Actor() { Name = name , DOB = DateOnly.ParseExact(DOB, "dd/MM/yyyy") };
            List<Actor> Actors = _actorRepository.Get();
            if (Actors.Any(a => a.Name == actor.Name && a.DOB == actor.DOB) || actor == null)
            {
                Console.WriteLine("Actor already exists");
                return null;
            }
            Console.WriteLine("Actor added successfully");
            return _actorRepository.Add(actor);
        }

        public Movie AddMovie(string name, int year, string plot, string[] actorIDs, int producerID)
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Movie name is empty");
                throw new InvalidArgumentException("Invalid arguments");
            }
            if (String.IsNullOrEmpty(plot))
            {
                Console.WriteLine("Movie Plot is empty");
                throw new InvalidArgumentException("Invalid arguments");
            }
            // the first film was released in 1888 so minimum year is 1888
            // maximum upcoming movies release date will be planed for 2 years from current year
            if (year > (DateTime.Now.Year + 2) || year < 1888)
            {
                Console.WriteLine("Year should be between {0} and {1}", 1888, (DateTime.Now.Year + 2));
                throw new InvalidArgumentException("Invalid arguments");
            }
            var actors = _actorRepository.Get();
            var producers = _producerRepository.Get();
            List<int> actorsList = new();
            foreach (var id in actorIDs)
            {
                var actorID = int.Parse(id);
                if (actorID > actors.Count || actorID < 1)
                {
                    throw new InvalidArgumentException("Invalid arguments");
                }
                if (!actorsList.Any(b => b.Equals(actorID)))
                {
                    actorsList.Add(actorID);
                }
            }
            if (producerID > producers.Count || producerID < 1)
            {
                Console.WriteLine("Enter the correct ProducerID");
                throw new InvalidArgumentException("Invalid arguments");
            }
            var movie = new Movie() { Name = name, Year = year, Plot = plot, ActorIDs = actorsList.ToArray(), ProducerID = producerID };
            var Movies = _movieRepository.Get();
            if (Movies.Any(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year))
            {
                Console.WriteLine("Movie already exists");
                return null;
            }
            Console.WriteLine("Movie added Sucessfully");
            return _movieRepository.Add(movie);
        }

        public Producer AddProducer(string name, string DOB)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(DOB))
            {
                throw new ArgumentNullException("Invalid arguments");
            }
            Producer producer = new Producer() { Name = name, DOB = DateOnly.ParseExact(DOB, "dd/MM/yyyy") };
            List<Producer> Producers = _producerRepository.Get();
            if (Producers.FindAll(a => a.Name == producer.Name && a.DOB == producer.DOB).Count != 0 || producer == null)
            {
                Console.WriteLine("Producer already exists");
                return null;
            }
            Console.WriteLine("Producer added sucessfully");
            return _producerRepository.Add(producer);
        }

        public Movie DeleteMovie(int movieID)
        {
            var Movies = _movieRepository.Get();
            var movie = Movies.ElementAt(movieID - 1);
            if (Movies.FindAll(b => b.Name == movie.Name && b.Plot == movie.Plot && b.Year == movie.Year).Count == 0)
            {
                Console.WriteLine("Movie is not in the List");
                return null;
            }
            Console.WriteLine("Movie deleted...");
            return _movieRepository.Delete(movie);
        }

        public List<Actor> GetActors()
        {
            return _actorRepository.Get(); 
        }

        public List<Producer> GetProducers()
        {
            return _producerRepository.Get();
        }

        public List<Movie> GetMovies()
        {
            var list = _movieRepository.Get();
            if (list.Count == 0)
            {
                Console.WriteLine("Movies list is Empty");
                return null;
            }
            return list;
        }
    }
}
