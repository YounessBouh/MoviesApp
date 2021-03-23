

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Dtos.Movie
{
    public class MovieUpdateModel
    {
        [Key] public string id { get; set; }
        [Required, StringLength(50)] public string Title { get; set; }

        [Required, StringLength(400)] public string Description { get; set; }

         public IFormFile Picture { get; set; }

         public IFormFile video { get; set; }

       
    }
}
