using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImagenesDicatadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Dictadors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Dictadors");
        }
    }
}
