using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_WebApp.Entites;

namespace Silicon_WebApp.Controllers
{
	[Authorize]
	public class CoursesController : Controller
	{

		public async Task<IActionResult> Index()
		{
			using var http = new HttpClient();
			var response = await http.GetAsync("https://localhost:7030/api/courses");
			var json = await response.Content.ReadAsStringAsync();
			var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);
			if (data != null)
			{
				return View(data);
			}
			else
			{
				return RedirectToAction("Index", "NotFound");
			}
		}
	}
}
