using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TSI.DAL;
using TSI.Models;

namespace TSI.Controllers
{
    public class HomeController : Controller
    {
	    public IActionResult Index()
        {
	        var context = new DataContext();
	        var cars = context.Cars
		        .OrderByDescending(car => car.Price)
		        .ToList();

	        if (!cars.Any())
	        {
		        ViewBag.Cars = new List<Car>();
	        }
	        else
	        {
		        ViewBag.Cars = cars;
		        ViewBag.Total = cars.Sum(cartItem => cartItem.Price);
				
	        }
			return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
