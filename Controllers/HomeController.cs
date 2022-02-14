using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
		    var query = context.Cars.AsQueryable();

		    if (searchQuery.Mark != null)
		    {
			    query = query.Where(car => car.Mark.Contains(searchQuery.Mark));
		    }

		    if (searchQuery.BodyType != "Любой")
		    {
			    query = query.Where(car => car.BodyType == searchQuery.BodyType);
		    }

		    if (searchQuery.Drive != "Любой")
		    {
			    query = query.Where(car => car.Drive == searchQuery.Drive);
		    }

		    if (searchQuery.Engine != "Любой")
		    {
			    query = query.Where(car => car.Engine == searchQuery.Engine);
		    }

		    if (searchQuery.State != "Любой")
		    {
			    query = query.Where(car => car.State == searchQuery.State);
		    }

		    if (searchQuery.Transmission != "Любой")
		    {
			    query = query.Where(car => car.Transmission == searchQuery.Transmission);
		    }

		    var cars = query
			    .Where(car => car.Price <= searchQuery.MaxPrice && car.Price >= searchQuery.MinPrice)
			    .Where(car => car.Consumption <= searchQuery.MaxConsumption && car.Consumption >= searchQuery.MinConsumption)
			    .Where(car => car.Mileage <= searchQuery.MaxMileage && car.Mileage >= searchQuery.MinMileage)
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

		[HttpGet]
		public string SmartSearch()
		{
			var req = Request.Query.Keys.FirstOrDefault();
			var context = new DataContext();
			var cars = context.Cars
				.Where(car => car.Mark.ToLower().Contains(req.ToLower()))
				.Select(car => new CarResponse{ Mark = car.Mark, CarId = car.CarId, Year = car.Year})
				.ToList();

			return JsonConvert.SerializeObject(cars);
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}