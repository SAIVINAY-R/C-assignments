using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain
{
    public class Movie
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Plot { get; set; }
        public int[] ActorIDs { get; set; }
        public int ProducerID { get; set; }

        public Movie(string name, int year, string plot, int[] actorIDs, int producerID)
        {
            Name = name;
            Year = year;
            Plot = plot;
            ActorIDs = actorIDs;
            ProducerID = producerID;
        }
    }
}
