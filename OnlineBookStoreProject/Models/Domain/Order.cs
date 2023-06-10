using Microsoft.Build.Framework;

namespace OnlineBookStoreProject.Models.Domain
{
    //We did it
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.UtcNow;
        [Required]
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; }= false;

        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
