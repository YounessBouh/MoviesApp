

using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Dtos.Category
{
    public class CategoryUpdateModel
    {
          public string CategoryId { get; set; }
        [Required, StringLength(100)] public string name { get; set; }
    }
}
