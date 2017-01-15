﻿using IsoRunner.Service.WebApi.DTOs;
using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi.Services
{
	public interface IFiltersService
	{
		void SaveFilter(User user, FilterDTO filter);
		Filter GetFilter(User user);
	}
}
