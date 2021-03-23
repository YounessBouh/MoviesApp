

using MoviesApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApp.Core.Interfaces
{
   public interface IActorRepo
    {
        IEnumerable<Actor> GetActors();
        Task<Actor> GetActor(string id);
        Task Add(Actor actor);
        Task Update(Actor actor);
        Task Delete(Actor actor);
    }
}
