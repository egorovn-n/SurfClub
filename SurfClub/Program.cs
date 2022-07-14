using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurfClub.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClubContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ClubContext")));

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequiredLength = 6;   // ����������� �����
    options.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
    options.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
    options.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
    options.Password.RequireDigit = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;
})
                .AddEntityFrameworkStores<ClubContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    using (var context = scope.ServiceProvider.GetService<ClubContext>())
    {
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        await SeedData.Initialize(services);
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
