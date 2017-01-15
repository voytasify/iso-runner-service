using Microsoft.EntityFrameworkCore.Migrations;

namespace IsoRunner.Service.WebApi.Migrations
{
	public partial class TrainingsWeatherConditionsString : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "WeatherConditions",
				table: "Trainings",
				nullable: true,
				oldClrType: typeof(int));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "WeatherConditions",
				table: "Trainings",
				nullable: false,
				oldClrType: typeof(string),
				oldNullable: true);
		}
	}
}
