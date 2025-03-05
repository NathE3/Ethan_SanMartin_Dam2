using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class GucciFlipFlop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_dicatador",
                table: "Autor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_dicatador",
                table: "Autor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
