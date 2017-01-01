using System.Linq;
using System.Threading.Tasks;
using IsoRunner.Service.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace IsoRunner.Service.WebApi.Middleware
{
	public class AuthorizationMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IApiKeyService _apiKeyService;

		public AuthorizationMiddleware(RequestDelegate next, IApiKeyService apiKeyService)
		{
			_next = next;
			_apiKeyService = apiKeyService;
		}

		public async Task Invoke(HttpContext context)
		{
			if (context.Request.Path.ToString().StartsWith("/swagger/"))
			{
				await _next.Invoke(context);
			}
			else
			{
				StringValues apiKeys;
				if (context.Request.Headers.TryGetValue("X-ApiKey", out apiKeys))
				{
					var apiKey = apiKeys.FirstOrDefault();
					if (apiKey == _apiKeyService.ApiKey)
						await _next.Invoke(context);
				}

				context.Response.StatusCode = 401;
			}
		}
	}
}
