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
	        }
			return View();
        }

	    public IActionResult Search(SearchQuery searchQuery)
	    {
		    var context = new DataContext();
		    var cars = context.Cars
			    .Where(car => car.Price <= searchQuery.MaxPrice && car.Price >= searchQuery.MinPrice)
			    .Where(car => car.BodyType == searchQuery.BodyType)
			    .Where(car => car.Consumption <= searchQuery.MaxConsumption && car.Consumption >= searchQuery.MinConsumption)
			    .Where(car => car.Drive == searchQuery.Drive)
			    .Where(car => car.Engine == searchQuery.Engine)
			    .Where(car => car.Mileage <= searchQuery.MaxMileage && car.Mileage >= searchQuery.MinMileage)
			    .Where(car => car.State == searchQuery.State)
			    .Where(car => car.Transmission == searchQuery.Transmission)
			    .Where(car => car.Year <= searchQuery.MaxYear && car.Year >= searchQuery.MinYear)
			    .Where(car => car.Power <= searchQuery.MaxPower && car.Power >= searchQuery.MinPower)
			    .OrderByDescending(car => car.Price)
			    .ToList();

		    if (!cars.Any())
		    {
			    ViewBag.Cars = new List<Car>();
		    }
		    else
		    {
			    ViewBag.Cars = cars;

		    }
		    return View("Index");
}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
