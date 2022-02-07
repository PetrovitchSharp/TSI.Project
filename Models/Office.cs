using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSI.Models
{
	[Table("Offices")]
	public class Office
	{
		[Key] public Guid OfficeId { get; set; }

		[Required] public string City { get; set; }

		[Required] public string Street { get; set; }

		[Required] public string Building { get; set; }

		[Required] public string FullAddress { get; set; }

	}

}
