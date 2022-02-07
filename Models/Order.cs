using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSI.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid OfficeId { get; set; }

        [ForeignKey("OfficeId")]
        public virtual Office Office { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public string Status { get; set; }
    }

}
