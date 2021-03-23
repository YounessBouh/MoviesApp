
using MoviesApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApp.Core.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<AppUser> getAllUsers();
        Task<AppUser> getById(string id);
        Task  Remove(AppUser user);
        
    }
}
