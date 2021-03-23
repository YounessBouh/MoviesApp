

using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Dtos.Category
{
    public class CategoryCreateModel
    {
        [Required, StringLength(100)] public string name { get; set; }
    }
}
