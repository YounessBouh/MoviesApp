
using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace MoviesApp.Core.Entities
{
   public class AppUser:IdentityUser
    {
        public string Address { get; set; }

    }
}
