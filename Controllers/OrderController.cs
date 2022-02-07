using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSI.DAL;
using TSI.Models;

namespace TSI.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Order()
		{
			var context = new DataContext();
			var cartItems = context.CartItems
				.OrderByDescending(cartItem => cartItem.Price)
				.ToList();
			ViewBag.Offices = context.Offices;

			if (!cartItems.Any())
			{
				ViewBag.CartItems = new List<CartItem>();
				ViewBag.Total = 0;
			}
			else
			{
				ViewBag.CartItems = cartItems;
				ViewBag.Total = cartItems.Sum(item => item.Price);
			}
			return View();
		}

		public IActionResult AddToOrder(Guid id)
		{
			var context = new DataContext();
			var car = context.Cars
				.FirstOrDefault(car => car.CarId == id);

			var cartItem = new CartItem();
			cartItem.CartItemId = Guid.NewGuid();
			cartItem.Mark = car.Mark;
			cartItem.Year = car.Year;
			cartItem.Transmission = car.Transmission;
			cartItem.Gears = car.Gears;
			cartItem.Price = car.Price;
			cartItem.Power = car.Power;
			cartItem.Photo = car.Photo;
			cartItem.CarId = id;

			context.CartItems.Add(cartItem);
			context.SaveChanges();


			return Redirect("/Order/Order");
		}

		public IActionResult AddOrder(OrderViewModel orderView)
		{
			var context = new DataContext();
			var cartItems = context.CartItems.ToList();
			var office = context.Offices.FirstOrDefault(off => off.FullAddress == orderView.Office).OfficeId;

			var order = new Order();
			order.OrderId = Guid.NewGuid();
			if (context.Users.FirstOrDefault(user => user.Name == HttpContext.User.Identity.Name) != null)
			{
				order.UserId = context.Users.FirstOrDefault(user => user.Name == HttpContext.User.Identity.Name).UserId;
			}
			else
			{
				order.UserId = new Guid("d8c9ea9b-c836-4dde-8664-586eaa5d2c6e");
			}
			
			order.CreateDate = DateTime.Now;
			order.Total = cartItems.Sum(item => item.Price);
			order.Status = "Заказ принят";
			order.OfficeId = office;

			context.Orders.Add(order);

			foreach (var item in cartItems)
			{
				var connector = new CarsOrdersConnector();
				connector.CarId = item.CarId;
				connector.OrderId = order.OrderId;
				connector.CarsOrdersConnectorId = Guid.NewGuid();

				context.CarsOrdersConnectors.Add(connector);
			}

			context.SaveChanges();

			context.CartItems.RemoveRange(context.CartItems);

			return Redirect("/Profile/Profile");
		}

		public IActionResult UpdateOrder(Guid id)
		{
			var context = new DataContext();
			var order = context.Orders.FirstOrDefault(order => order.OrderId == id);
			ViewBag.Order = order;

			return View();
		}

		[HttpPost]
		public IActionResult UpdateOrder(Order orderData, Guid id)
		{
			var context = new DataContext();
			var order = context.Orders.FirstOrDefault(order => order.OrderId == id);

			order.Status = order.Status;

			context.Orders.Update(order);
			context.SaveChanges();

			return Redirect("/Admin/OrderPanel");
		}
	}
}
