using System;

namespace IsoRunner.Service.WebApi.DTOs
{
	public class NoteDTO
	{
		public string NoteId { get; set; }
		public string Text { get; set; }
		public DateTime CreationTime { get; set; }
	}
}
