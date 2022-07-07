using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SurfClub.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ClubContext(serviceProvider.GetRequiredService<DbContextOptions<ClubContext>>()))
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
                    context.SaveChanges();
                }

                if (context.Posts.Any())
                {
                    return;
                }

                context.Posts.AddRange(
                    new Post()
                    {
                        AuthorId = systemUser.Id,
                        Text = "1111",
                        CreateDate = new DateTime(2022, 06, 12, 09, 08, 00)
                    },
                    new Post()
                    {
                        AuthorId = systemUser.Id,
                        Text = "очень старая запись",
                        CreateDate = new DateTime(2021, 05, 30)
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
