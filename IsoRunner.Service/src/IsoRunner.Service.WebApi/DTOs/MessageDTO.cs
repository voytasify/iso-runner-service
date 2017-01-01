using System;

namespace IsoRunner.Service.WebApi.DTOs
{
	public class MessageDTO
	{
		public int MessageId { get; set; }
		public string Text { get; set; }
		public DateTime PublishDate { get; set; }
		public string PublisherName { get; set; }
	}
}
