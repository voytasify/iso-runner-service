using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsoRunner.Service.WebApi.Migrations
{
	public partial class FiltersNullableFields : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "ToTemperature",
				table: "Filters",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<double>(
				name: "ToDistance",
				table: "Filters",
				nullable: true,
				oldClrType: typeof(double));

			migrationBuilder.AlterColumn<DateTime>(
				name: "ToDate",
				table: "Filters",
				nullable: true,
				oldClrType: typeof(DateTime));

			migrationBuilder.AlterColumn<int>(
				name: "FromTemperature",
				table: "Filters",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<double>(
				name: "FromDistance",
				table: "Filters",
				nullable: true,
				oldClrType: typeof(double));

			migrationBuilder.AlterColumn<DateTime>(
				name: "FromDate",
				table: "Filters",
				nullable: true,
				oldClrType: typeof(DateTime));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "ToTemperature",
				table: "Filters",
				nullable: false,
				oldClrType: typeof(int),
				oldNullable: true);

			migrationBuilder.AlterColumn<double>(
				name: "ToDistance",
				table: "Filters",
				nullable: false,
				oldClrType: typeof(double),
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "ToDate",
				table: "Filters",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "FromTemperature",
				table: "Filters",
				nullable: false,
				oldClrType: typeof(int),
				oldNullable: true);

			migrationBuilder.AlterColumn<double>(
				name: "FromDistance",
				table: "Filters",
				nullable: false,
				oldClrType: typeof(double),
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "FromDate",
				table: "Filters",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldNullable: true);
		}
	}
}
