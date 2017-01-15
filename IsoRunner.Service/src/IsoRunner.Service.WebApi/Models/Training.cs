using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsoRunner.Service.WebApi.Models
{
	public class Training
	{
		public int TrainingId { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Duration { get; set; }
		public double Distance { get; set; }
		public string Description { get; set; }
		public int Temperature { get; set; }
		public int WeatherConditions { get; set; }

		[ForeignKey("UserForeignKey")]
		public virtual User User { get; set; }
		public int UserForeignKey { get; set; }
	}
}
