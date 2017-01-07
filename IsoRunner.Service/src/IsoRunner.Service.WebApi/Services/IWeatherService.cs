using System.Threading.Tasks;
using IsoRunner.Service.WebApi.DTOs;

namespace IsoRunner.Service.WebApi.Services
{
	public interface IWeatherService
	{
		Task<WeatherDTO> GetCurrentWeather(float latitude, float longitude);
	}
}
