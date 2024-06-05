using Microsoft.AspNetCore.Mvc;

namespace TestApplicationTessa.Controllers
{ 

	[Route("")]
	public class MainPageController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
