


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Core.Entities
{
    public class Movie
    {
        public string Id { get; set; }

        [Required, StringLength(50)] public string Title { get; set; }

        [Required, StringLength(400)] public string Description { get; set; }

        [Required, StringLength(50)] public string Picture { get; set; }

        [Required] public string MovieLink { get; set; }

        public string CategoryId { get; set; }
        public Category category { get; set; }

        public ICollection<Actor> Actors { get; set; }

        
    }
}
