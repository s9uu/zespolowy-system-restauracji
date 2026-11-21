using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauracja.Api.Migrations
{
    /// <inheritdoc />
    public partial class ZdjeciaDan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 4,
                column: "ZdjecieUrl",
                value: "images/rosol.jpg");

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 5,
                column: "ZdjecieUrl",
                value: "images/schab.jpg");

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 6,
                column: "ZdjecieUrl",
                value: "images/pierogimieso.jpg");

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 7,
                column: "ZdjecieUrl",
                value: "images/szarlotka.jpg");

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 8,
                column: "ZdjecieUrl",
                value: "images/kompot.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 4,
                column: "ZdjecieUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 5,
                column: "ZdjecieUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 6,
                column: "ZdjecieUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 7,
                column: "ZdjecieUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dania",
                keyColumn: "Id",
                keyValue: 8,
                column: "ZdjecieUrl",
                value: null);
        }
    }
}
