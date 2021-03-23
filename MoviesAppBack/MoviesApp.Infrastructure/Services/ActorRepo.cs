

using Microsoft.EntityFrameworkCore;
using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Infrastructure.Services
{
    public class ActorRepo : IActorRepo
    {
        private readonly ApplicationDbContext _context;
        public ActorRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Actor actor)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> GetActor(string id)
        {
            return await _context.Actors.SingleOrDefaultAsync(x=>x.Id==id);
        }

        public IEnumerable<Actor> GetActors()
        {
            return _context.Actors.ToList();
        }

        public async Task Update(Actor actor)
        {
            var model = await GetActor(actor.Id);
            model.ActorName = actor.ActorName;
            model.ActorPicture = actor.ActorPicture;
            await _context.SaveChangesAsync();

        }
    }
}
