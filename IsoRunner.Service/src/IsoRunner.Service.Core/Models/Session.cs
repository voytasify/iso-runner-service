using System;

namespace IsoRunner.Service.Core.Models
{
	public class Session
	{
		public string Id { get; set; }
		public string Key { get; set; }
		public DateTime StartTime { get; set; }
		public User User { get; set; }
	}
}
