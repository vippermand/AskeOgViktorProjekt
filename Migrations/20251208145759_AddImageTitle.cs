using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskeOgViktorProjekt.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Images",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Images");
        }
    }
}
