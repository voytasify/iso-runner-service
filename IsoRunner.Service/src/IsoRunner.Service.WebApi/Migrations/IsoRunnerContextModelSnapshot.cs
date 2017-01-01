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
					b.Property<int>("MessageId")
						.ValueGeneratedOnAdd();

					b.Property<DateTime>("PublishDate");

					b.Property<string>("Text");

					b.Property<int>("UserForeignKey");

					b.HasKey("MessageId");

					b.HasIndex("UserForeignKey");

					b.ToTable("Messages");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Note", b =>
				{
					b.Property<int>("NoteId")
						.ValueGeneratedOnAdd();

					b.Property<DateTime>("CreationTime");

					b.Property<string>("Text");

					b.Property<int>("UserForeignKey");

					b.HasKey("NoteId");

					b.HasIndex("UserForeignKey");

					b.ToTable("Notes");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Token", b =>
				{
					b.Property<string>("TokenId")
						.ValueGeneratedOnAdd();

					b.Property<DateTime>("CreationTime");

					b.Property<DateTime>("ExpirationTime");

					b.Property<string>("Key");

					b.Property<int>("UserForeignKey");

					b.HasKey("TokenId");

					b.HasIndex("UserForeignKey");

					b.ToTable("Tokens");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.User", b =>
				{
					b.Property<int>("UserId")
						.ValueGeneratedOnAdd();

					b.Property<string>("Name");

					b.Property<string>("Password");

					b.HasKey("UserId");

					b.ToTable("Users");
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Message", b =>
				{
					b.HasOne("IsoRunner.Service.WebApi.Models.User", "User")
						.WithMany("Messages")
						.HasForeignKey("UserForeignKey")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Note", b =>
				{
					b.HasOne("IsoRunner.Service.WebApi.Models.User", "User")
						.WithMany("Notes")
						.HasForeignKey("UserForeignKey")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("IsoRunner.Service.WebApi.Models.Token", b =>
				{
					b.HasOne("IsoRunner.Service.WebApi.Models.User", "User")
						.WithMany("Tokens")
						.HasForeignKey("UserForeignKey")
						.OnDelete(DeleteBehavior.Cascade);
				});
		}
	}
}
