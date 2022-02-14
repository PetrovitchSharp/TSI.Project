using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSI.Models
{
	public class OfficeResponse
	{
		public string City { get; set; }

		public string Street { get; set; }

		public string Building { get; set; }
	}
}
