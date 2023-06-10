using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreProject.Models.Domain
{
    //We did it
    public class OrderStatus
    {
        public int Id { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        [MaxLength(20)]
        public string ?StatusName { get; set; }

    }
}
