using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzdavanjeFaktura.Data.Migrations
{
    public partial class DeletedTablePorez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakture_Porezi_PorezId",
                table: "Fakture");

            migrationBuilder.DropTable(
                name: "Porezi");

            migrationBuilder.DropIndex(
                name: "IX_Fakture_PorezId",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "PorezId",
                table: "Fakture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PorezId",
                table: "Fakture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Porezi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IznosPoreza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porezi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fakture_PorezId",
                table: "Fakture",
                column: "PorezId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fakture_Porezi_PorezId",
                table: "Fakture",
                column: "PorezId",
                principalTable: "Porezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
