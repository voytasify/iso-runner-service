using System;

namespace IsoRunner.Service.WebApi.DTOs
{
	public class FilterDTO
	{
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public double? FromDistance { get; set; }
		public double? ToDistance { get; set; }
		public int? FromTemperature { get; set; }
		public int? ToTemperature { get; set; }
		public string WeatherConditions { get; set; }
	}
}
