


using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesApp.Core.Entities;

namespace MoviesApp.Core.Interfaces
{
    public interface IMovieRepo
    {
        IEnumerable<Movie> GetAllMovies();
        Task<Movie> GetMovieById(string id);
        Task Add(Movie movie);
        Task Delete(Movie movie);
        Task Update(Movie movie);
    }
}
