namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class ApiKeyService : IApiKeyService
	{
		public ApiKeyService(string apiKey)
		{
			ApiKey = apiKey;
		}

		public string ApiKey { get; }
	}
}
