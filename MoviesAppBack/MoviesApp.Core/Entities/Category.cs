

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Core.Entities
{
    public class Category
    {
        
        [Key] public string CategoryId { get; set; }
        [Required, StringLength(100)] public string name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
