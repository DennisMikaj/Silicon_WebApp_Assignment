using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Silicon_WebApp.Models;
using Silicon_WebApp.Services;
using Silicon_WebApp.ViewModels;

namespace Silicon_WebApp.Controllers;

[Authorize]
public class AccountController(UserManager<AppUser> userManager, AddressManager addressManager, AccountManager accountManager) : Controller
{
	private readonly UserManager<AppUser> _userManager = userManager;
	private readonly AddressManager _addressManager = addressManager;
	private readonly AccountManager _accountManager = accountManager;
	






	#region Details
	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var model = new AccountDetailsViewModel();

		model.ProfileInfo = await PopulateProfileInfoAsync();
		model.BasicInfo ??= await PopulateBasicInfoAsync();
		model.AddressInfo ??= await PopulateAddressInfoAsync();

		return View(model);
	}
	#endregion


	#region [HttpPost]Details
	[HttpPost]
	public async Task<IActionResult> Index(AccountDetailsViewModel model)
	{
		if (model.BasicInfo != null)
		{
			if (model.BasicInfo.FirstName != null && model.BasicInfo.LastName != null && model.BasicInfo.Email != null)
			{

				var user = await _userManager.GetUserAsync(User);
				if (user != null)
				{
					user.FirstName = model.BasicInfo.FirstName;
					user.LastName = model.BasicInfo.LastName;
					user.Email = model.BasicInfo.Email;
					user.PhoneNumber = model.BasicInfo.Phone;
					user.Biography = model.BasicInfo.Biography;

					var result = await _userManager.UpdateAsync(user);
					if (!result.Succeeded)
					{
						ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to update basic information.");
						ViewData["ErrorMessage"] = "Something went wrong! Unable to update basic information.";
					}
				}
			}
		}

		if (model.AddressInfo != null)
		{
			if (model.AddressInfo.AddressLine_1 != null && model.AddressInfo.PostalCode != null && model.AddressInfo.City != null)
			{

				var user = await _userManager.GetUserAsync(User);
				if (user != null)
				{
					var address = await _addressManager.GetAddressAsync(user.Id);
					if (address != null)
					{
						address.AddressLine_1 = model.AddressInfo.AddressLine_1;
						address.AddressLine_2 = model.AddressInfo.AddressLine_2;
						address.PostalCode = model.AddressInfo.PostalCode;
						address.City = model.AddressInfo.City;

						var result = await _addressManager.UpdateAddressAsync(address);
						if (!result)
						{
							ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to update address info.");
							ViewData["ErrorMessage"] = "Something went wrong! Unable to update address info.";
						}
					}
					else
					{
						address = new AddressEntity
						{
							AppUserId = user.Id,
							AddressLine_1 = model.AddressInfo.AddressLine_1,
							AddressLine_2 = model.AddressInfo.AddressLine_2,
							PostalCode = model.AddressInfo.PostalCode,
							City = model.AddressInfo.City,
						};

						var result = await _addressManager.CreateAddressAsync(address);
						if (!result)
						{
							ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to update address info.");
							ViewData["ErrorMessage"] = "Something went wrong! Unable to update address info.";
						}
					}
				}
			}
		}

		model.ProfileInfo = await PopulateProfileInfoAsync();
		model.BasicInfo ??= await PopulateBasicInfoAsync();
		model.AddressInfo ??= await PopulateAddressInfoAsync();

		return View(model);
	}

	#endregion

	#region PopulateBasicInfoAsync
	private async Task<AccountDetailsBasicInfoModel> PopulateBasicInfoAsync()
	{
		var user = await _userManager.GetUserAsync(User);
		{
			return new AccountDetailsBasicInfoModel
			{
				UserId = user!.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email!,
				Phone = user.PhoneNumber,
				Biography = user.Biography,
				ProfileImageUrl = user.ProfileImageUrl,
			};
		}
	}

	private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
	{
		var user = await _userManager.GetUserAsync(User);
		{
			return new ProfileInfoViewModel
			{
				FirstName = user!.FirstName,
				LastName = user.LastName,
				Email = user.Email!,
				ProfileImageUrl = user.ProfileImageUrl,
			};
		}
	}



	private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoAsync()
	{
		var user = await _userManager.GetUserAsync(User);
		if (user != null)
		{
			var address = await _addressManager.GetAddressAsync(user.Id);
			return new AccountDetailsAddressInfoModel
			{
				AddressLine_1 = address?.AddressLine_1,
				AddressLine_2 = address?.AddressLine_2,
				PostalCode = address?.PostalCode,
				City = address?.City,
			};
		}
		return new AccountDetailsAddressInfoModel();
	}
	#endregion



	private async Task<AccountDetailsViewModel> PopulateAccountDetailsViewModelAsync()
	{
		var user = await _userManager.GetUserAsync(User);

		var model = new AccountDetailsViewModel
		{
			BasicInfo = new AccountDetailsBasicInfoModel
			{
				UserId = user!.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email!,
				Phone = user.PhoneNumber,
				Biography = user.Biography,
				ProfileImageUrl = user.ProfileImageUrl
			}
		};

		return model!;
	}

	[HttpPost]
	public async Task<IActionResult> UploadImage(IFormFile file)

	{
		var result = await _accountManager.UploadUserProfileImageAsync(User, file);

		return RedirectToAction("Index");
	}

}