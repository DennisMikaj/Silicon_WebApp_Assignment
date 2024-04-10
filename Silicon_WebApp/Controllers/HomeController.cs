using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_WebApp.Entites;
using Silicon_WebApp.ViewModels;
using System.Diagnostics;
using System.Text;

namespace Silicon_WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var viewModel = new SubscribeViewModel();
			return View(viewModel);
		}

	}
}
