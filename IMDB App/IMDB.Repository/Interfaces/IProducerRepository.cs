using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;

namespace IMDB.Repository.Interfaces
{
    public interface IProducerRepository
    {
        public Producer Add(Producer producer);
        public List<Producer> Get();
    }
}
