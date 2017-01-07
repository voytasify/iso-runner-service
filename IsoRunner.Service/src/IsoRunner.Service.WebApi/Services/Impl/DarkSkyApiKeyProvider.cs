namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class DarkSkyApiKeyProvider : IDarkSkyApiKeyProvider
	{
		public DarkSkyApiKeyProvider(string apiKey)
		{
			ApiKey = apiKey;
		}

		public string ApiKey { get; }
	}
}
