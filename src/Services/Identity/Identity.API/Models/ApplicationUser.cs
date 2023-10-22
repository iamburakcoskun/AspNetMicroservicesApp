using Microsoft.AspNetCore.Identity;

namespace Identity.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
