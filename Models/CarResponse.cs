using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSI.Models
{
	public class CarResponse
	{
		public Guid CarId { get; set; }

		public string Mark { get; set; }

		public int Year { get; set; }
	}
}
