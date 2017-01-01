using IsoRunner.Service.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace IsoRunner.Service.WebApi.Extensions
{
	public static class AuthorizationExtensions
	{
		public static IApplicationBuilder UseAuthorization(this IApplicationBuilder builder)
			=> builder.UseMiddleware<AuthorizationMiddleware>();
	}
}
