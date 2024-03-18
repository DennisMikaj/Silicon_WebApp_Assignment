using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Silicon_WebApp.Models;

namespace Silicon_WebApp.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
{
	public DbSet<AddressEntity> AddressEntity { get; set; }
}
