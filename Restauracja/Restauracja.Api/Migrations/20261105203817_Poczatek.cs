using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restauracja.Api.Migrations
{
    /// <inheritdoc />
    public partial class Poczatek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kod = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    DataZlozenia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImieKlienta = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SposobOdbioru = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Kwota = table.Column<decimal>(type: "TEXT", nullable: false),
                    Oplacone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Cena = table.Column<decimal>(type: "TEXT", nullable: false),
                    Porcja = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    ZdjecieUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Dostepne = table.Column<bool>(type: "INTEGER", nullable: false),
                    Usuniete = table.Column<bool>(type: "INTEGER", nullable: false),
                    KategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dania_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PozycjeZamowien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ZamowienieId = table.Column<int>(type: "INTEGER", nullable: false),
                    DanieId = table.Column<int>(type: "INTEGER", nullable: false),
                    NazwaDania = table.Column<string>(type: "TEXT", nullable: false),
                    CenaDania = table.Column<decimal>(type: "TEXT", nullable: false),
                    Ilosc = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjeZamowien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PozycjeZamowien_Dania_DanieId",
                        column: x => x.DanieId,
                        principalTable: "Dania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PozycjeZamowien_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Zupy" },
                    { 2, "Dania główne" },
                    { 3, "Pierogi" },
                    { 4, "Desery" },
                    { 5, "Napoje" }
                });

            migrationBuilder.InsertData(
                table: "Dania",
                columns: new[] { "Id", "Cena", "Dostepne", "KategoriaId", "Nazwa", "Opis", "Porcja", "Usuniete", "ZdjecieUrl" },
                values: new object[,]
                {
                    { 1, 16.00m, true, 1, "Żurek", "Tradycyjny żurek na zakwasie z białą kiełbasą i jajkiem.", "350 ml", false, "images/zurek.jpg" },
                    { 2, 24.00m, true, 3, "Pierogi ruskie", "Ręcznie lepione pierogi z ziemniakami, twarogiem i cebulką.", "8 szt.", false, "images/pierogi.jpg" },
                    { 3, 14.00m, false, 4, "Sernik", "Delikatny sernik na kruchym spodzie.", "150 g", false, "images/sernik.jpg" },
                    { 4, 14.00m, true, 1, "Rosół", "Domowy rosół z makaronem i natką pietruszki.", "350 ml", false, null },
                    { 5, 34.00m, true, 2, "Kotlet schabowy", "Kotlet schabowy z ziemniakami i kapustą zasmażaną.", "400 g", false, null },
                    { 6, 26.00m, true, 3, "Pierogi z mięsem", "Ręcznie lepione pierogi z mięsem, podawane ze skwarkami.", "8 szt.", false, null },
                    { 7, 13.00m, true, 4, "Szarlotka", "Ciepła szarlotka z cynamonem.", "150 g", false, null },
                    { 8, 8.00m, true, 5, "Kompot", "Domowy kompot z owoców sezonowych.", "300 ml", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dania_KategoriaId",
                table: "Dania",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamowien_DanieId",
                table: "PozycjeZamowien",
                column: "DanieId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamowien_ZamowienieId",
                table: "PozycjeZamowien",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_Kod",
                table: "Zamowienia",
                column: "Kod",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PozycjeZamowien");

            migrationBuilder.DropTable(
                name: "Dania");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
