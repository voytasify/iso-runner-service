namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class ApiKeyProvider : IApiKeyProvider
	{
		public ApiKeyProvider(string apiKey)
		{
			ApiKey = apiKey;
		}

		public string ApiKey { get; }
	}
}
