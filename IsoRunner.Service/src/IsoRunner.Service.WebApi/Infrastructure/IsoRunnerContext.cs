﻿using IsoRunner.Service.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IsoRunner.Service.WebApi.Infrastructure
{
	public class IsoRunnerContext : DbContext
	{
		public IsoRunnerContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Note> Notes { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Session> Sessions { get; set; }
	}
}
