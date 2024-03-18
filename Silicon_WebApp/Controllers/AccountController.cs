using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silicon_WebApp.ViewModels;

namespace Silicon_WebApp.Controllers;

[Authorize]
public class AccountController : Controller
{
	public IActionResult Index()
	{
		var model = new AccountDetailsViewModel();
		return View(model);
	}
}
