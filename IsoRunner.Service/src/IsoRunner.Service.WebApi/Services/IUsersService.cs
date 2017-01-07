using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi.Services
{
	public interface IUsersService
	{
		string Login(string name, string password, out string error);
		string Register(string name, string password, out string error);
		User GetUser(string token);
	}
}
