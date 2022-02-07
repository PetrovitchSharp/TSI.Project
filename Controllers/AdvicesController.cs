using Microsoft.AspNetCore.Mvc;

namespace TSI.Controllers
{
	public class AdvicesController : Controller
	{
		public IActionResult Advices()
		{
			return View();
		}
	}
}
