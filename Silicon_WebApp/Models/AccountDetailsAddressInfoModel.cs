using System.ComponentModel.DataAnnotations;

namespace Silicon_WebApp.Models;

public class AccountDetailsAddressInfoModel
{
	[Required(ErrorMessage = "A valid address line is required")]
	[DataType(DataType.Text)]
	[Display(Name = "Address Line 1", Prompt = "Enter your address line", Order = 0)]
	public string AddressLine_1 { get; set; } = null!;



	[Display(Name = "Address Line 2 (optional)", Prompt = "Enter your second address line", Order = 1)]
	public string? AddressLine_2 { get; set; }


	[Required(ErrorMessage = "A valid postal code is required")]
	[Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
	[DataType(DataType.PostalCode)]
	public string PostalCode { get; set; } = null!;


	[Required(ErrorMessage = "A valid city is required")]
	[DataType(DataType.Text)]
	[Display(Name = "City", Prompt = "Enter your city", Order = 3)]
	public string City { get; set; } = null!;
}
