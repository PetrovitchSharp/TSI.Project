using System.ComponentModel.DataAnnotations;

namespace TSI.Models
{
	public class OrderViewModel
	{
		[Required]
		public string Office { get; set; }

		[Required]
		public string Time { get; set; }

		[Required]
		public string Payment { get; set; }
	}

}
