using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NesrinBookStore.Data.Migrations
{
    public partial class CleanSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("4fdb4eec-1015-41a2-aab2-cf765fedb868"),
                columns: new[] { "Author", "Description", "Name", "Rating" },
                values: new object[] { "Robert Kiyosaki", "Tavsiya etilmaydi.", "Boy ota kambag'al ota", "2" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("7178347d-1cc5-4b67-80e2-13e27f295c7a"),
                columns: new[] { "Author", "Description", "Name", "Price", "Rating" },
                values: new object[] { "Muhammad Yusuf Muhammad Sodiq", "Albatt tavsiya etiladi.", "Ijyimoiy odoblar", "50 000", "5" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("71da79e2-fecd-4e4b-bdca-40e7d6b1f421"),
                columns: new[] { "Author", "Description", "Name", "Price", "Rating" },
                values: new object[] { "Muhammad Yusuf Muhammad Sodiq", "Albatta tavsiya etiladi.", "Baxtiyor Oila", "60 000", "5" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("9126aea5-cfa3-4e45-92da-be5ca57d3afe"),
                columns: new[] { "Author", "Name" },
                values: new object[] { "Nomalum", "Qalb iffati" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("f50fb0cb-cfe7-4649-af66-8178ad69230a"),
                columns: new[] { "Author", "Description", "Name", "Price", "Rating" },
                values: new object[] { "Ahadquli XolMuhammad O'g'li", "Albatt tavsiya etiladi.", "Savdogarlar Ustozi", "30 000", "5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("4fdb4eec-1015-41a2-aab2-cf765fedb868"),
                columns: new[] { "Author", "Description", "Name", "Rating" },
                values: new object[] { "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "4" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("7178347d-1cc5-4b67-80e2-13e27f295c7a"),
                columns: new[] { "Author", "Description", "Name", "Price", "Rating" },
                values: new object[] { "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("71da79e2-fecd-4e4b-bdca-40e7d6b1f421"),
                columns: new[] { "Author", "Description", "Name", "Price", "Rating" },
                values: new object[] { "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("9126aea5-cfa3-4e45-92da-be5ca57d3afe"),
                columns: new[] { "Author", "Name" },
                values: new object[] { "Kel Nyuport", "Diqqat" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: new Guid("f50fb0cb-cfe7-4649-af66-8178ad69230a"),
                columns: new[] { "Author", "Description", "Name", "Price", "Rating" },
                values: new object[] { "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" });
        }
    }
}
