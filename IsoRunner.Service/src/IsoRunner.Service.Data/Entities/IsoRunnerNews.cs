using System;
using IsoRunner.Service.Data.Enums;

namespace IsoRunner.Service.Data.Entities
{
	public class IsoRunnerNews
	{
		public Guid Id { get; set; }
		public DateTime Date { get; set; }
		public IsoRunnerNewsType Type { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
