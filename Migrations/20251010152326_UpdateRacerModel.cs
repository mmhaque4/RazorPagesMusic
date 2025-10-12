using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBarrelRacers.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRacerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "Racers",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompetitionDate",
                table: "Racers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventLocation",
                table: "Racers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HorseName",
                table: "Racers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Qualified",
                table: "Racers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompetitionDate",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "EventLocation",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "HorseName",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "Qualified",
                table: "Racers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "Racers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}
