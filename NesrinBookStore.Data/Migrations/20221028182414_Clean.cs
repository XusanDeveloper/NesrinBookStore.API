using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NesrinBookStore.Data.Migrations
{
    public partial class Clean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Description", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { new Guid("4fdb4eec-1015-41a2-aab2-cf765fedb868"), "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" },
                    { new Guid("7178347d-1cc5-4b67-80e2-13e27f295c7a"), "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" },
                    { new Guid("71da79e2-fecd-4e4b-bdca-40e7d6b1f421"), "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" },
                    { new Guid("9126aea5-cfa3-4e45-92da-be5ca57d3afe"), "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" },
                    { new Guid("f50fb0cb-cfe7-4649-af66-8178ad69230a"), "Kel Nyuport", "Tavsiya etiladi.", "Diqqat", "40 000", "4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
