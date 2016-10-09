using AutoMapper;
using IsoRunner.Service.Core.Dto;
using IsoRunner.Service.Data.Entities;

namespace IsoRunner.Service.WebApi
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<IsoRunnerNews, IsoRunnerNewsDto>();
		}
	}
}
