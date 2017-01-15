using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IsoRunner.Service.WebApi.Migrations
{
	public partial class TrainingsAndFilters : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Filters",
				columns: table => new
				{
					FilterId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					FromDate = table.Column<DateTime>(nullable: false),
					FromDistance = table.Column<double>(nullable: false),
					FromTemperature = table.Column<int>(nullable: false),
					ToDate = table.Column<DateTime>(nullable: false),
					ToDistance = table.Column<double>(nullable: false),
					ToTemperature = table.Column<int>(nullable: false),
					UserForeignKey = table.Column<int>(nullable: false),
					WeatherConditions = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Filters", x => x.FilterId);
					table.ForeignKey(
						name: "FK_Filters_Users_UserForeignKey",
						column: x => x.UserForeignKey,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Trainings",
				columns: table => new
				{
					TrainingId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Date = table.Column<DateTime>(nullable: false),
					Description = table.Column<string>(nullable: true),
					Distance = table.Column<double>(nullable: false),
					Duration = table.Column<TimeSpan>(nullable: false),
					Temperature = table.Column<int>(nullable: false),
					UserForeignKey = table.Column<int>(nullable: false),
					WeatherConditions = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Trainings", x => x.TrainingId);
					table.ForeignKey(
						name: "FK_Trainings_Users_UserForeignKey",
						column: x => x.UserForeignKey,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Filters_UserForeignKey",
				table: "Filters",
				column: "UserForeignKey",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Trainings_UserForeignKey",
				table: "Trainings",
				column: "UserForeignKey");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Filters");

			migrationBuilder.DropTable(
				name: "Trainings");
		}
	}
}
