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
            Actor newActor = new Actor(name , DateOnly.ParseExact(DOB, "dd/MM/yyyy"));
            List<Actor> Actors = _actorRepository.Get();
            if (Actors.Any(actor => actor.Name == newActor.Name && actor.DOB == newActor.DOB) || newActor == null)
            {
                throw new Exception("Actor already exists");
            }
            Console.WriteLine("Actor added successfully");
            return _actorRepository.Add(newActor);
        }

        public Movie AddMovie(string name, int year, string plot, string[] actorIDs, int producerID)
        {
            bool argumentException = false;
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Movie name is empty");
                argumentException = true;
            }
            if (String.IsNullOrEmpty(plot))
            {
                Console.WriteLine("Movie Plot is empty");
                argumentException |= true;
            }
            // the first film was released in 1888 so minimum year is 1888
            // maximum upcoming movies release date will be planed for 2 years from current year
            if (year > (DateTime.Now.Year + 2) || year < 1888)
            {
                Console.WriteLine("Year should be between {0} and {1}", 1888, (DateTime.Now.Year + 2));
                argumentException |= true;
            }
            var actors = _actorRepository.Get();
            var producers = _producerRepository.Get();
            List<int> actorsList = new();
            foreach (var id in actorIDs)
            {
                var actorID = int.Parse(id);
                if (actorID > actors.Count || actorID < 1)
                {
                    Console.WriteLine("actor ID {0} is not in the actors list", actorID);
                    argumentException |= true;
                }
                if (!actorsList.Any(actorId => actorId.Equals(actorID)))
                {
                    actorsList.Add(actorID);
                }
            }
            if (producerID > producers.Count || producerID < 1)
            {
                Console.WriteLine("producer ID {0} is not in the producers list", producerID);
                argumentException |= true;
            }
            if (argumentException)
            {
                throw new InvalidArgumentException("Invalid arguments");
            }
            var newMovie = new Movie(name, year, plot, actorsList.ToArray(), producerID);
            var movies = _movieRepository.Get();
            if (movies.Any(movie => movie.Name == newMovie.Name && movie.Plot == newMovie.Plot && movie.Year == newMovie.Year))
            {
                throw new Exception("Movie already exists");
            }
            Console.WriteLine("Movie added Sucessfully");
            return _movieRepository.Add(newMovie);
        }

        public Producer AddProducer(string name, string DOB)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(DOB))
            {
                throw new InvalidArgumentException("Invalid arguments");
            }
            Producer newProducer = new Producer(name, DateOnly.ParseExact(DOB, "dd/MM/yyyy"));
            List<Producer> Producers = _producerRepository.Get();
            if (Producers.Any(producer => producer.Name == newProducer.Name && producer.DOB == newProducer.DOB) || newProducer == null)
            {
                throw new Exception("Producer already exists");
            }
            Console.WriteLine("Producer added sucessfully");
            return _producerRepository.Add(newProducer);
        }

        public Movie DeleteMovie(int movieID)
        {
            var movies = _movieRepository.Get();
            if (movieID > movies.Count || movieID < 1)
            {
                throw new FileNotFoundException("Movie is not in the List");
            }
            var movie = movies.ElementAt(movieID - 1);
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
            var movies = _movieRepository.Get();
            if (movies.Count == 0)
            {
                Console.WriteLine("Movies list is Empty");
            }
            return movies;
        }
    }
}
