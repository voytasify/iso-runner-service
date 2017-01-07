namespace IsoRunner.Service.WebApi.DTOs
{
	public class WeatherDTO
	{
		public string Summary { get; set; }
		public float Temperature { get; set; }
		public float CloudCover { get; set; }
		public float Humidity { get; set; }
		public float WindSpeed { get; set; }
	}
}
