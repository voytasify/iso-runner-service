using System;
using System.Collections.Generic;
using System.Linq;
using IsoRunner.Service.WebApi.Infrastructure;
using IsoRunner.Service.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class NotesService : INotesService
	{
		private readonly IsoRunnerContext _context;

		public NotesService(IsoRunnerContext context)
		{
			_context = context;
		}

		public void AddNote(string text, User user)
		{
			var note = new Note
			{
				Text = text,
				CreationTime = DateTime.Now,
				User = user
			};
			_context.Notes.Add(note);
			_context.SaveChanges();
		}

		public IEnumerable<Note> GetNotes(User user)
		{
			var notes = _context.Users.Include(u => u.Notes)
				.FirstOrDefault(u => u.UserId == user.UserId).Notes;
			return notes;
		}
	}
}
