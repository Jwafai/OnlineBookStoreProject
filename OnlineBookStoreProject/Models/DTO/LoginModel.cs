using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace OnlineBookStoreProject.Models.DTO
{
    public class LoginModel
    {
        [Required]
        public string?  Username { get; set; }
        
        [Required]
        public string? Password { get; set; }
        
    }
}
