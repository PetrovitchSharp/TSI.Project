#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TSI.Models
{
	public class SearchQuery
	{
		public string State { get; set; }
		public int MinYear { get; set; }
		public int MaxYear { get; set; }
		public int MinMileage { get; set; }
		public int MaxMileage { get; set; }
		public string BodyType { get; set; }
		public string Transmission { get; set; }
		public string Engine { get; set; }
		public int MinPower { get; set; }
		public int MaxPower { get; set; }
		public string Drive { get; set; }
		public double MinConsumption { get; set; }
		public double MaxConsumption { get; set; }
		public int MinPrice { get; set; }
		public int MaxPrice { get; set; }
	}
}
