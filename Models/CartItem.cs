using System;
using System.ComponentModel.DataAnnotations;

namespace TSI.Models
{
	public class CartItem
	{
		[Key]
		public Guid CartItemId { get; set; }

		[Required]
		public Guid CarId { get; set; }

		[Required]
		public string Mark { get; set; }

		[Required]
		public int Year { get; set; }

		[Required]
		public string Transmission { get; set; }

		[Required]
		public int Gears { get; set; }

		[Required]
		public double Power { get; set; }

		[Required]
		public int Price { get; set; }

		[Required]
		public Guid? Photo { get; set; }

	}

}
