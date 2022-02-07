using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSI.DAL;
using TSI.Helpers;
using TSI.Models;

namespace TSI.Controllers
{
	public class CarsController : Controller
	{
		public IActionResult AddCar()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddCar(Car car, IFormFile imageData)
		{
			var context = new DataContext();

			car.Photo = await ImageHelper.UploadImage(imageData);

			context.Cars.Add(car);
			context.SaveChanges();
			return Redirect("/Admin/CarPanel");
		}

		public IActionResult UpdateCar(Guid id)
		{
			var context = new DataContext();
			var car = context.Cars.FirstOrDefault(car => car.CarId == id);
			ViewBag.Car = car;

			return View();
		}

		[HttpPost]
		public IActionResult UpdateCar(Car carData, Guid id)
		{
			var context = new DataContext();
			var car = context.Cars.FirstOrDefault(car => car.CarId == id);
			car.BodyType = carData.BodyType;
			car.Consumption = carData.Consumption;
			car.Drive = carData.Drive;
			car.Engine = carData.Engine;
			car.Gears = carData.Gears;
			car.Mark = carData.Mark;
			car.Mileage = carData.Mileage;
			car.Power = carData.Power;
			car.State = carData.State;
			car.Price = carData.Price;
			car.Transmission = carData.Transmission;
			car.Year = carData.Year;
			context.Cars.Update(car);
			context.SaveChanges();

			return Redirect("/Admin/CarPanel");
		}


		public IActionResult CarPage(Guid id)
		{
			var context = new DataContext();
			var car = context.Cars
				.FirstOrDefault(car => car.CarId == id);

			ViewBag.Title = car.Mark;
			ViewBag.Img = Url.Content(ImageHelper.GetUrl(car.Photo));

			ViewBag.Car = car;
			return View();
		}




	}
}
