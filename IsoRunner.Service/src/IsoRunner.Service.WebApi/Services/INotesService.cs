using System.Collections.Generic;
using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi.Services
{
	public interface INotesService
	{
		void AddNote(string text, User user);
		void RemoveNote(int noteId, User user);
		IEnumerable<Note> GetNotes(User user);
	}
}
