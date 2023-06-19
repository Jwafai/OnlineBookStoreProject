using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Build.Framework;

namespace OnlineBookStoreProject.Models.Domain
{
    //we did it
    public class CartDetail
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }
        


        public Book Book { get; set; }
        public ShoppingCart ShoppingCart { get; set; }


    }
}
