using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository.Interfaces;

namespace IMDB.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly List<Producer> _producers = new List<Producer>();
        public Producer Add(Producer producer)
        {
            _producers.Add(producer);
            return producer;
        }

        public List<Producer> Get()
        {
            return _producers;
        }
    }
}
