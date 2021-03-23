

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MoviesApp.Dtos.Movie
{
    public class MovieCreateModel
    {
        [Required, StringLength(50)] public string Title { get; set; }

        [Required, StringLength(400)] public string Description { get; set; }

        [Required] public IFormFile Picture { get; set; }

        [Required] public IFormFile video { get; set; }

        public string CategoryId { get; set; }

        public List<string> actorsId { get; set; }

        


    }
}
