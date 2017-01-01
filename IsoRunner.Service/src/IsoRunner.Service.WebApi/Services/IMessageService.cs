using System.Collections.Generic;
using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi.Services
{
	public interface IMessageService
	{
		void AddMessage(User user, string text);
		IEnumerable<Message> GetMessages();
	}
}
