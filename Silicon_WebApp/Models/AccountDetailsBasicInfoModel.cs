﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Silicon_WebApp.Models;

public class AccountDetailsBasicInfoModel
{

	public string UserId { get; set; } = null!;


	[DataType(DataType.ImageUrl)]
	public string? ProfileImage { get; set; }


	[Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
	[Required(ErrorMessage = "First name is required")]
	public string FirstName { get; set; } = null!;

	[Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
	[Required(ErrorMessage = "Last name is required")]
	public string LastName { get; set; } = null!;

	[DataType(DataType.EmailAddress)]
	[Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
	[Required(ErrorMessage = "Email is required")]
	[RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Your email address is invalid")]
	public string Email { get; set; } = null!;


	[Display(Name = "Phone (optional)", Prompt = "Enter your phone", Order = 3)]
	[DataType(DataType.PhoneNumber)]
	public string? Phone { get; set; }

	[Display(Name = "Bio (optional)", Prompt = "add a short bio...", Order = 4)]
	[DataType(DataType.MultilineText)]
	public string? Biography { get; set; }
}
