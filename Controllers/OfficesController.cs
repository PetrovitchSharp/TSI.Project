using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

		//[HttpPost]
		//public IActionResult AddOffice(Office office)
		//{
		//	var context = new DataContext();
		//	office.FullAddress = GetAddress(office);

		//	context.Offices.Add(office);
		//	context.SaveChanges();
		//	return View();
		//}

		[HttpPost]
		[EnableCors]
		public bool AjaxAddOffice() 
		{
			//var parser = HttpMultipartParser.MultipartFormDataParser.ParseAsync(Request.Body).Result;
			//var params_ = parser.Parameters;
			var json = "";

			using( var stream = Request.Body)
			{
				json = new StreamReader(stream).ReadToEndAsync().Result;
			}


			//var office = new Office{
			//	City = params_[0].Data,
			//	Street = params_[1].Data,
			//	Building = params_[2].Data
			//}; 

			var office = JsonConvert.DeserializeObject<OfficeResponse>(json);
			var officeData = new Office
			{
				City = office.City,
				Street = office.Street,
				Building = office.Building
			};

			var context = new DataContext();
			officeData.FullAddress = GetAddress(officeData);
			officeData.OfficeId = Guid.NewGuid();

			context.Offices.Add(officeData);
			context.SaveChanges();

			return true;
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
