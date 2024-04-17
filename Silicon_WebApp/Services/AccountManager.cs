using Microsoft.AspNetCore.Identity;
using Silicon_WebApp.Contexts;
using Silicon_WebApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;


namespace Silicon_WebApp.Services;

public class AccountManager(UserManager<AppUser> userManager, AppDbContext context, IConfiguration configuration)
{
	private readonly UserManager<AppUser> _userManager = userManager;
	private readonly AppDbContext _context = context;
	private readonly IConfiguration _configuration = configuration;

	public async Task<bool> UploadUserProfileImageAsync(ClaimsPrincipal user, IFormFile file)
	{
		try
		{
			if (user != null && file != null && file.Length != 0) 
			{
				var userEntity = await _userManager.GetUserAsync(user);
				if (userEntity != null)
				{
					var fileName = $"p_{userEntity.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FileUploadPath"]!, fileName);

					using var fs = new FileStream(filePath, FileMode.Create);
					await file.CopyToAsync(fs);

					userEntity.ProfileImageUrl = fileName;
					_context.Update(userEntity);
					await _context.SaveChangesAsync();

					return true;
				}
			}
		}
		catch (Exception ex) 
		{
			Debug.WriteLine(ex.Message);
		}
		return false;
	}
}
