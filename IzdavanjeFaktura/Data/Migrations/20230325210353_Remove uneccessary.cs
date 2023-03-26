using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzdavanjeFaktura.Data.Migrations
{
    public partial class Removeuneccessary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
