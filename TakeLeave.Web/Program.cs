using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeLeave.Data;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Web;
using TakeLeave.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<TakeLeaveDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<Employee, EmployeeRole>()
    .AddEntityFrameworkStores<TakeLeaveDbContext>();

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
options =>
{
    options.LoginPath = "/Login/OnLogin";
    options.LogoutPath = "/Logout/OnLogout";
    options.AccessDeniedPath = "/Home/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

builder.Services.ConfigureRepository();

builder.Services.ConfigureAppServices();

builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "User",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=IndexPageByRole}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();
