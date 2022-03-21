using IMDB_App.Services;
using IMDB_App.Exceptions;
using IMDB.Domain;

var iMDBService = new IMDBService();
Console.Write("\t1) List Movies\n\t2) Add Movie\n\t3) Add Actor\n\t4) Add Producer\n\t5) Delete Movie\n\t6)Exit");
while (true)
{
    try
    {
        Console.WriteLine("\nWhat do you want to do?");
        var option = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(option))
        {
            throw new ArgumentNullException();
        }
        var choice = 0;
        int.TryParse(option, out choice);
        if (choice == 0)
        {
            throw new ArgumentException();
        }
        List<Actor> actors;
        List<Producer> producers;
        if (choice == 6)
        {
            break;
        }
        switch (choice)
        {
            case 1:
                actors = iMDBService.GetActors();
                producers = iMDBService.GetProducers();
                var movies = iMDBService.GetMovies();
                if (movies != null)
                {
                    foreach (var mv in movies)
                    {
                        Console.WriteLine("{0} ({1})", mv.Name, mv.Year);
                        Console.WriteLine("Plot - {0}", mv.Plot);
                        Console.Write("Actors - ");
                        Console.WriteLine(String.Join(", ", actors.Where(b => mv.ActorIDs.Contains(actors.IndexOf(b) + 1)).Select(b => b.Name)));
                        Console.WriteLine("Producers - {0}\n", producers.ElementAt(mv.ProducerID - 1).Name);
                    }

                }
                break;
            case 2:
                actors = iMDBService.GetActors();
                producers = iMDBService.GetProducers();
                if (actors.Count == 0 && producers.Count == 0)
                {
                    Console.WriteLine("Actors List and Producer List are empty");
                    break;
                }
                else if (actors.Count == 0)
                {
                    Console.WriteLine("Actors List is empty");
                    break;
                }
                else if (producers.Count == 0)
                {
                    Console.WriteLine("Producers List is empty");
                    break;
                }
                Console.Write("Name: ");
                var name = Console.ReadLine().Trim();
                Console.Write("Year of release: ");
                int year = int.Parse(Console.ReadLine().Trim());
                Console.Write("Plot: ");
                var plot = Console.ReadLine().Trim();
                Console.Write("\nChoose actor(s) \"eg: 1 2 3\": ");
                int i = 1;
                foreach (var actor in actors)
                {
                    Console.Write("{0}. {1} ", i++, actor.Name);
                }
                Console.WriteLine();
                var actorIDs = Console.ReadLine().Trim().Split();
                Console.Write("Choose Producer: ");
                i = 1;
                foreach (var producer in producers)
                {
                    Console.Write("{0}. {1} ", i++, producer.Name);
                }
                Console.WriteLine();
                var producerID = int.Parse(Console.ReadLine());
                var movie = iMDBService.AddMovie(name, year, plot, actorIDs, producerID);
                break;
            case 3:
                Console.Write("Name: ");
                var actorName = Console.ReadLine().Trim();
                Console.Write("DOB (dd/MM/yyyy): ");
                var date = Console.ReadLine().Trim();
                iMDBService.AddActor(actorName, date);
                break;
            case 4:
                Console.Write("Name: ");
                var producerName = Console.ReadLine();
                Console.Write("DOB (dd/MM/yyyy): ");
                var dob = Console.ReadLine();
                var producerObj = iMDBService.AddProducer(producerName, dob);
                break;
            case 5:
                var moviesList = iMDBService.GetMovies();
                if (moviesList != null)
                {
                    int k = 1;
                    foreach (var item in moviesList)
                    {
                        Console.WriteLine("{0}. {1}", k++, item.Name);
                    }
                    int mvID = int.Parse(Console.ReadLine());
                    iMDBService.DeleteMovie(mvID);
                }
                break;
            default:
                Console.WriteLine("Please enter a valid Option");
                break;
        }

    }
    catch (Exception)
    {
        Console.WriteLine("\nInvalid Input");
    } 
}

