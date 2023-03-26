using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzdavanjeFaktura.Data.Migrations
{
    public partial class InitalMigrationondbIzdavanjeFaktura2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PorezId",
                table: "Fakture",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakture_Porezi_PorezId",
                table: "Fakture");

            migrationBuilder.DropIndex(
                name: "IX_Fakture_PorezId",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "PorezId",
                table: "Fakture");
        }
    }
}
