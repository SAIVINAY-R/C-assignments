using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository.Interfaces;

namespace IMDB.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly List<Actor> _actors = new List<Actor>();
        public Actor AddActor(Actor actor)
        {
            _actors.Add(actor);
            return actor;
        }

        public List<Actor> GetActors()
        {
            return _actors;
        }
    }
}
