using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Silicon_WebApp.Models;

public class AppUser : IdentityUser
{
	[Required]
	[Display(Name = "First name")]
	[ProtectedPersonalData]
	public string FirstName { get; set; } = null!;



	[Required]
	[Display(Name = "Last name")]
	[ProtectedPersonalData]
	public string LastName { get; set; } = null!;

	[ProtectedPersonalData]
	public string? PhoneNumber { get; set; }

	[ProtectedPersonalData]
	public string? Biography { get; set; }

	public ICollection<AddressEntity> Addresses { get; set; } = [];
}
