using System;
using System.Linq;

namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class TokenService : ITokenService
	{
		private const string Characters = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPRSTUVWXYZ";
		private const int Size = 64;

		public string CreateKey()
		{
			var random = new Random();
			return new string(Enumerable.Range(0, Size).Select(x => Characters[random.Next(0, Characters.Length)]).ToArray());
		}
	}
}
