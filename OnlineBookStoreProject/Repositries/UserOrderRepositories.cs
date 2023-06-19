using OnlineBookStoreProject.Models.Domain;
using OnlineBookStoreProject.Repositries.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace OnlineBookStoreProject.Repositries.Implementation
{ 
    public class UserOrderRepositories: IUserOrderRepository
    {
        private readonly DatabaseContext _ctx;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        public UserOrderRepositories(DatabaseContext ctx, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager) {
            _ctx = ctx;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }
       
        public async Task<IEnumerable<Order>> UserOrders(int? statusId = 0)
        {
            var userId = GetUserId();
            string roles = await GetUserRole();
            List<string> roleList = roles.Split(separator: ',').ToList();
            bool isAdmin = roleList.Contains("Admin");
            if (string.IsNullOrEmpty(userId))
                throw new Exception("User is not logged-in");
            

            var orders = await _ctx.Order
                            .Include(x => x.OrderStatus)
                            .Include(x => x.OrderDetail)
                            .ThenInclude(x => x.Book)
                            .Where(a => a.UserId == userId)
                            .ToListAsync();
            if (isAdmin)
            {
                orders = await _ctx.Order
                            .Include(x => x.OrderStatus)
                            .Include(x => x.OrderDetail)
                            .ThenInclude(x => x.Book)
                            .ToListAsync();
            }
            return orders;
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }
        private async Task<string> GetUserRole()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            var user = await _userManager.FindByIdAsync(userId);

            // Get the roles for the user
            var roles = await _userManager.GetRolesAsync(user);
            string roleString = string.Join(", ", roles);
            return roleString;
        }
    }
}