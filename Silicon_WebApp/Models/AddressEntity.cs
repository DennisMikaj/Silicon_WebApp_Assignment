using System.ComponentModel.DataAnnotations;

namespace Silicon_WebApp.Models
{
	public class AddressEntity
	{
		public int Id { get; set; }

		[Required]
		public string AddressLine_1 { get; set; } = null!;

		public string? AddressLine_2 { get; set; }

		[Required]
		public string PostalCode { get; set; } = null!;

		[Required]
		public string City { get; set; } = null!;

		public string AppUserId { get; set; } = null!;
		public AppUser AppUser { get; set; } = null!;
	}
}
