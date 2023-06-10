using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookStoreProject.Constants;


namespace OnlineBookStoreProject.Data.DbSeed
{
    //we did this
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMngr = service.GetService<RoleManager<IdentityRole>>();
            //adding some rules to db
            await roleMngr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMngr.CreateAsync(new IdentityRole(Roles.User.ToString()));
            //create admin user
            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if(userInDb is null)
            {
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
    }
}
