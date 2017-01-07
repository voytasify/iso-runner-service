using AutoMapper;
using DarkSkyApi.Models;
using IsoRunner.Service.WebApi.DTOs;
using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Note, NoteDTO>();
			CreateMap<Message, MessageDTO>()
				.ForMember(dest => dest.PublisherName, opts => opts.MapFrom(src => src.User.Name));
			CreateMap<CurrentDataPoint, WeatherDTO>();
		}
	}
}
