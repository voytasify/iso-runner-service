using AutoMapper;
using IsoRunner.Service.WebApi.Infrastructure;
using IsoRunner.Service.WebApi.Services;
using IsoRunner.Service.WebApi.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IsoRunner.Service.WebApi
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();

			MapperConfiguration = new MapperConfiguration(cfg =>
				cfg.AddProfile(new AutoMapperProfile()));
		}

		public IConfigurationRoot Configuration { get; }
		private MapperConfiguration MapperConfiguration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(MapperConfiguration.CreateMapper());
			services.AddDbContext<IsoRunnerContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("IsoRunner")));

			services.AddTransient<IUsersService, UsersService>();
			services.AddTransient<ITokenService, TokenService>();
			services.AddTransient<INotesService, NotesService>();
			services.AddTransient<IMessageService, MessageService>();

			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc();
		}
	}
}
