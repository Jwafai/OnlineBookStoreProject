namespace OnlineBookStoreProject.Models.Domain
{
    //DO NOT USE
    public class BookWithDetails : Book
    {
        public List<OrderDetail> OrderDetails { get; set; }
        public List<CartDetail> CartDetails { get; set; }
    }
}
