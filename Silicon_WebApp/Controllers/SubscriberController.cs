using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_WebApp.Entites;
using Silicon_WebApp.ViewModels;
using System.Net.Http.Headers;
using System.Text;

namespace Silicon_WebApp.Controllers;

public class SubscriberController : Controller
{
	public IActionResult Index()
	{
		return View(new SubscribeViewModel());
	}

	[HttpPost]
	public async Task<IActionResult> Index(SubscribeViewModel viewModel)
	{
		
			if (ModelState.IsValid)
			{
				using var http = new HttpClient();

				var url = $"https://localhost:7030/api/subscriber?email={viewModel.Email}";
				var request = new HttpRequestMessage(HttpMethod.Post, url);


				var response = await http.SendAsync(request);
				if (response.IsSuccessStatusCode)
				{
				viewModel.IsSubscribed = true;
				TempData["IsSubscribed"] = true;
				return Redirect(Url.Action("Index", "Home") + "#signup-section");
			}
			return Redirect(Url.Action("Index", "Home") + "#signup-section");
		}
		return Redirect(Url.Action("Index", "Home") + "#signup-section");

	}
}


