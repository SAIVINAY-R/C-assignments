using IMDB.Domain;
using IMDB_App;
using IMDB_App.Services;

var iMDBService = new IMDBService();
Console.Write("\t1) List Movies\n\t2) Add Movie\n\t3) Add Actor\n\t4) Add Producer\n\t5) Delete Movie\n\t6)Exit");
while (true)
{
    try
    {
        Console.WriteLine("\nWhat do you want to do?");
        int option = int.Parse(Console.ReadLine());
        if (option == 6)
        {
            break;
        }
        switch (option)
        {
            case 1:
                var movies = iMDBService.ListMovies();
                if (movies != null)
                {
                    foreach (var mv in movies)
                    {
                        Console.WriteLine("{0} ({1})", mv.Name, mv.Year);
                        Console.WriteLine("Plot - {0}", mv.Plot);
                        Console.Write("Actors - ");
                        foreach (var actor in mv.Actors)
                        {
                            Console.Write("{0}, ", actor);
                        }
                        Console.WriteLine("\nProducers - {0}", mv.Producer);
                    }

                }
                else
                {
                    Console.WriteLine("Movies List is empty");
                }
                break;
            case 2:
                Console.Write("Name: ");
                var name = Console.ReadLine().Trim();
                Console.Write("Year of release: ");
                int year = int.Parse(Console.ReadLine().Trim());
                Console.Write("Plot: ");
                var plot = Console.ReadLine().Trim();
                Console.Write("\nChoose actor(s): ");
                int i = 1;
                var Actors = iMDBService.GetActors();
                if (Actors.Count == 0)
                {
                    Console.WriteLine("Actors List is empty");
                    break;
                }
                foreach (var actor in Actors)
                {
                    Console.Write("{0}. {1} ", i, actor.Name);
                    i++;
                }
                Console.WriteLine();
                var actorIDs = Console.ReadLine().Trim().Split();
                Console.Write("Choose Producer: ");
                i = 1;
                var Producers = iMDBService.GetProducerList();
                if (Producers.Count == 0)
                {
                    Console.WriteLine("Producers List is empty");
                    break;
                }
                foreach (var producer in Producers)
                {
                    Console.Write("{0}. {1} ", i, producer.Name);
                    i++;
                }
                Console.WriteLine();
                var producerID = int.Parse(Console.ReadLine());
                var movie = iMDBService.AddMovie(name, year, plot, actorIDs, producerID);

                if (movie == null)
                {
                    Console.WriteLine("Movie already exists OR Null or Empty Field");
                }
                break;
            case 3:
                Console.Write("Name: ");
                var actorName = Console.ReadLine().Trim();
                Console.Write("DOB (dd/MM/yyyy): ");
                var date = Console.ReadLine().Trim();
                var actorObj = iMDBService.AddActor(actorName, date);
                if (actorObj == null)
                {
                    Console.WriteLine("Actor already exists");
                }
                break;
            case 4:
                Console.Write("Name: ");
                var producerName = Console.ReadLine();
                Console.Write("DOB (dd/MM/yyyy): ");
                var dob = Console.ReadLine();
                var producerObj = iMDBService.AddProducer(producerName, dob);
                if (producerObj == null)
                {
                    Console.WriteLine("Actor already exists");
                }
                break;
            case 5:
                var moviesList = iMDBService.ListMovies();
                int k = 0;
                foreach (var item in moviesList)
                {
                    Console.WriteLine("{0}. {1}", k, item.Name);
                }
                int mvID = int.Parse(Console.ReadLine());
                var movieObj = iMDBService.DeleteMovie(mvID);
                if (movieObj == null)
                {
                    Console.WriteLine("Movie is not in the List");
                }
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }

    }
    catch (Exception)
    {
        Console.WriteLine("\nInvalid Input");
    } 
}

