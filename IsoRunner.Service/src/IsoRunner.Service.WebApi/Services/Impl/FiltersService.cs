using System.Linq;
using IsoRunner.Service.WebApi.DTOs;
using IsoRunner.Service.WebApi.Infrastructure;
using IsoRunner.Service.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class FiltersService : IFiltersService
	{
		private readonly IsoRunnerContext _context;

		public FiltersService(IsoRunnerContext context)
		{
			_context = context;
		}

		public void SaveFilter(User user, FilterDTO filterDTO)
		{
			var filter = _context.Filters.Include(f => f.User)
				.First(f => f.User.UserId == user.UserId);

			filter.FromDate = filterDTO.FromDate;
			filter.ToDate = filterDTO.ToDate;
			filter.FromDistance = filterDTO.FromDistance;
			filter.ToDistance = filterDTO.ToDistance;
			filter.FromTemperature = filterDTO.FromTemperature;
			filter.ToTemperature = filterDTO.ToTemperature;
			filter.WeatherConditions = filterDTO.WeatherConditions;

			_context.Filters.Update(filter);
			_context.SaveChanges();
		}

		public Filter GetFilter(User user)
		{
			var filter = _context.Users.Include(u => u.Filter)
				.First(u => u.UserId == user.UserId).Filter;
			return filter;
		}
	}
}
