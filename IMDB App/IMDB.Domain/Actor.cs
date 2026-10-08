using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain
{
    public class Actor
    {
        public string Name { get; set; }
        public DateOnly DOB { get; set; }

        public Actor(string name, DateOnly DOB)
        {
            Name = name;
            DOB = DOB;
        }
    }
}
