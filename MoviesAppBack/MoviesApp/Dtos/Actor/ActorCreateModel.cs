

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Dtos.Actor
{
    public class ActorCreateModel
    {
       
        [Required,StringLength(50)] public string ActorName { get; set; }

        [Required] public IFormFile ActorPicture { get; set; }

        public string MovieId { get; set; }
    }
}
