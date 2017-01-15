using System;
using System.Linq;
using IsoRunner.Service.WebApi.Infrastructure;
using IsoRunner.Service.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class UsersService : IUsersService
	{
		private readonly IsoRunnerContext _context;
		private readonly ITokenService _tokenService;

		public UsersService(IsoRunnerContext context, ITokenService tokenService)
		{
			_context = context;
			_tokenService = tokenService;
		}

		public string Login(string name, string password, out string error)
		{
			error = null;

			var user = _context.Users.Include(u => u.Tokens).FirstOrDefault(u => u.Name == name);
			if (user == null)
			{
				error = "User does not exist";
				return null;
			}

			if (user.Password != password)
			{
				error = "Invalid password";
				return null;
			}

			var token = user.Tokens.FirstOrDefault(t => t.ExpirationTime > DateTime.Now);
			if (token != null)
				return token.Key;

			token = new Token
			{
				Key = _tokenService.CreateKey(),
				CreationTime = DateTime.Now,
				ExpirationTime = DateTime.Now.AddDays(100),
				User = user
			};
			_context.Tokens.Add(token);
			_context.SaveChanges();

			return token.Key;
		}

		public string Register(string name, string password, out string error)
		{
			error = null;

			if (_context.Users.Any(u => u.Name == name))
			{
				error = "Name already taken";
				return null;
			}

			var user = new User
			{
				Name = name,
				Password = password
			};

			var token = new Token
			{
				Key = _tokenService.CreateKey(),
				CreationTime = DateTime.Now,
				ExpirationTime = DateTime.Now.AddDays(100),
				User = user
			};
			user.Tokens.Add(token);
			
			var filter = new Filter();
			user.Filter = filter;

			_context.Users.Add(user);
			_context.SaveChanges();

			return token.Key;
		}

		public User GetUser(string token)
		{
			var user = _context.Tokens.Include(t => t.User)
				.FirstOrDefault(t => t.Key == token && t.ExpirationTime > DateTime.Now)?.User;
			return user;
		}
	}
}
