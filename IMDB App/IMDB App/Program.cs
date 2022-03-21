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
            throw new ArgumentNullException("option can't be null or whitespace");
        }
        var choice = 0;
        int.TryParse(option, out choice);
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
                        Console.WriteLine("{0} ({1})\nPlot - {2}\nActors - {3}\nProducers - {4}\n", mv.Name, mv.Year,
                        mv.Plot, String.Join(", ", actors.Where(b => mv.ActorIDs.Contains(actors.IndexOf(b) + 1)).Select(b => b.Name)),
                        producers.ElementAt(mv.ProducerID - 1).Name);
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
                var name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name should not be null or whitespace");
                    break;
                }
                Console.Write("Year of release: ");
                var yr = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(yr))
                {
                    Console.WriteLine("Year can't be null or white space");
                    break;
                }
                var year = -1;
                if (!int.TryParse(yr, out year))
                {
                    Console.WriteLine("Year should be integer only");
                    break;
                }
                Console.Write("Plot: ");
                var plot = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(plot))
                {
                    Console.WriteLine("Plot should not be null or whitespace");
                    break;
                }
                Console.Write("\nChoose actor(s) \"eg: 1 2 3\": ");
                int i = 1;
                foreach (var actor in actors)
                {
                    Console.Write("{0}. {1} ", i++, actor.Name);
                }
                Console.WriteLine();
                var actorIDs = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(actorIDs))
                {
                    Console.WriteLine("Actor IDs should not be null or whitespace");
                    break;
                }
                Console.Write("Choose Producer: ");
                i = 1;
                foreach (var producer in producers)
                {
                    Console.Write("{0}. {1} ", i++, producer.Name);
                }
                Console.WriteLine();
                var pID = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(pID))
                {
                    Console.WriteLine("Producer ID should not be null or whitespace");
                    break;
                }
                var producerID = 0;
                if (!int.TryParse(pID, out producerID))
                {
                    Console.WriteLine("Given producer ID is not integer type");
                    break;
                }
                var movie = iMDBService.AddMovie(name, year, plot, actorIDs.Trim().Split(), producerID);
                break;
            case 3:
                Console.Write("Name: ");
                var actorName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(actorName))
                {
                    Console.WriteLine("Actor name should not be null or whitespace");
                    break;
                }
                Console.Write("DOB (dd/MM/yyyy): ");
                var date = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(date))
                {
                    Console.WriteLine("Date of birth should not be null or whitespace");
                    break;
                }
                iMDBService.AddActor(actorName.Trim(), date.Trim());
                break;
            case 4:
                Console.Write("Name: ");
                var producerName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(producerName))
                {
                    Console.WriteLine("Producer name should not be null or whitespace");
                    break;
                }
                Console.Write("DOB (dd/MM/yyyy): ");
                var dob = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(dob))
                {
                    Console.WriteLine("Date of birth should not be null or whitespace");
                    break;
                }
                var producerObj = iMDBService.AddProducer(producerName.Trim(), dob.Trim());
                break;
            case 5:
                var moviesList = iMDBService.GetMovies();
                if (moviesList.Count != 0)
                {
                    int k = 1;
                    foreach (var item in moviesList)
                    {
                        Console.WriteLine("{0}. {1}", k++, item.Name);
                    }
                    var id = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(id))
                    {
                        Console.WriteLine("Movie Id should not be null or whitespace");
                        break;
                    }
                    var mvID = 0;
                    if (!int.TryParse(id, out mvID))
                    {
                        Console.WriteLine("Given Movie Id is not integer");
                        break;
                    }
                    iMDBService.DeleteMovie(mvID);
                }
                break;
            default:
                Console.WriteLine("Please enter a valid Option");
                break;
        }

    }
    catch (Exception e)
    {
        Console.WriteLine("{0}", e.Message);
    } 
}

