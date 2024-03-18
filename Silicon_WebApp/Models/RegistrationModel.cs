using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Silicon_WebApp.Models;

public class RegistrationModel
{
    [Required]
    [Display(Name = "First name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Display(Name = "Last name")]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;
	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Confirm Password")]
	public string ConfirmPassword { get; set; } = null!;

	[Required]
    public bool TermsAndConditions { get; set; }
}
