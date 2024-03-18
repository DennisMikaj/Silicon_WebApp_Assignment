using Microsoft.EntityFrameworkCore;
using Silicon_WebApp.Contexts;
using Silicon_WebApp.Models;

namespace Silicon_WebApp.Services;

public class AddressManager(AppDbContext context)
{
	private readonly AppDbContext _context = context;

	public async Task<AddressEntity> GetAddressAsync(string UserId)
	{
		var addressEntity = await _context.AddressEntity.FirstOrDefaultAsync(x => x.AppUserId == UserId);
		return addressEntity!;
	}

	public async Task<bool> CreateAddressAsync(AddressEntity entity)
	{
		_context.AddressEntity.Add(entity);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> UpdateAddressAsync(AddressEntity entity)
	{
		var existing = await _context.AddressEntity.FirstOrDefaultAsync(x => x.AppUserId == entity.AppUserId);
        if (existing != null)
        {
			_context.Entry(existing).CurrentValues.SetValues(entity);
			await _context.SaveChangesAsync();

			return true;
		}
		return false;
	}
}
