using IsoRunner.Service.WebApi.Models;
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
		public DbSet<Token> Tokens { get; set; }
		public DbSet<Filter> Filters { get; set; }
		public DbSet<Training> Trainings { get; set; }
	}
}
