using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSI.Models
{
	[Table("Cars")]
	public class Car
	{
		[Key]
		public Guid CarId { get; set; }

		[Required]
		public string Mark { get; set; }

		[Required]
		public string State { get; set; }

		[Required]
		public int Year { get; set; }

		[Required]
		public int Mileage { get; set; }

		[Required]
		public string BodyType { get; set; }

		[Required]
		public string Transmission { get; set; }

		[Required]
		public int Gears { get; set; }

		[Required]
		public string Engine { get; set; }

		[Required]
		public double Power { get; set; }

		[Required]
		public string Drive { get; set; }

		[Required]
		public double Consumption { get; set; }

		[Required]
		public int Price { get; set; }

		[Required]
		public Guid? Photo { get; set; }

	}
}
