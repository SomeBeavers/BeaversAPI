using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeaversDB.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimalImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Animals",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Animals");
        }
    }
}
