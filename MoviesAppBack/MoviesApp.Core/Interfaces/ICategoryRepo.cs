

using MoviesApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApp.Core.Interfaces
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetCategories();
        Task<Category> GetCategory(string id);
        Task add(Category category);
        Task delete(Category category);
        Task update(Category category);

    }
}
