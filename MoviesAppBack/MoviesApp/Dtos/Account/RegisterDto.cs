

using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Dtos.Account
{
    public class RegisterDto
    {
        [Required,StringLength(30)] public string username { get; set; }
        [Required]public string password { get; set; }
        [Required,StringLength(30)]public string email { get; set; }
        [Required,StringLength(50)]public string Address { get; set; }
        [Required,StringLength(15)]public string mobile { get; set; }
    }
}
