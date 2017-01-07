using System;

namespace IsoRunner.Service.WebApi.DTOs
{
	public class NoteDTO
	{
		public int NoteId { get; set; }
		public string Text { get; set; }
		public DateTime CreationTime { get; set; }
	}
}
