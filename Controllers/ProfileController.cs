using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSI.DAL;
using TSI.Helpers;
using TSI.Models;

namespace TSI.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Profile()
		{
			var context = new DataContext();
			User user;

			if (HttpContext.User.Claims.Any())
			{
				user = context.Users.FirstOrDefault(user => user.Email == HttpContext.User.Claims.First().Value);
			}
			else
			{
				user = context.Users.FirstOrDefault(user => user.Email == "admin@mail.ru");
			}

			ViewBag.User = user;

			var orders = context.Orders.Where(order => order.UserId == user.UserId);
			ViewBag.Orders = orders;
			return View();
		}

		public IActionResult UpdateUser(Guid id)
		{
			var context = new DataContext();
			var user = context.Users.FirstOrDefault(user => user.UserId == id);
			ViewBag.User = user;

			return View();
		}

		public IActionResult UpdateUser_(User userData, Guid id)
		{
			var context = new DataContext();

			var user = context.Users.FirstOrDefault(user => user.UserId == id);
			user.Name = userData.Name;
			user.Email = userData.Email;

			context.Users.Update(user);
			context.SaveChanges();

			AuthenticationHelper.Authenticate(user.Email, HttpContext);

			return View("Profile");
		}

		public IActionResult OnDeleteUser(Guid id)
		{
			var context = new DataContext();
			context.Users.Remove(context.Users.FirstOrDefault(user => user.UserId == id));
			context.SaveChanges();

			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return Redirect("/Home/Index");
		}
	}
}
