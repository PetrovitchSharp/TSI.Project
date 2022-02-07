using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TSI.DAL;

namespace TSI.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult About()
		{
			var context = new DataContext();
			var offices = context.Offices.Select(office => office.FullAddress).ToList();

			ViewBag.Addresses = offices;

			return View();
		}
	}

}
