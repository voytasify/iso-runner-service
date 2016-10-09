﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IsoRunner.Service.Core.Services;
using IsoRunner.Service.Core.Services.Stubs;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc().AddJsonOptions(options =>
			{
				options.SerializerSettings.Converters = new JsonConverter[] { new StringEnumConverter() };
			});

			services.AddSingleton(provider => MapperConfiguration.CreateMapper());
			services.AddTransient<INewsRepository>(provider => new NewsRepositoryStub());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc();
		}
	}
}
