using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzdavanjeFaktura.Data.Migrations
{
    public partial class Addedpropertyforporez2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakture_Porezi_PorezId",
                table: "Fakture");

            migrationBuilder.RenameColumn(
                name: "PorezId",
                table: "Fakture",
                newName: "PorId");

            migrationBuilder.RenameIndex(
                name: "IX_Fakture_PorezId",
                table: "Fakture",
                newName: "IX_Fakture_PorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fakture_Porezi_PorId",
                table: "Fakture",
                column: "PorId",
                principalTable: "Porezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakture_Porezi_PorId",
                table: "Fakture");

            migrationBuilder.RenameColumn(
                name: "PorId",
                table: "Fakture",
                newName: "PorezId");

            migrationBuilder.RenameIndex(
                name: "IX_Fakture_PorId",
                table: "Fakture",
                newName: "IX_Fakture_PorezId");

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
