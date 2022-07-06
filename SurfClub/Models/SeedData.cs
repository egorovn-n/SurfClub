using Microsoft.AspNetCore.Identity;

namespace SurfClub.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var systemUser = await userManager.FindByEmailAsync("qwe@qwe.ru");
            if (systemUser == null)
            {
                systemUser = new User()
                {
                    UserName = "system",
                    Email = "qwe@qwe.ru"
                };
                var result = await userManager.CreateAsync(systemUser, "qwe123");
                ;
            }
        }
    }
}
