using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Silicon_WebApp.Contexts;
using Silicon_WebApp.Models;
using Silicon_WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddDefaultIdentity<AppUser>(x =>
{
	x.User.RequireUniqueEmail = true;
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
	x.LoginPath = "/login";
	x.LogoutPath = "/signout";
	x.AccessDeniedPath = "/login";

	x.Cookie.HttpOnly = true;
	x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
	x.SlidingExpiration = true;
});


builder.Services.AddScoped<AddressManager>();
builder.Services.AddScoped<AccountManager>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "catch-all",
	pattern: "{*url}",
	defaults: new { controller = "NotFound", action = "Index" });
app.Run();
