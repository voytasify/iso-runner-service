using System.Collections.Generic;

namespace IsoRunner.Service.WebApi.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public List<Note> Notes { get; set; }
		public List<Message> Messages { get; set; }
		public List<Session> Sessions { get; set; }
	}
}
