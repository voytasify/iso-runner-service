using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi.Services
{
	public interface IUsersService
	{
		string Login(string name, string password);
		string Register(string name, string password);
		User GetUser(string token);
	}
}
