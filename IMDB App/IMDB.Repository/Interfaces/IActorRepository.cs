using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;


namespace IMDB.Repository.Interfaces
{
    public interface IActorRepository
    {
        public Actor Add(Actor actor);
        public List<Actor> Get();
    }
}
