using OnlineBookStoreProject.Models.Domain;
using OnlineBookStoreProject.Models.DTO;

namespace OnlineBookStoreProject.Repositries.Abstract
{
    public interface IUserOrderRepository
	{
        Task<IEnumerable<Order>> UserOrders(int? statusId);
    }
}
