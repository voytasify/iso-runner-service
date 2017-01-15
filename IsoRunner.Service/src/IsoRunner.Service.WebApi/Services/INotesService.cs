using System.Collections.Generic;
using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi.Services
{
	public interface INotesService
	{
		void AddNote(User user, string text);
		void RemoveNote(User user, int noteId);
		IEnumerable<Note> GetNotes(User user);
	}
}