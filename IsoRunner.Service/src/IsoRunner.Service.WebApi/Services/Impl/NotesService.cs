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

		public void AddNote(User user, string text)
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

		public void RemoveNote(User user, int noteId)
		{
			var note = _context.Notes.Include(n => n.User).FirstOrDefault(n => n.NoteId == noteId);
			if (note?.User.UserId != user.UserId)
				return;

			_context.Notes.Remove(note);
			_context.SaveChanges();
		}

		public IEnumerable<Note> GetNotes(User user)
		{
			var notes = _context.Users.Include(u => u.Notes)
				.First(u => u.UserId == user.UserId).Notes
				.ToList();
			return notes;
		}
	}
}
