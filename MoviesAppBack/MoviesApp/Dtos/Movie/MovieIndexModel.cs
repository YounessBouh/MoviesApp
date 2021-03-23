

using MoviesApp.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Dtos.Movie
{
    public class MovieIndexModel
    {
        public string Id { get; set; }

        [Required, StringLength(50)] public string Title { get; set; }

        [Required, StringLength(200)] public string Description { get; set; }

        [Required, StringLength(50)] public string Picture { get; set; }

        [Required] public string MovieLink { get; set; }

        public IEnumerable<ActorIndexModel> Actors { get; set; }

        public string CategoryId { get; set; }



    }
}
