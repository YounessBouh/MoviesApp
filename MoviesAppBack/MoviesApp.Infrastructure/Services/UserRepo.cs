using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MoviesApp.Infrastructure.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<AppUser> getAllUsers()
        {
             return  _context.appUsers.ToList(); 
           
        }

        public async Task<AppUser> getById(string id)
        {
            return await _context.appUsers.SingleOrDefaultAsync(x=>x.Id==id);
        }


        public async Task Remove(AppUser user)
        { 
            _context.appUsers.Remove(user);
            await _context.SaveChangesAsync();

        }

       
    }
}
