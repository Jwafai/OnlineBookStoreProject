using Microsoft.AspNetCore.Identity;

namespace OnlineBookStoreProject.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
