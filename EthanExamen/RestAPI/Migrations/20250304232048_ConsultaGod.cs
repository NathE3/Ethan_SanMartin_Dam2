using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConsultaGod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_autor",
                table: "Dictadors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_dicatador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicatadorEntityGrupoEntity",
                columns: table => new
                {
                    DicatadoresId = table.Column<int>(type: "int", nullable: false),
                    GruposId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicatadorEntityGrupoEntity", x => new { x.DicatadoresId, x.GruposId });
                    table.ForeignKey(
                        name: "FK_DicatadorEntityGrupoEntity_Dictadors_DicatadoresId",
                        column: x => x.DicatadoresId,
                        principalTable: "Dictadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DicatadorEntityGrupoEntity_Grupo_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dictadors_Id_autor",
                table: "Dictadors",
                column: "Id_autor");

            migrationBuilder.CreateIndex(
                name: "IX_DicatadorEntityGrupoEntity_GruposId",
                table: "DicatadorEntityGrupoEntity",
                column: "GruposId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dictadors_Autor_Id_autor",
                table: "Dictadors",
                column: "Id_autor",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dictadors_Autor_Id_autor",
                table: "Dictadors");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "DicatadorEntityGrupoEntity");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropIndex(
                name: "IX_Dictadors_Id_autor",
                table: "Dictadors");

            migrationBuilder.DropColumn(
                name: "Id_autor",
                table: "Dictadors");
        }
    }
}
