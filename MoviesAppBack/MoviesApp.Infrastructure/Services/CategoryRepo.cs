
using Microsoft.EntityFrameworkCore;
using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Infrastructure.Services
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task add(Category category)
        {
            _context.Add(category);
           await _context.SaveChangesAsync();
        }

        public async Task delete(Category category)
        {
            _context.Categories.Remove(category);
           await _context.SaveChangesAsync();
        }

        public IEnumerable<Category> GetCategories()
        {
           return _context.Categories.ToList();
        }

        public async Task<Category> GetCategory(string id)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(x=>x.CategoryId==id);
            if (model == null) return null;
            return model;
        }

        public async Task update(Category category)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(x=>x.CategoryId==category.CategoryId);
            model.name = category.name;
            _context.SaveChanges();
        }
    }
}
