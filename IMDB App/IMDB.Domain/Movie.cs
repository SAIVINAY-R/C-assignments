using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain
{
    public class Movie
    {
        public string Name;
        public int Year;
        public string Plot;
        public List<string> Actors = new();
        public string Producer;
    }
}
