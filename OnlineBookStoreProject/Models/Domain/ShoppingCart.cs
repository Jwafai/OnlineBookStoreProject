using Microsoft.Build.Framework;

namespace OnlineBookStoreProject.Models.Domain
{
    //we did it
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
