using Microsoft.AspNetCore.Mvc;

namespace Silicon_WebApp.Controllers
{
	public class NotFound : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
