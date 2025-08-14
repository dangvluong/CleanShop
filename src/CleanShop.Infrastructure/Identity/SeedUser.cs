using Microsoft.AspNetCore.Identity;

namespace CleanShop.Infrastructure.Identity
{
    public static class SeedUser
    {
        public static async Task SeedUsers(AppIdentityDbContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var admin = new User
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, [UserTypes.Admin, UserTypes.Member]);

                var user = new User
                {
                    UserName = "user@example.com",
                    Email = "user@example.com",
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, UserTypes.Member);
                
                await context.SaveChangesAsync();
            }
        }
    }
}