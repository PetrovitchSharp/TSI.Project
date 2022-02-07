using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TSI.DAL;
using TSI.Models;

namespace TSI.Controllers
{
	public class OfficesController : Controller
	{
		public IActionResult AddOffice()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddOffice(Office office)
		{
			var context = new DataContext();
			office.FullAddress = GetAddress(office);

			context.Offices.Add(office);
			context.SaveChanges();
			return View();
		}

		public IActionResult UpdateOffice(Guid id)
		{
			var context = new DataContext();
			var office = context.Offices.FirstOrDefault(office => office.OfficeId == id);
			ViewBag.Office = office;

			return View();
		}

		public IActionResult UpdateOffice_(Office officeData, Guid id)
		{
			var context = new DataContext();

			var office = context.Offices.FirstOrDefault(car => car.OfficeId == id);
			office.City = officeData.City;
			office.Street = officeData.Street;
			office.Building = officeData.Building;
			office.FullAddress = GetAddress(officeData);

			context.Offices.Update(office);
			context.SaveChanges();

			return Redirect("/Admin/OfficePanel");
		}

		public string GetAddress(Office office)
		{
			return $"г. {office.City} ул. {office.Street} д. {office.Building}";
		}
	}

}
