using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		private readonly IMessageService _messageService;
		private readonly IWeatherService _weatherService;
		private readonly IFiltersService _filtersService;
		private readonly ITrainingsService _trainingsService;
		private readonly IMapper _mapper;

		public IsoRunnerController(IUsersService usersService, INotesService notesService, IMessageService messageService, 
			IWeatherService weatherService, IFiltersService filtersService, ITrainingsService trainingsService, IMapper mapper)
		{
			_usersService = usersService;
			_notesService = notesService;
			_messageService = messageService;
			_weatherService = weatherService;
			_filtersService = filtersService;
			_trainingsService = trainingsService;
			_mapper = mapper;
		}

		[HttpGet]
		public string Hello()
			=> "it works!";

		[HttpPost]
		public TokenDTO Login(string name, string password)
		{
			string error;
			var token = _usersService.Login(name, password, out error);

			return new TokenDTO
			{
				Token = token,
				Error = error
			};
		}

		[HttpPost]
		public TokenDTO Register(string name, string password)
		{
			string error;
			var token = _usersService.Register(name, password, out error);

			return new TokenDTO
			{
				Token = token,
				Error = error
			};
		}

		[HttpPost]
		public string AddNote([FromQuery] string token, string text)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return "Invalid token";

			_notesService.AddNote(user, text);
			return "Ok";
		}

		[HttpPost]
		public string RemoveNote([FromQuery] string token, int noteId)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return "Invalid token";

			_notesService.RemoveNote(user, noteId);
			return "Ok";
		}

		[HttpGet]
		public IEnumerable<NoteDTO> GetNotes(string token)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return Enumerable.Empty<NoteDTO>();

			var notes = _notesService.GetNotes(user);
			return _mapper.Map<IEnumerable<NoteDTO>>(notes);
		}

		[HttpPost]
		public string AddMessage([FromQuery] string token, string text)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return "Invalid token";

			_messageService.AddMessage(user, text);
			return "Ok";
		}

		[HttpGet]
		public IEnumerable<MessageDTO> GetMessages(string token)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return Enumerable.Empty<MessageDTO>();

			var messages = _messageService.GetMessages();
			return _mapper.Map<IEnumerable<MessageDTO>>(messages);
		}

		[HttpGet]
		public async Task<WeatherDTO> GetCurrentWeather(float latitude, float longitude)
			=> await _weatherService.GetCurrentWeather(latitude, longitude);

		[HttpPost]
		public string SaveFilter([FromQuery] string token, FilterDTO filter)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return "Invalid token";

			_filtersService.SaveFilter(user, filter);
			return "Ok";
		}

		[HttpGet]
		public FilterDTO GetFilter(string token)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return new FilterDTO();

			var filter = _filtersService.GetFilter(user);
			return _mapper.Map<FilterDTO>(filter);
		}

		[HttpPost]
		public string AddTraining([FromQuery] string token, TrainingDTO training)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return "Invalid token";

			_trainingsService.AddTraining(user, training);
			return "Ok";
		}

		[HttpPost]
		public string RemoveTraining([FromQuery] string token, int trainingId)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return "Invalid token";

			_trainingsService.RemoveTraining(user, trainingId);
			return "Ok";
		}

		[HttpGet]
		public IEnumerable<TrainingDTO> GetTrainings(string token)
		{
			var user = _usersService.GetUser(token);
			if (user == null)
				return Enumerable.Empty<TrainingDTO>();

			var trainings = _trainingsService.GetTrainings(user);
			return _mapper.Map<IEnumerable<TrainingDTO>>(trainings);
		}
	}
}
