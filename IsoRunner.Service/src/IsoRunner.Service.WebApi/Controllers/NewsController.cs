using System.Collections.Generic;
using AutoMapper;
using IsoRunner.Service.Core.Dto;
using IsoRunner.Service.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsoRunner.Service.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class NewsController : Controller
	{
		private readonly INewsRepository _newsRepository;
		private readonly IMapper _mapper;

		public NewsController(INewsRepository newsRepository, IMapper mapper)
		{
			_newsRepository = newsRepository;
			_mapper = mapper;
		}

		// GET api/news
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_mapper.Map<IEnumerable<IsoRunnerNewsDto>>(_newsRepository.GetNews()));
		}
	}
}
