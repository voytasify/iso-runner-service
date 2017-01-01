using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using IsoRunner.Service.WebApi.Infrastructure;

namespace IsoRunner.Service.WebApi.Migrations
{
	[DbContext(typeof(IsoRunnerContext))]
	partial class IsoRunnerContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Message", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<DateTime>("PublishDate");

					b.Property<string>("Text");

					b.Property<int?>("UserId");

					b.HasKey("Id");

					b.HasIndex("UserId");

					b.ToTable("Messages");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Note", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<DateTime>("CreationTime");

					b.Property<string>("Text");

					b.Property<int?>("UserId");

					b.HasKey("Id");

					b.HasIndex("UserId");

					b.ToTable("Notes");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Session", b =>
				{
					b.Property<string>("Id")
						.ValueGeneratedOnAdd();

					b.Property<string>("Key");

					b.Property<DateTime>("StartTime");

					b.Property<int?>("UserId");

					b.HasKey("Id");

					b.HasIndex("UserId");

					b.ToTable("Sessions");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.User", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<string>("Name");

					b.Property<string>("Password");

					b.HasKey("Id");

					b.ToTable("Users");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Message", b =>
				{
					b.HasOne("IsoRunner.Service.WebApi.Models.User", "User")
						.WithMany("Messages")
						.HasForeignKey("UserId");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Note", b =>
				{
					b.HasOne("IsoRunner.Service.WebApi.Models.User", "User")
						.WithMany("Notes")
						.HasForeignKey("UserId");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Session", b =>
				{
					b.HasOne("IsoRunner.Service.WebApi.Models.User", "User")
						.WithMany("Sessions")
						.HasForeignKey("UserId");
				});
		}
	}
}
