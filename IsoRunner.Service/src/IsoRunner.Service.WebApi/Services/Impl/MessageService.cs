using System;
using System.Collections.Generic;
using System.Linq;
using IsoRunner.Service.WebApi.Infrastructure;
using IsoRunner.Service.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class MessageService : IMessageService
	{
		private readonly IsoRunnerContext _context;

		public MessageService(IsoRunnerContext context)
		{
			_context = context;
		}

		public void AddMessage(User user, string text)
		{
			var message = new Message
			{
				Text = text,
				PublishDate = DateTime.Now,
				User = user
			};

			_context.Messages.Add(message);
			_context.SaveChanges();
		}

		public IEnumerable<Message> GetMessages()
		{
			var messages = _context.Messages.Include(m => m.User).ToList();
			return messages;
		}
	}
}
