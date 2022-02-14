using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TSI.DAL;
using TSI.Models;

namespace TSI.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult CarPanel()
		{
			var context = new DataContext();

			ViewBag.Cars = context.Cars;
			return View();
		}

		public IActionResult OfficePanel()
		{
			var context = new DataContext();

			ViewBag.Offices = context.Offices;
			return View();
		}

		public IActionResult OrderPanel()
		{
			var context = new DataContext();

			Dictionary<Order,List<string>> connections = new Dictionary<Order,List<string>>();
			var orders = context.Orders.ToList();

			foreach (var order in orders)
			{
				var connectors = context.CarsOrdersConnectors.Where(conn => conn.OrderId == order.OrderId).ToList();

				List<string> list = new List<string>();
				foreach (var connector in connectors)
				{
					var carName = context.Cars.FirstOrDefault(car => car.CarId == connector.CarId).Mark;
					list.Add(carName);
				}

				connections.Add(order, list);
			}

			ViewBag.Orders = connections;

			return View();
		}

		public IActionResult OnDeleteCar(Guid id)
		{
			var context = new DataContext();
			context.Cars.Remove(context.Cars.FirstOrDefault(car => car.CarId == id));
			context.SaveChanges();

			return View("CarPanel");
		}

		public IActionResult OnDeleteOffice(Guid id)
		{
			var context = new DataContext();
			context.Offices.Remove(context.Offices.FirstOrDefault(office => office.OfficeId == id));
			context.SaveChanges();

			return View("OfficePanel");
		}

		public IActionResult OnDeleteOrder(Guid id)
		{
			var context = new DataContext();
			context.Orders.Remove(context.Orders.FirstOrDefault(order => order.OrderId == id));
			context.SaveChanges();

			return View("OrderPanel");
		}

		public static string GetName(Guid userId)
		{
			var context = new DataContext();
			return context.Users.FirstOrDefault(user => user.UserId == userId).Name;
		}

		public static string GetAddress(Guid officeId)
		{
			var context = new DataContext();
			return context.Offices.FirstOrDefault(office => office.OfficeId == officeId).FullAddress;
		}

		[HttpGet]
		public string GetOfficePanel()
		{
			var context = new DataContext();

			var offices = context.Offices
				.Select(office => new OfficeResponse { City = office.City, Street = office.Street, Building = office.Building })
				.ToList();

			return JsonConvert.SerializeObject(offices);
		}
	}
}
