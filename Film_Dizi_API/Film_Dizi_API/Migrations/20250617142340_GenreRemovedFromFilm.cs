using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Film_Dizi_API.Migrations
{
    /// <inheritdoc />
    public partial class GenreRemovedFromFilm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Films");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
