using System.Threading.Tasks;
using AutoMapper;
using DarkSkyApi;
using IsoRunner.Service.WebApi.DTOs;

namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class WeatherService : IWeatherService
	{
		private readonly IDarkSkyApiKeyProvider _darkSkyApiKeyProvider;
		private readonly IMapper _mapper;

		public WeatherService(IDarkSkyApiKeyProvider darkSkyApiKeyProvider, IMapper mapper)
		{
			_darkSkyApiKeyProvider = darkSkyApiKeyProvider;
			_mapper = mapper;
		}

		public async Task<WeatherDTO> GetCurrentWeather(float latitude, float longitude)
		{
			var client = new DarkSkyService(_darkSkyApiKeyProvider.ApiKey);
			var weather = await client.GetWeatherDataAsync(latitude, longitude, Unit.SI, Language.English);
			return _mapper.Map<WeatherDTO>(weather.Currently);
		}
	}
}
