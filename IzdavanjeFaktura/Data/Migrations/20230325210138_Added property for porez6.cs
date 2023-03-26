using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzdavanjeFaktura.Data.Migrations
{
    public partial class Addedpropertyforporez6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "FakturaId",
                table: "Porezi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Porezi_FakturaId",
                table: "Porezi",
                column: "FakturaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Porezi_Fakture_FakturaId",
                table: "Porezi",
                column: "FakturaId",
                principalTable: "Fakture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Porezi_Fakture_FakturaId",
                table: "Porezi");

            migrationBuilder.DropIndex(
                name: "IX_Porezi_FakturaId",
                table: "Porezi");

            migrationBuilder.DropColumn(
                name: "FakturaId",
                table: "Porezi");

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
    }
}
