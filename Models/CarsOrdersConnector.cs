using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSI.Models
{
	[Table("CarsOrdersConnector")]
    public class CarsOrdersConnector
    {
	    [Key]
	    public Guid CarsOrdersConnectorId { get; set; }

		[Required]
		public Guid CarId { get; set; }

		[ForeignKey("CarId")]
	    public virtual Car Car { get; set; }

	    [Required]
	    public Guid OrderId { get; set; }

		[ForeignKey("OrderId")]
	    public virtual Order Order { get; set; }
    }

}
