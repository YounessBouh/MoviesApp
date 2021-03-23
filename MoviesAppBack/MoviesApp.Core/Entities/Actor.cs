


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Core.Entities
{
    public class Actor
    {
        public string Id { get; set; }

       [Required] public string ActorName { get; set; }

       [Required]public string ActorPicture { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
