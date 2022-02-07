using Microsoft.AspNetCore.Mvc;

namespace TSI.Controllers
{
	public class TermsController : Controller
	{
		public IActionResult Terms()
		{
			return View();
		}
	}
}
