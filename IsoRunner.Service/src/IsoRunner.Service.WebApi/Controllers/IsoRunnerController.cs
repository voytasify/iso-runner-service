using System.Collections.Generic;
using AutoMapper;
using IsoRunner.Service.WebApi.DTOs;
using IsoRunner.Service.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsoRunner.Service.WebApi.Controllers
{
	[Route("api/[action]")]
	public class IsoRunnerController : Controller
	{
		private readonly IUsersService _usersService;
		private readonly INotesService _notesService;
		private readonly IMapper _mapper;

		public IsoRunnerController(IUsersService usersService, INotesService notesService, IMapper mapper)
		{
			_usersService = usersService;
			_notesService = notesService;
			_mapper = mapper;
		}

		[HttpGet]
		public string Hello()
			=> "it works!";

		[HttpPost]
		public string Login(string name, string password)
			=> _usersService.Login(name, password);

		[HttpPost]
		public string Register(string name, string password)
			=> _usersService.Register(name, password);

		[HttpPost]
		public void AddNote([FromQuery] string token, string text)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return;

			_notesService.AddNote(text, user);
		}

		[HttpGet]
		public IEnumerable<NoteDTO> GetNotes(string token)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return null;

			var notes = _notesService.GetNotes(user);
			return _mapper.Map<IEnumerable<NoteDTO>>(notes);
		}
	}
}
