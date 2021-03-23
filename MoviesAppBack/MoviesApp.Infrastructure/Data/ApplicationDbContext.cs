

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoviesApp.Core.Entities;

namespace MoviesApp.Infrastructure.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Actor> Actors { get;set; }
      

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
         

          builder.Entity<Category>()
         .HasMany(p => p.Movies)
         .WithOne(t => t.category)
         .OnDelete(DeleteBehavior.SetNull);


            base.OnModelCreating(builder);

        }

    }

    
}
