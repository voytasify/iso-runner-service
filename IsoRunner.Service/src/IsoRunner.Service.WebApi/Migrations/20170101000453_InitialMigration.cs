using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IsoRunner.Service.WebApi.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(nullable: true),
					Password = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Messages",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					PublishDate = table.Column<DateTime>(nullable: false),
					Text = table.Column<string>(nullable: true),
					UserId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Messages", x => x.Id);
					table.ForeignKey(
						name: "FK_Messages_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Notes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					CreationTime = table.Column<DateTime>(nullable: false),
					Text = table.Column<string>(nullable: true),
					UserId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Notes", x => x.Id);
					table.ForeignKey(
						name: "FK_Notes_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Sessions",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					Key = table.Column<string>(nullable: true),
					StartTime = table.Column<DateTime>(nullable: false),
					UserId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Sessions", x => x.Id);
					table.ForeignKey(
						name: "FK_Sessions_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Messages_UserId",
				table: "Messages",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Notes_UserId",
				table: "Notes",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Sessions_UserId",
				table: "Sessions",
				column: "UserId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Messages");

			migrationBuilder.DropTable(
				name: "Notes");

			migrationBuilder.DropTable(
				name: "Sessions");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
