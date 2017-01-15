using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsoRunner.Service.WebApi.Models
{
	public class Filter
	{
		public int FilterId { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public double FromDistance { get; set; }
		public double ToDistance { get; set; }
		public int FromTemperature { get; set; }
		public int ToTemperature { get; set; }
		public string WeatherConditions { get; set; }

		[ForeignKey("UserForeignKey")]
		public virtual User User { get; set; }
		public int UserForeignKey { get; set; }
	}
}
