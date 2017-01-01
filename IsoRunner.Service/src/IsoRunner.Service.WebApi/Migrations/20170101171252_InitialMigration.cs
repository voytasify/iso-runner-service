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
					UserId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(nullable: true),
					Password = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.UserId);
				});

			migrationBuilder.CreateTable(
				name: "Messages",
				columns: table => new
				{
					MessageId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					PublishDate = table.Column<DateTime>(nullable: false),
					Text = table.Column<string>(nullable: true),
					UserForeignKey = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Messages", x => x.MessageId);
					table.ForeignKey(
						name: "FK_Messages_Users_UserForeignKey",
						column: x => x.UserForeignKey,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Notes",
				columns: table => new
				{
					NoteId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					CreationTime = table.Column<DateTime>(nullable: false),
					Text = table.Column<string>(nullable: true),
					UserForeignKey = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Notes", x => x.NoteId);
					table.ForeignKey(
						name: "FK_Notes_Users_UserForeignKey",
						column: x => x.UserForeignKey,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Tokens",
				columns: table => new
				{
					TokenId = table.Column<string>(nullable: false),
					CreationTime = table.Column<DateTime>(nullable: false),
					ExpirationTime = table.Column<DateTime>(nullable: false),
					Key = table.Column<string>(nullable: true),
					UserForeignKey = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tokens", x => x.TokenId);
					table.ForeignKey(
						name: "FK_Tokens_Users_UserForeignKey",
						column: x => x.UserForeignKey,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Messages_UserForeignKey",
				table: "Messages",
				column: "UserForeignKey");

			migrationBuilder.CreateIndex(
				name: "IX_Notes_UserForeignKey",
				table: "Notes",
				column: "UserForeignKey");

			migrationBuilder.CreateIndex(
				name: "IX_Tokens_UserForeignKey",
				table: "Tokens",
				column: "UserForeignKey");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Messages");

			migrationBuilder.DropTable(
				name: "Notes");

			migrationBuilder.DropTable(
				name: "Tokens");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
