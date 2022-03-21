using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_App.Exceptions
{
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException()
        {
        }

        public InvalidArgumentException(string message)
            : base(message)
        {
        }

        public InvalidArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
