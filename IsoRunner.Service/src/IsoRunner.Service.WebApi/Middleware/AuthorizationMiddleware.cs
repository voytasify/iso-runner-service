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
		private readonly IApiKeyProvider _apiKeyProvider;

		public AuthorizationMiddleware(RequestDelegate next, IApiKeyProvider apiKeyProvider)
		{
			_next = next;
			_apiKeyProvider = apiKeyProvider;
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
					if (apiKey == _apiKeyProvider.ApiKey)
						await _next.Invoke(context);
				}
				else
				{
					context.Response.StatusCode = 401;
				}
			}
		}
	}
}
