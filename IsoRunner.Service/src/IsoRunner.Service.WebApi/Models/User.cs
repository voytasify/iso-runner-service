using System.Collections.Generic;

namespace IsoRunner.Service.WebApi.Models
{
	public class User
	{
		public User()
		{
			Trainings = new List<Training>();
			Notes = new List<Note>();
			Messages = new List<Message>();
			Tokens = new List<Token>();
		}

		public int UserId { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public Filter Filter { get; set; }
		public virtual ICollection<Training> Trainings { get; set; }
		public virtual ICollection<Note> Notes { get; set; }
		public virtual ICollection<Message> Messages { get; set; }
		public virtual ICollection<Token> Tokens { get; set; }
	}
}
