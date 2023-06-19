using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStoreProject.Models.Domain
{
    [Table("OrderDetail")]

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

        public Order Order { get; set; }
        [BindNever]
        public Book Book { get; set; }
    }
}
