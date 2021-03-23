

using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Dtos.Actor
{
    public class ActorUpdateModel
    {
        public string Id { get; set; }

        [Required,StringLength(50)] public string ActorName { get; set; }

        [Required] public string ActorPicture { get; set; }
    }
}
