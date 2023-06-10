using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Build.Framework;

namespace OnlineBookStoreProject.Models.Domain
{
    public class OrderDetail
    {
       
        public int Id { get; set; }
        [Required]
        //Make sure Order id isnt same with id
        public int OrderId{ get; set; }
        [Required]
        //makeit foreign key
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnityPrice { get; set; }
        [Required]

        public Order Order { get; set; }
        [BindNever]
        public Book Book { get; set; }
    }
}
