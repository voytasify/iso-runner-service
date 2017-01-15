using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsoRunner.Service.WebApi.Models
{
	public class Note
	{
		public int NoteId { get; set; }
		public string Text { get; set; }
		public DateTime CreationTime { get; set; }

		[ForeignKey("UserForeignKey")]
		public virtual User User { get; set; }
		public int UserForeignKey { get; set; }
	}
}
