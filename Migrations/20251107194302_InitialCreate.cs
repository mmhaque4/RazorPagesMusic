using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorPagesMusic.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Artist = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rating = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Artist", "Genre", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Aurora Ray", "Indie Pop", "Good", new DateTime(2018, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midnight Sun" },
                    { 2, "The Nomads", "Folk-Rock", "Better", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desert Roads" },
                    { 3, "Vivid Echo", "Synthwave", "Best", new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neon Skyline" },
                    { 4, "Harbour Lights", "Jazz", "Good", new DateTime(2015, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue Harbor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
