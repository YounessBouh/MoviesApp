

using Microsoft.EntityFrameworkCore;
using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Infrastructure.Services
{
    public class MovieRepo : IMovieRepo
    {
        private readonly ApplicationDbContext _context;
        public MovieRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Movie movie)
        {
            _context.Movies.Add(movie);
             await _context.SaveChangesAsync();
        }

        public async Task Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieById(string id)
        {
            return await _context.Movies.Include(x=>x.Actors).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
          var MoviesList=  _context.Movies.Include(x => x.Actors).ToList();

            return MoviesList;
        }

        public async Task Update(Movie movie)
        {
            var model = await GetMovieById(movie.Id);
            model.Title = movie.Title;
            model.Description = movie.Description;
            model.Picture = movie.Picture;
            model.MovieLink = movie.MovieLink;
            await _context.SaveChangesAsync();
        }
    }
}
