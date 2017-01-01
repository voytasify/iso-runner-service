using System;

namespace IsoRunner.Service.WebApi.Models
{
	public class Message
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime PublishDate { get; set; }
		public User User { get; set; }
	}
}
