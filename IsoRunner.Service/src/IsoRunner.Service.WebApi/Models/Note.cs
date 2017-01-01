using System;

namespace IsoRunner.Service.WebApi.Models
{
	public class Note
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime CreationTime { get; set; }
		public User User { get; set; }
	}
}
