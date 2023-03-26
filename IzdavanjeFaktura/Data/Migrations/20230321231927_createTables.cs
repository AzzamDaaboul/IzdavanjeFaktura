using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzdavanjeFaktura.Data.Migrations
{
    public partial class createTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fakture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojFakture = table.Column<int>(type: "int", nullable: false),
                    DatumStvaranjaFakture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDospijecaFakture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UkupnaCijenaBezPoreza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UkupnaCijenaSaPorezom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StvarateljRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimateljRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FakturaStavke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojStavke = table.Column<int>(type: "int", nullable: false),
                    KolicinaProdaneStavke = table.Column<int>(type: "int", nullable: false),
                    JedinicnaCijenaStavkeBezPoreza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UkupnaCijenaStavkeBezPoreza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FakturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakturaStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FakturaStavke_Fakture_FakturaId",
                        column: x => x.FakturaId,
                        principalTable: "Fakture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FakturaStavke_FakturaId",
                table: "FakturaStavke",
                column: "FakturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakturaStavke");

            migrationBuilder.DropTable(
                name: "Fakture");
        }
    }
}
