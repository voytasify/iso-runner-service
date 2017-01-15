﻿using System;

namespace IsoRunner.Service.WebApi.DTOs
{
	public class TrainingDTO
	{
		public int TrainingId { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Duration { get; set; }
		public double Distance { get; set; }
		public string Description { get; set; }
		public int Temperature { get; set; }
		public int WeatherConditions { get; set; }
	}
}
