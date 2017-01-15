using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsoRunner.Service.WebApi.Models
{
	public class Token
	{
		public string TokenId { get; set; }
		public string Key { get; set; }
		public DateTime CreationTime { get; set; }
		public DateTime ExpirationTime { get; set; }

		[ForeignKey("UserForeignKey")]
		public virtual User User { get; set; }
		public int UserForeignKey { get; set; }
	}
}
